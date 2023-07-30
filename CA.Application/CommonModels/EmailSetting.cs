using System;
using System.Collections.Generic;
using System.Text;

namespace CA.Application.CommonModels
{
    public class EmailSetting
    {
        public string APIKey { get; set; }
        public string FromAddress { get; set; }
        public string FromName { get; set; }
    }
}
