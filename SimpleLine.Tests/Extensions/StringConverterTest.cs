// using SimpleLineLibrary.Extensions;

// namespace SimpleLineLibrary.Tests.Extensions
// {
//     [TestClass]
//     public class StringConverterTest
//     {
//         [TestMethod]
//         public void ConvertToInt()
//         {
//             Assert.AreEqual(10, "10".ConvertTo<int>());
//             Assert.ThrowsException<Exception>(
//                 () => "abc".ConvertTo<int>());
//         }

//         [TestMethod]
//         public void ConvertToFloat()
//         {
//             Assert.AreEqual(1.5f, "1,5".ConvertTo<float>());
//             Assert.ThrowsException<Exception>(
//                 () => "abc".ConvertTo<float>());
//         }


//         [TestMethod]
//         public void ConvertToBool()
//         {
//             Assert.AreEqual(true, "true".ConvertTo<bool>());
//         }

//         [TestMethod]
//         public void ConvertToString()
//         {
//             Assert.AreEqual("text", "text".ConvertTo<string>());
//         }

//         [TestMethod]
//         public void ConvertToChar()
//         {
//             Assert.AreEqual('t', "t".ConvertTo<char>());
//             Assert.ThrowsException<Exception>(
//                 () => "123abc".ConvertTo<char>());
//         }

//         [TestMethod]
//         public void ConvertToDateTime()
//         {
//             Assert.AreEqual(new DateTime(2014, 10, 1), 
//                 "1.10.2014".ConvertTo<DateTime>());
//             Assert.ThrowsException<Exception>(
//                 () => "-1.00.2001".ConvertTo<DateTime>());
//         }

//         [TestMethod]
//         public void ConvertToFileInfo()
//         {
//             Assert.AreEqual(
//                 new FileInfo("/home/danil/Projects/SimpleLine/.git/config").CreationTime,
//                 "/home/danil/Projects/SimpleLine/.git/config".ConvertTo<FileInfo>().CreationTime);
//             Assert.ThrowsException<Exception>(
//                 () => "home/danil/Projects/notfile".ConvertTo<FileInfo>());
//         }

//         [TestMethod]
//         public void ConvertToDirectoryInfo()
//         {
//             var path = Environment
//                     .GetFolderPath(Environment.SpecialFolder.MyDocuments);                    

//             Assert.AreEqual(new DirectoryInfo(path).FullName, 
//                 path.ConvertTo<DirectoryInfo>().FullName);
//             Assert.ThrowsException<Exception>(
//                 () => "/random/path/for/throw/exception".ConvertTo<DirectoryInfo>());
//         }
//     }
// }