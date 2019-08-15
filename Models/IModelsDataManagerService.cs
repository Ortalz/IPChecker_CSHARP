using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public interface IDataManagerService
    {
        Task<List<Ip>> GetIPs();
        void ReplaceIpInfo(Ip newIp);
        void AddIp(Ip ip);
        void AddIps(List<Ip> ips);
    }
}
