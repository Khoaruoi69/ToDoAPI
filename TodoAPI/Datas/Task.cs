using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TodoAPI.Datas
{
    [Table("Task")]
    public class Task
    {
       
        [Key]
        [Column("Ids")]
        public Guid Ids { get; set; }
    
        [Column("Name")]
        [MaxLength(50)]
        [Required(ErrorMessage = "Name can't null")]
        public string name { get; set; }

        [Column("Description")]
        [StringLength(500,MinimumLength =10,ErrorMessage = "Description must be 10 to 500 characters ")]
        public string description { get; set; }

        [Column("IsComplete")]
        [Required(ErrorMessage = "Status can't null")]
        public bool isComplete { get; set; }

        [Column("Id")]
        [Required(ErrorMessage = "Status can't null")]
        public Guid? Id { get; set; }

        [ForeignKey("Id")]
        public virtual User User { get; set; }
       
    }
}
