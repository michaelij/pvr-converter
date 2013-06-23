using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PvrConverter
{
    public partial class MainForm : Form
    {
        /// <summary>
        /// Whether we want a GUI or the command line only.
        /// True if command line arguments are provided on startup.
        /// </summary>
        private bool closeForCommandLine;

        public MainForm()
        {
            closeForCommandLine = false;
            InitializeComponent();
        }
        
        public MainForm(string[] args)
            : this()
        {
            closeForCommandLine = true;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            if (closeForCommandLine == true)
            {
                this.Close();
                return;
            }
        }
    }
}
