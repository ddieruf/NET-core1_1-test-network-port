using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Net.Sockets;

namespace controllers
{
  [Route("testport")]
	public class TestPort : Controller
	{
		public TestPort()
		{
		}

    [HttpPost]
    public bool Create([FromBody] TestPortRequest req){
      if (req == null){
        throw new ArgumentNullException();
      }

      return IsPortOpen(req.host, req.port, new TimeSpan(0,0,req.timeoutSeconds));
    }

		private bool IsPortOpen(string host, int port, TimeSpan timeout)
		{
      //let exceptions bubble up

			using (var client = new TcpClient()){
        var connectAsync = client.ConnectAsync(host, port);
        connectAsync.Wait(timeout);

				if (!client.Connected){
					return false;
				}
			}

			return true;
		}
	}
  public class TestPortRequest{
    public string host { get; set; }
    public int port { get; set; }
    public int timeoutSeconds { get; set; }
  }
}
