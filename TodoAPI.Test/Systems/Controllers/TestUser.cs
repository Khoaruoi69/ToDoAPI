using FluentMigrator.Runner.Processors;
using Microsoft.EntityFrameworkCore;
using TodoAPI.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoAPI.Services.Interfaces;
using Abp.Domain.Uow;
using TodoAPI.Controllers;
using System.Linq.Expressions;
using TodoAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TodoAPI.Test.MockData;
using TodoAPI.Models.ViewModel.Users;

namespace TodoAPI.Test.Systems.Controllers;

public class TestUser
{
    private readonly IUserRepository _service;
    private readonly UsersController _controller;

    public TestUser()
    {
        _service = new MockDataUser();
        _controller = new UsersController(_service);
    }
    [Fact]
    public void Get_WhenCalled_ReturnOKResult()
    {
        //Act 
        var okResult = _controller.getAll();
        // Assert
        Xunit.Assert.IsType<OkObjectResult>(okResult as OkObjectResult);
    }

    [Fact]
    public void Get_WhenCalled_ReturnsAllItems()
    {
        //Act
        var okResult = _controller.getAll() as OkObjectResult;
        //Assert
        var items = Xunit.Assert.IsType<List<UsersVM>>(okResult.Value);
        Xunit.Assert.Equal(3, items.Count);
    }
    [Fact]
    public void GetById_UnknowGuidPassed_ReturnNotFoundResult()
    {
        //Act
        var notFoundResult=_controller.GetById(Guid.NewGuid());
        //Assert 
        Xunit.Assert.IsType<NotFoundResult>(notFoundResult);
    }

    [Fact]
    public void GetById_ExistingGuiPassed_ReturnsRightItem()
    {
        //Arrange
        var testGuid = new Guid("ab2bd817-98cd-4cf3-a80a-53ea0cd9c200");
        //Act
        var okResult = _controller.GetById(testGuid) as OkObjectResult;
        // Assert
        Xunit.Assert.IsType<UsersVM>(okResult.Value);
        Xunit.Assert.Equal(testGuid, (okResult.Value as UsersVM).Id);
    }

    [Fact]
    public void Add_ValidObjectPassed_ReturnBadRequest()
    {
        //Arange
        var nameMissingItem = new CreateUser()
        {
            Password = "2345"

        };
        _controller.ModelState.AddModelError("Name","Request");

        //Act 
        var badRequest = _controller.Add(nameMissingItem);

        // Asert
        Xunit.Assert.IsType<BadRequestObjectResult>(badRequest);
    }

    [Fact]
    public void Add_ValidObjectPassed_ReturnCreatedResponse()
    {
        //Arange
        CreateUser nameItem = new CreateUser()
        {
            Password = "2345",
            Name = "Khaoa pápp"
        };
        //Act 
        var createdResponse = _controller.Add(nameItem);

        // Asert
        Xunit.Assert.IsType<CreatedAtActionResult>(createdResponse);
    }
    [Fact]
    public void Remove_ExistingGuiPassed_RemovesOneItem()
    {
        //Arrange
        var existingGuid = new Guid("ab2bd817-98cd-4cf3-a80a-53ea0cd9c201");
        //Act 
        var okResponse = _controller.Delete(existingGuid);
        //Assert 
        Xunit.Assert.Equal(2, _service.GetAll().Count);
    }
}

