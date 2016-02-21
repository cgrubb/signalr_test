using System;
using NetMQ;
namespace test_console
{
  class MainClass
  {
    public static void Main (string[] args)
    {
      using (var context = NetMQContext.Create ()) {
        using (var socket = context.CreatePublisherSocket ()) {
          socket.Bind ("tcp://localhost:8089");
          var input = string.Empty;
          while (input.ToLower() != "quit") {
            Console.Write ("> ");
            input = Console.ReadLine ();
            socket.SendMoreFrame ("message").SendFrame (input);
          }
        }
      }
    }
  }
}
