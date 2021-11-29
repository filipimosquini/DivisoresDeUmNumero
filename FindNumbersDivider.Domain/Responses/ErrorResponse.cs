using System.Collections.Generic;

namespace FindNumbersDivider.Domain.Responses
{
    public class ErrorResponse
    {
        public IEnumerable<string> Errors { get; set; }
    }
}