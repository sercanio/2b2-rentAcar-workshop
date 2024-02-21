using Business.Abstract;
using Business.Requests.Customers;
using Business.Responses.Customer;
using Business.Responses.Customers;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IndividualCustomersController : ControllerBase
    {
        private readonly IIndividualCustomerService _individualCustomerService;

        public IndividualCustomersController(IIndividualCustomerService individualCustomerService)
        {
            _individualCustomerService = individualCustomerService;
        }

        [HttpGet]
        public GetIndividualCustomerListResponse GetList([FromQuery] GetIndividualCustomerListRequest request)
        {
            GetIndividualCustomerListResponse response = _individualCustomerService.GetList(request);
            return response;
        }

        [HttpPost]
        public ActionResult<AddIndividualCustomerResponse> Add(AddIndividualCustomerRequest request)
        {
            try
            {
                AddIndividualCustomerResponse response = _individualCustomerService.Add(request);
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
        public ActionResult<UpdateIndividualCustomerResponse> Update([FromRoute] int id, [FromBody] UpdateIndividualCustomerRequest request)
        {
            if (id != request.Id)
                return BadRequest();

            UpdateIndividualCustomerResponse response = _individualCustomerService.Update(request);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public DeleteIndividualCustomerResponse Delete([FromRoute] int id)
        {
            DeleteIndividualCustomerResponse delete = _individualCustomerService.Delete(new DeleteIndividualCustomerRequest(id));
            return delete;
        }
    }
}
