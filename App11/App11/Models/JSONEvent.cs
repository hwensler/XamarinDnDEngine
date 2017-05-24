using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App11.Models;

namespace App11.Models
{
    class JSONEvent
    {
        int error_code;
        string msg;
        public List<ServerEvent> data;
    }
}
