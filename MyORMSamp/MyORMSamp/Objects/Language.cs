using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyORMSamp
{
    public class Language
    {
        private ICollection<Employee> _employees;
        public virtual Guid ID { get; set; }
        public virtual string Name { get; set; }

        public virtual ICollection<Employee> Employees
        {
            get { return _employees; }
            set { this._employees = value; }
        }

        public Language()
        {
            _employees = new List<Employee>();
        }
    }
}
