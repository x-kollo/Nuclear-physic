using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
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

        List<string> energy = new List<string>()
        {
             "кВт/год","Джоулі","МеВ"
        };   
        List<string> mass = new List<string>()
        {
            "грами","кілограми","тони","центнери","а.о.м."
        };
        List<string> time = new List<string>()
        {
           "мілісекунди","мікросекунди","наносекунди", "cекунди","хвилини","години","дні","роки"
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
            }
        }
        private void OnTextBox_Enter(object sender, EventArgs e)
        {
            TextBox tbx = (TextBox)sender;
            tbx.Text = null;
            button2.Enabled = true;
         
        }
        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox3.SelectedIndex == 0)
            {
                comboBox1.Items.Clear();
                comboBox2.Items.Clear();
                for (int i = 0; i < energy.Count; i++)
                {
                    comboBox1.Items.Add(energy[i]);
                    comboBox2.Items.Add(energy[i]);
                }
            }
            if (comboBox3.SelectedIndex == 1)
            {
                comboBox1.Items.Clear();             
                comboBox2.Items.Clear();
                for (int i = 0; i < mass.Count;i++)
                {
                    comboBox1.Items.Add(mass[i]);
                    comboBox2.Items.Add(mass[i]);
                }
            }
            if (comboBox3.SelectedIndex == 2)
            {
                comboBox1.Items.Clear();
                comboBox2.Items.Clear();
                for (int i = 0; i < time.Count; i++)
                {
                    comboBox1.Items.Add(time[i]);
                    comboBox2.Items.Add(time[i]);
                }
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Double Result;
            Result = Convert.ToDouble(textBox1.Text);
            switch (comboBox3.SelectedIndex)
            {
                case 0:
                    if(comboBox1.SelectedIndex == comboBox2.SelectedIndex)
                    {
                        label4.Text = Convert.ToString(Result) + "  Дж";
                        label4.Visible = true;
                    }
                    break;
                case 1:
                    if (comboBox1.SelectedIndex == comboBox2.SelectedIndex)
                    {
                        label4.Text = Convert.ToString(Result) + "  кг";
                        label4.Visible = true;
                    }
                        break;
                case 2:
                    if (comboBox1.SelectedIndex == comboBox2.SelectedIndex)
                    {
                        label4.Text = Convert.ToString(Result) + "  год";
                        label4.Visible = true;
                    }
                    break;
            }
            }
        }
}
