using DareAcademy_DataAccess.Domain;
using DareAcademy_DataAccess.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DareAcademy_BusinessLogic.SpecificReposoitory
{
    public interface ICourseRepository
    {
        Task<int> Insert(CourseDTO courseDTO);
        Task<List<CourseDTO>> LoadAll();
        Task<CourseDTO> Load(int Id);
        Task Update(CourseDTO courseDTO);
        Task Delete(int Id);
        List<Course> LoadCoursesBySubCategoriesID(int Id);
        List<Course> LoadPlan_ItemByCourse_ID(int Id);
    }
}
