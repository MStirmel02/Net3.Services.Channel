using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Net3.Services.Channel.Services.Models;
using System.Reflection;

namespace Net3.Services.Channel.Services.Services
{
    public class ChannelService : IChannelService
    {
        protected readonly IConfiguration _configuration;

        public ChannelService(IConfiguration configuration )
        {
            _configuration = configuration;
        }

        /*
         * print '' print '*** sp_create_channel ***'
GO
CREATE PROC sp_create_channel(
	@UserID				[NVARCHAR](50)
,	@PasswordHash		[NVARCHAR](255)
,	@ChannelID			[NVARCHAR](255)
) 
         */
        public async Task<bool> CreateChannelAsync(ChannelModel channel, string userId)
        {
            SqlConnection conn = new SqlConnection(_configuration["ConnectionStrings:Database"]);
            List<SqlParameter> sqlParam = new List<SqlParameter>
            {
                new SqlParameter
                {
                    ParameterName = "@UserID",
                    Value = userId
                }, 
                new SqlParameter
                {
                    ParameterName = "@ChannelID",
                    Value = channel.ChannelId
                },
                new SqlParameter
                {
                    ParameterName = "@ChannelHash",
                    Value = channel.ChannelHash
                }
            };

            int result = await SqlExecutor.ExecuteNonQueryAsync(conn, sqlParam, "sp_create_channel");

            return result != 0 ? true : false;
        }

        public async Task<List<ChannelModel>> GetUserChannelsAsync(string userId)
        {
            SqlConnection conn = new SqlConnection(_configuration["ConnectionStrings:Database"]);
            List<SqlParameter> sqlParam = new List<SqlParameter>
            {
                new SqlParameter
                {
                    ParameterName = "@UserID",
                    Value = userId
                }
            };

            DataSet ds = await SqlExecutor.ExecuteQueryAsync(conn, sqlParam, "sp_user_view_channels");
            List<ChannelModel> result = new List<ChannelModel>();
            foreach(DataRow row in ds.Tables[0].Rows)
            {
                result.Add(new ChannelModel
                {
                    ChannelId = row["ChannelId"].ToString(),
                    ChannelRole = row["RoleId"].ToString()

                });
            }

            return result;
        }

        public Task<ChannelModel> JoinChannelAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ChannelModel> LeaveChannelAsync()
        {
            throw new NotImplementedException();
        }
    }
}
