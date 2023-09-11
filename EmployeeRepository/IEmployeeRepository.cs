using ASH.CodeTest.Common.Models;

namespace EmployeeRepository;

public interface IEmployeeRepository
{
    Task<List<Employee>> GetEmployees();
    Task<Employee> GetEmployee(int employeeId);

    Task<int> AddEmployee(Employee employee);
}
