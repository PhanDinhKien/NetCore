using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bbk.Data.EntityModel
{
    public class AppUsers : IdentityUser<Guid>
    {
        public string FistName { get; set; }
    }
}
