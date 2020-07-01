﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApplication1.Properties;

namespace WindowsFormsApplication1
{
    public partial class Ex3 : Form
    {
        public event EventHandler updateEvent;
        string[] TextBoxTip = {
            "", "МеВ", "кіловатгодини", "грами","Джоулі","Джоулі","а.о.м."
        };
        string[] answers00 = {
            " кВт/год"," Дж"," МеВ "
        };
        string[] answers01 = {
            " мВат/год"," МДж"," МеВ "," пДж"
        };
        string[] answers10 = {
            " г"," кг"," тон"," центнерів"," а.о.м."
        };
        string[] answers11 = {
            " г"," кг"," тон"," центнерів","йокта а.о.м."
        };
        string[] answers20 = {
            " ",
        };
        string[] answers21 = {
            " ",
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
        private bool isCollapsed ;
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
                        label4.Text = Convert.ToString(Result) + answers00[comboBox2.SelectedIndex];
                    }

                    else if (comboBox1.SelectedIndex==1&& comboBox2.SelectedIndex==0)
                    {
                        Result *= 0.27777777777778;
                        label4.Text = Convert.ToString(Result) + answers01[comboBox2.SelectedIndex];
                    }
                    else if (comboBox1.SelectedIndex == 0 && comboBox2.SelectedIndex == 1)
                    {
                        Result *= 3.6;
                        label4.Text = Convert.ToString(Result) + answers01[comboBox2.SelectedIndex];
                    }
                    else if (comboBox1.SelectedIndex == 1 && comboBox2.SelectedIndex == 2)
                    {
                        Result *= 6241509647120.4;
                        label4.Text = Convert.ToString(Result) + answers01[comboBox2.SelectedIndex];
                    }
                    else if (comboBox1.SelectedIndex == 2 && comboBox2.SelectedIndex == 1)
                    {
                        Result *= 0.1602176487;
                        label4.Text = Convert.ToString(Result) + answers01[comboBox2.SelectedIndex + comboBox1.SelectedIndex];
                    }

                    else
                    {
                        label4.Text = "Некоректна дія!";
                    }
                    break;

                case 1:
                    if (comboBox1.SelectedIndex == comboBox2.SelectedIndex)
                    {
                        label4.Text = Convert.ToString(Result) + answers10[comboBox2.SelectedIndex];
                    }

                    else if (comboBox1.SelectedIndex == 0 && comboBox2.SelectedIndex == 4)
                    {
                        Result *= 602.21366516752;
                        label4.Text = Convert.ToString(Result) + answers11[comboBox2.SelectedIndex];
                    }
                    else if (comboBox1.SelectedIndex == 1 && comboBox2.SelectedIndex == 4)
                    {
                        Result *= 0.60221366516752;
                        label4.Text = Convert.ToString(Result) + answers11[comboBox2.SelectedIndex];
                    }

                    else
                    {
                        label4.Text = "Некоректна дія!";
                    }
                    break;

                case 2:
                    if (comboBox1.SelectedIndex == comboBox2.SelectedIndex)
                    {
                        label4.Text = Convert.ToString(Result) + answers20[comboBox2.SelectedIndex];
                    }



                    else
                    {
                        label4.Text = "Некоректна дія!";
                    }
                    break;

            }
            label4.Visible = true;
        }

       /* private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                this.Controls["panel1"].Visible = false;
                for (int i = 0; i < 10; i++)
                {
                    this.Controls["convertor2" + i.ToString()].Visible = false;
                }
            }
            catch { }
        }*/

        private void toolStripLabel1_Click_1(object sender, EventArgs e)
        {
            if (this.Controls.ContainsKey("helppanel1") == false)
            {
                Label[] convertor1 = new Label[10];

                for (int i = 0; i < 10; i++)
                {
                    convertor1[i] = new Label();
                    convertor1[i].Location = new Point(10, 37 + (i * 3) + (20 * i));
                    convertor1[i].ForeColor = Color.Black;
                    convertor1[i].BackColor = Color.LightGray;
                    convertor1[i].Name = "convertor1" + i.ToString();
                    convertor1[i].Font = new Font("Consolas", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
                }
                convertor1[0].Text = "Дека - 10<sup>1</sup>";
                convertor1[1].Text = "Гекто - ";
                convertor1[2].Text = "Кіло - ";
                convertor1[3].Text = "Мега - ";
                convertor1[4].Text = "Гіга - ";
                convertor1[5].Text = "Тера - ";
                convertor1[6].Text = "Пета - ";
                convertor1[7].Text = "Екса - ";
                convertor1[8].Text = "Зета -  ";
                convertor1[9].Text = "Йота - ";

                Panel helppanel1 = new Panel();
                helppanel1.Location = new Point(12, 33);
                helppanel1.Size = new Size(195, 354);
                helppanel1.BackColor = Color.LightGray;
                helppanel1.Name = "helppanel1";

                for (int i = 0; i < 10; i++)
                {
                    helppanel1.Controls.Add(convertor1[i]);
                    this.Controls.Add(convertor1[i]);
                }
                this.Controls.Add(helppanel1);
            }
        }

        private void toolStripLabel2_Click_1(object sender, EventArgs e)
        {
            if (this.Controls.ContainsKey("helppanel2") == false)
            {
                Label[] convertor2 = new Label[10];

                for (int i = 0; i < 10; i++)
                {
                    convertor2[i] = new Label();
                    convertor2[i].Location = new Point(10, 37 + (i * 3) + (20 * i));
                    convertor2[i].ForeColor = Color.Black;
                    convertor2[i].BackColor = Color.LightGray;
                    convertor2[i].Name = "convertor2" + i.ToString();
                    convertor2[i].Font = new Font("Consolas", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
                }
                convertor2[0].Text = "Деци - 10<sup>-1</sup>";
                convertor2[1].Text = "Санти - ";
                convertor2[2].Text = "Мілі - ";
                convertor2[3].Text = "Мікро - ";
                convertor2[4].Text = "Нано - ";
                convertor2[5].Text = "Піко - ";
                convertor2[6].Text = "Фемто - ";
                convertor2[7].Text = "Ато - ";
                convertor2[8].Text = "Зепто - ";
                convertor2[9].Text = "Йокто - ";

                Panel helppanel2 = new Panel();
                helppanel2.Location = new Point(30, 35);
                helppanel2.Size = new Size(200, 404);
                helppanel2.BackColor = Color.LightGray;
                helppanel2.Name = "helppanel2";

                for (int i = 0; i < 10; i++)
                {
                    helppanel2.Controls.Add(convertor2[i]);
                    this.Controls.Add(convertor2[i]);
                }
                this.Controls.Add(helppanel2);
            }
        }
        private void timer1_Tick_1(object sender, EventArgs e)
        {
            if (isCollapsed)
            {
                button3.Image = Resources.Collapse_Arrow_20px;
                panelDropDawn.Height += 10;
                if (panelDropDawn.Size == panelDropDawn.MaximumSize)
                {
                    timer1.Stop();
                    isCollapsed = false;
                }
            }
            else
            {
                button3.Image = Resources.Expand_Arrow_20px;
                panelDropDawn.Height -= 10;
                if (panelDropDawn.Size == panelDropDawn.MinimumSize)
                {
                    timer1.Stop();
                    isCollapsed = true;
                }
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            timer1.Start();
        }
    }
}
