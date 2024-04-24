using Net3.Services.Channel.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net3.Services.Channel.Services.Services
{
    public interface IChannelService
    {
        Task<List<ChannelModel>> GetUserChannelsAsync(string userId);
        Task<bool> CreateChannelAsync(ChannelModel channel, string userId);
        Task<bool> JoinChannelAsync(ChannelModel channel, string userId);
        Task<bool> LeaveChannelAsync(ChannelModel channel, string userId);
        Task<bool> DeleteChannelAsync(ChannelModel channel);
    }
}
