using System;
using System.Collections;
using System.Linq;
using System.Text;
using NUnit.Framework;
using NUnit.Framework.Interfaces;

namespace Open_Lab_05._02
{
    public class Tests
    {

        private StringTools tools;
        private bool shouldStop;

        private const int RandMarksMin = 1;
        private const int RandMarksMax = 10;
        private const int RandWordSizeMin = 2;
        private const int RandWordSizeMax = 10;
        private const int RandWordCountMin = 1;
        private const int RandWordCountMax = 9;
        private const int RandSeed = 502502502;
        private const int RandTestCasesCount = 95;
        private static readonly char[] RandMarks = { '.', '!', '?' };

        [OneTimeSetUp]
        public void Init()
        {
            tools = new StringTools();
            shouldStop = false;
        }

        [TearDown]
        public void TearDown()
        {
            var outcome = TestContext.CurrentContext.Result.Outcome;

            if (outcome == ResultState.Failure || outcome == ResultState.Error)
                shouldStop = true;
        }

        [TestCase("What went wrong?????????", "What went wrong?")]
        [TestCase("Oh my goodness!!!", "Oh my goodness!")]
        [TestCase("I just!!! can!!! not!!! believe!!! it!!!", "I just!!! can!!! not!!! believe!!! it!")]
        [TestCase("Oh my goodness!", "Oh my goodness!")]
        [TestCase("I just cannot believe it..", "I just cannot believe it..")]
        public void NoYellingTest(string str, string expected) =>
            Assert.That(tools.NoYelling(str), Is.EqualTo(expected));

        [TestCaseSource(nameof(GetRandom))]
        public void NoYellingTestRandom(string str, string expected)
        {
            if (shouldStop)
                Assert.Ignore("Previous test failed!");

            NoYellingTest(str, expected);
        }

        private static IEnumerable GetRandom()
        {
            var rand = new Random(RandSeed);

            for (var i = 0; i < RandTestCasesCount; i++)
            {
                var words = new char[rand.Next(RandWordCountMin, RandWordCountMax + 1)][];
                var mark = RandMarks[rand.Next(RandMarks.Length)];
                var marksCount = new int[words.Length];

                for (var j = 0; j < words.Length; j++)
                {
                    words[j] = new char[rand.Next(RandWordSizeMin, RandWordSizeMax + 1)];
                    marksCount[j] = mark != '.' || j + 1 == words.Length ? rand.Next(RandMarksMin, RandMarksMax) : 0;

                    for (var k = 0; k < words[j].Length; k++)
                        words[j][k] = (char) rand.Next('a', 'z' + 1);
                }

                var sb = new StringBuilder(words.Select(word => word.Length).Sum() + words.Length - 1 + marksCount.Sum());

                for (var j = 0; j < words.Length; j++)
                {
                    foreach (var ch in words[j])
                        sb.Append(ch);

                    for (var k = 0; k < marksCount[j]; k++)
                        sb.Append(mark);

                    if (j + 1 < words.Length)
                        sb.Append(' ');
                }

                var str = sb.ToString();
                yield return new TestCaseData(str, mark == '.' ? str : new string(str[..^(marksCount[^1] - 1)]));
            }
        }

    }
}
