using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data_table
{
    public class LSMTree
    {
        private List<SSTable> sstables = new List<SSTable>();
        public int MaxSize { get; } = 30;

        public void AddOrUpdate(string key, string value)
        {
            if (!sstables.Any() || (sstables.Last().Count >= MaxSize && !sstables.Last().ContainsKey(key)))
            {
                sstables.Add(new SSTable());
            }
            sstables.Last().AddOrUpdate(key, value);
        }

        public string Get(string key)
        {
            foreach (var sstable in sstables.Reverse<SSTable>())
            {
                var value = sstable.Get(key);
                if (value != null)
                {
                    return value;
                }
            }
            return null;
        }

        public void Delete(string key)
        {
            foreach (var sstable in sstables)
            {
                sstable.Delete(key);
            }
        }

        public void Compact()
        {
            var compactedData = new Dictionary<string, string>();
            foreach (var sstable in sstables)
            {
                foreach (var kvp in sstable.GetAllData())
                {
                    compactedData[kvp.Key] = kvp.Value;
                }
            }

            var newSSTable = new SSTable();
            foreach (var kvp in compactedData)
            {
                newSSTable.AddOrUpdate(kvp.Key, kvp.Value);
            }

            sstables.Clear();
            sstables.Add(newSSTable);
        }

    }
}
