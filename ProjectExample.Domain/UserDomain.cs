namespace ProjectExample.Domain
{
    public abstract class UserDomain
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

    }
}