using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimateChangeIndicators.Data.Entities
{
    public class DataType
    {
        public DataType()
        {
            Name = Id.ToString();
        }

        public DataTypeEnum Id { get; set; }
        public string Name { get; set; }
    }
}
