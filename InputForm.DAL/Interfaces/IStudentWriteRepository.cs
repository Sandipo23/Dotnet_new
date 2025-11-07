using InputForm.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InputForm.DAL
{
    public interface IStudentWriteRepository
    {
        Task SaveAsync(Student student);
    }
}