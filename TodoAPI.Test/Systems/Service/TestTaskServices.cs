using Castle.MicroKernel.Registration;
using FluentAssertions;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoAPI.Models;
using TodoAPI.Services;
using TodoAPI.Test.MockData;

namespace TodoAPI.Test.Systems.Service;

public class TestTaskServices: IDisposable
{
    private readonly MyDbContext _dbContext;

    public TestTaskServices()
    {
        var options = new DbContextOptionsBuilder<MyDbContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;

        _dbContext = new MyDbContext(options);
        _dbContext.Database.EnsureCreated();

    }

   

    [Fact]
    public void GetAll_ReturnTaskCollection()
    {
        /// Arrange ...
        _dbContext.TaskDB.AddRange((IEnumerable<Datas.Task>)TaskMockData.GetTasks());
        _dbContext.SaveChanges();

        var sut = new TaskRepository(_dbContext);
        /// Act ...
        var result = sut.GetAll();
        /// Assert ...
        result.Should().HaveCount(TaskMockData.GetTasks().Count);
    }

    public void Dispose()
    {
        _dbContext.Database.EnsureDeleted();
        _dbContext.Dispose();

    }
}
