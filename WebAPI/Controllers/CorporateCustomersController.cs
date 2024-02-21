using Business.Abstract;
using Business.Requests.CorporateCustomer;
using Business.Requests.Customers;
using Business.Responses.CorporateCustomer;
using Business.Responses.Customers;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CorporateCustomersController : ControllerBase
    {
        private readonly ICorporateCustomerService _corporateCustomerService;

        public CorporateCustomersController(ICorporateCustomerService corporateCustomerService)
        {
            _corporateCustomerService = corporateCustomerService;
        }

        [HttpGet]
        public GetCorporateCustomerListResponse GetList([FromQuery] GetCorporateCustomerListRequest request)
        {
            GetCorporateCustomerListResponse response = _corporateCustomerService.GetList(request);
            return response;
        }

        [HttpPost]
        public ActionResult<AddCorporateCustomerResponse> Add(AddCorporateCustomerRequest request)
        {
            try
            {
                AddCorporateCustomerResponse response = _corporateCustomerService.Add(request);
                return CreatedAtAction(nameof(GetList), response);
            }
            catch (Core.CrossCuttingConcerns.Exceptions.BusinessException exception)
            {
                return BadRequest(new Core.CrossCuttingConcerns.Exceptions.BusinessProblemDetails()
                {
                    Title = "Business Exceptions",
                    Status = StatusCodes.Status400BadRequest,
                    Detail = exception.Message,
                    Instance = HttpContext.Request.Path
                });
            }
        }

        [HttpPut("{id}")]
        public ActionResult<UpdateCorporateCustomerResponse> Update([FromRoute] int Id, [FromBody] UpdateCorporateCustomerRequest request)
        {
            if (Id != request.CorporateCustomerId)
                return BadRequest();

            UpdateCorporateCustomerResponse response = _corporateCustomerService.Update(request);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public DeleteCorporateCustomerResponse Delete([FromRoute] int id)
        {
            DeleteCorporateCustomerResponse delete = _corporateCustomerService.Delete(new DeleteCorporateCustomerRequest(id));
            return delete;
        }
    }
}
