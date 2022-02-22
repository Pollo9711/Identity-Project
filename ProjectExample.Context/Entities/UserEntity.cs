using System.ComponentModel.DataAnnotations;

namespace ProjectExample.Context.Entities
{
    public abstract class UserEntity
    {
        [Key]
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}