using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diyetisyen_Application
{
    public class returnValue
    {
        public string message { get; set; }
        public bool state { get; set; }
        public returnValue(bool state = true,string message="success")
        {
            this.state = state;
            this.message = message;
        }
    }
}
