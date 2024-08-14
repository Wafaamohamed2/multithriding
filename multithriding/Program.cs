
using System.Threading;
using System.Net.WebSockets;

internal class Program
{
    private static void Main(string[] args)
    {
       

        var cts =new CancellationTokenSource();

        Processbatch1(cts.Token);
        Processbatch2(cts.Token);

        Console.WriteLine("enter your name :");
        var name = Console.ReadLine();
        Console.WriteLine("wellcom " + name);
        Console.ReadKey();

    }

    private static object _lock = new object();

    private static  async Task Processbatch2(CancellationToken cancellationToken)
    {

        // await must be used with async method .... it used to wait task to complete it work

       
       
        for (var i = 101; i <= 200; i++) {

            if (cancellationToken.IsCancellationRequested) { return; }

            await Task.Delay(500);

            lock (_lock) { 
                 Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(i);
                Console.ForegroundColor= ConsoleColor.White;
            }

        
        }
        return;

    }

    private static async Task Processbatch1(CancellationToken cancellationToken)
    {

       

        
        for (var i = 1; i <= 100; i++)
        {

            if (cancellationToken.IsCancellationRequested) { return; }

            await Task.Delay(500);
            lock (_lock)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(i);
                Console.ForegroundColor = ConsoleColor.White;
            }


        }
        return ;

    }
}