// See https://aka.ms/new-console-template for more information
using Thread;

Console.WriteLine("Hello, World!");

DoTask1 doTask1 = new DoTask1();

Func<int> func = () => { return 1 + 2; };
IAsyncResult asyncResult= func.BeginInvoke(x =>
{

	try
	{
		if (x.IsCompleted)
		{
			var y = func.EndInvoke(x);
			Console.WriteLine(y);

		}
	}
	catch (Exception ex)
	{

        Console.WriteLine(ex);
	}
}, func);

asyncResult.AsyncWaitHandle.WaitOne();