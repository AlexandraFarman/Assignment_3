using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DAL
{
    public class ListManager<T> : IListManager<T>
    {
        private List<T> _list;
        public int Count { get; }

        public ListManager()
        {
            _list = new List<T>();
        }

        public bool Add(T item)
        {
            if (_list == null)
                return false;

            _list.Add(item);
            return true;
        }

        public bool BinaryDeserialize(string fileName)
        {
            using (StreamReader streamReader = new StreamReader(fileName))
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                try
                {
                    _list = (List<T>)binaryFormatter.Deserialize(streamReader.BaseStream);
                }
                catch (SerializationException)
                {
                    return false;
                }
                return true;
            }
        }

        public bool BinarySerialize(string fileName)
        {
            if (_list == null) return false;

            using (StreamWriter streamWriter = new StreamWriter(fileName))
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                try
                {
                    binaryFormatter.Serialize(streamWriter.BaseStream, _list);
                }
                catch (SerializationException)
                {
                    return false;
                }
                return true;
            }
        }

        public bool ChangeAt(T item, int index)
        {
            if (!CheckIndex(index))
                return false;

            _list[index] = item;
            return true;
        }

        public bool CheckIndex(int index)
        {
            if (_list == null)
                return false;

            return index < _list.Count;
        }

        public void DeleteAll()
        {
            if (_list != null)
                _list.Clear();
        }

        public bool DeleteAt(int index)
        {
            if (!CheckIndex(index))
                return false;

            _list.RemoveAt(index);
            return true;
        }

        public T GetAt(int index)
        {
            if (!CheckIndex(index))
                return default;

            return _list[index];
        }

        public List<T> GetAll()
        {
            return _list.ToList();
        }

        public string[] ToStringArray()
        {
            if (_list == null) return null;

            return _list.Select(i => i.ToString()).ToArray<string>();
        }

        public List<string> ToStringList()
        {
            if (_list == null) return null;

            return _list.Select(i => i.ToString()).ToList<string>();
        }

        public void Reset()
        {

        }
    }
}
