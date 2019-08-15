using Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IpCheckerView
{
    public partial class IpCheckerForm : Form
    {
        private static readonly HttpClient client = new HttpClient();
        private readonly string SERVER_ADDRESS = "http://localhost:6000";
        private readonly string GET_IPS_LIST = "/iplist";
        private readonly string CHECK_IP = "/checkip";

        public IpCheckerForm()
        {
            InitializeComponent();
        }

        private async void GetIPS_Click(object sender, EventArgs e)
        {
            var response = await client.GetAsync($"{SERVER_ADDRESS}/{GET_IPS_LIST}");
            var ip_list = JsonConvert.DeserializeObject<List<Ip>>(await response.Content.ReadAsStringAsync());
            IPListView.SetObjects(ip_list);
        }

        private async void Checkip_ClickAsync(object sender, EventArgs e)
        {
            var jsonIPS = JsonConvert.SerializeObject((Ip)IPListView.SelectedObject);
            var stringContent = new StringContent(jsonIPS, UnicodeEncoding.UTF8, "application/json");
            var response = await client.PostAsync($"{SERVER_ADDRESS}/{CHECK_IP}", stringContent);
            var ip_list = JsonConvert.DeserializeObject<List<Ip>>(await response.Content.ReadAsStringAsync());
            IPListView.SetObjects(ip_list);
        }

    }
}
