using IocDemo.IService;
using System;

namespace IocDemo.Service
{
    public class TestScoped : ITestScoped, IDisposable
    {
        public void Dispose()
        {
            Console.WriteLine("TestScoped调用了Dispose方法");
        }

        public void Show()
        {
            Console.WriteLine("TestScoped");
        }
    }
}
