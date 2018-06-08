using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonPattern
{
    /// <summary>
    /// 单例模式--简单懒汉模式
    /// </summary>
    public class DemoSingletonPattern
    {
        //定义一个静态变量来保存类的实例
        private static DemoSingletonPattern instance;
        //定义私有构造函数，使外界不能创建实例
        private DemoSingletonPattern() { }
        //定义公有方法（公有属性）提供一个全局访问点
        public static DemoSingletonPattern GetDemoInstance()
        {
            //判断是否已经创建实例，如果已经创建则返回已存在的实例，否则创建新实例
            if (instance == null)
            {
                instance = new DemoSingletonPattern();
            }
            return instance;
        }
        //Demo  获取返回DemoSingletonPattern信息
        public string GetMessage()
        {
            return "DemoSingletonPattern";
        }

    }
    /// <summary>
    /// 单例模式-简单懒汉模式优化，支持多线程安全，开销增加，不推荐
    /// </summary>

    public class DemoLockSingletonPattern
    {
        //定义一个静态变量来保存类的实例
        private static DemoLockSingletonPattern instance;
        //定义私有构造函数，使外界不能创建实例
        private DemoLockSingletonPattern() { }
        //定义一个标识确保线程同步
        private static readonly object locker = new object();
        //定义公有方法（公有属性）提供一个全局访问点
        public static DemoLockSingletonPattern GetDemoLockInstance()
        {
            // 当第一个线程运行到这里时，此时会对locker对象 "加锁"，
            // 当第二个线程运行该方法时，首先检测到locker对象为"加锁"状态，该线程就会挂起等待第一个线程解锁
            // lock语句运行完之后（即线程运行完之后）会对该对象"解锁"
            lock (locker)
            {
                // 如果类的实例不存在则创建，否则直接返回
                if (instance == null)
                {
                    instance = new DemoLockSingletonPattern();
                }
            }            
            return instance;
        }
        //Demo  获取返回DemoLockSingletonPattern信息
        public  string GetMessage()
        {
            return "DemoLockSingletonPattern";
        }
    }
    /// <summary>
    /// 单例模式-懒汉模式--双重检验
    /// </summary>
    public class DemoTwoLockSingletonPattern
    {
        //定义一个静态变量来保存类的实例
        private static DemoTwoLockSingletonPattern instance;
        //定义私有构造函数，使外界不能创建实例
        private DemoTwoLockSingletonPattern() { }
        //定义一个标识确保线程同步
        private static readonly object locker = new object();
        //定义公有方法（公有属性）提供一个全局访问点
        public static DemoTwoLockSingletonPattern GetDemoTwoLockInstance()
        {
            // 当第一个线程运行到这里时，此时会对locker对象 "加锁"，
            // 当第二个线程运行该方法时，首先检测到locker对象为"加锁"状态，该线程就会挂起等待第一个线程解锁
            // lock语句运行完之后（即线程运行完之后）会对该对象"解锁"
            // 校验是否已经存在实例
            if (instance == null)
            {
                lock (locker)
                {
                    // 如果类的实例不存在则创建，否则直接返回
                    if (instance == null)
                    {
                        instance = new DemoTwoLockSingletonPattern();
                    }
                }
            }
            return instance;
        }

        //Demo  获取返回DemoTwoLockSingletonPattern信息
        public  string GetMessage()
        {
            return "DemoTwoLockSingletonPattern";
        }
    }
    /// <summary>
    /// 静态内部类单例模式，线程安全
    /// </summary>
    public class DemoInnerSingletonPattern
    {

        //内部类InnerSingletonPatternHandler只有在GetInnerSingletonPatternInstance()方法第一次调用的时候才会被加载（实现了延迟加载效果），
        //而且其加载过程是线程安全的（实现线程安全）。内部类加载的时候只实例化了一次instance
        private static class InnerSingletonPatternHandler
        {
            /// <summary>
            /// 当一个类有静态构造函数时，它的静态成员变量不会被beforefieldinit修饰
            /// 就会确保在被引用的时候才会实例化，而不是程序启动的时候实例化
            /// </summary>
            static InnerSingletonPatternHandler() { }

            internal static DemoInnerSingletonPattern instance = new DemoInnerSingletonPattern();
        }
        //定义私有构造函数，使外界不能创建实例
        private DemoInnerSingletonPattern() { }

        public static DemoInnerSingletonPattern GetInnerSingletonPatternInstance()
        {
            return InnerSingletonPatternHandler.instance;
        }
        //Demo  获取返回DemoInnerSingletonPattern信息
        public string GetMessage()
        {
            return "DemoInnerSingletonPattern";
        }
    }

    /// <summary>
    /// 单例模式-饿汉模式
    /// </summary>
    public class DemoHungrySingletonPattern
    {
        ////定义一个静态变量来保存类的实例,c
        private static DemoHungrySingletonPattern instance = new DemoHungrySingletonPattern();
        //定义私有构造函数，使外界不能创建实例
        private DemoHungrySingletonPattern() { }

        public static DemoHungrySingletonPattern GetDemoHungrySingletonInstance()
        {
            return instance;
        }

        //Demo  获取返回DemoHungrySingletonPattern信息
        public string GetMessage()
        {
            return "DemoHungrySingletonPattern";
        }
    }


}
