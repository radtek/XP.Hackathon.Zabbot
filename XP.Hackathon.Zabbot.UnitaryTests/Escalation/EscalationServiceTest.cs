using FluentAssertions;
using Moq;
using Xunit;

namespace XP.Hackathon.Zabbot.Tests
{

    public class EscalationServiceTest
    {
        public EscalationFixtureTest _fixture { get; set; }

        public EscalationServiceTest()
        {
            _fixture = new EscalationFixtureTest();
        }

        [Fact]
        public async void Escalation_GetAll_Success()
        {
            // Arrange
            var escalationList = _fixture.GetAllEscalation();
            var _service = _fixture.GetEscalationMoq();

            _fixture._escalationRepository.Setup(s => s.GetAsync()).Returns(escalationList);

            // Act
            var result = await _service.GetAsync();

            // Assert
            _fixture._escalationRepository.Verify(r => r.GetAsync(), Times.Once);
            result.Should().NotBeNull();
        }
    }
}
