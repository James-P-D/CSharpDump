using System;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadPauseResumeTest
{
  class Program
  {
    static ManualResetEvent manualResetEvent = new ManualResetEvent(false);

    static void Main(string[] args)
    {
      Task task = Task.Factory.StartNew(() =>
      {
        GetDataFromServer(1);
      });

      Task.Factory.StartNew(() =>
      {
        GetDataFromServer(2);
      });

      Console.ReadLine();

      //Send first signal to get first set of data from server 1 and server 2
      manualResetEvent.Set();
      manualResetEvent.Reset();

      Console.ReadLine();
      //Send second signal to get second set of data from server 1 and server 2
      manualResetEvent.Set();

      Console.ReadLine();

      /* Result
          * I get first data from server1
          * I get first data from server2
          * I get second data from server1
          * I get second data from server2
          * All the data collected from server2
          * All the data collected from server1
          */
    }

    static void GetDataFromServer(int serverNumber)
    {
      //Calling any webservice to get data
      Console.WriteLine("I get first data from server" + serverNumber);
      manualResetEvent.WaitOne();
      Console.WriteLine("I get second data from server" + serverNumber);
      manualResetEvent.WaitOne();
      Console.WriteLine("All the data collected from server" + serverNumber);
    }
  }
}
