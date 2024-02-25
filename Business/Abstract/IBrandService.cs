using Business.Requests.Brand;
using Business.Responses.Brand;
using Core.CrossCuttingConcerns;
using Entities.Concrete;

namespace Business.Abstract;

public interface IBrandService
{
    public ServiceResult<AddBrandResponse> Add(AddBrandRequest request);

    public ServiceResult<GetBrandListResponse> GetList(GetBrandListRequest request);
    Brand? GetById(int id); //TODO: Replace with DTO
} 