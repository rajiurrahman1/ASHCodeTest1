

using ASH.CodeTest.Common.Models;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Data.SqlClient;
using ToDoApplication1.Configuration;

namespace EmployeeRepository
{
    public class EmployeeRepo : IEmployeeRepository
    {
        ILogger _logger;
        private string _dbConnectionString;

        public EmployeeRepo(IOptions<DBConnectionConfiguration> config, ILogger logger)
        {
            _logger = logger;
            _dbConnectionString = config == null? null : config.Value.EmployeeDatabaseConnectionString;
        }

        public async Task<List<Employee>> GetEmployees() {
            SqlConnection conn = new SqlConnection(_dbConnectionString);
            conn.Open();

            IEnumerable<Employee> results = null;
            string query = "SELECT " +
                "Employee.EmployeeId, Employee.FirstName, Employee.LastName, Employee.EmployeeType" +
                "ST.SalaryType, ST.Salary " +
                "FROM Employee JOIN Employee_SalaryType AS ES ON Employee.EmployeeId = ES.EmployeeId" +
                "JOIN SalaryType ST ON ES.SalaryTypeId = ST.SalaryTypeId";

            try
            {
                results =  await conn.QueryAsync<List<Employee>>
                     (query);

                conn.Close();
            }
            catch (Exception ex)
            {
                _logger.LogError("Database Operation was unsuccessful. Couldn't get Employee data.");
            }

            return (List<Employee>)results;
        }

        public Task<Employee> GetEmployee(int employeeId)
        {
            return null;
        }

        public Task<int> AddEmployee(Employee employee)
        {
            //Didn't get time to finish this part
            return null;
        }
    }
}
