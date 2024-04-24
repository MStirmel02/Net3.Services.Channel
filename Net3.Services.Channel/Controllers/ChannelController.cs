using Microsoft.AspNetCore.Mvc;
using Net3.Services.Channel.Services.Models;
using Net3.Services.Channel.Services.Services;
using System.ComponentModel.DataAnnotations;

namespace Net3.Services.Channel.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ChannelController : ControllerBase
    {
        private ILogger<ChannelController> _logger;
        private IChannelService _channelService;

        public ChannelController(ILogger<ChannelController> logger, IChannelService channelService)
        {
            _logger = logger;
            _channelService = channelService;
        }

        [HttpGet]
        [Route("/channels/{userId}")]
        [ProducesResponseType(typeof(ResponseModel<ChannelModel>), 200)]
        [ProducesResponseType(typeof(ResponseModel<ChannelModel>), 500)]
        public async Task<ResponseModel<List<ChannelModel>>> ViewUserChannelsAsync([Required][FromRoute] string userId)
        {
            ResponseModel<List<ChannelModel>> response = new();
            try
            {
                response.Response = await _channelService.GetUserChannelsAsync(userId);
                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, typeof(ChannelController));
                return new ResponseModel<List<ChannelModel>>
                {
                    Error = new Error
                    {
                        Code = 500,
                        Message = ex.Message
                    }
                };
            }
        }

        [HttpPost]
        [Route("/channels/create")]
        [ProducesResponseType(typeof(ResponseModel<bool>), 200)]
        [ProducesResponseType(typeof(ResponseModel<bool>), 500)]
        public async Task<ResponseModel<bool>> CreateChannelAsync([Required][FromBody] ChannelRequestModel request)
        {
            ResponseModel<bool> response = new();
            try
            {
                response.Response = await _channelService.CreateChannelAsync(request.channel, request.UserId);
                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, typeof(ChannelController));
                return new ResponseModel<bool>
                {
                    Error = new Error
                    {
                        Code = 500,
                        Message = ex.Message
                    }
                };
            }
        }

        [HttpPost]
        [Route("/channels/join")]
        [ProducesResponseType(typeof(ResponseModel<bool>), 200)]
        [ProducesResponseType(typeof(ResponseModel<bool>), 500)]
        public async Task<ResponseModel<bool>> JoinChannelAsync([Required][FromBody] ChannelRequestModel request)
        {
            ResponseModel<bool> response = new();
            try
            {
                response.Response = await _channelService.JoinChannelAsync(request.channel, request.UserId);
                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, typeof(ChannelController));
                return new ResponseModel<bool>
                {
                    Error = new Error
                    {
                        Code = 500,
                        Message = ex.Message
                    }
                };
            }
        }


        [HttpPost]
        [Route("/channels/leave")]
        [ProducesResponseType(typeof(ResponseModel<bool>), 200)]
        [ProducesResponseType(typeof(ResponseModel<bool>), 500)]
        public async Task<ResponseModel<bool>> LeaveChannelAsync([Required][FromBody] ChannelRequestModel request)
        {
            ResponseModel<bool> response = new();
            try
            {
                response.Response = await _channelService.LeaveChannelAsync(request.channel, request.UserId);
                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, typeof(ChannelController));
                return new ResponseModel<bool>
                {
                    Error = new Error
                    {
                        Code = 500,
                        Message = ex.Message
                    }
                };
            }
        }

        [HttpPost]
        [Route("/channels/delete")]
        [ProducesResponseType(typeof(ResponseModel<bool>), 200)]
        [ProducesResponseType(typeof(ResponseModel<bool>), 500)]
        public async Task<ResponseModel<bool>> DeleteChannelAsync([Required][FromBody] ChannelModel request)
        {
            ResponseModel<bool> response = new();
            try
            {
                response.Response = await _channelService.DeleteChannelAsync(request);
                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, typeof(ChannelController));
                return new ResponseModel<bool>
                {
                    Error = new Error
                    {
                        Code = 500,
                        Message = ex.Message
                    }
                };
            }
        }
    }
}