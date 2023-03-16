using DareAcademy_DataAccess.Domain;
using DareAcademy_DataAccess.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DareAcademy_BusinessLogic.SpecificReposoitory
{
    public interface ISectiontRepository
    {
        Task<int> Insert(SectionDTO sectionDTO);
        Task<List<SectionDTO>> LoadAll();
        Task<SectionDTO> Load(int Id);
        Task Update(SectionDTO sectionDTO1);
        Task Delete(int Id);
        List<Section> LoadSectionByCourseID(int Id);
    }
}
