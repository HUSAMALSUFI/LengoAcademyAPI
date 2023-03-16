using DareAcademy_DataAccess.Entity;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DareAcademy_DataAccess.Domain
{
    public class CategoryDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "The Name Field is Required")]
        public string Name { get; set; }
        public string IconPath { get; set; }
        public int? SubCategoryID { get; set; }
    }
}
