using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
/***********************
 * Function:单例模式实现配置文件读取，WebConfigSingleton
 * Author:SunXiaobei
 * CreatedDt：20180609
 * **********************/
namespace SingletonPattern
{
   /// <summary>
   /// 单例模式实现配置文件的修改-- 饿汉式
   /// </summary>
   public class WebConfigSingleton
    {
        //定义私有构造函数
        private WebConfigSingleton() { }
        //定义私有的、静态的webConfigInstance的类对象，全局唯一
        private static WebConfigSingleton webConfiginstance = new WebConfigSingleton();

        //定义公用的静态的全局入口，
        public static WebConfigSingleton getWebConfigInstance()
        {
            return webConfiginstance;
        }
        
        /// <summary>
        /// j加载配置文件 ，查找singleode对应的节点
        /// </summary>
        /// <param name="singleNode"></param>
        /// <returns></returns>
        public XmlNode getXMLConfigRoot(string singleNode)
        {
            //创建Xml对象
            XmlDocument xmlDoc = new XmlDocument();
            string xmlPatch = System.Environment.CurrentDirectory;
            if (!File.Exists(xmlPatch + "\\Web.config"))
            {
                throw new Exception("找不到WebConfig配置文件");
            }
            //加载配置文件
            xmlDoc.Load(xmlPatch + "\\Web.config");
            //选中WebConfig.xml文件的根节点
            XmlNode root = xmlDoc.SelectSingleNode("configuration");
            //定义需要查找的节点
            XmlNode resultRoot = null;
            foreach(XmlNode childNode in root.ChildNodes)
            {
                //遍历查找子节点，若存在则返回该该节点
                if (childNode.Name.Equals(singleNode))
                {
                    resultRoot = root.SelectSingleNode(singleNode);
                }
            }
            return resultRoot;
        }
        /// <summary>
        ///  读取配置属性值（key对应的属性值）
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public string getConfigValue(string key)
        {
            //获取查找节点的父节点
            XmlNode needRoot = getXMLConfigRoot("appSettings");
            string value = "";//存储属性值
            if (needRoot == null)
            {
                throw new Exception("读取配置节点出错");
            }
            //遍历所有节点的属性，并获取属性值
            foreach (XmlNode  chileNode in needRoot.ChildNodes)
            {
                if (chileNode.Attributes["key"].Value==key)
                {
                    value = chileNode.Attributes["value"].Value;
                    break;
                }
            }
            return value;
        }
    }
}
