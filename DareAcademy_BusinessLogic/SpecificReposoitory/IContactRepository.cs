using DareAcademy_DataAccess.Domain;
using DareAcademy_DataAccess.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DareAcademy_BusinessLogic.SpecificReposoitory
{
    public interface IContactRepository
    {
        Task<int> Insert(ContactDTO contactDTO);
        Task<List<ContactDTO>> LoadAll();
        Task<ContactDTO> Load(int Id);
        Task Update(ContactDTO contactDTO);
        Task Delete(int Id);
    }
}
