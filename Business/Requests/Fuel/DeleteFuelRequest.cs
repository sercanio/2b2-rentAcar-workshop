namespace Business.Requests.Fuel
{
    public class DeleteFuelRequest
    {
        public int Id { get; set; }
        public DeleteFuelRequest(int id)
        {
            Id = id;
        }
    }
}