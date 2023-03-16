using DareAcademy_DataAccess.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DareAcademy_BusinessLogic.SpecificReposoitory
{
    public interface IPlanRepository
    {
        Task<int> Insert(PlanDTO planDTO);
        Task<List<PlanDTO>> LoadAll();
        Task<PlanDTO> Load(int Id);
        Task Update(PlanDTO planDTO);
        Task Delete(int Id);
    }
}
