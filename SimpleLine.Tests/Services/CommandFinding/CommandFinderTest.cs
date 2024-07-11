using SimpleLineLibrary.Models;
using SimpleLineLibrary.Services.CommandFinding;

namespace SimpleLineLibrary.Tests.Services.CommandFinding
{
    [TestClass]
    public class CommandFinderTest
    {
        private readonly CommandFinder _finder = new();

        [TestMethod]
        public void Test_1()
        {
            var q = new Queue<string>();

            q.Enqueue("new");
            q.Enqueue("msg");

            var root = new CommandNode("root");
            var @new = new CommandNode("new");
            var @msg = new CommandNode("msg");

            msg.Command = new Command("a");

            root.Children.Add(@new.Uid, @new);
            @new.Children.Add(@msg.Uid, @msg);

            var res = _finder.Find(q, root);

            Assert.AreEqual(@msg.Command, res);
        }
    }
}