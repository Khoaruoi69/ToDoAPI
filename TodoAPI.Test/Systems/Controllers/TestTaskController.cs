using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoAPI.Controllers;
using TodoAPI.Services.Interfaces;
using TodoAPI.Test.MockData;

namespace TodoAPI.Test.Systems.Controllers
{
    public class TestTaskController
    {
        [Fact]
        public void getAll_ShouldReturn200Status() // 200 OK
        {
            /// Arrange
            var MockTaskRepositor = new Mock<ITaskRepositorycs>();
           
            MockTaskRepositor.Setup(_ => _.GetAll()).Returns(TaskMockData.GetTasks());
            var TaskRepositor = new TasksController(MockTaskRepositor.Object);

            //Act
            var result = TaskRepositor.getAll();
            ///Assert
            result.GetType().Should().Be(typeof(OkObjectResult));
            (result as OkObjectResult).StatusCode.Should().Be(200);
        }
        [Fact]
        public void getAll_ShouldReturn204Status() // 204 no content
        {
            /// Arrange
            var MockTaskRepositor = new Mock<ITaskRepositorycs>();

            MockTaskRepositor.Setup(_ => _.GetAll()).Returns(TaskMockData.EmtyTask());
            var TaskRepositor = new TasksController(MockTaskRepositor.Object);

            //Act
            var result = TaskRepositor.getAll();
            ///Assert
            result.GetType().Should().Be(typeof(NoContentResult));
            (result as NoContentResult).StatusCode.Should().Be(204);
        }


        [Fact]
        public void AddTask() 
        {
            /// Arrange
            var MockTaskRepositor = new Mock<ITaskRepositorycs>();
            var newTask = TaskMockData.addTask();
            var sut = new TasksController(MockTaskRepositor.Object);
            //Act
            var result = sut.Add(newTask);
            ///Assert
            MockTaskRepositor.Verify(_=>_.Add(newTask),Times.Exactly(1));
        }


    }
   
}
