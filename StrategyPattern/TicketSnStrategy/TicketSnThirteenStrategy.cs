using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/***********************
 * Function:策略模式具体类TicketSnThirteen，13位准考证生成:年（四位)+月(两位）+日（两位）+考场号（三位）+座号（两位）
 * Author:SunXiaobei
 * CreatedDt：20180607
 * **********************/

namespace StrategyPattern
{
    public class TicketSnThirteenStrategy : ITicketSnStrategy
    {
        public string AutoGenerateTicketSn(string roomNo, string seatNo, DateTime? dateTime = null)
        {
            /// <summary>
            /// 13位准考证生成:年（四位)+月(两位）+日（两位）+考场号（3位）+座号（两位）
            /// </summary>
            /// <param name="roomNo">考场号</param>
            /// <param name="seatNo">座号</param>
            /// <returns></returns>
            if (dateTime == null)
            {
                dateTime = DateTime.Now;
            }
            return Convert.ToDateTime(dateTime).ToString("yyyyMMdd") + roomNo.PadLeft(3, '0') + seatNo.PadLeft(2, '0');
        }        
    }
}
