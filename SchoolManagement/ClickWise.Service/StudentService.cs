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
     
        public async Task<StudentBasicInfoDTO?> Add(StudentBasicInfoDTO student)
        {
            var studentToAdd = _mapper.Map<StudentBasicInfo>(student);
            if (studentToAdd != null)
            {
                await _repositoryManager.Student.AddAsync(studentToAdd);

                await _repositoryManager.SaveAsync();

                //if (!string.IsNullOrEmpty(student.folderKey))
                //{
                //    var folderEntity = await _repositoryManager.Documents.GetByS3KeyAsync(student.folderKey);
                //    if (folderEntity != null)
                //    {
                //        folderEntity.Id = studentToAdd.Id; // foreign key = student id
                //        folderEntity.UpdatedAt = DateTime.Now;

                //        await _repositoryManager.SaveAsync();
                //    }
                //}
                return _mapper.Map<StudentBasicInfoDTO>(studentToAdd);
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

        public async Task<IEnumerable<StudentBasicInfo>> GetAllAsync()
        {
            var students = await _repositoryManager.Student.GetAllWithDetailsAsync();
            return students;
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

        public async Task<StudentBasicInfoDTO?> UpdateAsync(int id, StudentBasicInfoDTO studentDto)
        {
            if (studentDto == null) return null;

            // שליפת הישות הקיימת
            var existingStudent = await _repositoryManager.Student.GetByIdWithDetailsAsync(id);
            if (existingStudent == null) return null;
            Console.WriteLine("===> existingStudent לפני מיפוי:");
            
            // מיפוי חכם רק לשדות שנשלחו
            _mapper.Map(studentDto, existingStudent);

            Console.WriteLine("===> existingStudent אחרי מיפוי:");
           
            // שמירה
            await _repositoryManager.SaveAsync();

            // החזרת המידע המעודכן
            return _mapper.Map<StudentBasicInfoDTO>(existingStudent);
        }
        public async Task<IEnumerable<StudentAI>> GetAllAiDtoAsync()
        {
            var students = await _repositoryManager.Student.GetAllWithDetailsAsync();

            return students.Select(s => new StudentAI
            {
                Id = s.Id,
                FirstName = s.FirstName,
                LastName = s.LastName,
                IdentityNumber = s.IdentityNumber,
                Phone = s.Phone,
                City = s.City,
                DateOfBirth = s.DateOfBirth,
                HealthInsurance = s.HealthInsurance,
                UpdatedAt = s.UpdatedAt,
                CreatedAt = s.CreatedAt,

                FatherName = s.AdditionalInfo?.FatherName,
                FatherPhone = s.AdditionalInfo?.FatherPhone,
                MotherName = s.AdditionalInfo?.MotherName,
                MotherPhone = s.AdditionalInfo?.MotherPhone,
                YeshivaName = s.AdditionalInfo?.YeshivaName,
                Note = s.AdditionalInfo?.Note
            });
        }

    }
}
