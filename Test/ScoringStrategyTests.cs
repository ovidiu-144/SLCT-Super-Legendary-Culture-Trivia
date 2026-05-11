using Logic;
using System;
using System.Collections.Generic;
using System.Text;

namespace Test
{
    [TestFixture]
    public class ScoringStrategyTests
    {
        [Test]
        public void SimpleScoring_CorrectAnswer_ShouldReturnPositive()
        {
            var strategy = new SimpleScoring();
            int score = strategy.CalculateScore(true, 0);
            Assert.That(score, Is.GreaterThan(0));
        }

        [Test]
        public void NegativeScoring_WrongAnswer_ShouldReturnNegative()
        {
            var strategy = new NegativeScoring();
            int score = strategy.CalculateScore(false, 0);
            Assert.That(score, Is.LessThan(0));
        }

        [Test]
        public void TimedScoring_FasterAnswer_ShouldScoreHigher()
        {
            var strategy = new TimedScoring();
            int fastScore = strategy.CalculateScore(true, 1);
            int middleScore = strategy.CalculateScore(true, 6);
            int slowScore = strategy.CalculateScore(true, 11);

            Assert.That(fastScore, Is.GreaterThan(middleScore));
            Assert.That(fastScore, Is.GreaterThan(slowScore));
            Assert.That(middleScore, Is.GreaterThan(slowScore));
        }

        [Test]
        public void TimedScoring_SlowerAnswer_ShouldScoreLower()
        {
            var strategy = new TimedScoring();
            int score = strategy.CalculateScore(true, 30);

            Assert.That(score, Is.EqualTo(1));
        }
    }
}
