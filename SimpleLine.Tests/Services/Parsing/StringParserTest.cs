using SimpleLineLibrary.Services.Parsing.Tokens;

namespace SimpleLineLibrary.Tests.Services.Parsing
{
    [TestClass]
    internal class StringParserTest
    {

        [TestMethod]
        public void DoubleQuotesRegionTest2()
        {
            var t = new TokenParser();

            var res = t.Parse("\"   - _ - _ - _ - _ - _ |\"");

            Console.WriteLine(string.Join(" ", res));
            
            Assert.IsTrue(res is ["   - _ - _ - _ - _ - _ |"]);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void DoubleQuotesRegionTest3()
        {
            _ = new TokenParser().Parse("dddsd \" ppp!");
        }

        [TestMethod]
        public void QuotesRegionTest1()
        {
            var t = new TokenParser();

            var res = t.Parse("' |_ _ _ _ _ | '");

            Console.WriteLine(string.Join(" ", res));

            Assert.IsTrue(res is [" |_ _ _ _ _ | "]);
        }

        [TestMethod]
        public void BracketsRegionTest1()
        {
            var t = new TokenParser();

            var res = t.Parse(" \\[ [1;_2;_3]");

            Console.WriteLine(string.Join(" ", res));

            Assert.IsTrue(res is ["[", "1;_2;_3"]);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void BracketsRegionTest2()
        {
            _ = new TokenParser().Parse(" \\[ [1;_2 ] ;_3]");
        }

        [TestMethod]
        public void InputTest1()
        {
            var t = new TokenParser();

            var res = t.Parse("simple-line math sum --left = 100 --right = 5");

            Console.WriteLine(string.Join(" ", res));

            Assert.IsTrue(res is ["simple-line", "math", "sum", "--left", "=", "100", "--right", "=", "5"]);
        }
        [TestMethod]
        public void InputTest2()
        {
            var t = new TokenParser();

            var res = t.Parse("simple-line math \"s u m\" 100 5");

            Console.WriteLine(string.Join(" ", res));

            Assert.IsTrue(res is ["simple-line", "math", "s u m", "100", "5"]);
        }

        [TestMethod]
        public void InputTest3()
        {
            var t = new TokenParser();

            var res = t.Parse("edit_profile --name \"Jane Rotcher\" --email jane@example.com");

            Console.WriteLine(string.Join(" ", res));
            Assert.IsTrue(res is ["edit_profile", "--name", "Jane Rotcher", "--email", "jane@example.com"]);
        }

        [TestMethod]
        public void InputTest4()
        {
            var t = new TokenParser();
            
            var res = t.Parse("search --keyword \"apple\"");

            Console.WriteLine(string.Join(" ", res));

            Assert.IsTrue(res is ["search", "--keyword", "apple"]);
        }

        [TestMethod]
        public void EmptyTest()
        {
            var t = new TokenParser();

            var res = t.Parse("");

            Console.WriteLine(string.Join(" ", res));

            Assert.IsTrue(res is []);
        }

        [TestMethod]
        public void Test()
        {
            var t = new TokenParser();

            var res = t.Parse("\"My name 'artem', hi!\"");

            Console.WriteLine(string.Join(" ", res));

            Assert.IsTrue(res is ["My name 'artem', hi!"]);
        }
    }
}