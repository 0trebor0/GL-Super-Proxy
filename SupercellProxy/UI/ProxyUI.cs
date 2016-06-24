using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SupercellProxy
{
    public partial class ProxyUI : Form
    {
        public static ProxyUI Instance;
        public static int TotalPackets;

        /// <summary>
        /// ProxyUI constructor
        /// </summary>
        public ProxyUI()
        {
            try
            {
                // Set the public instance
                Instance = this;

                // UI setup
                InitializeComponent();
                this.versionTxt.Text = "Public Release " + Helper.AssemblyVersion;

                // Timers
                Timer TimeRefresh = new Timer() { Interval = 75, Tag = "Time Refresher", Enabled = true };
                TimeRefresh.Tick += (s, a) =>
                {
                    this.timeTxt.Text = DateTime.Now.ToLocalTime().ToString();
                };

                // Game List
                AddEventLogText("UI initialized!");
                AddEventLogText("Waiting for user action..");
            }
            catch(Exception ex)
            {
                MessageBox.Show("Failed to initialize the UI (" + ex.GetType() + ")!", "Fatal error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Adds text to the eventlog box
        /// </summary>
        public void AddEventLogText(string Text)
        {
            eventBox.Text += String.Concat(Text, Environment.NewLine);
        }

        /// <summary>
        /// Adds a row to a datagridview and enables AutoScrolling
        /// </summary>
        public void AddPacket(int ID, int PayloadLength, PacketDestination Dest, DateTime Timestamp, byte[] Payload)
        {
            try
            {
                TotalPackets++;
                totalPacketsTxt.Text = TotalPackets + " total packet(s)";

                int firstDisplayed = packetView.FirstDisplayedScrollingRowIndex;
                int displayed = packetView.DisplayedRowCount(true);
                int lastVisible = (firstDisplayed + displayed) - 1;
                int lastIndex = packetView.RowCount - 1;

                packetView.Rows.Add(ID.ToString(), PayloadLength.ToString(), Dest.ToString(), Timestamp.ToString(), Encoding.UTF8.GetString(Payload));

                if (lastVisible == lastIndex)
                {
                    packetView.FirstDisplayedScrollingRowIndex = firstDisplayed + 1;
                }               
            }
            catch(Exception ex)
            {
                MessageBox.Show("Failed to add packet " + ID + " to the DataGridView (" + ex.GetType() + ")!", "Fatal error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Kills the entire program when the red "X" was clicked
        /// </summary>
        private void ProxyUI_FormClosing(object sender, FormClosingEventArgs e)
        {
            Program.Kill();
        }

        /// <summary>
        /// Starts the proxy (UI)
        /// </summary>
        private void startBtn_Click(object sender, EventArgs e)
        {
            try
            {
                Proxy.Start();
                AddEventLogText("Proxy started!");
            }
            catch(Exception ex)
            {
                MessageBox.Show("Failed to start the proxy (" + ex.GetType() + ")!", "Fatal error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Stops the proxy (UI)
        /// </summary>
        private void stopBtn_Click(object sender, EventArgs e)
        {
            try
            {
                Proxy.Stop();
                AddEventLogText("Proxy stopped!");
            }
            catch(Exception ex)
            {
                MessageBox.Show("Failed to stop the proxy (" + ex.GetType() + ")!", "Fatal error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Sends an API request
        /// </summary>
        private void aPIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("http://localhost:" + Config.WebAPI_PORT);
        }

        /// <summary>
        /// Clears the packet DataGridView
        /// </summary>
        private void clearPacketViewBtn_Click(object sender, EventArgs e)
        {
            packetView.Rows.Clear();
        }
    }
}
