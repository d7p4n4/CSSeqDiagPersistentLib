using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using d7p4n4Namespace.Final.Class;

namespace d7p4n4Namespace.Context.Class
{
    public class AllContext : DbContext
    {
        public AllContext(string baseName) : base(baseName)
        {
            
        }

        public DbSet<Ac4ySDSequence> Ac4ySDSequences { get; set; }


    }
}
