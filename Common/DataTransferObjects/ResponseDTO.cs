using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DataTransferObjects
{
    public class ResponseDTO
    {
        public Object data { get; set; }
        public string message { get; set; }
        public bool success { get; set; }

        public ResponseDTO(Object data, string message, bool success)
        {
            this.data = data;
            this.success = success;
            this.message = message;
        }
    }
}
