
using Business.Requests.Users;
using Business.Responses.Users;

namespace Business.Abstract
{
    public interface IUsersService
    {
        AddUsersResponse Add(AddUsersRequest request);
        UpdateUsersResponse Update(UpdateUsersRequest request);
        DeleteUsersResponse Delete(DeleteUsersRequest request);
        GetUsersListResponse GetList(GetUsersListRequest request);
    }
}
