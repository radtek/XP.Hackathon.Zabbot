using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace XP.Hackathon.Zabbot.Tests
{
    [TestClass]
    public class EscalationGroupServiceTest
    {
        public EscalationGroupFixtureTest _fixture { get; set; }

        public EscalationGroupServiceTest()
        {
            _fixture = new EscalationGroupFixtureTest();
        }

        [TestMethod("Obtém as lista de times")]
        public async void EscalationGroup_GetAll_Success()
        {
            // Arrange
            var escalationGroupList = _fixture.GetAllEscalationGroup();
            var _service = _fixture.GetEscalationGroupMoq();

            _fixture._escalationGroupRepository.Setup(s => s.GetAsync()).Returns(escalationGroupList);

            // Act
            var result = await _service.GetAsync();

            // Assert
            _fixture._escalationGroupRepository.Verify(r => r.GetAsync(), Times.Once);
            result.Should().NotBeNull();
        }
    }
}
