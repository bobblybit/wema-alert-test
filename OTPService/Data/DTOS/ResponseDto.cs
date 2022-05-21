using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OTPService.Data.DTOS
{
    public class ResponseDto<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public Dictionary<string, string> Errors { get; set; }
        public T Data { get; set; }
    }
}
