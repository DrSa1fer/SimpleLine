using SimpleLineLibrary.Models;
using SimpleLineLibrary.Services.Invokation.Finding;

namespace SimpleLineLibrary.Tests.Services.Invokation.Finding
{
    [TestClass]
    public class CommandFinderTest
    {
        private readonly CommandFinder _finder;
        private readonly List<Command> _commands;


        public CommandFinderTest()
        {
            _finder = new("root");

            var hello = new Command("hello", "", "", true);
            var root = new Command("@root", "", "", false);
            var test = new Command("test", "", "", false);
            var meow = new Command("meow", "", "", false);      
            

            test.RegisterSubcommand(meow);

            _commands = new()
            {
                root,
                test,
                meow,
                hello
            };
        }

        [TestMethod]
        public void ZeroArgs()
        {
            var q = new Queue<string>();

            var res = _finder.Find(q, _commands);

            Assert.AreEqual("root", res?.Name);
        }

        [TestMethod]
        public void OneArgsTest()
        {
            var q = new Queue<string>();

            q.Enqueue("hello");

            var res = _finder.Find(q, _commands);

            Assert.AreEqual("hello", res?.Name);
        }

        [TestMethod]
        public void TwoArgsTest()
        {
            var q = new Queue<string>();

            q.Enqueue("test");
            q.Enqueue("meow");

            var res = _finder.Find(q, _commands);

            Assert.AreEqual("meow", res?.Name);
        }

        [TestMethod]
        public void ThreeArgsTest()
        {
            var q = new Queue<string>();

            q.Enqueue("hello");
            q.Enqueue("world");
            q.Enqueue("meow");

            var res = _finder.Find(q, _commands);

            Assert.AreEqual("hello", res?.Name);
        }
    }
}
