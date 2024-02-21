namespace Business.Requests.Brand;

public class AddBrandRequest
{ 
    public string Name { get; set; }

    public AddBrandRequest(string name)
    {
        Name = name;
    }
}
