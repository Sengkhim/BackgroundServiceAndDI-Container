using BackgroundServiceFromScratch.Model;
using BackgroundServiceFromScratch.Service;

namespace BackgroundServiceFromScratch.Implement;

public class UserService : IUserService
{
    public IEnumerable<UserModel> GetAllUser()
    {
        return new List<UserModel>
        {
            new UserModel() { Id = Guid.NewGuid().ToString(), Name = "User1" , Address = "Phnom Penh" },
            new UserModel() { Id = Guid.NewGuid().ToString(), Name = "User2" , Address = "Phnom Penh" },
            new UserModel() { Id = Guid.NewGuid().ToString(), Name = "User3" , Address = "Phnom Penh" }
        };
    }
}