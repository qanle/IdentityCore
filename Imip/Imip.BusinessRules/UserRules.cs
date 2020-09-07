using Imip.Models;
using System.Linq;

namespace Imip.BusinessRules
{
    public class UserRules: RulesBase
    {
        public Users GetBySystemId(string id)
        {
            return _dbContext.User.FirstOrDefault(e => e.SystemUserId == id);
        }

        public bool CreateUser(Users user)
        {
            _dbContext.User.Add(user);
            _dbContext.SaveChanges();
            return true;
        }
    }
}
