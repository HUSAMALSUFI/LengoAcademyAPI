﻿using DareAcademy_DataAccess.Application;
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
    public class CourseDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "The Name Field is Required")]
        public string Name { get; set; }
        [NotMapped]
        public IFormFile? Image { get; set; }
        public string? ImagePath { get; set; }
        public string Certificate { get; set; }
        [Required]
        public double OriginalPrice { get; set; }
        public double? Descount { get; set; }
        public string Descrption { get; set; }
        public string Requirement { get; set; }
        public string Instructor { get; set; }
        public string Duration { get; set; }
        public int SubCategoriesID { get; set; }
    }
}
