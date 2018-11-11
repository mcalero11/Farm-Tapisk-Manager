using System;
using System.Collections.Generic;
using System.Text;

namespace TapiskAPP.Models
{
    public abstract class BaseResponse
    {
        public string ResponseMessage { get; set; }
        public bool IsSuccess { get; set; }
    }
}
