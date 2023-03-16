using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DareAcademy_DataAccess.Generic
{
    public interface IGeneric<T>
    {
        Task<int> Insert(T obj);
        Task Update(T obj);
        Task delete(int Id);
        Task<T> Load(int Id);
        Task<List<T>> LoadAll();
    }
}
