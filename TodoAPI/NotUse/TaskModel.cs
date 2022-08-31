using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using TodoAPI.Datas;

namespace TodoAPI.NotUse
{
    public class TaskModel
    {
        public Guid Ids { get; set; }
        public string name { get; set; }

        public string description { get; set; }

        public bool isComplete { get; set; }
        public Guid? Id { get; set; }
        //[ForeignKey("Id")]
        //public User User { get; set; }

    }
}
