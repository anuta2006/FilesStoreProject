using BLL.Interface.Entities;

namespace BLL.Interface.Services
{
    public interface IUserServise : IService<BllUser>
    {
        BllUser GetByLogin(string login);
    }
}
