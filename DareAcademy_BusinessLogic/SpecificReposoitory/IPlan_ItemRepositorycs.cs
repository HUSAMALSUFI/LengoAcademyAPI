using DareAcademy_DataAccess.Domain;
using DareAcademy_DataAccess.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DareAcademy_BusinessLogic.SpecificReposoitory
{
    public interface IPlan_ItemRepositorycs
    {
        Task<int> Insert(Plan_ItemDTO planDTO);
        Task<List<Plan_ItemDTO>> LoadAll();
        Task Delete(int Id);
        Task Update(Plan_ItemDTO planDTO);
    }
}
