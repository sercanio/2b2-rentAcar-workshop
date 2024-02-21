using Business.Abstract;
using Business.Requests.Customers;
using Business.Responses.Customers;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomersService _customersService;

        public CustomersController(ICustomersService customersService)
        {
            _customersService = customersService;
        }

        [HttpGet]
        public GetCustomersListResponse GetList([FromQuery] GetCustomersListRequest request)
        {
            GetCustomersListResponse response = _customersService.GetList(request);
            return response;
        }

        [HttpPost]
        public ActionResult<AddCustomersResponse> Add(AddCustomersRequest request)
        {
            try
            {
                AddCustomersResponse response = _customersService.Add(request);
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
        public ActionResult<UpdateCustomersResponse> Update([FromRoute] int Id, [FromBody] UpdateCustomersRequest request)
        {
            if (Id != request.Id)
                return BadRequest();

            UpdateCustomersResponse response = _customersService.Update(request);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public DeleteCustomersResponse Delete([FromRoute] int id)
        {
            DeleteCustomersResponse delete = _customersService.Delete(new DeleteCustomersRequest(id));
            return delete;
        }
    }
}
