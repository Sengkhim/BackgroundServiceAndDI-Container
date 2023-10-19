using BackgroundServiceFromScratch.Model;
using BackgroundServiceFromScratch.Service;

namespace BackgroundServiceFromScratch.Controller;

public class UserController
{
    private readonly IUserService? _service;

    public UserController(IUserService? service)
    {
        _service = service;
    }

    public IEnumerable<UserModel> GetAllUser()
    {
        return _service!.GetAllUser();
    }
}