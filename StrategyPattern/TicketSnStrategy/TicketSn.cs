using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/***********************
 * Function:客户类TicketSn
 * Author:SunXiaobei
 * CreatedDt：20180607
 * **********************/
namespace StrategyPattern
{
    public class TicketSn
    {
        // 准考证策略上下文，为客户选择合适的策略
        private ITicketSnStrategy ticketSn = null;
        //构造函数
        public TicketSn(ITicketSnStrategy ticketSn)
        {
            this.ticketSn = ticketSn;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="roomNo"></param>
        /// <param name="seatNo"></param>
        /// <param name="type">类型（11：11位，13:13位）</param>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public string GetTicketSn(string roomNo, string seatNo,int type = 11, DateTime? dateTime = null)
        {
            //默认策略11位
            if (this.ticketSn==null)
            {
                this.ticketSn = new TicketSnElevenStrategy();
            }
            //如果type=13  十三位准考证；否则 11位准考证
            if (type==13)
            {
                this.ticketSn = new TicketSnThirteenStrategy();
            }
            else
            {
                this.ticketSn = new TicketSnElevenStrategy();
            }
            return this.ticketSn.AutoGenerateTicketSn(roomNo, seatNo, dateTime);
        }
        /// <summary>
        /// 切换模式
        /// </summary>
        /// <param name="ticketSn"></param>
        public void changeTicketSn(ITicketSnStrategy ticketSn)
        {
            this.ticketSn = ticketSn;
        }
    }
}
