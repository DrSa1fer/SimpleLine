using SimpleLineLibrary.Services.Parsing.Arguments;
using SimpleLineLibrary.Services.Parsing.Arguments.Exceptions;

namespace SimpleLineLibrary.Tests.Services.Parsing
{
    [TestClass]
    public class ArgumentParserTest
    {
        private readonly ArgumentParser _parser;

        public ArgumentParserTest()
        {
            _parser = new ArgumentParser();
        }

        [TestMethod]
        public void Test_Parse_0()
        {
            var tokens = new string[]
            {
            };

            var q = new Queue<string>(tokens);

            var res = _parser.Parse(q);

            Assert.AreEqual(0, res.Count);
        }

        [TestMethod]
        public void Test_Parse_1()
        {
            var tokens = new string[]
            {
                "hello"
            };

            var q = new Queue<string>(tokens);

            var res = _parser.Parse(q);

            Assert.IsTrue(res.Count == 1 
                && res[0].HasKey()  == false
                && res[0].Value     == "hello"
            );
        }

        [TestMethod]
        public void Test_Parse_2()
        {
            var tokens = new string[]
            {
                "--a", "=", "100",
                "a"
            };

            var q = new Queue<string>(tokens);

            var res = _parser.Parse(q);

            Assert.IsTrue(res.Count == 2
                && res[0].Key       == "--a"
                && res[0].Value     == "100"
                && res[1].HasKey()  == false 
                && res[1].Value     == "a"
                );
        }

        [TestMethod]
        [ExpectedException(typeof(KeyAwaitsValueException))]
        public void Test_Parse_3()
        {
            var tokens = new string[]
            {
                "--a", "="
            };

            var q = new Queue<string>(tokens);
            var res = _parser.Parse(q); 
        }
    }
}
