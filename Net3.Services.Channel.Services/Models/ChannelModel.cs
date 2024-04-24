using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net3.Services.Channel.Services.Models
{
    public class ChannelModel
    {
        public string ChannelId { get; set; }
        public int? UsersInChannel { get; set; }
        public string ChannelHash { get; set; }
        public bool? Deleted { get; set; }
        public string? ChannelRole { get; set; }
    }
}
