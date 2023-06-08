using IocDemo.IService;
using System;

namespace IocDemo.Service
{
    public class TestTransient : ITestTransient, IDisposable
    {
        public void Dispose()
        {
            Console.WriteLine("TestTransient调用了Dispose方法");
        }

        public void Show()
        {
            Console.WriteLine("TestTransient");
        }
    }
}
