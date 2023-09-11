using ASH.CodeTest.Common.Models;

namespace ASH.CodeTest.Services.Interfaces;

public interface IEmployeeService
{
    Task<List<Employee>> GetEmployees();
    Task<Employee> GetEmployee(int employeeId);

    Task<int> AddEmployee(Employee employee);
}
