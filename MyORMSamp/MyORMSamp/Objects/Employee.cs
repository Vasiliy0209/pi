using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyORMSamp
{
    public class Employee
    {
        private ICollection<Education> _education;
        private ICollection<Language> _languages;

        public virtual Guid ID { get; set; }
        public virtual string Name { get; set; }
        public virtual int Age { get; set; }
        public virtual string Email { get; set; }

        public virtual ICollection<Education> Educations
        {
            get { return _education; }
            set { this._education = value; }
        }

        public virtual ICollection<Language> Languages
        {
            get { return _languages; }
            set { this._languages = value; }
        }

        public Employee()
        {
            _education = new List<Education>();
            _languages = new List<Language>();
        }
    }
}
