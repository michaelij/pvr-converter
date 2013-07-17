using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PvrConverter
{
    public partial class MainForm : Form
    {
        /// <summary>
        /// Application settings
        /// </summary>
        private Settings settings;

        private List<FileInfo> fileList;

        /// <summary>
        /// Whether we want a GUI or the command line only.
        /// True if command line arguments are provided on startup.
        /// </summary>
        private bool closeForCommandLine;

        public delegate void ReceiveProcessOuputDelegate(string text);
        public ReceiveProcessOuputDelegate receiveProcessOutputDelegate;
        public ReceiveProcessOuputDelegate receiveProcessErrorDelegate;

        public MainForm()
        {
            closeForCommandLine = false;
            InitializeComponent();
        }
        
        public MainForm(string[] args)
            : this()
        {
            closeForCommandLine = true;

            ArgumentParser commandLine = new ArgumentParser(args);
            if (commandLine["out"] != null)
            {
                Console.WriteLine("Outfile is = ");
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            settings = Settings.Load("settings.xml");

            if (closeForCommandLine == true)
            {
                this.Close();
                return;
            }

            receiveProcessOutputDelegate = new ReceiveProcessOuputDelegate(receiveProcessOutput);
            receiveProcessErrorDelegate = new ReceiveProcessOuputDelegate(receiveProcessError);

            populateFileList();
            setupFileListView();
        }

        private void setupFileListView()
        {
            fileListView.Columns.Add("checkbox", "", 20);
            fileListView.Columns.Add("name", "Name", 370);
            fileListView.Columns.Add("size", "Size", 50);
            fileListView.Columns.Add("status", "Status", 100);

            populateFileListView();
        }

        private void populateFileList()
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(settings.DefaultSearchPath);
            IEnumerable<FileInfo> files = directoryInfo.GetFilesByExtensions(settings.Extensions.ToArray());
            this.fileList = files.ToList<FileInfo>();
        }

        /// <summary>
        /// Populates the file listview with all relevant information about each file
        /// </summary>
        private void populateFileListView()
        {
            fileListView.Items.Clear();

            foreach (FileInfo file in this.fileList)
            {
                string defaultStatus = "Ready to process";

                ListViewItem item = new ListViewItem();
                item.SubItems.Add(file.FullName); // Full path to the file
                item.SubItems.Add(file.Length.ToFileSize()); // Size of file

                // Item is selected for processing by default.
                item.Selected = true;

                if (File.Exists(Path.Combine(settings.DefaultOutDirectory, file.Name)))
                {
                    // The file appears to already be at the output directory, it was most likely already processed
                    // It can be deselected by default and changed to a greyed out colour.
                    defaultStatus = "Already processed";
                    item.Selected = false;
                    item.BackColor = SystemColors.ControlLight;
                }

                item.SubItems.Add(defaultStatus); // The default status
                
                fileListView.Items.Add(item);
            }
        }

        /// <summary>
        /// Receive output from a tool process
        /// </summary>
        /// <param name="output">The output</param>
        private void receiveProcessOutput(string output)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Receive errors from a tool process
        /// </summary>
        /// <param name="output">The output</param>
        private void receiveProcessError(string text)
        {
            throw new NotImplementedException();
        }
    }
}
