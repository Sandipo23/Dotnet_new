using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    internal interface IStudentWriteService
    {
        void Save(Student student);

        void SaveImage(string source, string destination);
    }
}