using IocDemo.IService;
using System;

namespace IocDemo.Service
{
    public class TestSingleton : ITestSingleton, IDisposable
    {
        public void Dispose()
        {
            Console.WriteLine("TestSingleton调用了Dispose方法");
        }

        public void Show()
        {
            Console.WriteLine("TestSingleton");
        }
    }
}
