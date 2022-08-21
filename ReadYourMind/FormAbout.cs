using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReadYourMind
{
    public partial class FormAbout : Form
    {
        public FormAbout()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormAbout_Load(object sender, EventArgs e)
        {
            this.linkLabelOtherGames.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkClicked);
            this.linkLabelGithub.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkClicked);

        }
        private void LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            String URL = ((LinkLabel)sender).Text;
            System.Diagnostics.Process.Start(URL);
        }
    }
}
