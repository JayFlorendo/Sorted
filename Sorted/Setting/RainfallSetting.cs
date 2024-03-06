using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace Sorted.Setting
{
    public class RainfallSetting
    {

        public string Root { get; set; }
        public RainfallSetting()
        {
            Root = $"http://environment.data.gov.uk/flood-monitoring/";
        
        }
    }
}
