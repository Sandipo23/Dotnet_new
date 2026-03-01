using Dapper;
using InputFormEF.DAL;
using InputFormEF.DAL.Data;
using Microsoft.AspNetCore.Identity;
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
        private readonly UserManager<IdentityUser<int>> _userManager;

        public LoginRepository(UserManager<IdentityUser<int>> userManager)
        {
            _userManager = userManager;
        }

        public async Task<bool> LoginAsync(string userName, string password)
        {
            var appUser = await _userManager.FindByNameAsync(userName);

            if (appUser == null)

                return false;
            bool success = await _userManager.CheckPasswordAsync(appUser, password);
            return success;
        }
    }
}