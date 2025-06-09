using AutoMapper;
using ClickWise.Core.DTOs;
using ClickWise.Core.Entities;
using ClickWise.Core.Repositories;
using ClickWise.Core.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClickWise.Service
{
    public class UserService : IUserService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        private readonly IEmailSender _emailSender;

        public UserService(IRepositoryManager repositoryManager, IMapper mapper, IEmailSender emailSender)
        {        
            _repositoryManager = repositoryManager;
            _mapper = mapper;
            _emailSender = emailSender;
        }


        public async Task AddAsync(UserDTO user)
        {
            var existing = await _repositoryManager.User.GetByNationalIdAsync(user.Identity);
            if (existing != null)
                throw new Exception("עובד עם ת.ז זו כבר קיים");


            var employee = new User
            {

                Identity = user.Identity,
                Name = user.Name,
                Email = user.Email,
                Role = "Staff",
                IsActive = false,
                Password = null 
            };
            await _repositoryManager.User.AddAsync(employee);
            await _repositoryManager.SaveAsync();
            var token = Guid.NewGuid().ToString(); 
            var callbackUrl = $"http://cllickwise-maneger.onrender.com/reset-password?token={token}&email={employee.Email}";
       

            await _emailSender.SendEmailAsync(employee.Email, "קביעת סיסמה", $"הגדר סיסמה כאן: <a href='{callbackUrl}'>לחץ כאן</a>");

        }

        public async Task<bool> DeleteAsync(int id)
        {
            var userDTO = await _repositoryManager.User.GetByIdAsync(id);
            if (userDTO == null)  return false;
            
            var userToDelete = _mapper.Map<User>(userDTO);
            if (userToDelete == null) return false;
            
            await _repositoryManager.User.DeleteAsync(userToDelete);
            await _repositoryManager.SaveAsync();
            return true;

        }


        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _repositoryManager.User.GetAllAsync();
        }

        public async Task<User> GetByIdAsync(int id)
        {
            var user = await _repositoryManager.User.GetByIdAsync(id);
            return user;
        }

        public async Task<User> GetUserByName(string name)
        {
            var user = await _repositoryManager.User.GetUserByEmail(name);
            return user;
        }

        public async Task<User> ResetPasswordAsync(User user, string token, string newPassword)
        {

            user.Password = newPassword;
            user.UpDatedAt = DateTime.UtcNow;
            user.IsActive = true;

            await _repositoryManager.User.UpdateAsync(user.Id, user);
            await _repositoryManager.SaveAsync();
            
            return user;
        }

        public async Task<User?> UpdateAsync(int id, UserDTO user)
        {
            if (user == null) return null;

            var userToUpdate = _mapper.Map<User>(user);
            await _repositoryManager.User.UpdateAsync(id, userToUpdate);
            await _repositoryManager.SaveAsync();
            return userToUpdate;

        }

    }
}
