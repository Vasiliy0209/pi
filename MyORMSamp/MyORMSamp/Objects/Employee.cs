using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyORMSamp
{
    class Employee
    {
        public virtual Guid ID { get; set; }
        public virtual string Name { get; set; }
        public virtual int Age { get; set; }
        public virtual string Email { get; set; }
    }
}
