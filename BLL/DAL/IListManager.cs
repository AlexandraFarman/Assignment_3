using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DAL
{
    public interface IListManager<T>
    {
        int Count { get; }

        bool Add(T item);
        bool BinaryDeserialize(string fileName);
        bool BinarySerialize(string fileName);
        bool ChangeAt(T item, int index);
        bool CheckIndex(int index);
        void DeleteAll();
        bool DeleteAt(int index);
        T GetAt(int index);
        string[] ToStringArray();
        List<string> ToStringList();
    }
}
