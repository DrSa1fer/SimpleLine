using SimpleLineLibrary.Services.Execution;
using SimpleLineLibrary.Services.Execution.Converting;

namespace SimpleLineLibrary.Tests.Services.Invokation.Execution
{
    [TestClass]
    public class HandlerExecutorTest
    {
        private readonly Converter _converter;
        private readonly HandlerExecutor _executor;

        public HandlerExecutorTest()
        {
            _converter = new();



            _executor = new(_converter);
        }

        [TestMethod]
        public void HandlerExecutor_Execute()
        {
        }

        [TestMethod]
        public void HandlerExecutor_Execute_1()
        {
        }

        [TestMethod]
        public void HandlerExecutor_Execute_2()
        {
        }
    }
}
