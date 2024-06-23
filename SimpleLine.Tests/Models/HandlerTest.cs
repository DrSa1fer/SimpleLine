using SimpleLineLibrary.Models;

namespace SimpleLineLibrary.Tests.Models
{
    [TestClass]
    public class HandlerTest
    {
        [TestMethod]
        public void Equals_Test_Key()
        {
            var ps1 = Array.Empty<Parameter>();
            var ps2 = Array.Empty<Parameter>();

            var h1 = MakeTestHandler(ps1);
            var h2 = MakeTestHandler(ps2);

            var res = h1.Equals(h2);

            Assert.IsTrue(res);
        }


        [TestMethod]
        public void Equals_Test_Both_0_Parameters()
        {
            var ps1 = Array.Empty<Parameter>();
            var ps2 = Array.Empty<Parameter>();

            var h1 = MakeTestHandler(ps1);
            var h2 = MakeTestHandler(ps2);

            var res = h1.Equals(h2);

            Assert.IsTrue(res);
        }

        [TestMethod]
        public void Equals_Test_Single_1_Parameters_1()
        {
            var ps1 = new Parameter[]
            {
                MakeTestParameter("--a", "-a", 0)
            };
            var ps2 = Array.Empty<Parameter>();

            var h1 = MakeTestHandler(ps1);
            var h2 = MakeTestHandler(ps2);

            var res = h1.Equals(h2);

            Assert.IsFalse(res);
        }

        [TestMethod]
        public void Equals_Test_Single_1_Parameters_2()
        {
            var ps1 = Array.Empty<Parameter>();
            var ps2 = new Parameter[]
            {
                MakeTestParameter("--a", "-a", 0)
            };

            var h1 = MakeTestHandler(ps1);
            var h2 = MakeTestHandler(ps2);

            var res = h1.Equals(h2);

            Assert.IsFalse(res);
        }

        [TestMethod]
        public void Equals_Test_Both_2_Parameters_1()
        {
            var ps1 = new Parameter[]
            {
                MakeTestParameter("--a", "-a", 0),
                MakeTestParameter("--b", "-b", 1),
            };

            var ps2 = new Parameter[]
            {
                MakeTestParameter("--a", "-a", 0),
                MakeTestParameter("--c", "-c", 1),
            };

            var h1 = MakeTestHandler(ps1);
            var h2 = MakeTestHandler(ps2);

            var res = h1.Equals(h2);

            Assert.IsTrue(res);
        }



        private static Handler MakeTestHandler(Parameter[] ps)
        {
            return new Handler((x) => null, ps);
        }

        private static Parameter MakeTestParameter(string lk, string sk, int i)
        {
            return new Parameter("x", "x", lk, sk, i, true, typeof(string), null);
        }
    }
}
