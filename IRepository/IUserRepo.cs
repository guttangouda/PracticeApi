using WebApplication1.Modules;
using WebApplication1.Repository;

namespace WebApplication1.IRepository
{
    public interface IUserRepo
    {
        public ServiceResponse<string> Post(User userData);
    }
}
