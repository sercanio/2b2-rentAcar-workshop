namespace Business;

public class GetModelListRequest//Brand,Fuel,Transmission göre listeleme yap
{
    public int? FilterByBrandId { get; set; }
    public int? FilterByFuelId { get; set; }
    public int? FilterByTransmissionId { get; set; }
}
