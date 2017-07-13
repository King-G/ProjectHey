using System.Collections.Generic;

namespace ProjectHeyMobile.APICommunication
{
    public class ProjectHeyAPIMultiResponse<T>
    {
        public IEnumerable<T> Value { get; set; }

    }
}
