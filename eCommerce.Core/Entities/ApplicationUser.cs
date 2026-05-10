using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Core.Entities
{
    public class ApplicationUser
    {
        public Guid UserId { get; set; }
        public String? Email { get; set; }
        public String? Password { get; set; }
        public String? PersonName { get; set; }
        public String? Gender { get; set; }

    }
}
