using InputFormEF.DAL;
using InputFormEF.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InputFormEF.DAL
{
    public interface IStudentWriteRepository
    {
        Task SaveAsync(Student student);

        Task UpdateAsync(Student student);

        Task DeleteAsync(int studentId);
    }
}