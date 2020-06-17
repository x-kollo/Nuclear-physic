using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Ex3 : Form
    {
        public event EventHandler updateEvent;
        string[] TextBoxTip = {
            " ", "МеВ", "кіловатгодини", "грами","Джоулі","Джоулі","а.о.м."
        };
        public Ex3()
        {
            InitializeComponent();
        }
        void form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Visible = false;
        }
        void handleUpdateEvent(object sender, EventArgs e)
        {
            this.BackColor = Color.Red;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Ex3 form1 = new Ex3();
            form1.updateEvent += new EventHandler(handleUpdateEvent);
            form1.Update();
            form1.FormClosed += new FormClosedEventHandler(form1_FormClosed);
            Visible = false;
        }
        private void OnTextBox_Leave(object sender, EventArgs e)
        {
            TextBox tbx = (TextBox)sender;

            for (int i = 1; i <= 6; i++)
            {
                if (tbx.Name == ("textBox" + 1))
                {
                    if (tbx.Text != "")
                    {
                        button2.Enabled = true;
                    }
                    else tbx.Text = TextBoxTip[i];
                }
                 if (tbx.Name == ("textBox" + 2))
                {
                    if (tbx.Text != "")
                    {
                        button3.Enabled = true;
                    }
                    else tbx.Text = TextBoxTip[i];
                }
                 if (tbx.Name == ("textBox" + 3))
                {
                    if (tbx.Text != "")
                    {
                        button4.Enabled = true;
                    }
                    else tbx.Text = TextBoxTip[i];
                }
                 if (tbx.Name == ("textBox" + 4))
                {
                    if (tbx.Text != "")
                    {
                        button5.Enabled = true;
                    }
                    else tbx.Text = TextBoxTip[i];
                }
                 if (tbx.Name == ("textBox" + 5))
                {
                    if (tbx.Text != "")
                    {
                        button6.Enabled = true;
                    }
                    else tbx.Text = TextBoxTip[i];
                }
                 if (tbx.Name == ("textBox" + 6))
                {
                    if (tbx.Text != "")
                    {
                        button7.Enabled = true;
                    }
                    else tbx.Text = TextBoxTip[i];
                }
            }
        }
        private void OnTextBox_Enter(object sender, EventArgs e)
        {
            TextBox tbx = (TextBox)sender;
            tbx.Text = null;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = true;
            button6.Enabled = true;
            button7.Enabled = true;
        }
        Double txtbvalue1 = 0;
        Double txtbvalue2 = 0;
        Double txtbvalue3 = 0;
        Double txtbvalue4 = 0;
        Double txtbvalue5 = 0;
        Double txtbvalue6 = 0;
        private void OnTextBox_Change(object sender, EventArgs e)
        {
            TextBox tbx = (TextBox)sender;
            if (tbx.Name == "textBox1" && tbx.Text != "")
            { txtbvalue1 = Convert.ToDouble(textBox1.Text); }
            else if (tbx.Name == "textBox2" && tbx.Text != "")
            { txtbvalue2 = Convert.ToDouble(textBox2.Text); }
            else if (tbx.Name == "textBox3" && tbx.Text != "")
            { txtbvalue3 = Convert.ToDouble(textBox3.Text); }
            else if (tbx.Name == "textBox4" && tbx.Text != "")
            { txtbvalue4 = Convert.ToDouble(textBox4.Text); }
            else if (tbx.Name == "textBox5" && tbx.Text != "")
            { txtbvalue5 = Convert.ToDouble(textBox5.Text); }
            else if (tbx.Name == "textBox6" && tbx.Text != "")
            { txtbvalue6 = Convert.ToDouble(textBox6.Text); }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Double Result;
            Result = txtbvalue1;
            Result = Result * 0.1602176565;
            label4.Text = Convert.ToString(Result) + "  пДж";
            label4.Visible = true;
        }
        private void button3_Click_1(object sender, EventArgs e)
        {
            Double Result;
            Result = txtbvalue2;
            Result = Result * 3600;
            label5.Text = Convert.ToString(Result) + "  кДж";
            label5.Visible = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Double Result;
            Result = txtbvalue3;
            Result = Result * 0.60221417912066701211790570510273;
            label6.Text = Convert.ToString(Result) + "  а.о.м.";
            label6.Visible = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Double Result;
            Result = txtbvalue4;
            Result = Result / 3.6;
            label10.Text = Convert.ToString(Result) + "  годинват";
            label10.Visible = true;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Double Result;
            Result = txtbvalue5;
            Result = Result * 0.1602176565;
            label11.Text = Convert.ToString(Result) + "  ексаеВ";
            label11.Visible = true;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Double Result;
            Result = txtbvalue6;
            Result = Result * 1.66053878283;
            label12.Text = Convert.ToString(Result) + "  йоктограм";
            label12.Visible = true;
        }
    }
}
