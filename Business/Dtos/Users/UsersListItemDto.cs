namespace Business.Dtos.Users
{
    public class UsersListItemDto
    {
        public string Id { get; set; }//
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        //gerekli durumlarda listele veya listelenme
        public string Password { get; set; } 
    }
}
