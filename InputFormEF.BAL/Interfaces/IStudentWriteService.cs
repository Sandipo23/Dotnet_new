using InputFormEF.BAL.Dto;

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
        Task<OutputDto> SaveAsync(StudentCreateDto request);

        //  void SaveImage(string source, string destination);
        Task<OutputDto> SaveImageAsync(SaveImageRequest request);

        Task<OutputDto> UpdateAsync(StudentUpdateDto request);

        Task<OutputDto> DeleteAsync(int studentId);
    }
}