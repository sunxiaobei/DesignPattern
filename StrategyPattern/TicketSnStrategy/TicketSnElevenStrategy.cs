﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/***********************
 * Function:策略模式具体类TicketSnEleven，11位准考证生成:年（后两位)+月(两位）+日（两位）+考场号（3位）+座号（两位）
 * Author:SunXiaobei
 * CreatedDt：20180607
 * **********************/
namespace StrategyPattern
{
    public class TicketSnElevenStrategy : ITicketSnStrategy
    {
        /// <summary>
        /// 11位准考证生成:年（后两位)+月(两位）+日（两位）+考场号（3位）+座号（两位）
        /// </summary>
        /// <param name="roomNo">考场号</param>
        /// <param name="seatNo">座号</param>
        /// <returns></returns>
        public string AutoGenerateTicketSn(string roomNo, string seatNo,DateTime? dateTime = null)
        {
            if (dateTime == null)
            {
                dateTime = DateTime.Now;
            }
            return Convert.ToDateTime(dateTime).ToString("yyMMdd") + roomNo.PadLeft(3, '0') + seatNo.PadLeft(2, '0');
        }        
    }
}
