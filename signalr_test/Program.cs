namespace signalr_test
{
	using System;
	using Microsoft.Owin.Hosting;
	using Owin;

	/// <summary>
	/// main Program class
	/// </summary>
	class MainClass
	{
		/// <summary>
		/// Main program method 
		/// </summary>
		/// <param name="args">The command-line arguments.</param>
		public static void Main (string[] args)
		{
			string url = "http://localhost:8080";
			using (WebApp.Start (url)) {
				Console.WriteLine ("Server running on {0}", url);
				Console.ReadLine ();
			}
		}
	}
}
