using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/***********************
 * Function:策略模式接口ITicketSn，准考证生成
 * Author:SunXiaobei
 * CreatedDt：20180607
 * **********************/
namespace StrategyPattern
{
    public interface ITicketSnStrategy
    {
        /// <summary>
        /// 自动生成准考证号
        /// </summary>
        /// <param name="roomNo">考场号</param>
        /// <param name="seatNo">座号</param>
        /// <returns></returns>

       string AutoGenerateTicketSn(string roomNo,string seatNo,DateTime? dateTime=null);

    }
}
