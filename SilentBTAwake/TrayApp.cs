using System;
using System.Drawing;
using System.Media;
using System.Windows.Forms;

namespace BluetoothKeepAlive
{
    public partial class TrayApp : Form
    {
        private NotifyIcon trayIcon;
        private SoundPlayer player;

        public TrayApp()
        {
            // Hide window
            this.WindowState = FormWindowState.Minimized;
            this.ShowInTaskbar = false;
            this.Visible = false;
            this.Hide();

            // Load silent WAV
            player = new SoundPlayer(SilentWav());
            player.PlayLooping();

            trayIcon = new NotifyIcon()
            {
                Icon = new Icon("btAwake.ico"), // put your .ico file in project folder
                ContextMenu = new ContextMenu(new MenuItem[] {
                    new MenuItem("Exit", Exit)
                }),
                Visible = true,
                Text = "Bluetooth Keep-Alive"
            };
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.Visible = false;
            this.Hide();
        }

        private void Exit(object sender, EventArgs e)
        {
            player.Stop();
            trayIcon.Visible = false;
            Application.Exit();
        }

        private System.IO.Stream SilentWav()
        {
            int sampleRate = 44100;
            int duration = 1; // seconds
            int numSamples = sampleRate * duration;
            byte[] wav = new byte[44 + numSamples * 2];

            // RIFF header
            wav[0] = (byte)'R'; wav[1] = (byte)'I'; wav[2] = (byte)'F'; wav[3] = (byte)'F';
            int fileSize = wav.Length - 8;
            BitConverter.GetBytes(fileSize).CopyTo(wav, 4);
            wav[8] = (byte)'W'; wav[9] = (byte)'A'; wav[10] = (byte)'V'; wav[11] = (byte)'E';
            wav[12] = (byte)'f'; wav[13] = (byte)'m'; wav[14] = (byte)'t'; wav[15] = (byte)' ';
            BitConverter.GetBytes(16).CopyTo(wav, 16);
            BitConverter.GetBytes((short)1).CopyTo(wav, 20);
            BitConverter.GetBytes((short)1).CopyTo(wav, 22);
            BitConverter.GetBytes(sampleRate).CopyTo(wav, 24);
            BitConverter.GetBytes(sampleRate * 2).CopyTo(wav, 28);
            BitConverter.GetBytes((short)2).CopyTo(wav, 32);
            BitConverter.GetBytes((short)16).CopyTo(wav, 34);
            wav[36] = (byte)'d'; wav[37] = (byte)'a'; wav[38] = (byte)'t'; wav[39] = (byte)'a';
            BitConverter.GetBytes(numSamples * 2).CopyTo(wav, 40);
            // The rest is silence (zeros)
            return new System.IO.MemoryStream(wav);
        }

        private void TrayApp_Load(object sender, EventArgs e)
        {

        }
    }
}