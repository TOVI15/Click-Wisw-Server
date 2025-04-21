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
    public class StudentService : IStudentService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public StudentService(IRepositoryManager repositoryManager, IMapper mapper)
        {
            
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<StudentBasicInfo?> Add(StudentBasicInfo student)
        {
            var studentToAdd = _mapper.Map<StudentBasicInfo>(student);
            if (studentToAdd != null)
            {
                await _repositoryManager.Student.AddAsync(studentToAdd);
                await _repositoryManager.SaveAsync();
                return _mapper.Map<StudentBasicInfo>(studentToAdd);
            }
            return null;


        }

        public async Task<bool> DeleteAsync(int id)
        {
            var studentDTO = await _repositoryManager.Student.GetByIdAsync(id);
            if (studentDTO == null) return false;

            var studentToDelete = _mapper.Map<StudentBasicInfo>(studentDTO);
            if (studentToDelete == null) return false;

            await _repositoryManager.Student.DeleteAsync(studentToDelete);
            await _repositoryManager.SaveAsync();
            return true;
        }

        public async Task<IEnumerable<StudentBasicInfoDTO>> GetAllAsync()
        {
            var students = await _repositoryManager.Student.GetAllAsync();
            return _mapper.Map<IEnumerable<StudentBasicInfoDTO>>(students);
        }

        public async Task<StudentBasicInfoDTO> GetByIdAsync(int id)
        {
            var student = await _repositoryManager.Student.GetByIdAsync(id);
            return _mapper.Map<StudentBasicInfoDTO>(student);
        }

        public async Task<StudentBasicInfoDTO> GetByNameAsync(string name)
        {
            var student = await _repositoryManager.Student.GetStudentByName(name);
            return _mapper.Map<StudentBasicInfoDTO>(student);
        }

        public async Task<StudentBasicInfoDTO?> UpdateAsync(int id, StudentBasicInfoDTO student)
        {
            if (student == null) return null;

            var studentToUpdate = _mapper.Map<StudentBasicInfo>(student);
            await _repositoryManager.Student.UpdateAsync(id, studentToUpdate);
            await _repositoryManager.SaveAsync();
            return _mapper.Map<StudentBasicInfoDTO>(studentToUpdate);
        }
    }
}
