﻿using ClickWise.Core.DTOs;
using ClickWise.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClickWise.Core.Services
{
    public interface IStudentService
    {
        public Task<IEnumerable<StudentBasicInfo>> GetAllAsync();
        public Task<StudentBasicInfoDTO> GetByIdAsync(int id);
        public Task<StudentBasicInfoDTO> GetByNameAsync(string name);
        public Task<StudentBasicInfoDTO?> Add(StudentBasicInfoDTO student);
        public Task<StudentBasicInfoDTO?> UpdateAsync(int id, StudentBasicInfoDTO student);
        public Task<bool> DeleteAsync(int id);
        Task<IEnumerable<StudentAI>> GetAllAiDtoAsync();


    }
}
