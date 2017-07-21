using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectHey.Web.ProjectHeyAPI
{
    public class APIMultiResponse<T>
    {
        public IEnumerable<T> Value { get; set; }

    }
}