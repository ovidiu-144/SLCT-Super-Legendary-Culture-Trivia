// Proiect:      SLCT – Super Legendary Culture Trivia
// Fișier:       ScoringStrategyTests.cs
// Autor:        Turnea David-Catalin
// Echipă:       Alesia, Ioana, Ovidiu, Catalin
// Descriere:    Fisierul contine clasa de testare pentru ScoringStrategy,
//               verificând funcționalitatea principalelor metode
//               și comportamentul acestora în diferite scenarii


using Logic;
using System;
using System.Collections.Generic;
using System.Text;

namespace Test
{
    /// <summary>
    /// Clasa pentru testarea ScoringStrategy
    /// </summary>
    [TestFixture]
    public class ScoringStrategyTests
    {
        /// <summary>
        /// Verifica daca SimpleScoring returneaza un scor pozitiv pentru un raspuns corect
        /// </summary>
        [Test]
        public void SimpleScoring_CorrectAnswer_ShouldReturnPositive()
        {
            var strategy = new SimpleScoring();
            int score = strategy.CalculateScore(true);
            Assert.That(score, Is.GreaterThan(0));
        }
        
        /// <summary>
        /// Verifica daca NegativeScoring returneaza un scor negativ pentru un raspuns gresit
        /// </summary>
        [Test]
        public void NegativeScoring_WrongAnswer_ShouldReturnNegative()
        {
            var strategy = new NegativeScoring();
            int score = strategy.CalculateScore(false);
            Assert.That(score, Is.LessThan(0));
        }
    }
}
