using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InputForm.DAL
{
    public class LoginRepository : ILoginRepository
    {
        private readonly IDapperRepository _dapper;

        public LoginRepository(IDapperRepository dapper)
        {
            // _dapper = new DapperRepository(); this is old way without using DI
            _dapper = dapper;
        }

        public async Task<bool> LoginAsync(string userName, string password)
        {
            string query = "SELECT COUNT(Id) FROM Users WHERE UserName = @userName and Password = @password;";
            var parameters = new Dictionary<string, object>();
            parameters.Add("@username", userName);
            parameters.Add("@password", password);

            int count = await _dapper.ExecuteScalarAsync(query, parameters);

            return count > 0;
        }
    }
}