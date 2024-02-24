using Core.Entities;

namespace Business.Requests.Brand;

public class AddBrandRequest
{ 
    public string Name { get; set; }
    public string Role { get; set; }
    public AddBrandRequest(string name, string role)
    {
        Name = name;
        Role = role;
    }
}
