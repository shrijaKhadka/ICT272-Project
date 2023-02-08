using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ICT272.Models
{
    public class Role
    {
        public int Id { get; set; }
        public string RoleName { get; set; }
        public virtual ICollection<UserRoles> UserRoles { get; set; }
    }
}