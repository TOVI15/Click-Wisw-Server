using AutoMapper;
using ClickWise.Core.DTOs;
using ClickWise.Core.Entities;
using ClickWise.Core.Repositories;
using ClickWise.Core.Services;
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

        public UserService(IRepositoryManager repositoryManager, IMapper mapper)
        {        
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }


        public async Task<UserDTO?> AddAsync(UserDTO user)
        {
            var userToAdd = _mapper.Map<User>(user);
            if (userToAdd != null)
            {
                await _repositoryManager.User.AddAsync(userToAdd);
                await _repositoryManager.SaveAsync();
                return _mapper.Map<UserDTO>(userToAdd);
            }
            return null;
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

        public async Task<IEnumerable<UserDTO>> GetAllAsync()
        {
            var users = await _repositoryManager.User.GetAllAsync();
            return _mapper.Map<IEnumerable<UserDTO>>(users);

        }

        public async Task<UserDTO> GetByIdAsync(int id)
        {
            var user = await _repositoryManager.User.GetByIdAsync(id);
            return _mapper.Map<UserDTO>(user);
        }

        public async Task<UserDTO> GetUserByName(string name)
        {
            var user = await _repositoryManager.User.GetUserByName(name); 
            return _mapper.Map<UserDTO>(user);
        }

        public async Task<UserDTO?> UpdateAsync(int id, UserDTO user)
        {
            if (user == null) return null;
            
            var userToUpdate = _mapper.Map<User>(user);
            await _repositoryManager.User.UpdateAsync(id, userToUpdate);
            await _repositoryManager.SaveAsync();
            return _mapper.Map<UserDTO>(userToUpdate);

        }
    }
}
