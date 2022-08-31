using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoAPI.Models;
using TodoAPI.Models.ViewModel.Tasks;

namespace TodoAPI.Test.MockData
{
    public class TaskMockData
    {
        public static List<Tasks> GetTasks()
        {
            return new List<Tasks>
            {
                new Tasks
                {
                    Ids =Guid.Parse("19010D79-9860-4197-DC3D-08DA82C2B2F8"),
                    Name="task 100",
                    Description="to do task 100",
                    IsComplete=false,
                    Id=Guid.Parse("52939B11-445A-45FD-EF6E-08DA85A7DCBE")
                },
                new Tasks
                {
                    Ids=Guid.Parse("8AEF8A07-20A0-41ED-2B00-08DA82C450E0"),
                    Name="task 888444",
                    Description="task 100",
                    IsComplete=false,
                    Id=Guid.Parse("DCAED26E-5849-4D33-61A3-08DA84D2E33D")
                },
                new Tasks
                {
                    Ids=Guid.Parse("8AEF8A07-20A0-41ED-2B00-08DA82C450E8"),
                    Name="task 123",
                    Description="to do 1236",
                    IsComplete=true,
                    Id=Guid.Parse("8AEF8A07-20A0-41ED-2B00-08DA82C450E8")
                }


            };
        }
        public static List<Tasks> EmtyTask()
        {
            return new List<Tasks>();
        }
        public static CreateTask addTask()
        {
            return new CreateTask
            {

                Name = "task 100",
                Description = "to do task 100",
                IsComplete = false,
                Id = Guid.Parse("52939B11-445A-45FD-EF6E-08DA85A7DCBE")
            };
        }
    }
}
