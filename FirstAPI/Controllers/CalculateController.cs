using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FirstAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CalculateController : ControllerBase
	{
		[HttpGet("api/Calculate/add")]
		// api/Calculate/add?a=10&b=20
		public int Add(int a , int b)
		{
			return a + b;
		}
		[HttpPost("api/Calculate/sub")]
		// api/Calculate/sub?a=10&b=20
		public int Sub(int a , int b)
		{
			return a - b;
		}
		// api/Calculate/mul?a=10&b=20
		[HttpPost("api/Calculate/mul")]
		public int Mul(int a , int b)
		{
			return a * b;
		}
		// api/Calculate/div?a=10&b=20
		[HttpPost("api/Calculate/div")]
		public int Div(int a , int b)
		{
			if(b == 0)
			{
				return 0;
			}
			return a / b;
		
		}


	}
}
