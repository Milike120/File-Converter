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

namespace ConvertFile
{
    public partial class Form1 : Form
    {
        string InputFileName = "";
        string OutputFileName = "";

        string rootFolderPath = @"" + Environment.GetEnvironmentVariable("ProgramFiles(x86)") + "\\ffmpeg\\bin\\";
        string destinationPath = @"" + Environment.GetEnvironmentVariable("USERPROFILE") + "\\Desktop\\";
        string destFile;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            InputFileName = textBox1.Text;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            OutputFileName = textBox2.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (InputFileName != "" && OutputFileName != "")
            {
                label3.Text = "Please Wait ...";

                Process process = new Process();
                process.StartInfo.FileName = "cmd.exe";
                process.StartInfo.CreateNoWindow = true;
                process.StartInfo.RedirectStandardInput = true;
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.UseShellExecute = false;
                process.Start();
                process.StandardInput.WriteLine("cd " + Environment.GetEnvironmentVariable("ProgramFiles(x86)") + "/ffmpeg/bin/");
                process.StandardInput.WriteLine("ffmpeg -i " + InputFileName + " " + OutputFileName);
                process.StandardInput.Flush();
                process.StandardInput.Close();
                process.WaitForExit();
                Console.WriteLine(process.StandardOutput.ReadToEnd());
                label3.Text = "Done";

                destFile = Path.Combine(destinationPath, OutputFileName);
                if (File.Exists(destFile))
                    File.Delete(destFile);

                File.Move(rootFolderPath + OutputFileName, destinationPath + OutputFileName);
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {
            
        }
    }
}
