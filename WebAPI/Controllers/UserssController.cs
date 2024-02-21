using Business.Abstract;
using Business.Requests.Users;
using Business.Responses.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersService _usersService;

        public UsersController(IUsersService usersService)
        {
            _usersService = usersService;
        }

        [HttpGet]
        public GetUsersListResponse GetList([FromQuery] GetUsersListRequest request)
        {
            GetUsersListResponse response = _usersService.GetList(request);
            return response;
        }

        [HttpPost]
        public ActionResult<AddUsersResponse> Add(AddUsersRequest request)
        {
            try
            {
                AddUsersResponse response = _usersService.Add(request);
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
        public ActionResult<UpdateUsersResponse> Update([FromRoute] int Id, [FromBody] UpdateUsersRequest request)
        {
            if (Id != request.Id)
                return BadRequest();

            UpdateUsersResponse response = _usersService.Update(request);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public DeleteUsersResponse Delete([FromRoute] int id)
        {
            DeleteUsersResponse delete = _usersService.Delete(new DeleteUsersRequest(id));
            return delete;
        }
    }
}
