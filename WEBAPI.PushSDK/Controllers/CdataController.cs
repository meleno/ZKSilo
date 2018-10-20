using Interfaces;
using Microsoft.AspNetCore.Mvc;
using Silo.Client;
using Silo.Grains;
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace WEBAPI.PushSDK.Controllers
{
	[Route("iclock/[controller]")]
	[ApiController]
	public class CdataController : ControllerBase
	{
		[HttpGet()]
		public string Get([RequiredFromQuery]string sn)
		{
			return "GET OPTION FROM: 3836171500145\r\nATTLOGStamp = 1\r\nOPERLOGStamp = 1\r\nATTPHOTOStamp = 1\r\nUSERINFOStamp = 1\r\nErrorDelay = 30\r\nDelay = 10\r\nTransTimes =\r\nTransInterval =\r\nTransFlag = 11111111110\r\nTimeZone = 1\r\nRealtime = 1\r\nEncrypt = 0\r\nServerVer = 1.20181019";
		}

		[HttpPost]
		public async Task<string> Post([RequiredFromQuery] string sn, [RequiredFromQuery] string table)
		{
			if (table == "OPERLOG")
			{
				string message;

				using (var reader = new StreamReader(Request.Body, Encoding.Default))
				{ message = reader.ReadToEnd(); }

				try
				{
					var saver = (await SiloClient.GetSiloClient()).GetGrain<ISavePunch>(0);
					await saver.SavePunchInDatabase(new CommonData.Punch() { Date = DateTime.Now, EmployeeId = "000000009" });
				}
				catch (Exception e) { return e.Message; }
			}

			return "OK";
		}
	}
}
