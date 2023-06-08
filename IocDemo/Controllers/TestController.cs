using IocDemo.IService;
using IocDemo.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace IocDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [HttpGet]
        [Route("/Get")]
        public string Get([FromServices] ITestScoped testScoped, [FromServices] ITestScoped testScoped1,
                          [FromServices] ITestSingleton testSingleton, [FromServices] ITestSingleton testSingleton1,
                          [FromServices] ITestTransient testTransient, [FromServices] ITestTransient testTransient1)
        {
            //获取请求作用域(请求容器)
            var requestServices = HttpContext.RequestServices;
            //在请求作用域下创建子作用域
            using (IServiceScope scope = requestServices.CreateScope())
            {
                //在子作用域中通过其容器获取注入的不同生命周期对象
                ITestSingleton testSingleton11 = scope.ServiceProvider.GetService<ITestSingleton>();
                ITestScoped testScoped11 = scope.ServiceProvider.GetService<ITestScoped>();
                ITestTransient testTransient11 = scope.ServiceProvider.GetService<ITestTransient>();


                ITestSingleton testSingleton12 = scope.ServiceProvider.GetService<ITestSingleton>();
                ITestScoped testScoped12 = scope.ServiceProvider.GetService<ITestScoped>();
                ITestTransient testTransient12 = scope.ServiceProvider.GetService<ITestTransient>();
                Console.WriteLine("================Singleton=============");
                Console.WriteLine($"请求作用域的ITestSingleton对象:{testSingleton.GetHashCode()}");
                Console.WriteLine($"请求作用域的ITestSingleton1对象:{testSingleton1.GetHashCode()}");
                Console.WriteLine($"请求作用域下子作用域的ITestSingleton11对象:{testSingleton11.GetHashCode()}");
                Console.WriteLine($"请求作用域下子作用域的ITestSingleton12对象:{testSingleton12.GetHashCode()}");
                Console.WriteLine("================Scoped=============");
                Console.WriteLine($"请求作用域的ITestScoped对象:{testScoped.GetHashCode()}");
                Console.WriteLine($"请求作用域的ITestScoped1对象:{testScoped1.GetHashCode()}");
                Console.WriteLine($"请求作用域下子作用域的ITestScoped11对象:{testScoped11.GetHashCode()}");
                Console.WriteLine($"请求作用域下子作用域的ITestScoped12对象:{testScoped12.GetHashCode()}");
                Console.WriteLine("================Transient=============");
                Console.WriteLine($"请求作用域的ITestTransient对象:{testTransient.GetHashCode()}");
                Console.WriteLine($"请求作用域的ITestTransient1对象:{testTransient1.GetHashCode()}");
                Console.WriteLine($"请求作用域下子作用域的ITestTransient11对象:{testTransient11.GetHashCode()}");
                Console.WriteLine($"请求作用域下子作用域的ITestTransient12对象:{testTransient12.GetHashCode()}");
            }

            return "TestController";
        }
    }
}
