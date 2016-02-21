namespace signalr_test
{
	using System;
	using Microsoft.AspNet.SignalR;
	using System.Threading.Tasks;
	using System.Threading;
	using NetMQ;
	using System.Collections.Generic;

	public class MyHub : Hub
	{	
		private MessageListener listener;
		
		/// <summary>
		/// Initializes a new instance of the <see cref="signalr_test.MyHub"/> class.
		/// </summary>
		public MyHub ()
		{
			this.listener = MessageListener.Instance;
		}

		/// <summary>
		/// Send the specified name and message.
		/// </summary>
		/// <param name="name">Name.</param>
		/// <param name="message">Message.</param>
		public void Send(string name, string message)
		{
			Clients.All.addMessage (name, message);
		}
	}
}

