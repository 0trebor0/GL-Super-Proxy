using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace SupercellProxy
{
    public partial class Loader : Form
    {
        public Loader()
        {
            InitializeComponent();

            // Set background colors           R    G    B
            Color DunkelGrau = Color.FromArgb(105, 105, 105);
            this.BackColor = DunkelGrau;
            this.TransparencyKey = DunkelGrau;

            var LoadingThread = new Thread(new ThreadStart(Load));
            LoadingThread.SetApartmentState(ApartmentState.STA);
            LoadingThread.Start();
        }

        /// <summary>
        /// Simulated loading process
        /// </summary>
        private void Load()
        {
            // Simulate loading
            UpdateProgressBar(50);
            Thread.Sleep(850);
       
            UpdateProgressBar(40);
            Thread.Sleep(1350);

            UpdateProgressBar(10);
            Thread.Sleep(500);

            this.Hide();

            new ProxyUI().ShowDialog();
        }

        /// <summary>
        /// Updates the progressbar progress
        /// </summary>
        public void UpdateProgressBar(int percentage)
        {
            if (this.IsHandleCreated)
            {
                this.Invoke(new Action(() =>
                {
                    progress.Step = percentage;
                    progress.PerformStep();
                }));
            }
        }
    }
}
