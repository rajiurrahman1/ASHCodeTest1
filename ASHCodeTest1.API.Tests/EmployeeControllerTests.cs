using ASH.CodeTest.Common.Models;
using ASH.CodeTest.Services.Interfaces;
using ASHCodeTest1.API.Controllers.EmployeeControllers;
using AutoFixture;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ASHCodeTest1.API.Tests;

public class EmployeeControllerTests
{
    public readonly Fixture _fixture;
    public readonly EmployeeController _controller;
    public readonly Mock<IEmployeeService> _service;

    public EmployeeControllerTests()
    {
        _fixture = new Fixture();
        _service = new Mock<IEmployeeService>();

        _controller = new EmployeeController(_service.Object);
    }

    [Fact]
    public async Task GetEmployees_ReturnsSuccess()
    {
        //Arrange 
        var employees = (List<Employee>)_fixture.Build<Employee>()
            .CreateMany();

        _service.Setup(x => x.GetEmployees()).Returns(employees);

        //Act
        var result = (ObjectResult)await _controller.GetEmployees();

        //Assert
        Assert.NotNull(result);
        Assert.Equal((int)HttpStatusCode.OK, result.StatusCode);
    }


}
