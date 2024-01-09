using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data_table
{
    public class SSTable
    {
        private Dictionary<string, string> table = new Dictionary<string, string>();
        public int MaxSize { get; } = 30;

        public int Count
        {
            get { return table.Count; }
        }

        public void AddOrUpdate(string key, string value)
        {
            if (Count >= MaxSize && !ContainsKey(key))
            {
                throw new InvalidOperationException("SSTable is full and the key does not exist for an update.");
            }
            table[key] = value;
        }

        public string Get(string key)
        {
            if (table.TryGetValue(key, out string value))
            {
                return value;
            }
            return null;
        }

        public void Delete(string key)
        {
            if (table.ContainsKey(key))
            {
                table.Remove(key);
            }
        }

        public bool ContainsKey(string key)
        {
            return table.ContainsKey(key);
        }

        public Dictionary<string, string> GetAllData()
        {
            return new Dictionary<string, string>(table);
        }

    }
}
