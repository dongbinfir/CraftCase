using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User.Domain.Common;

namespace User.Domain.Entities
{
    public class UserProfile: BaseEntity<int>
    {
        public string Email { get; set; } = null!;

        public string Password { get; set; } = null!;
    }
}
