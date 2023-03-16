using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DareAcademy_DataAccess.Domain
{
    public class RoleDTO
    {
        [Required]
        public string Name { get; set; }
    }
}
