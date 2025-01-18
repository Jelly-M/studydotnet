using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DF_Thread
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //1
            //执行场景时异步方法有返回值，需要等待返回值，异步方法返回值时用EndInvoke获取
            //回调函数需要一个外部传入参数可以通过arr.AsyncState获取参数,不需要异步方法返回值的结果
            //执行顺序是
            //先执行异步方法
            //等待执行完成打印出sum值
            //然后在执行回调函数
            //Console.WriteLine($"1主线程：threadID=[{Thread.CurrentThread.ManagedThreadId}]");
            //Func<int, int, int> func = (x, y) =>
            //{
            //    //Thread.Sleep(2000);
            //    Console.WriteLine("开始执行委托方法");
            //    Console.WriteLine($"异步方法线程：{DateTime.Now.ToString()},threadID=[{Thread.CurrentThread.ManagedThreadId}]");
            //    return x + y;
            //};
            //AsyncCallback asyncCallback = arr =>
            //{
            //    //Thread.Sleep(1000);
            //    Console.WriteLine($"传入的参数【{arr.AsyncState}】");
            //    Console.WriteLine($"回调函数线程：threadID=[{Thread.CurrentThread.ManagedThreadId}]");

            //};
            //IAsyncResult asyncResult = func.BeginInvoke(2, 3, asyncCallback, "这个参数时给arr的对应参数，回调函数需要用到的参数");

            //Console.WriteLine($"2主线程：threadID=[{Thread.CurrentThread.ManagedThreadId}]");
            ////asyncResult.AsyncWaitHandle.WaitOne();//异步等待，用来让主线程等待异步线程执行完，确保callback能狗执行完

            //while (!asyncResult.IsCompleted)
            //{
            //    Console.WriteLine($"3主线程： threadID=[{Thread.CurrentThread.ManagedThreadId}]");
            //    Console.WriteLine("还没执行完异步方法");
            //}
            //if (asyncResult.IsCompleted)
            //{
            //    Console.WriteLine($"4主线程： threadID=[{Thread.CurrentThread.ManagedThreadId}]");
            //    int i = func.EndInvoke(asyncResult);//拿到异步方法调用的结果
            //    Console.WriteLine($"5主线程： threadID=[{Thread.CurrentThread.ManagedThreadId}]");
            //    Console.WriteLine($"异步调用函数的返回结果:{i}");
            //}
            //Console.ReadKey();


            Console.WriteLine("-----------------------------------------------------");

            //2
            //回调函数需要异步方法的返回结果然后计算的
            //验证了，只要BeginInvoke调用的委托方法执行完毕后，就会执行回调函数，不是等待下例中主线程睡10s后才执行的
            Console.WriteLine($"1主线程：threadID=[{Thread.CurrentThread.ManagedThreadId}]");
            Func<int, int, int> func = (x, y) =>
            {
                //Thread.Sleep(2000);
                Console.WriteLine("开始执行委托方法");
                Console.WriteLine($"异步方法线程：{DateTime.Now.ToString()},threadID=[{Thread.CurrentThread.ManagedThreadId}]");
                return x + y;
            };
            AsyncCallback asyncCallback = arr =>
            {
                //回调函数用到异步方法的结果
                Console.WriteLine($"传入的参数【{arr.AsyncState}】");
                var addFunc = (Func<int, int, int>)arr.AsyncState;

                int result = addFunc.EndInvoke(arr);
                Console.WriteLine($"异步方法返回结果+回调函数内部处理{result+9}");
                Console.WriteLine($"回调函数线程：threadID=[{Thread.CurrentThread.ManagedThreadId}]");

            };
            IAsyncResult asyncResult = func.BeginInvoke(2, 3, asyncCallback, func);

            Console.WriteLine($"2主线程：threadID=[{Thread.CurrentThread.ManagedThreadId}]");
            asyncResult.AsyncWaitHandle.WaitOne();//异步等待，用来让主线程等待异步线程执行完，确保callback能狗执行完
            Console.WriteLine($"3主线程： threadID=[{Thread.CurrentThread.ManagedThreadId}]");
            
            if (asyncResult.IsCompleted)
            {
                Thread.Sleep(10000);
                Console.WriteLine($"4主线程： threadID=[{Thread.CurrentThread.ManagedThreadId}]");
                //int i = func.EndInvoke(asyncResult);//拿到异步方法调用的结果
            }
            Console.ReadKey();



        }
    }
}
