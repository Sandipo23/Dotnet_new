using Dapper;
using InputFormEF.DAL;
using InputFormEF.DAL.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InputFormEF.DAL
{
    public class LoginRepository : ILoginRepository
    {
        private readonly ApplicationDbContext _context;

        public LoginRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> LoginAsync(string userName, string password)
        {
            //int count = await _context
            //                  .Users
            //                  .Where(x => x.UserName == userName && x.Password == password)
            //                  .CountAsync();
            int count = await _context
                              .Users
                              .CountAsync(x => x.UserName == userName && x.Password == password);
            return count > 0;
        }
    }
}