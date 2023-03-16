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
using System.Xml.Serialization;

namespace DareAcademy_BusinessLogic.SpecificReposoitory
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly IGeneric<Category> generic;
        private readonly DareAcademyContext context;

        public CategoryRepository(IGeneric<Category> _generic, DareAcademyContext _context)
        {
            generic = _generic;
            context = _context;
        }
        public async Task<int> Insert(CategoryDTO categoryDTO)
        {
            var newCategory = new Category()
            {
                Name = categoryDTO.Name,
                IconPath=categoryDTO.IconPath,
                SubCategoryID = categoryDTO.SubCategoryID  
            };
            return await generic.Insert(newCategory);
        }
        public async Task<List<CategoryDTO>> LoadAll()
        {
            var categories = new List<CategoryDTO>();
            var allcategory = await generic.LoadAll();
            if (allcategory?.Any() == true)
            {
                foreach (var category in allcategory)
                {
                    categories.Add(new CategoryDTO()
                    {
                        Id = category.Id,
                        Name = category.Name,
                        IconPath = category.IconPath,
                        SubCategoryID = category.SubCategoryID
                    });
                }
            }
            return categories;
        }
        public async Task<CategoryDTO> Load(int Id)
        {
            var category = await generic.Load(Id);
            if (category != null)
            {
                var categoryDetails = new CategoryDTO()
                {
                    Name = category.Name,
                    IconPath = category.IconPath,
                    SubCategoryID = category.SubCategoryID
                };
                return categoryDetails;
            }
            return null;
        }
        public async Task Update(CategoryDTO categoryDTO)
        {
            var newCategory = new Category()
            {
                Id = categoryDTO.Id,
                Name = categoryDTO.Name,
                IconPath = categoryDTO.IconPath,
                SubCategoryID = categoryDTO.SubCategoryID
            };
            await generic.Update(newCategory);
        }
        public async Task Delete(int Id)
        {
            await generic.delete(Id);
        }
        public List<Category> MainCategory()
        {
            List<Category> category = context.categories.Where(p => p.SubCategoryID == null).ToList();
            return category;
        }
        public List<Category> SubCategory()
        {
            List<Category> category = context.categories.Where(s => s.SubCategoryID != null).ToList();
            return category;
        }
        public List<Count_Courses> Count()
        {
            List<Count_Courses> li = context.categories.Select(data =>
            new Count_Courses()
            {
                category = data,
                Count = data.LiCourse.Count()
            }
            ).ToList();
            return li;
        }
    }
}
