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

namespace DareAcademy_BusinessLogic.SpecificReposoitory
{
    public class SectiontRepository : ISectiontRepository
    {
        private readonly IGeneric<Section> generic;
        private readonly DareAcademyContext context;


        public SectiontRepository(IGeneric<Section> _generic, DareAcademyContext _context)
        {
            generic = _generic;
            context = _context;
        }
        public async Task<int> Insert(SectionDTO sectionDTO)
        {
            var newSection = new Section()
            {
                StartDate = sectionDTO.StartDate,
                EndDate = sectionDTO.EndDate,
                Type = sectionDTO.Type,
                Time = sectionDTO.Time,
                Capacity = sectionDTO.Capacity,
                Course_ID = sectionDTO.Course_ID,
                LiCourse_Schedule = new List<Course_Schedule>()
            };
            foreach (Course_ScheduleDTO item in sectionDTO.LiCourse_Schedule) {

                Course_Schedule dayInfo = new Course_Schedule();
                dayInfo.Day = item.Day;
                newSection.LiCourse_Schedule.Add(dayInfo);
            }
            return await generic.Insert(newSection);
        }
        public async Task<List<SectionDTO>> LoadAll()
        {
            var section = new List<SectionDTO>();
            var allsection = await generic.LoadAll();
            if (allsection?.Any() == true)
            {
                foreach (var section1 in allsection)
                {
                    section.Add(new SectionDTO()
                    {
                        Id = section1.Id,
                        StartDate = section1.StartDate,
                        EndDate = section1.EndDate,
                        Type = section1.Type,
                        Time = section1.Time,
                        Capacity = section1.Capacity,
                        Course_ID = section1.Course_ID,
                        LiCourse_Schedule = new List<Course_ScheduleDTO>()
                    });
                   /* foreach (Course_Schedule item in section1.LiCourse_Schedule)
                    {

                        Course_ScheduleDTO dayInfo = new Course_ScheduleDTO();
                        dayInfo.Day = item.Day;
                        section.LiCourse_Schedule.Add(dayInfo);
                    }*/
                }
            }
            return section;
        }
        public async Task<SectionDTO> Load(int Id)
        {
            var section = await generic.Load(Id);
            if (section != null)
            {
                var sectionDetails = new SectionDTO()
                {
                    Id = section.Id,
                    StartDate = section.StartDate,
                    EndDate = section.EndDate,
                    Type = section.Type,
                    Time = section.Time,
                    Capacity = section.Capacity,
                    Course_ID = section.Course_ID,
                };
                return sectionDetails;
            }
            return null;
        }
      
        public async Task Update(SectionDTO sectionDTO)
        {
            var newSection = new Section()
            {
                Id = sectionDTO.Id,
                StartDate = sectionDTO.StartDate,
                EndDate = sectionDTO.EndDate,
                Type = sectionDTO.Type,
                Time = sectionDTO.Time,
                Capacity = sectionDTO.Capacity,
                Course_ID = sectionDTO.Course_ID,
                LiCourse_Schedule = new List<Course_Schedule>()
            };
            foreach (Course_ScheduleDTO item in sectionDTO.LiCourse_Schedule)
            {

                Course_Schedule dayInfo = new Course_Schedule();
                dayInfo.Day = item.Day;
                newSection.LiCourse_Schedule.Add(dayInfo);
            }
            await generic.Update(newSection);
        }

        public async Task Delete(int Id)
        {
            await generic.delete(Id);
        }
        public List<Section> LoadSectionByCourseID(int Id)
        {
            List<Section> section = context.sections.Where(s => s.Course_ID == Id).ToList();
            return section;
        }
    }
}
