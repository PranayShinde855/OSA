using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OSA.Utility;

namespace OSA.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HelperController : ControllerBase
    {
        public HelperController()
        {
            
        }

        [HttpPost("ConvertToBase64")]
        public async Task<string> ConvertToBase64(IFormFile requestFile)
        {
            if (requestFile == null)
                return "";

            return Utils.ConvertIFromFileToBase64(requestFile);
        }
    }
}
