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
    public class TopicsRepository : ITopicsRepository
    {
        private readonly IGeneric<Topics> generic;
        private readonly DareAcademyContext context;

        public TopicsRepository(IGeneric<Topics> _generic, DareAcademyContext _context)
        {
            generic = _generic;
            context = _context;
        }
        public async Task<int> Insert(TopicsDTO topicsDTO)
        {
            var newTopics = new Topics()
            {
                Main = topicsDTO.Main,
                Duration = topicsDTO.Duration,
                SubTopicsID = topicsDTO.SubTopicsID,
                Course_ID = topicsDTO.Course_ID,

            };
            return await generic.Insert(newTopics);
        }
        public async Task<List<TopicsDTO>> LoadAll()
        {
            var topics = new List<TopicsDTO>();
            var alltopic = await generic.LoadAll();
            if (alltopic?.Any() == true)
            {
                foreach (var topic in alltopic)
                {
                    topics.Add(new TopicsDTO()
                    {
                        Id = topic.Id,
                        Main = topic.Main,
                        Duration = topic.Duration,
                        SubTopicsID = topic.SubTopicsID,
                        Course_ID = topic.Course_ID,

                    });
                }
            }
            return topics;
        }
        public async Task<TopicsDTO> Load(int Id)
        {
            var topics = await generic.Load(Id);
            if (topics != null)
            {
                var topicsDetails = new TopicsDTO()
                {
                    Id = topics.Id,
                    Main = topics.Main,
                    Duration = topics.Duration,
                    SubTopicsID = topics.SubTopicsID,
                    Course_ID = topics.Course_ID,
                };
                return topicsDetails;
            }
            return null;
        }
        /* public Topics LoadByCourseId(int Id)
         {
             return context.topics.Where(e => e.Course_ID == Id).FirstOrDefault();
         }*/
        public async Task Update(TopicsDTO topicsDTO)
        {
            var newtopics = new Topics()
            {
                Id = topicsDTO.Id,
                Main = topicsDTO.Main,
                Duration = topicsDTO.Duration,
                SubTopicsID = topicsDTO.SubTopicsID,
                Course_ID = topicsDTO.Course_ID,
            };
            await generic.Update(newtopics);
        }
        public async Task Delete(int Id)
        {
            await generic.delete(Id);
        }
        public List<Topics> MainTopics()
        {
            List<Topics> topics = context.topics.Where(p => p.SubTopicsID == null).ToList();
            return topics;
        }
        public List<Topics> SubTopics()
        {
            List<Topics> topics = context.topics.Where(s => s.SubTopicsID != null).ToList();
            return topics;
        }
        public List<Topics> LoadTopicsByCourseID(int Id)
        {
            List<Topics> topics = context.topics.Where(s => s.Course_ID == Id).ToList();
            return topics;
        }
        public List<Topics> MainTopics1(int Id)
        {
            List<Topics> topics = context.topics.Where(p => p.SubTopicsID == null && p.Course_ID == Id).ToList();
            return topics;
        }
    }
}
