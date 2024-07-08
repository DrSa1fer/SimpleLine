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

            var root = new Command("root");
            var @new = new Command("new");
            var @msg = new Command("msg");

            root._children.Add(@new.Uid, @new);
            @new._children.Add(@msg.Uid, @msg);

            var res = _finder.Find(q, root);

            Assert.AreEqual(@msg, res);
        }
    }
}