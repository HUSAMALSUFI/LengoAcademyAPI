using DareAcademy_DataAccess.Domain;
using DareAcademy_DataAccess.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DareAcademy_BusinessLogic.SpecificReposoitory
{
    public interface IProcessRepository
    {
        Task<int> Insert(ProcessDTO processDTO);
        Task<List<ProcessDTO>> LoadAll();
        Task<ProcessDTO> Load(int Id);
        Task Update(ProcessDTO processDTO);
        Task Delete(int Id);
        List<Process> LoadProcessByCourseID(int Id);
    }
}
