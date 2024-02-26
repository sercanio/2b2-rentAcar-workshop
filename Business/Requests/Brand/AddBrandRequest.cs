using Core.Entities;

namespace Business.Requests.Brand;

public class AddBrandRequest
{ 
    public string Name { get; set; }
    public string LogoUrl { get; set; }
    public AddBrandRequest(string name, string logoUrl)
    {
        Name = name;
        LogoUrl = logoUrl;
    }
}
