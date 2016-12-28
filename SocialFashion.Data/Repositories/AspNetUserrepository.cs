using SocialFashion.Data.Infrastructure;
using SocialFashion.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialFashion.Data.Repositories
{
    public interface IAspNetUserRepository : IRepository<AspNetUser>
    {
        
    }
    public class AspNetUserRepository : RepositoryBase<AspNetUser>, IAspNetUserRepository
    {
        public AspNetUserRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
