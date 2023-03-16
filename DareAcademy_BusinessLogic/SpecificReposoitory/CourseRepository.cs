using DareAcademy_DataAccess.Context;
using DareAcademy_DataAccess.Domain;
using DareAcademy_DataAccess.Entity;
using DareAcademy_DataAccess.Generic;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DareAcademy_BusinessLogic.SpecificReposoitory
{
    public class CourseRepository : ICourseRepository
    {
        private readonly IGeneric<Course> generic;
        private readonly DareAcademyContext context;


        public CourseRepository(IGeneric<Course> _generic, DareAcademyContext _context
)
        {
            generic = _generic;
            context = _context;
        }
        public async Task<int> Insert(CourseDTO courseDTO)
        {
            var newCourse = new Course()
            {
                Name = courseDTO.Name,
                ImagePath = courseDTO.ImagePath,
                Certificate = courseDTO.Certificate,
                OriginalPrice = courseDTO.OriginalPrice,
                Descount = courseDTO.Descount,
                Descrption = courseDTO.Descrption,
                Duration=courseDTO.Duration,
                Instructor =courseDTO.Instructor,
                SubCategoriesID = courseDTO.SubCategoriesID,
                Requirement= courseDTO.Requirement, 
            };
            return await generic.Insert(newCourse);
        }
        public async Task<List<CourseDTO>> LoadAll()
        {
            var courses = new List<CourseDTO>();
            var allcourses = await generic.LoadAll();
            if (allcourses?.Any() == true)
            {
                foreach (var course in allcourses)
                {
                    courses.Add(new CourseDTO()
                    {
                        Id = course.Id,
                        Name = course.Name,
                        ImagePath = course.ImagePath,
                        Certificate = course.Certificate,
                        OriginalPrice = course.OriginalPrice,
                        Descount = course.Descount,
                        Descrption = course.Descrption,
                        Duration=course.Duration,
                        Instructor=course.Instructor,
                        SubCategoriesID = course.SubCategoriesID,
                        Requirement= course.Requirement,    

                    });
                }
            }
            return courses;
        }
        public async Task<CourseDTO> Load(int Id)
        {
            var courses = await generic.Load(Id);
            if (courses != null)
            {
                var coursesDetails = new CourseDTO()
                {
                    Id= courses.Id, 
                    Name = courses.Name,
                    ImagePath = courses.ImagePath,
                    Certificate = courses.Certificate,
                    OriginalPrice = courses.OriginalPrice,
                    Descount = courses.Descount,
                    Descrption = courses.Descrption,
                    Duration=courses.Duration,
                    Instructor=courses.Instructor,
                    SubCategoriesID = courses.SubCategoriesID,
                    Requirement = courses.Requirement,
                };
                return coursesDetails;
            }
            return null;
        }
        public async Task Update(CourseDTO courseDTO)
        {
            var newCourse = new Course()
            {
                Id= courseDTO.Id,
                Name = courseDTO.Name,
                ImagePath = courseDTO.ImagePath,
                Certificate = courseDTO.Certificate,
                OriginalPrice = courseDTO.OriginalPrice,
                Descount = courseDTO.Descount,
                Descrption = courseDTO.Descrption,
                Duration=courseDTO.Duration,
                Instructor=courseDTO.Instructor,
                SubCategoriesID = courseDTO.SubCategoriesID,
                Requirement = courseDTO.Requirement,
            };
            await generic.Update(newCourse);
        }
        public async Task Delete(int Id)
        {
            await generic.delete(Id);
        }
        public List<Course> LoadCoursesBySubCategoriesID(int Id)
        {
            List<Course> topics = context.courses.Where(s => s.SubCategoriesID != Id).ToList();
            return topics;
        }
        public List<Course> LoadPlan_ItemByCourse_ID(int Id)
        {
            Plan_Item plan_Item = context.plan_Item.Where(c => c.Course_ID == Id).FirstOrDefault();
            List<Course> li = context.courses.Where(c => c.LiPlan_Item.Any(p => p.Plan_ID == plan_Item.Plan_ID)).ToList();
            return li;  
        }
    }
}
