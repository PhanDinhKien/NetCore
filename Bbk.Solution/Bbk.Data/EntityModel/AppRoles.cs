using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bbk.Data.EntityModel
{
    public class AppRoles : IdentityRole<Guid>
    {
        public string Decription { get; set; }
    }
}
