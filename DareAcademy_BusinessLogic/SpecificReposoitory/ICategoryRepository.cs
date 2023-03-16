using DareAcademy_DataAccess.Domain;
using DareAcademy_DataAccess.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DareAcademy_BusinessLogic.SpecificReposoitory
{
    public interface ICategoryRepository
    {
        Task<int> Insert(CategoryDTO ctegoryDTO);
        Task<List<CategoryDTO>> LoadAll();
        Task<CategoryDTO> Load(int Id);
        List<Category> MainCategory();
        List<Category> SubCategory();
        Task Update(CategoryDTO categoryDTO);
        Task Delete(int Id);
        List<Count_Courses> Count();
    }
}
