using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net3.Services.Channel.Services.Models
{
    public class ChannelRequestModel
    {
        public string UserId { get; set; }

        public ChannelModel channel { get; set; }
    }
}
