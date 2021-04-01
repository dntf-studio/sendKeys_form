using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace sendKeys
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        static bool intervalchecked;

        private void button1_Click(object sender, EventArgs e)
        {

            if(txtProcess.Text != "")
            {
                if (!checktimer.Checked)
                {
                    try
                    {
                        Microsoft.VisualBasic.Interaction.AppActivate(txtProcess.Text);
                        if (checkBox1.Checked)
                        {
                            txt.Text += Environment.NewLine;
                            SendKeys.SendWait(txt.Text + "{ENTER}");
                        }
                        else
                        {
                            SendKeys.SendWait(txt.Text);
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("the Targetname is incorrect", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else if (checktimer.Checked)
                {
                    bool canConvert_sec = int.TryParse(textBox1.Text, out var ipio);
                    if(canConvert_sec && textBox1.Text != "")
                    {
                        var sec = int.Parse(textBox1.Text);
                        var convert_ms = sec * 1000;
                        label5.Visible = true;
                        label5.Text = sec.ToString() + "seconds Slept...";
                        Thread.Sleep(convert_ms);
                        try
                        {
                            Microsoft.VisualBasic.Interaction.AppActivate(txtProcess.Text);
                            if (checkBox1.Checked)
                            {
                                txt.Text += Environment.NewLine;
                                SendKeys.SendWait(txt.Text + "{ENTER}");
                            }
                            else
                            {
                                SendKeys.SendWait(txt.Text);
                            }
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("the Targetname is incorrect", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            bool canConvert = int.TryParse(txtInterval.Text,out var iio);
            if(canConvert && txtInterval.Text != "" && intervalchecked)
            {
                var time = int.Parse(txtInterval.Text);
                while (intervalchecked)
                {
                    Task.Delay(time);
                    try
                    {
                        Microsoft.VisualBasic.Interaction.AppActivate(txtProcess.Text);
                        if (checkBox1.Checked)
                        {
                            SendKeys.SendWait(txt.Text + "{ENTER}");
                        }
                        else
                        {
                            SendKeys.SendWait(txt.Text);
                        }
                    }
                    catch (Exception)
                    {
                        //MessageBox.Show("the Targetname is incorrect", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        public static int Count(string s,string ss)
        {
            return s.Length - s.Replace(ss.ToString(), "").Length;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtInterval.Enabled = false;
            label3.Enabled = false;
            intervalchecked = false;
            checkBox1.Checked = true;
            checktimer.Checked = false;
            label4.Enabled = false;
            textBox1.Enabled = false;
        }

        private void setinterval_CheckedChanged(object sender, EventArgs e)
        {
            if (setinterval.Checked)
            {
                txtInterval.Enabled = true;
                label3.Enabled = true;
                intervalchecked = true;
            }
            else
            {
                txtInterval.Enabled = false;
                label3.Enabled = false;
                intervalchecked = false;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void checktimer_CheckedChanged(object sender, EventArgs e)
        {
            if (checktimer.Checked)
            {
                label4.Enabled = true;
                textBox1.Enabled = true;
            }
            else
            {
                label4.Enabled = false;
                textBox1.Enabled = false;
            }
        }
    }
}
