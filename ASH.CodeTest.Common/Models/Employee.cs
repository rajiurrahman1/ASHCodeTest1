using ASH.CodeTest.Common.Constants;

namespace ASH.CodeTest.Common.Models;

public class Employee
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string EmployeeType { get; set; }
    public Address Address { get; set; }
    public string SalaryType { get; set; }
    public decimal Salary { get; set; }

}
