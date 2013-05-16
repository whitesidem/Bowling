using System.Collections.Generic;
using NUnit.Framework;

namespace Kata
{

    [TestFixture]
    public class TestIt : IScoreBoard
    {
        private int _totalScore;

        [Test]
        public void TotalGutterballGame_NoScore()
        {
            var game = new Game(this);
            for (int i = 0; i < 20; i++)
                game.Bowl(0);

            var assertion = Is.EqualTo(0);
            Assert.That(_totalScore, assertion);
        }

        [Test]
        public void Total1PinGame_ScoreIs20()
        {
            var game = new Game(this);
            for (int i = 0; i < 20; i++)
                game.Bowl(1);

            var assertion = Is.EqualTo(20);
            Assert.That(_totalScore, assertion);
        }

        [Test]
        public void StrikeFollowedBy2Game_ScoreIs14()
        {
            var game = new Game(this);

            game.Bowl(10);
            game.Bowl(2);

            for (int i = 0; i < 17; i++)
                game.Bowl(0);

            var assertion = Is.EqualTo(14);
            Assert.That(_totalScore, assertion);
        }

        [Test]
        public void StrikeFollowedBy2FollowedBy2_ScoreIs16()
        {
            var game = new Game(this);

            game.Bowl(10);
            game.Bowl(2);
            game.Bowl(2);

            for (int i = 0; i < 16; i++)
                game.Bowl(0);

            var assertion = Is.EqualTo(18);
            Assert.That(_totalScore, assertion);
        }

        //[Test]


        //[Test]
        //public void Total9PinFramesGame_ScoreIs20()
        //{
        //    var game = new Game(this);
        //    for (int i = 0; i < 10; i++)
        //    {
        //        game.Bowl(5);
        //        game.Bowl(4);
        //    }

        //    Assert.That(_totalScore, Is.EqualTo(90));
        //}


        public void Score(int currentScore)
        {
            _totalScore = currentScore;
        }
    }

    public class Game
    {
        private readonly IScoreBoard _board;
        private readonly List<int> _scores = new List<int>();
        private int _bowlCount = 0;

        public Game(IScoreBoard board)
        {
            _board = board;
        }

        public void Bowl(int pins)
        {
            _scores.Add(pins);

            _bowlCount += pins == 10 ? 2 : 1;
            if (IsGameOver())
                _board.Score(CalcScore());
        }

        private bool IsGameOver()
        {
            return _bowlCount > 19;
        }

        private int CalcScore()
        {
            var result = 0;
            int rollsToDoubleCount = 0;
            foreach (var score in _scores)
            {
                result += rollsToDoubleCount > 0
                    ? score * 2
                    : score;
                rollsToDoubleCount--;
                if (score == 10) rollsToDoubleCount = 2;
            }
            return result;
        }

        private int CalcScore()
        {
            var result = 0;
            foreach (var score in _scores)
                resykt += IsFrameDoubleCounted(frame)
                              ? score*2
                              : score;
        }

    }

    public interface IScoreBoard
    {
        void Score(int score);
    }
}
