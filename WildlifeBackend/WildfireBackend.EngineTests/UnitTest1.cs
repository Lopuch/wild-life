using WildlifeBackend.Engine.Helpers;
using WildlifeBackend.Engine.Models;

namespace WildfireBackend.EngineTests
{
    public class UnitTest1
    {
        [Fact]
        public void NewPositionShouldReturnGoodNewPosition1()
        {
            // arrange
            var actualPos = new Position(0, 0);
            var rotation = 45.0;
            var speedPerSec = 1.0;
            var timeMs = 1000.0;

            var nextPos = new Position(Math.Sqrt(2)/2, Math.Sqrt(2)/2);

            // act

            var res = MathHelper.CalculateNextPosition(actualPos, rotation, speedPerSec, timeMs);

            // assert

            Assert.Equal(res, nextPos);
        }

        [Fact]
        public void NewPositionShouldReturnGoodNewPosition2()
        {
            // arrange
            var actualPos = new Position(0, 0);
            var rotation = 225.0;
            var speedPerSec = 1.0;
            var timeMs = 1000.0;

            var expectedPos = new Position(-Math.Sqrt(2) / 2, -Math.Sqrt(2) / 2);

            // act

            var res = MathHelper.CalculateNextPosition(actualPos, rotation, speedPerSec, timeMs);

            // assert

            Assert.Equal(expectedPos, res);
        }
    }
}