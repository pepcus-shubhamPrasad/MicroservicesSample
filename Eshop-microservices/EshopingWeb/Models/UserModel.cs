namespace EshopingWeb.Models
{
    public class UserModel
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
    }
    public class UserResponse
    {
        public string Id { get; set; }
    }
    public class UserLogin
    {
        public string Username { get; set; }
    }
    public class UserList
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
    }
}
