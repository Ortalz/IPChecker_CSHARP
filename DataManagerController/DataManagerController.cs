using Models;
using Nancy;
using Nancy.ModelBinding;
using System.Threading.Tasks;

namespace DataManagerController
{
    public class DataManagerController : NancyModule
    {
        private IDataManagerService _modelsDataService;
        private ICheckIPService _checkIPService;
        private readonly string GET_IPS_LIST = "/iplist";
        private readonly string CHECK_IP = "/checkip";

        public DataManagerController(IDataManagerService modelsDataService, ICheckIPService checkIPService)
        {
            _modelsDataService = modelsDataService;
            _checkIPService = checkIPService;

            Get(GET_IPS_LIST, 
                async noParams => await GetIPs());

            Post(CHECK_IP,
                async ip => await CheckIP(this.Bind<Ip>()));
        }

        private async Task<Response> CheckIP(Ip ipToCheck)
        {
            
            await _checkIPService.CheckIP(ipToCheck);
            _modelsDataService.ReplaceIpInfo(ipToCheck);
            return Response.AsJson(await _modelsDataService.GetIPs());
        }

        private async Task<Response> GetIPs()
        {
            return Response.AsJson(await _modelsDataService.GetIPs());
        }
    }
}
