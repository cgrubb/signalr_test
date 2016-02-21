namespace signalr_test
{
  using System;
  using Microsoft.AspNet.SignalR;
  using NetMQ;
  using System.Threading.Tasks;
  using System.Collections.Generic;

  /// <summary>
  /// Message listener.
  /// </summary>
  public class MessageListener
  {
    /// <summary>
    /// The hub context.
    /// </summary>
    private IHubContext context;

    /// <summary>
    /// The message listener instance.
    /// </summary>
    private readonly static Lazy<MessageListener> _instance = 
      new Lazy<MessageListener> (
        () => new MessageListener(GlobalHost.ConnectionManager.GetHubContext<MyHub>())
      );

    /// <summary>
    /// Initializes a new instance of the <see cref="signalr_test.MessageListener"/> class.
    /// </summary>
    /// <param name="context">Context.</param>
    private MessageListener (IHubContext context)
    {
      this.context = context;
      this.Run ();
    }

    /// <summary>
    /// Gets the instance.
    /// </summary>
    /// <value>The instance.</value>
    public static MessageListener Instance
    {
      get 
      {
        return MessageListener._instance.Value;
      }
    }

    /// <summary>
    /// Run this instance.
    /// </summary>
    private void Run()
    {
      Task.Run (() => {
        using (var context = NetMQContext.Create())
        {
          using (var socket = context.CreateSubscriberSocket())
          {
            socket.Connect("tcp://localhost:8089");
            socket.Subscribe("message");
            while (true)
            {
              var timeout = new TimeSpan(0, 0, 0, 0, 100);
              var msg = new List<string>();
              if (socket.TryReceiveMultipartStrings(timeout, ref msg))
              {
                if (msg.Count == 2)
                {
                  this.context.Clients.All.addMessage("test", msg[1]);
                }
              }
            }
          }
        }
      });
    }
  }
}

