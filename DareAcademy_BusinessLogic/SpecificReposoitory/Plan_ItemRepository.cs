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
    public class Plan_ItemRepository : IPlan_ItemRepositorycs
    {
        private readonly DareAcademyContext context;
        private readonly IGeneric<Plan> generic;
        public Plan_ItemRepository (DareAcademyContext _context, IGeneric<Plan> _generic)
        {
            context = _context;
            generic = _generic;
        }
        public async Task<int> Insert(Plan_ItemDTO plan_ItemDTO)
        {
             
            var newPlan =  new Plan_Item()
            {
                Course_ID = plan_ItemDTO.Course_ID,
                Plan_ID = plan_ItemDTO.Plan_ID,  
            };
            await context.plan_Item.AddAsync(newPlan);
            return await context.SaveChangesAsync();
        }
        public async Task<List<Plan_ItemDTO>> LoadAll()
        {
            var Plans = new List<Plan_ItemDTO>();
            var allPlans = await context.plan_Item.ToListAsync();
            if (allPlans?.Any() == true)
            {
                foreach (var Plan in allPlans)
                {
                    Plans.Add(new Plan_ItemDTO()
                    {
                        Course_ID = Plan.Course_ID,
                        Plan_ID = Plan.Plan_ID,
                    });
                }
            }
            return Plans;
        }
        public async Task Delete(int Id)
        {
            Plan_Item  obj = await context.plan_Item.FindAsync(Id);
            context.plan_Item.Remove(obj);
            await context.SaveChangesAsync();
        }
        public async Task Update(Plan_ItemDTO plan_ItemDTO)
        {
            var newPlans = new Plan_Item()
            {
                Course_ID = plan_ItemDTO.Course_ID,
                Plan_ID = plan_ItemDTO.Plan_ID,
            };
            context.plan_Item.Attach(newPlans);
            context.plan_Item.Entry(newPlans).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }
    }
}
