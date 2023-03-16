using DareAcademy_DataAccess.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DareAcademy_BusinessLogic.SpecificReposoitory
{
    public interface ICourse_ScheduleRepository
    {
        Task<int> Insert(Course_ScheduleDTO course_ScheduleDTO);
        Task<List<Course_ScheduleDTO>> LoadAll();
        Task<Course_ScheduleDTO> Load(int Id);
        Task Update(Course_ScheduleDTO course_ScheduleDTO);
        Task Delete(int Id);
    }
}
