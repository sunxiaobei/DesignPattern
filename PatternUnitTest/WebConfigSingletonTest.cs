using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SingletonPattern;
namespace PatternUnitTest
{
    [TestClass]
    public class WebConfigSingletonTest
    {
        [TestMethod]
        public void TestGetConfigValue()
        {
            string ApplicationID = WebConfigSingleton.getWebConfigInstance().getConfigValue("ApplicationID");
            Assert.AreEqual(ApplicationID, "1");
        }
    }
}
