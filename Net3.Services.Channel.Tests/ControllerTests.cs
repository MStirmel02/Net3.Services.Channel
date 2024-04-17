namespace Net3.Services.Channel.Tests
{
    [TestClass]
    public class ControllerTests
    {
        [TestMethod]
        public void ViewUserChannelsAsyncReturnsList()
        {
            List<ChannelModel> channels = new List<ChannelModel>
            {
                new ChannelModel
                {
                    ChannelId = "t",
                    ChannelHash = "t",
                    ChannelRole = "t",
                    UsersInChannel = 1,
                    Deleted = false
                },
                new ChannelModel
                {
                    ChannelId = "t",
                    ChannelHash = "t",
                    ChannelRole = "t",
                    UsersInChannel = 1,
                    Deleted = false
                }
            };

            Mock<IChannelService> mockChannelService = new Mock<IChannelService>();

            mockChannelService.Setup(t => t.GetUserChannelsAsync(It.IsAny<string>())).ReturnsAsync(channels);

            ChannelController channelController = new ChannelController(new Logger<ChannelController>(new LoggerFactory()), mockChannelService.Object);

            var result = channelController.ViewUserChannelsAsync("test");

            Assert.AreEqual(2, result.Result.Response.Count);
        }




        [TestMethod]
        public void ViewUserChannelsAsyncReturnsNullList()
        {
            List<ChannelModel> channels = new List<ChannelModel>();

            Mock<IChannelService> mockChannelService = new Mock<IChannelService>();

            mockChannelService.Setup(t => t.GetUserChannelsAsync(It.IsAny<string>())).ReturnsAsync(channels);

            ChannelController channelController = new ChannelController(new Logger<ChannelController>(new LoggerFactory()), mockChannelService.Object);

            var result = channelController.ViewUserChannelsAsync("test");

            Assert.AreEqual(0, result.Result.Response.Count);
        }



        [TestMethod]
        public void ViewUserChannelsAsyncReturnsException()
        {
            List<ChannelModel> channels = new List<ChannelModel>();

            Mock<IChannelService> mockChannelService = new Mock<IChannelService>();

            mockChannelService.Setup(t => t.GetUserChannelsAsync(It.IsAny<string>())).ThrowsAsync(new Exception());

            ChannelController channelController = new ChannelController(new Logger<ChannelController>(new LoggerFactory()), mockChannelService.Object);

            var result = channelController.ViewUserChannelsAsync("test");

            Assert.AreEqual(500, result.Result.Error.Code);
        }

        [TestMethod]
        public void CreateChannelAsyncReturnsTrue()
        {

            ChannelRequestModel request = new ChannelRequestModel
            {
                UserId = "test",
                channel = new ChannelModel()
            };

            Mock<IChannelService> mockChannelService = new Mock<IChannelService>();

            mockChannelService.Setup(t => t.CreateChannelAsync(It.IsAny<ChannelModel>(), It.IsAny<string>())).ReturnsAsync(true);

            ChannelController channelController = new ChannelController(new Logger<ChannelController>(new LoggerFactory()), mockChannelService.Object);

            var result = channelController.CreateChannelAsync(request);

            Assert.AreEqual(true, result.Result.Response);
        }


        [TestMethod]
        public void CreateChannelAsyncReturnsFalse()
        {

            ChannelRequestModel request = new ChannelRequestModel
            {
                UserId = "test",
                channel = new ChannelModel()
            };

            Mock<IChannelService> mockChannelService = new Mock<IChannelService>();

            mockChannelService.Setup(t => t.CreateChannelAsync(It.IsAny<ChannelModel>(), It.IsAny<string>())).ReturnsAsync(false);

            ChannelController channelController = new ChannelController(new Logger<ChannelController>(new LoggerFactory()), mockChannelService.Object);

            var result = channelController.CreateChannelAsync(request);

            Assert.AreEqual(false, result.Result.Response);
        }


        [TestMethod]
        public void CreateChannelAsyncReturnsException()
        {

            ChannelRequestModel request = new ChannelRequestModel
            {
                UserId = "test",
                channel = new ChannelModel()
            };

            Mock<IChannelService> mockChannelService = new Mock<IChannelService>();

            mockChannelService.Setup(t => t.CreateChannelAsync(It.IsAny<ChannelModel>(), It.IsAny<string>())).ThrowsAsync(new Exception());

            ChannelController channelController = new ChannelController(new Logger<ChannelController>(new LoggerFactory()), mockChannelService.Object);

            var result = channelController.CreateChannelAsync(request);

            Assert.AreEqual(500, result.Result.Error.Code);
        }


        [TestMethod]
        public void JoinChannelAsyncReturnsTrue()
        {

            ChannelRequestModel request = new ChannelRequestModel
            {
                UserId = "test",
                channel = new ChannelModel()
            };

            Mock<IChannelService> mockChannelService = new Mock<IChannelService>();

            mockChannelService.Setup(t => t.JoinChannelAsync(It.IsAny<ChannelModel>(), It.IsAny<string>())).ReturnsAsync(true);

            ChannelController channelController = new ChannelController(new Logger<ChannelController>(new LoggerFactory()), mockChannelService.Object);

            var result = channelController.JoinChannelAsync(request);

            Assert.AreEqual(true, result.Result.Response);
        }

        [TestMethod]
        public void JoinChannelAsyncReturnsFalse()
        {

            ChannelRequestModel request = new ChannelRequestModel
            {
                UserId = "test",
                channel = new ChannelModel()
            };

            Mock<IChannelService> mockChannelService = new Mock<IChannelService>();

            mockChannelService.Setup(t => t.JoinChannelAsync(It.IsAny<ChannelModel>(), It.IsAny<string>())).ReturnsAsync(false);

            ChannelController channelController = new ChannelController(new Logger<ChannelController>(new LoggerFactory()), mockChannelService.Object);

            var result = channelController.JoinChannelAsync(request);

            Assert.AreEqual(false, result.Result.Response);
        }

        [TestMethod]
        public void JoinChannelAsyncReturnsException()
        {

            ChannelRequestModel request = new ChannelRequestModel
            {
                UserId = "test",
                channel = new ChannelModel()
            };

            Mock<IChannelService> mockChannelService = new Mock<IChannelService>();

            mockChannelService.Setup(t => t.JoinChannelAsync(It.IsAny<ChannelModel>(), It.IsAny<string>())).ThrowsAsync(new Exception());

            ChannelController channelController = new ChannelController(new Logger<ChannelController>(new LoggerFactory()), mockChannelService.Object);

            var result = channelController.JoinChannelAsync(request);

            Assert.AreEqual(500, result.Result.Error.Code);
        }



        [TestMethod]
        public void LeaveChannelAsyncReturnsTrue()
        {

            ChannelRequestModel request = new ChannelRequestModel
            {
                UserId = "test",
                channel = new ChannelModel()
            };

            Mock<IChannelService> mockChannelService = new Mock<IChannelService>();

            mockChannelService.Setup(t => t.LeaveChannelAsync(It.IsAny<ChannelModel>(), It.IsAny<string>())).ReturnsAsync(true);

            ChannelController channelController = new ChannelController(new Logger<ChannelController>(new LoggerFactory()), mockChannelService.Object);

            var result = channelController.LeaveChannelAsync(request);

            Assert.AreEqual(true, result.Result.Response);
        }


        [TestMethod]
        public void LeaveChannelAsyncReturnsFalse()
        {

            ChannelRequestModel request = new ChannelRequestModel
            {
                UserId = "test",
                channel = new ChannelModel()
            };

            Mock<IChannelService> mockChannelService = new Mock<IChannelService>();

            mockChannelService.Setup(t => t.LeaveChannelAsync(It.IsAny<ChannelModel>(), It.IsAny<string>())).ReturnsAsync(false);

            ChannelController channelController = new ChannelController(new Logger<ChannelController>(new LoggerFactory()), mockChannelService.Object);

            var result = channelController.LeaveChannelAsync(request);

            Assert.AreEqual(false, result.Result.Response);
        }


        [TestMethod]
        public void LeaveChannelAsyncReturnsException()
        {

            ChannelRequestModel request = new ChannelRequestModel
            {
                UserId = "test",
                channel = new ChannelModel()
            };

            Mock<IChannelService> mockChannelService = new Mock<IChannelService>();

            mockChannelService.Setup(t => t.LeaveChannelAsync(It.IsAny<ChannelModel>(), It.IsAny<string>())).ThrowsAsync(new Exception());

            ChannelController channelController = new ChannelController(new Logger<ChannelController>(new LoggerFactory()), mockChannelService.Object);

            var result = channelController.LeaveChannelAsync(request);

            Assert.AreEqual(500, result.Result.Error.Code);
        }
    }
}