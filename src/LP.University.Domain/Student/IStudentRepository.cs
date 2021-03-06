﻿using System.Collections.Generic;
using System.Threading.Tasks;

namespace LP.University.Domain.Student
{
    public interface IStudentRepository
    {
        Task<StudentDetailsItem> GetDetailsByStudentId(int studentId);

        Task<List<StudentDetailsItem>> GetDetailsAll();
    }
}
