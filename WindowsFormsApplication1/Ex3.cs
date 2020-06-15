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
        string[] TimeParams = { "-1", "-1", "-1" };
        string[] TextBoxTip = {
            " ", "Енергія (годВт)", "Енергія (МеВ)"
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

            for (int i = 1; i <= 2; i++)
            {
                if (tbx.Name == ("textBox" + 1))
                {
                    if (tbx.Text != "")
                    {
                        button2.Enabled = true;
                    }
                    else tbx.Text = TextBoxTip[i];
                }
                else if (tbx.Name == ("textBox" + 2))
                {
                    if (tbx.Text != "")
                    {
                        button3.Enabled = true;
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

        }
        private void OnTextBox_Change(object sender, EventArgs e)
        {
            TextBox tbx = (TextBox)sender;
            if (tbx.Name == "textBox1") TimeParams[1] = textBox1.Text;
            if (tbx.Name == "textBox2") TimeParams[2] = textBox2.Text;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            double Result;
            Result = Convert.ToDouble(TimeParams[1]);
            Result = Result * 0.1602176565;
            label4.Text = "Енергія в пікоДжоулях буде дорівнювати: " + Convert.ToString(Result) + " пДж";
            label4.Visible = true;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            double Result;
            Result = Convert.ToDouble(TimeParams[2]);
            Result = Result * 3600;
            label4.Text = "Енергія в кілоДжоулях буде дорівнювати: " + Convert.ToString(Result) + " кДж";
            label4.Visible = true;
        }
    }
}
