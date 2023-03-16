using DareAcademy_DataAccess.Domain;
using DareAcademy_DataAccess.Entity;
using DareAcademy_DataAccess.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DareAcademy_BusinessLogic.SpecificReposoitory
{
    public class Course_ScheduleRepository : ICourse_ScheduleRepository
    {

        private readonly IGeneric<Course_Schedule> generic;

        public Course_ScheduleRepository(IGeneric<Course_Schedule> _generic)
        {
            generic = _generic;
        }
        public async Task<int> Insert(Course_ScheduleDTO course_ScheduleDTO)
        {
            var newCourse_Schedule = new Course_Schedule()
            {
                Day = course_ScheduleDTO.Day,
                Section_ID = course_ScheduleDTO.Section_ID,

            };
            return await generic.Insert(newCourse_Schedule);
        }
        public async Task<List<Course_ScheduleDTO>> LoadAll()
        {
            var course_Schedule = new List<Course_ScheduleDTO>();
            var allcourse_Schedule = await generic.LoadAll();
            if (allcourse_Schedule?.Any() == true)
            {
                foreach (var course_Schedule1 in allcourse_Schedule)
                {
                    course_Schedule.Add(new Course_ScheduleDTO()
                    {
                        Id = course_Schedule1.Id,
                        Day = course_Schedule1.Day,
                        Section_ID = course_Schedule1.Section_ID,
                    });
                }
            }
            return course_Schedule;
        }
        public async Task<Course_ScheduleDTO> Load(int Id)
        {
            var course_Schedule = await generic.Load(Id);
            if (course_Schedule != null)
            {
                var course_ScheduleDetails = new Course_ScheduleDTO()
                {
                    Id = course_Schedule.Id,
                    Day = course_Schedule.Day,
                    Section_ID = course_Schedule.Section_ID,
                };
                return course_ScheduleDetails;
            }
            return null;
        }
        public async Task Update(Course_ScheduleDTO course_ScheduleDTO)
        {
            var newcourse_Schedule = new Course_Schedule()
            {
                Id = course_ScheduleDTO.Id,
                Day = course_ScheduleDTO.Day,
                Section_ID = course_ScheduleDTO.Section_ID,
            };
            await generic.Update(newcourse_Schedule);
        }
        public async Task Delete(int Id)
        {
            await generic.delete(Id);
        }
    }
}
