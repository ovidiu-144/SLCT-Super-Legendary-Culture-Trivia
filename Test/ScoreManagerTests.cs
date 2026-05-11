using Logic;
using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace Test
{
    [TestFixture]
    public class ScoreManagerTests
    {
        [Test]
        public void UpdateScore_SimpleStrategy_CorrectAnswer_ShouldIncreaseScore()
        {
            var manager = new ScoreManager("Simple");
            manager.UpdateScore(true, 0);
            Assert.That(manager.TotalScore, Is.GreaterThan(0));
        }

        [Test]
        public void UpdateScore_SimpleStrategy_WrongAnswer_ShouldNotIncreaseScore()
        {
            var manager = new ScoreManager("Simple");
            manager.UpdateScore(false, 0);
            Assert.That(manager.TotalScore, Is.EqualTo(0));
        }

        [Test]
        public void Reset_ShouldSetScoreToZero()
        {
            var manager = new ScoreManager("Simple");
            manager.UpdateScore(true, 0);
            manager.Reset();
            Assert.That(manager.TotalScore, Is.EqualTo(0));
        }

        [Test]
        public void UpdateScore_NegativeStrategy_WrongAnswer_ShouldDecreaseScore()
        {
            var manager = new ScoreManager("Negative");
            manager.UpdateScore(false, 0);
            Assert.That(manager.TotalScore, Is.LessThan(0));
        }

        [Test]
        public void UpdateScore_TimedStrategy_CorrectAnswer_ShouldIncreaseScore()
        {
            var manager = new ScoreManager("Timed");
            manager.UpdateScore(true, 5);
            Assert.That(manager.TotalScore, Is.GreaterThan(0));
        }

        [Test]
        public void Constructor_InvalidStrategy_ShouldThrow()
        {
            Assert.Throws<Exception>(() => new ScoreManager("Inexistenta"));
        }
    }
}
