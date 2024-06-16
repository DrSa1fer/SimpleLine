using SimpleLineLibrary.Setup;
using System.Reflection;

namespace SimpleLineLibrary.Tests.Setup
{
    [TestClass]
    public class CommandProviderTest
    {
        private readonly CommandProvider _provider;

        public CommandProviderTest()
        {
            _provider = new CommandProvider(new HashSet<string>() { "root" });
        }

        [TestMethod]
        public void Test_1()
        {
            var res = _provider.FindCommands
            (
                typeof(MathCommand).GetTypeInfo(),
                typeof(ReadCommand).GetTypeInfo(),
                typeof(WriteCommand).GetTypeInfo(),
                typeof(RootCommand).GetTypeInfo(),
                typeof(List<int>).GetTypeInfo(),
                typeof(string).GetTypeInfo()
            );

            Assert.AreEqual(4, res.Count);
        }

        [TestMethod]
        public void Test_2()
        {
            var res = _provider.FindCommands
            (
                typeof(MathCommand).GetTypeInfo(),
                typeof(ReadCommand).GetTypeInfo(),
                typeof(RootCommand).GetTypeInfo(),
                typeof(List<int>).GetTypeInfo(),
                typeof(string).GetTypeInfo()
            );

            var c = res.Single(x => x.Is("@root")).Handlers.Single();

            var ret = (int)c.Invoke(new object[] { 9, 19 })!;

            Assert.AreEqual(28, ret);
        }
    }



    [Command("math")]
    public class MathCommand
    {

    }

    [Command("read")]
    public class ReadCommand
    {

    }

    [Command("write")]
    public class WriteCommand
    {

    }

    [Command("@root")]
    public class RootCommand
    {
        [Handler]
        public int Main(
            [CustomKeys("-l",  "--left")] int l,
            [CustomKeys("-r", "--right")] int r)
        {
            return l + r;
        }
    }
}
