using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/***********************
 * Function:单例模式实现配置文件读取，WebConfigSingleton
 * Author:SunXiaobei
 * CreatedDt：20180609
 * **********************/
namespace SingletonPattern
{
   /// <summary>
   /// 单例模式实现配置文件的修改
   /// </summary>
   public class WebConfigSingleton
    {
        //定义私有构造函数
        private WebConfigSingleton() { }
        //定义私有的、静态的webConfigInstance的类对象，全局唯一
        private static WebConfigSingleton webConfiginstance = null;

        //定义公用的静态的全局入口，
        //public static WebConfigSingleton getWebConfigInstance()
        //{

        //}

    }
}
