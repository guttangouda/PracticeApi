using WebApplication1.IRepository;
using WebApplication1.Modules;
namespace WebApplication1.Repository
{
    public class UserRepo : IUserRepo
    {


        public readonly AppDbContext _context;
        public UserRepo (AppDbContext context)
        {
            _context = context;
        }

        public ServiceResponse<string> Post(User userData)
        {
            ServiceResponse<string> response= new ServiceResponse<string>();
            var Data = _context.User.Add(userData);
            _context.SaveChanges();
            response.status = 1;
            response.message = "success";
            //response.data = Data;
            return response;
        }
    }
}
