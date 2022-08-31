


using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TodoAPI.Datas
{
    [Table("user")]
    public class User
    {
        [Key]
        [Column("Id")]
        public Guid Id { get; set; }

        [Column("Name")]
        [Required(ErrorMessage =("Name can't null"))]
        [MaxLength(50)]
        public string Name { get; set; }

        [Column("Password")]
        [Required(ErrorMessage ="Password can't null")]
        [DataType(DataType.Password)]
        [MaxLength(10)]
        public string password { get; set; }

        public virtual ICollection<Task> tasks { get; set; }
    }
}
