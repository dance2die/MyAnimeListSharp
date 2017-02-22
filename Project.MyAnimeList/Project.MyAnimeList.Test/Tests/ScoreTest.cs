using System.Collections.Generic;
using MyAnimeListSharp.Enums;
using Xunit;

namespace Project.MyAnimeList.Test.Tests
{
    public class ScoreTest
    {
        [Theory]
        [ClassData(typeof(ScoreTestData))]
        public void TestScoreValues(Score score, int expected)
        {
            Assert.Equal(expected, (int) score);
        }
    }

    public class ScoreTestData : BaseTestData
    {
        public override List<object[]> Data { get; set; } = new List<object[]>
        {
            new object[] {Score.Appalling, 1},
            new object[] {Score.Horrible, 2},
            new object[] {Score.VeryBad, 3},
            new object[] {Score.Bad, 4},
            new object[] {Score.Average, 5},
            new object[] {Score.Fine, 6},
            new object[] {Score.Good, 7},
            new object[] {Score.VeryGood, 8},
            new object[] {Score.Great, 9},
            new object[] {Score.MasterPiece, 10},
        };
    }
}
