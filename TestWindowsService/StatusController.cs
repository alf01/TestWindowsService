using System.Web.Http;

namespace TestWindowsService
{
    public class StatusController : ApiController
    {
        [HttpGet]
        public bool CheckStatus()
        {
            return true;
        }
    }
}