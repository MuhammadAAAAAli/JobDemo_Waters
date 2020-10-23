using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace WatersUi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var errors = new List<string> { "" };
            result.ResetForeColor();
            result.DataSource = new List<string>();

            var fd = new OpenFileDialog();
            if (fd.ShowDialog() == DialogResult.OK)
            {
                if (fd.FileName.Substring(fd.FileName.Length - 4) != ".txt")
                {
                    result.ForeColor = Color.Red;
                    errors.Add("Only .txt file please");
                    result.DataSource = errors;
                }
                else
                {
                    Alghorithm.Path = fd.FileName;
                    
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var errors = new List<string> { "" };
            result.ResetForeColor();
            result.DataSource = new List<string>();

            if (Alghorithm.Path != null && !string.IsNullOrEmpty(inputFromUser.Text))
            {
                var toUi = new StringBuilder();
                try
                {
                    var finalList = Alghorithm.Go(inputFromUser.Text.ToUpper().ToCharArray());
                    result.DataSource = finalList;
                    howMany.Text = finalList.Count.ToString();
                }
                catch (Exception ex)
                {
                    result.ForeColor = Color.Red;
                    errors.Add(ex.Message);
                    result.DataSource = errors;
                }

            }
            else
            {
                if (Alghorithm.Path == null)
                {
                    errors.Add("Error : Need file");
                }
                if (string.IsNullOrWhiteSpace(inputFromUser.Text))
                {
                    errors.Add("Error : Need input chars");
                }
                result.ForeColor = Color.Red;
                result.DataSource = errors;
            }
        }
    }
}