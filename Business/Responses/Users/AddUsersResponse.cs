namespace Business.Responses.Users
{
    public class AddUsersResponse
    {   //FirstName, LastName, Email, Password
        public AddUsersResponse(int id, string firstName, string lastName, string email, string password, DateTime createdAt)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
            CreatedAt = createdAt;
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime CreatedAt { get; set; }

        public AddUsersResponse()
        {

        }
    }
}
