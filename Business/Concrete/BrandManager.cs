using AutoMapper;
using Business.Abstract;
using Business.BusinessRules;
using Business.Requests.Brand;
using Business.Responses.Brand;
using Core.CrossCuttingConcerns;
using Core.Entities;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Claims;

namespace Business.Concrete;

public class BrandManager : IBrandService
{
    private readonly IBrandDal _brandDal; // Bir entity service'i kendi entitysi dışında hiç bir entity'nin DAL'ını injekte etmemelidir.
    // private readonly IModelDal _modelDal;
    private readonly BrandBusinessRules _brandBusinessRules;
    private readonly IMapper _mapper;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public BrandManager(IBrandDal brandDal, BrandBusinessRules brandBusinessRules, IMapper mapper, IHttpContextAccessor httpContextAccessor)
    {
        _brandDal = brandDal; //new InMemoryBrandDal(); // Başka katmanların class'ları new'lenmez. Bu yüzden dependency injection kullanıyoruz.
        _brandBusinessRules = brandBusinessRules;
        _mapper = mapper;
        _httpContextAccessor = httpContextAccessor;
    }

    // AOP => Aspect Oriented Programming - Autofac
    // Pipeline 


    // mediatR, pipeline, cqrs
    // Auth&Authorization
    // Role implementasyonu => Claim'lere kullanıcı rollerini db'den ekleyip gelen isteklerde
    // rol bazlı kontrol yapılması..
    public ServiceResult<AddBrandResponse> Add(AddBrandRequest request)
    {
        // BrandAdmin
        if (!_httpContextAccessor.HttpContext.User.Identity.IsAuthenticated)
        {
            return new ServiceResult<AddBrandResponse>
            {
                IsSuccess = false,
                ErrorMessage = "You are not authenticated!"
            };
        }

        if (!_httpContextAccessor.HttpContext.User.HasClaim(c => c.Type == ClaimTypes.Role && (c.Value == "Editor" || c.Value == "Admin")))
        {
            return new ServiceResult<AddBrandResponse>
            {
                IsSuccess = false,
                ErrorMessage = "You are not authorized"
            };
        }

        _brandBusinessRules.CheckIfBrandNameNotExists(request.Name);

        Brand brandToAdd = _mapper.Map<Brand>(request); // Mapping

        _brandDal.Add(brandToAdd);

        AddBrandResponse response = _mapper.Map<AddBrandResponse>(brandToAdd);

        return new ServiceResult<AddBrandResponse>
        {
            IsSuccess = true,
            Data = response
        };
    }

    public Brand? GetById(int id)
    {
        return _brandDal.Get(i => i.Id == id);
    }

    public ServiceResult<GetBrandListResponse> GetList(GetBrandListRequest request)
    {
        if (!_httpContextAccessor.HttpContext.User.Identity.IsAuthenticated)
        {
            return new ServiceResult<GetBrandListResponse>
            {
                IsSuccess = false,
                ErrorMessage = "You are not authenticated!"
            };
        }

        if (!_httpContextAccessor.HttpContext.User.HasClaim(c => c.Type == ClaimTypes.Role && (c.Value == "2" || c.Value == "3")))
        {
            return new ServiceResult<GetBrandListResponse>
            {
                IsSuccess = false,
                ErrorMessage = "You are not authorized"
            };
        }
        IList<Brand> brandList = _brandDal.GetList();


        GetBrandListResponse response = _mapper.Map<GetBrandListResponse>(brandList);
        return new ServiceResult<GetBrandListResponse>
        {
            IsSuccess = true,
            Data = response
        };
    }
}