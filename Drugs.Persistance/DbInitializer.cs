using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drugs.Persistance
{
    public class DbInitializer
    {
        public static void Initialize(DrugsDbContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
