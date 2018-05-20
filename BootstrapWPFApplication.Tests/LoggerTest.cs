using BootstrapWPFApplication.Infrastructure.Utility.NLogger;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace BootstrapWPFApplication.Tests
{
    [TestClass()]
    public class LoggerTest
    {

        [TestMethod()]
        [ExpectedException(typeof(DirectoryNotFoundException))]
        public void ExceptionLogTest()
        {
            Directory.Delete(@"./logs", true);
            try
            {
                string str = "Mohamed";
                int num = int.Parse(str);
            }
            catch (Exception ex)
            {
                AppLogger.Instance.Log(ex);
            }
            var isExist = File.Exists(@"./logs/Error.log");
            Assert.IsTrue(isExist);
        }

        [TestMethod()]
        [ExpectedException(typeof(DirectoryNotFoundException))]
        public void ExceptionInfoLogTest()
        {
            Directory.Delete(@"./logs", true);
            AppLogger.Instance.Log(Core.Utility.LogCategory.Info, "ExceptionInfoLogTest Running");
            var isExist = File.Exists(@"./logs/Info.log");
            Assert.IsTrue(isExist);
        }
    }
}
