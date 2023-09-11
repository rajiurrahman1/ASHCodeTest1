using ASH.CodeTest.Common.Models;
using ASH.CodeTest.Services.Interfaces;
using EmployeeRepository;

namespace ASH.CodeTest.Services;

public class EmployeeService : IEmployeeService
{
    private readonly IEmployeeRepository _repo;
    
    public EmployeeService(IEmployeeRepository repo)
    {
        _repo = repo;
    }

    public async Task<List<Employee>> GetEmployees()
    {
        return await _repo.GetEmployees();
    }

    public async Task<Employee> GetEmployee(int employeeId)
    {
        return await _repo.GetEmployee(employeeId);
    }

    public async Task<int> AddEmployee(Employee employee)
    {
        return await _repo.AddEmployee(employee);
    }
}
