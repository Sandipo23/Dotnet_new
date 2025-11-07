using InputForm.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InputForm.BAL
{
    public interface IStudentWriteService
    {
        Task SaveAsync(Student student);

        void SaveImage(string source, string destination);
    }
}