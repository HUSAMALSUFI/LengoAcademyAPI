using DareAcademy_DataAccess.Context;
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
    public class ProcessRepository : IProcessRepository
    {
        private readonly IGeneric<Process> generic;
        private readonly DareAcademyContext context;

        public ProcessRepository(IGeneric<Process> _generic, DareAcademyContext _context)
        {
            generic = _generic;
            context = _context;
        }
        public async Task<int> Insert(ProcessDTO processDTO)
        {
            var newProcess = new Process()
            {
                Title = processDTO.Title,
                Descrption = processDTO.Descrption,
                Course_ID = processDTO.Course_ID,
            };
            return await generic.Insert(newProcess);
        }
        public async Task<List<ProcessDTO>> LoadAll()
        {
            var process = new List<ProcessDTO>();
            var allprocess = await generic.LoadAll();
            if (allprocess?.Any() == true)
            {
                foreach (var process1 in allprocess)
                {
                    process.Add(new ProcessDTO()
                    {
                        Id = process1.Id,
                        Title = process1.Title,
                        Descrption = process1.Descrption,
                        Course_ID = process1.Course_ID
                    });
                }
            }
            return process;
        }
        public async Task<ProcessDTO> Load(int Id)
        {
            var process = await generic.Load(Id);
            if (process != null)
            {
                var processDetails = new ProcessDTO()
                {
                    Id = process.Id,
                    Title = process.Title,
                    Descrption = process.Descrption,
                    Course_ID = process.Course_ID,
                };
                return processDetails;
            }
            return null;
        }

        /*
               public Process Load(int Id)
               {
                   return context.Process.Where(e => e.Course_ID == Id).FirstOrDefault();
               }*/
        public async Task Update(ProcessDTO processDTO)
        {
            var newprocess = new Process()
            {
                Id = processDTO.Id,
                Title = processDTO.Title,
                Descrption = processDTO.Descrption,
                Course_ID = processDTO.Course_ID,
            };
            await generic.Update(newprocess);
        }
        public async Task Delete(int Id)
        {
            await generic.delete(Id);
        }

        public List<Process> LoadProcessByCourseID(int Id)
        {
            List<Process> processes = context.Process.Where(s => s.Course_ID == Id).ToList();
            return processes;
        }
    }
}
