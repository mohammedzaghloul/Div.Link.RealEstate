using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Div.Link.RealEstate.DAL.Data
{
    public class ApplicationDbContext :DbContext
    {
        private readonly DbContextOptionsBuilder<ApplicationDbContext> dbContext;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> dbContext) :base(dbContext)
        {

        }
        
    }
}
