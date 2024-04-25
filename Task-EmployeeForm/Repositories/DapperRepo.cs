using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;
using Task_EmployeeForm.Models;
using Task_EmployeeForm.Repositories.IRepositories;

namespace Task_EmployeeForm.Repositories
{
    public class DapperRepo :IDapperRepo
    {
        private readonly IConfiguration _configuration;
        public DapperRepo(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IReadOnlyList<Employee>> GetAllAsync()
        {
            var sql = "SELECT * FROM Employees";
            using (var connection = new SqlConnection(_configuration.GetConnectionString("ConnectionString")))
            {
                connection.Open();
                var result = await connection.QueryAsync<Employee>(sql);
                return result.ToList();
            }
        }

        public async Task<Employee> GetByIdAsync(int id)
        {
            var sql = "SELECT * FROM Employees WHERE Id = @Id";
            using (var connection = new SqlConnection(_configuration.GetConnectionString("ConnectionString")))
            {
                connection.Open();
                var result = await connection.QuerySingleOrDefaultAsync<Employee>(sql, new { Id = id });
                return result;
            }
        }



    }
}
