using FluentAssertions;
using Moq;
using Xunit;

namespace XP.Hackathon.Zabbot.Tests
{

    public class EscalationGroupServiceTest
    {
        public EscalationGroupFixtureTest _fixture { get; set; }

        public EscalationGroupServiceTest()
        {
            _fixture = new EscalationGroupFixtureTest();
        }

        [Fact]
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
