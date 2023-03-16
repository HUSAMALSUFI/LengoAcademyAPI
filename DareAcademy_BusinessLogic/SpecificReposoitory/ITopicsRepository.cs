using DareAcademy_DataAccess.Domain;
using DareAcademy_DataAccess.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DareAcademy_BusinessLogic.SpecificReposoitory
{
    public interface ITopicsRepository
    {
        Task<int> Insert(TopicsDTO topicsDTO);
        Task<List<TopicsDTO>> LoadAll();
        Task<TopicsDTO> Load(int Id);
/*        Topics LoadByCourseId(int Id);
*/        List<Topics> MainTopics();
        List<Topics> SubTopics();
        Task Update(TopicsDTO topicsDTO);
        Task Delete(int Id);
        List<Topics> LoadTopicsByCourseID(int Id);
        List<Topics> MainTopics1(int Id);
    }
}
