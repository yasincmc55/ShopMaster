using ShopMaster.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopMaster.DataAccess.Repository.IRepository
{
    internal interface ICategoryRepository : IRepository<Category>
    {
        void Update(Category category);
        void Save();
    }
}
