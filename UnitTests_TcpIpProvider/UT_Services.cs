using Microsoft.VisualStudio.TestTools.UnitTesting;
using ServerServices;

namespace UnitTests_TcpIpProvider
{
    [TestClass]
    public class UT_Services
    {
        [TestMethod]
        public void TranslitToEngFromRus_SendFromServerToClient_Success()
        {
            var rusMessage = "ананас";
            var engMessage = "ananas";

            var translated = MessagesEncoder.TranslitToEng(rusMessage);

            if (engMessage.Equals(translated))
                Assert.IsTrue(true);
            else
                Assert.IsTrue(false);
        }

        [TestMethod]
        public void TranslitToRusFromEng_SendFromServerToClient_Success()
        {
            var rusMessage = "ананас";
            var engMessage = "ananas";

            var translated = MessagesEncoder.TranslitToRus(engMessage);

            if (rusMessage.Equals(translated))
                Assert.IsTrue(true);
            else
                Assert.IsTrue(false);
        }
    }
}
