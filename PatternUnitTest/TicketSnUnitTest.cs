using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StrategyPattern;
namespace PatternUnitTest
{
    [TestClass]
    public class TicketSnUnitTest
    {
        [ClassInitialize]
        public static void Init(TestContext testContext)
        {

        }

        string seatNo = "5", roomNo = "10";
        DateTime datetime = Convert.ToDateTime("2018-06-03");
        /// <summary>
        /// 测试11位准考证
        /// </summary>
        [TestMethod]
        public void TestGetTicketSn()
        {
            //11位
            TicketSn ticket = new TicketSn(new TicketSnEleven());
            string ticketSn11 =ticket.GetTicketSn(roomNo, seatNo,11, datetime);
            Assert.AreEqual(ticketSn11, "18060301005");
        }
        /// <summary>
        ///  测试13位准考证
        ///  
        /// </summary>
        [TestMethod]
        public void TestGet13TicketSn()
        {
            TicketSn ticket = new TicketSn(null);
            //13位
            ticket.changeTicketSn(new TicketSnThirteen());
            string ticketSn13 = ticket.GetTicketSn(roomNo, seatNo, 13, datetime);
            Assert.AreEqual(ticketSn13, "2018060301005");
        }
    }
}
