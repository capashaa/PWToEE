using PixelPilot.PixelGameClient;
using Newtonsoft.Json;
using System.Drawing.Printing;
using System.Linq.Expressions;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using Timer = System.Timers.Timer;
namespace PWToEE
{
    public partial class MainForm : Form
    {
        public ToolStripStatusLabel tssSText
        {
            get { return tsslblStatus; }
            set { tsslblStatus = value; }
        }
        private PixelPilotClient? _client;
        public static Settings? settings = new Settings();
        private static Timer? timer;
        private string settingsPath = $"{Directory.GetCurrentDirectory()}\\settings.json";
        public MainForm()
        {
            InitializeComponent();
            if (File.Exists(settingsPath))
            {
                settings = JsonConvert.DeserializeObject<Settings>(File.ReadAllText(settingsPath));
                if (settings != null)
                {
                    cbAuthToken.Checked = true;
                    txtbAuthToken.Text = settings.authToken;
                    txtbAuthToken.Select(0, 0);
                }
            }
            this.Text = "PW to EE";
        }

        private void DownloadNow(object data)
        {
            timer.Stop();
            if (timer.Enabled == false)
            {
                tssStatus.Text = "Info: Connected!";
                tssStatus.ForeColor = Color.DarkBlue;
            }
            Downloader.Download(_client,this);
        }
        private async Task ExecuteCode(string authToken,string worldId)
        {
            _client = new PixelPilotClient(authToken, false);
            _client.OnClientConnected += DownloadNow;
            await _client.Connect(worldId);
        }
        private async void btnDownload_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtbAuthToken.Text))
            {
                if (cbAuthToken.Checked)
                {
                    tssStatus.Text = "Info: AuthToken saved!";
                    tssStatus.ForeColor = Color.DarkBlue;
                    settings.authToken = txtbAuthToken.Text;
                    File.WriteAllText(settingsPath, JsonConvert.SerializeObject(settings, Newtonsoft.Json.Formatting.Indented));
                }
                if (!string.IsNullOrEmpty(txtbWorldId.Text))
                {
                    timer = new Timer(5000);
                    timer.Elapsed += TimerEnds;
                    timer.AutoReset = false;
                    timer.Start();
                    tssStatus.Text = "Info: Trying to Connect";
                    tssStatus.ForeColor = Color.DarkBlue;
                    await ExecuteCode(txtbAuthToken.Text, txtbWorldId.Text);

                }
                else
                {
                    tssStatus.Text = "Error: Couldn't find World ID!";
                    tssStatus.ForeColor = Color.DarkRed;
                }
            }
            else
            {
                tssStatus.Text = "Error: Couldn't find AuthToken!";
                tssStatus.ForeColor = Color.DarkRed;
            }
        }

        private void cbAuthToken_CheckedChanged(object sender, EventArgs e)
        {
            if (!cbAuthToken.Checked)
            {

                if (File.Exists(settingsPath)) File.Delete(settingsPath);
            }
        }
        private void TimerEnds(Object source, ElapsedEventArgs e)
        {
            tssStatus.Text = "Error: Couldn't connect.";
            tssStatus.ForeColor = Color.DarkRed;
        }
    }
    public class Settings
    {
        public string? authToken { get; set; } = null;
    }
}
