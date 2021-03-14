using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoochanaSeva_Model
{
    public class Sync
    {
        public int Id { get; set; }
        public string SyncFunctionName { get; set; }
        public bool SyncStatus { get; set; }
        public string User { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}
