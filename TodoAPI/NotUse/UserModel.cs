


using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TodoAPI.NotUse
{

    public class UserModel
    {

        public Guid Id { get; set; }
        public string Name { get; set; }

        public string password { get; set; }
    }
}
