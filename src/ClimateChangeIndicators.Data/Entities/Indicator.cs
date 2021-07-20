using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimateChangeIndicators.Data.Entities
{
    public class Indicator
    {
        public int Id { get; set; }
        public string DisplayName { get; set; }
        public Owner Owner { get; set; }
        public string Description { get; set; }
        public Unit Unit { get; set; }
        public string Target { get; set; }
        public DataType DataType { get; set; }
        public OcfReference OcfReference { get; set; }
        public CollectionInterval CollectionInterval { get; set; }
        public List<Entry> Entries { get; set; }
        public string Notes { get; set; }
    }
}
