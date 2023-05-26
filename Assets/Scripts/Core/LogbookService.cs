using System.Collections.Generic;
using Model;

namespace Core
{
    public class LogbookService : AbstractSerializationService
    {
        private List<MLogbookEntry> _entries = new();

        public List<MLogbookEntry> GetLogbook()
        {
            return _entries;
        }

        public bool AddEntry(MLogbookEntry j)
        {
            _entries.Add(j);
            return Serialize();
        }

        override protected string fileName()
        {
            return "Logbook.dat";
        }

        protected override object objectToSave()
        {
            return _entries;
        }

        protected override void handleLoad()
        {
            object deserialized = Deserialize<List<MLogbookEntry>>();
            if (deserialized != null)
            {
                _entries = (List<MLogbookEntry>)deserialized;
            }
            else
            {
                _entries = new();
            }
        }
    }
}