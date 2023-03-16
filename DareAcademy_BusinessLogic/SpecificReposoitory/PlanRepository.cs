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
    public class PlanRepository : IPlanRepository
    {
        private readonly IGeneric<Plan> generic;

        public PlanRepository(IGeneric<Plan> _generic)
        {
            generic = _generic;
        }
        public async Task<int> Insert(PlanDTO planDTO)
        {
            var newPlan = new Plan()
            {
                Name = planDTO.Name,
            };
            return await generic.Insert(newPlan);
        }
        public async Task<List<PlanDTO>> LoadAll()
        {
            var Plans = new List<PlanDTO>();
            var allPlans = await generic.LoadAll();
            if (allPlans?.Any() == true)
            {
                foreach (var Plan in allPlans)
                {
                    Plans.Add(new PlanDTO()
                    {
                        Id = Plan.Id,
                        Name = Plan.Name,
                    });
                }
            }
            return Plans;
        }
        public async Task<PlanDTO> Load(int Id)
        {
            var Plans = await generic.Load(Id);
            if (Plans != null)
            {
                var plansDetails = new PlanDTO()
                {
                    Name = Plans.Name,
                };
                return plansDetails;
            }
            return null;
        }
        public async Task Update(PlanDTO planDTO)
        {
            var newPlans = new Plan()
            {
                Id = planDTO.Id,
                Name = planDTO.Name,
            };
            await generic.Update(newPlans);
        }
        public async Task Delete(int Id)
        {
            await generic.delete(Id);
        }
    }
}