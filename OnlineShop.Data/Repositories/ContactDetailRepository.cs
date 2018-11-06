using OnlineShop.Model.Models;
using OnlineShop.Data.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Data.Repositories
{
    public interface IContactDetail : IRepository<ContactDetail>
    {

    }

    public class ContactDetailRepository : RepositoryBase<ContactDetail>, IContactDetail
    {
        public ContactDetailRepository(IDbFactory dbFactory) : base(dbFactory)
        {

        }
    }
}
