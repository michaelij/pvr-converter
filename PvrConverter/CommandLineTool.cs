using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PvrConverter
{
    class CommandLineTool : IDisposable
    {
        /// <summary>
        /// The main application form
        /// </summary>
        private MainForm form;

        /// <summary>
        /// The tool's process
        /// </summary>
        private Process process;

        /// <summary>
        /// Friendly name of the command line tool
        /// </summary>
        private string name;

        /// <summary>
        /// The file or command to run
        /// </summary>
        private string command;

        /// <summary>
        /// The arguments to pass to the tool
        /// </summary>
        private string arguments;

        /// <summary>
        /// True if the process is running, false otherwise
        /// </summary>
        private bool isRunning;

        public string Name
        {
            get
            {
                return this.name;
            }
        }

        public Boolean HasExited
        {
            get
            {
                return this.process.HasExited;
            }
        }

        public bool IsRunning
        {
            get
            {
                return this.isRunning;
            }
        }

        /// <summary>
        /// CommandLineTool constructor
        /// </summary>
        /// <param name="form">The main application form</param>
        /// <param name="command">The command that will run the tool.</param>
        /// <param name="arguments">Any initial arguments to the command</param>
        public CommandLineTool(MainForm form, string command, string arguments = "")
        {
            this.form = form;
            this.command = command;
            this.arguments = arguments;

            this.process = new Process();
            this.process.StartInfo.UseShellExecute = false;
            // Don't show the program's window
            this.process.StartInfo.CreateNoWindow = true;
            this.process.StartInfo.RedirectStandardOutput = true;
            this.process.StartInfo.RedirectStandardError = true;
            this.process.StartInfo.FileName = this.command;
            // Redirects the standard input so that commands can be sent to the shell.
            this.process.StartInfo.RedirectStandardInput = true;

            this.process.OutputDataReceived += new DataReceivedEventHandler(process_OutputDataReceived);
            this.process.ErrorDataReceived += new DataReceivedEventHandler(process_ErrorDataReceived);
            this.process.Exited += new EventHandler(process_Exited);
        }

        /// <summary>
        /// Start the tool using only the arguments provided on construction
        /// </summary>
        public void Start()
        {
            if (isRunning == false)
            {
                isRunning = true;

                // Append any arguments provided on initialisation
                process.StartInfo.Arguments = this.arguments;

                process.Start();

                process.BeginOutputReadLine();
                process.BeginErrorReadLine();
            }
        }

        /// <summary>
        /// Start the tool
        /// </summary>
        /// <param name="arguments">Addition arguments to pass to the tool</param>
        public void Start(string arguments)
        {
            if (isRunning == false)
            {
                // Append new arguments to the current string.
                this.arguments += " " + arguments;

                Start();
            }
        }

        /// <summary>
        /// Stop the process
        /// </summary>
        public void Abort()
        {
            process.Kill();
        }

        /// <summary>
        /// Send input to the process via the StandardInput stream
        /// </summary>
        /// <param name="input">The string to send to the process</param>
        public void SendInput(string input)
        {
            process.StandardInput.Write(input);
            process.StandardInput.Flush();
        }

        /// <summary>
        /// Occurs when the process writes to its StandardOutput stream
        /// </summary>
        /// <param name="sendingProcess"></param>
        /// <param name="output"></param>
        private void process_OutputDataReceived(object sendingProcess, DataReceivedEventArgs output)
        {
            if (output.Data != null)
            {
                this.form.Invoke(form.receiveProcessOutputDelegate, new object[] { output });
            }
        }

        /// <summary>
        /// Occurs when the process writes to its StandardError stream
        /// </summary>
        /// <param name="sendingProcess"></param>
        /// <param name="output"></param>
        private void process_ErrorDataReceived(object sendingProcess, DataReceivedEventArgs output)
        {
            if (output.Data != null)
            {
                this.form.Invoke(form.receiveProcessErrorDelegate, new object[] { output });
            }
        }

        /// <summary>
        /// Occurs when the process has exited.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void process_Exited(object sender, EventArgs e)
        {
            isRunning = false;
        }

        /// <summary>
        /// Instruct the System.Diagnostics.Process to wait indefinitely for the associated process to exit.
        /// </summary>
        public void WaitForExit()
        {
            this.process.WaitForExit();
        }

        /// <summary>
        /// Dispose of the process
        /// </summary>
        public void Dispose()
        {
            if (process != null)
            {
                process.Dispose();
            }
        }
    }
}
