using Microsoft.AspNetCore.Mvc;

namespace WEBAPI.PushSDK.Controllers
{
	[Route("iclock/[controller]")]
	[ApiController]
	public class GetRequestController : ControllerBase
	{
		// GET: api/GetRequest
		[HttpGet]
		public string Get([RequiredFromQuery]string sn)
		{
			return "OK";
		}
	}
}
