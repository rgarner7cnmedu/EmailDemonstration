using System;
using System.Collections.Generic;
using System.Text;

namespace EmailDemonstration.Shared
{
    public class Email
    {
        public string Address { get; set; }
        public string ToName { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }        
    }
}
