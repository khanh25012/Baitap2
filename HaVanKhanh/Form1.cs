﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HaVanKhanh
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ProcessStartInfo startsInfo = new ProcessStartInfo();
            startsInfo.CreateNoWindow = true;
            startsInfo.UseShellExecute = false;
            startsInfo.FileName = "D:\\Program Files\\Java\\bin\\java.exe";
            startsInfo.WindowStyle = ProcessWindowStyle.Hidden;
            startsInfo.RedirectStandardOutput = true;
            startsInfo.WorkingDirectory = "C:\\Users\\havankhanh\\Desktop\\duycop";
            startsInfo.Arguments = $"duycop {textBox1.Text} {textBox2.Text}";
            try
            {
                using (Process exe = Process.Start(startsInfo))
                {
                    exe.WaitForExit();
                    while (!exe.StandardOutput.EndOfStream)
                    {
                        string line = exe.StandardOutput.ReadLine();
                        textBox3.AppendText(line + "\n");

                    }
                }
            }
            catch (Exception ex)
            {
                textBox3.AppendText(ex.Message);
            }
        }
    }
}
