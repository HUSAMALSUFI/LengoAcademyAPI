using DareAcademy_DataAccess.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DareAcademy_DataAccess.Domain
{
    public class Plan_ItemDTO
    {
        public int Course_ID { get; set; }
        public int Plan_ID { get; set; }
    }
}
