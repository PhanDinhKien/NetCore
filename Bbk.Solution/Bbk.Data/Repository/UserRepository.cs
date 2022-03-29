using Bbk.Data.EntityFramework;
using Bbk.Data.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bbk.Data.Repository
{
    public class UserRepository : RepositoryBase<AppUsers, Guid>, IUserRepository
    {
        public UserRepository(BBKDbContext context) : base(context) 
        { 
             
        }

        public async Task<List<AppUsers>> GetListUserAsync()
        {
            return new List<AppUsers>(); 
        }
    }


    public interface IUserRepository  : IRepositoryBase<AppUsers, Guid>
    {

    }
}
