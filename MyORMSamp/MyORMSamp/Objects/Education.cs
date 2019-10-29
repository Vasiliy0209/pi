using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyORMSamp
{
    public class Education
    {        
        public virtual Guid ID { get; set; }
        public virtual string Name { get; set; }
        public virtual int Year { get; set; }
        public virtual Employee Employee { get; set; }
    }
}
