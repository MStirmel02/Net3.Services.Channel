using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net3.Services.Channel.Services.Models
{
    public class ResponseModel<TModel>
    {
        public TModel Response { get; set; }

        public Error Error { get; set; }
    }


    public class Error
    {
        public int Code { get; set; }

        public string Message { get; set; }
    }
}
