using ASC.Online.AuctionApp.Framework.Models.Models.Session;
using ASC.Online.AuctionApp.SessionSetup.Api.Controllers;
using ASC.Online.AuctionApp.SessionSetup.Business.Components.Interface;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace ASC.Online.Auction.SessionSetup.Api.UnitTests
{
    /// <summary>
    /// Sessions Controller Unit Tests
    /// </summary>
    public class SessionsControllerTests
    {
        /// <summary>
        /// The session list
        /// </summary>
        private readonly List<AuctionSession> sessionList;

        #region Constructor        
        /// <summary>
        /// Initializes a new instance of the <see cref="SessionsControllerTests"/> class.
        /// </summary>
        public SessionsControllerTests()
        {
            sessionList = new List<AuctionSession>()
            { new AuctionSession()
              {
                Id = 1,
                SessionName = "First Auction Session",
                SessionDescription = "First Auction Session Description",
                SessionStartDate = DateTime.Now,
                SessionEndDate = DateTime.Now,
                SessionStatus = "Pending",
                CreatedBy = "Ishi",
                CreatedDate = DateTime.Now,
                CreatedMemberId = 342,
                ModifiedBy = "Ishi",
                ModifiedDate = DateTime.Now,
                ModifiedMemberId = 342,
                NumberOfItems = 4
              }
            };
        }
        #endregion Constructor


        /// <summary>
        /// Gets all sessions asynchronous return all sessions returns all sessions.
        /// </summary>
        [Fact]
        public async Task GetAllSessionsAsync_ReturnAllSessions_ReturnsAllSessions()
        {
            //Arrange
            var sessionMock = new Mock<ISessionComponent>();
            var iLoggerMock = new Mock<ILogger<SessionsController>>();
            sessionMock.Setup(x => x.GetAllSessionsAsync()).ReturnsAsync(() => sessionList);

            var controller = new SessionsController(sessionMock.Object, iLoggerMock.Object);

            //Act
            var actionResult = await controller.GetAllSessionsAsync();

            //Assert
            var result = actionResult.Result.Should().BeOfType<OkObjectResult>().Subject;
            var sessions = result.Value.Should().BeAssignableTo<List<AuctionSession>>().Subject;
            sessions.Count.Should().Be(1);
        }
    }
}
