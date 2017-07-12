using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectHeyMobile.Interfaces
{
    public class ProjectHeyAPIResponse<T>
    {
        public IEnumerable<T> Value { get; set; }
    }
}
