using SimpleLineLibrary.Services.Converting;
using SimpleLineLibrary.Services.Execution;

namespace SimpleLineLibrary.Tests.Services.Invokation.Execution
{
    [TestClass]
    public class HandlerExecutorTest
    {
        private readonly ConverterProvider _converter;
        private readonly HandlerExecutor _executor;

        public HandlerExecutorTest()
        {
            _converter = new();

            _converter.RegisterConverter(new TypeConverter<string>(x => x));

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
