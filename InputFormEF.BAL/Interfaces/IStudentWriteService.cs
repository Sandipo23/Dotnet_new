using InputFormEF.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InputFormEF.BAL.Interfaces
{
    public interface IStudentWriteService
    {
        Task SaveAsync(Student student);

        void SaveImage(string source, string destination);

        Task UpdateAsync(Student student);

        Task DeleteAsync(int studentId);
    }
}