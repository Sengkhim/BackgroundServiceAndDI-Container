using BackgroundServiceFromScratch.Model;

namespace BackgroundServiceFromScratch.Service;

public interface IUserService
{
    IEnumerable<UserModel> GetAllUser();
}