using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectHey.Web.ProjectHeyAPI
{
    public class APISingleResponse<T>
    {
        public T Value { get; set; }

    }
}