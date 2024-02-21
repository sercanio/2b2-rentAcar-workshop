namespace Business.Requests.Users
{
    public class DeleteUsersRequest
    {
        public int Id { get; set; }

        public DeleteUsersRequest(int id)
        {
            Id = id;
        }
    }
}
