using System.Collections.Generic;

namespace FindNumbersDivider.Domain.Responses
{
    public class NumberResponse
    {
        public int Number { get; set; }
        public IEnumerable<int> Dividers { get; set; }
        public IEnumerable<int> PrimeDividers { get; set; }
    }
}