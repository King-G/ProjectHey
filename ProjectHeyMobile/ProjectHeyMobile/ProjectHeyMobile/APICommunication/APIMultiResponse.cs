using System.Collections.Generic;

namespace ProjectHeyMobile.APICommunication
{
    public class APIMultiResponse<T>
    {
        public IEnumerable<T> Value { get; set; }

    }
}
