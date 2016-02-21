namespace signalr_test
{
	using System;
	using Microsoft.AspNet.SignalR;
	using Microsoft.Owin.Hosting;
	using Owin;
	using Microsoft.Owin.Cors;

	/// <summary>
	/// Startup class
	/// </summary>
	public class Startup
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="signalr_test.Startup"/> class.
		/// </summary>
		public Startup ()
		{
		}

		/// <summary>
		/// Configure the application
		/// </summary>
		/// <param name="app">Application builder</param>
		public void Configuration(IAppBuilder app)
		{
			app.UseCors (CorsOptions.AllowAll);
			app.MapSignalR ();
		}
	}
}

