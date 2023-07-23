using System;
using System.Collections.Generic;
using System.Text;

namespace CA.Application.Response
{
    public class BaseCommandResponse
    {
        public Guid Id{ get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
        public List<string> Errors { get; set; }
    }
}
