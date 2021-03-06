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
           "Дж","кДж","МДж","ГДж","еВ","КеВ","МеВ","ГеВ","ТеВ","кал","ккал","Вт/сек","Вт/час","кВт/год","МВт/год"
        };   
        List<string> mass = new List<string>()
        {
            "г","кг","т","ц","а.о.м."
        };
        List<string> time = new List<string>()
        {
           "мс","мкс","нс", "с","хв","год","дні","роки"
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
            comboBox1.Enabled = true;
            comboBox2.Enabled = true;
            button2.Enabled = true;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Double Result = 0;
            Double left = 0;
            Double right = 0;
            try
            {
                Result = Convert.ToDouble(textBox1.Text);
            }
            catch
            {
                textBox1.Text = "Введіть значення!";
                textBox1.BackColor = Color.Brown;
                return;
            }
            switch (comboBox3.SelectedIndex)
            {
                case 0:
                    /* "Дж","кДж","МДж","ГДж","еВ","КеВ","МеВ","ГеВ","ТеВ","кал","ккал","Вт/сек","Вт/час","кВт/год","МВт/год" */
                    if (comboBox1.SelectedItem == comboBox2.SelectedItem)
                        label4.Text = "Некоректна дія!";

                        // якщо дж в ев і навпаки
                    else if((comboBox1.SelectedIndex >= 0 && comboBox1.SelectedIndex <= 3 && 
                        comboBox2.SelectedIndex >= 4 && comboBox2.SelectedIndex <= 8) ||
                        (comboBox2.SelectedIndex >= 0 && comboBox2.SelectedIndex <= 3 && 
                        comboBox1.SelectedIndex >= 4 && comboBox1.SelectedIndex <= 8))
                    {
                        switch (comboBox1.SelectedIndex)
                        {
                            case 0: left = 1; break;
                            case 1: left = 1E3; break;
                            case 2: left = 1E6; break;
                            case 3: left = 1E9; break;
                            case 4: left = 1; break;
                            case 5: left = 1E3; break;
                            case 6: left = 1E6; break;
                            case 7: left = 1E9; break;
                            case 8: left = 1E12; break;
                        }
                        switch (comboBox2.SelectedIndex)
                        {
                            case 0: right = 1; break;
                            case 1: right = 1E3; break;
                            case 2: right = 1E6; break;
                            case 3: right = 1E9; break;
                            case 4: right = 1; break;
                            case 5: right = 1E3; break;
                            case 6: right = 1E6; break;
                            case 7: right = 1E9; break;
                            case 8: right = 1E12; break;
                        }
                        /*if (left == right && comboBox1.SelectedItem != comboBox2.SelectedIndex)
                        {
                            Result *= 1.602176487E-19;
                        } */
                        if (left > right)
                        {
                            if (comboBox1.SelectedIndex <= 3)
                                Result = (Result / (right / left) * 6.2415096471204E+18);
                            else
                                Result = ((left / right) / 6.2415096471204E+18)*Result;                   
                        }          
                        else
                        {
                            if (comboBox1.SelectedIndex <= 3)
                                Result *= (left / right) * 6.2415096471204E+18;
                            else
                                Result *= (left / right) / 6.2415096471204E+18;
                        }
                        label4.Text = Convert.ToString(Result) + " " + comboBox2.SelectedItem;
                    }
                    //дж кдж мдж гдж ев кев мев гев тев
                    else if((comboBox1.SelectedIndex >= 0 && comboBox1.SelectedIndex <= 3 &&
                        comboBox2.SelectedIndex >= 0 && comboBox2.SelectedIndex <= 3
                        )|| (comboBox1.SelectedIndex >= 4 && comboBox1.SelectedIndex <= 8 && 
                        comboBox2.SelectedIndex >= 4 && comboBox2.SelectedIndex <= 8))
                    {
                       
                        switch (comboBox1.SelectedIndex)
                        {
                            case 0: left = 1; break;
                            case 1: left = 1E3; break;
                            case 2: left = 1E6; break;
                            case 3: left = 1E9; break;
                            case 4: left = 1; break;
                            case 5: left = 1E3; break;
                            case 6: left = 1E6; break;
                            case 7: left = 1E9; break;
                            case 8: left = 1E12; break; 
                        }
                        switch (comboBox2.SelectedIndex)
                        {
                            case 0: right = 1; break;
                            case 1: right = 1E3; break;
                            case 2: right = 1E6; break;
                            case 3: right = 1E9; break;
                            case 4: right = 1; break;
                            case 5: right = 1E3; break;
                            case 6: right = 1E6; break;
                            case 7: right = 1E9; break;
                            case 8: right = 1E12; break; 
                        }
                        if (left > right)
                            Result *= left / right;
                        else 
                            Result /= right / left;
                        label4.Text = Convert.ToString(Result) + " " + comboBox2.SelectedItem;
                    }
                    else if (comboBox1.SelectedIndex==1 && comboBox2.SelectedIndex==0)
                    {
                        Result *= 0.27777777777778;
                        label4.Text = Convert.ToString(Result) + " " + comboBox2.SelectedItem;
                    }
                    else if (comboBox1.SelectedIndex == 0 && comboBox2.SelectedIndex == 1)
                    {
                        Result *= 3.1556926E10;
                        label4.Text = Convert.ToString(Result) + " " + comboBox2.SelectedItem;
                    }
                    else if (comboBox1.SelectedIndex == 1 && comboBox2.SelectedIndex == 2)
                    {
                        Result *= 1.602176565E-19;
                        label4.Text = Convert.ToString(Result) + " "  +comboBox2.SelectedItem;
                    }
                    else if (comboBox1.SelectedIndex == 2 && comboBox2.SelectedIndex == 1)
                    {
                        Result *= 6.2415096471204E+18;
                        label4.Text = Convert.ToString(Result) + " " + comboBox2.SelectedItem;
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

        private void button4_Click(object sender, EventArgs e)
        {
            if (this.Controls.ContainsKey("helppanel1") == false)
            {
                Label[] convertor1 = new Label[10];

                for (int i = 0; i < 10; i++)
                {
                    convertor1[i] = new Label();
                    convertor1[i].Location = new Point(190, 94 + (i * 3) + (18 * i));
                    convertor1[i].ForeColor = Color.Black;
                    convertor1[i].BackColor = Color.LightGray;
                    convertor1[i].Name = "convertor1" + i.ToString();
                    convertor1[i].Font = new Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
                }
                convertor1[0].Text = "Дека   -  10\x00B9";
                convertor1[1].Text = "Гекто  -  10\x00B2";
                convertor1[2].Text = "Кіло   -  10\x00B3";
                convertor1[3].Text = "Мега   -  10\x2076";
                convertor1[4].Text = "Гіга   -  10\x2079";
                convertor1[5].Text = "Тера   -  10\x00B9\x00B2";
                convertor1[6].Text = "Пета   -  10\x00B9\x2075";
                convertor1[7].Text = "Екса   -  10\x00B9\x2078";
                convertor1[8].Text = "Зета   -  10\x00B2\x00B9";
                convertor1[9].Text = "Йота   -  10\x00B2\x2074";

                Panel helppanel1 = new Panel();
                helppanel1.Location = new Point(190, 94);
                helppanel1.Size = new Size(190, 245);
                helppanel1.BackColor = Color.Azure;
                helppanel1.Name = "helppanel1";

                Panel helppanel1_shadow = new Panel();
                helppanel1.Location = new Point(189, 93);
                helppanel1.Size = new Size(102, 214);
                helppanel1.BackColor = Color.Black;
                helppanel1.Name = "helppanel1_shadow";

                for (int i = 0; i < 10; i++)
                {
                    helppanel1.Controls.Add(convertor1[i]);
                    this.Controls.Add(convertor1[i]);
                }
                this.Controls.Add(helppanel1);
            }
        }
        private void button5_Click(object sender, EventArgs e)
        {
            if (this.Controls.ContainsKey("helppanel2") == false)
            {
                Label[] convertor2 = new Label[10];

                for (int i = 0; i < 10; i++)
                {
                    convertor2[i] = new Label();
                    convertor2[i].Location = new Point(244, 154 + (i * 3) + (20 * i));
                    convertor2[i].ForeColor = Color.Black;
                    convertor2[i].BackColor = Color.LightGray;
                    convertor2[i].Name = "convertor2" + i.ToString();
                    convertor2[i].Font = new Font("Consolas", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
                }
                convertor2[0].Text = "Деци - 10\x207B\x00B9";
                convertor2[1].Text = "Санти - 10\x207B\x00B2";
                convertor2[2].Text = "Мілі - 10\x207B\x00B3";
                convertor2[3].Text = "Мікро - 10\x207B\x2076";
                convertor2[4].Text = "Нано - 10\x207B\x2079";
                convertor2[5].Text = "Піко - 10\x207B\x00B9\x00B2";
                convertor2[6].Text = "Фемто - 10\x207B\x00B9\x2075";
                convertor2[7].Text = "Ато - 10\x207B\x00B9\x2078";
                convertor2[8].Text = "Зепто - 10\x207B\x00B2\x00B9";
                convertor2[9].Text = "Йокто - 10\x207B\x00B2\x2074";

                Panel helppanel2 = new Panel();
                helppanel2.Location = new Point(244, 144);
                helppanel2.Size = new Size(317, 245);
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
        private void timer1_Tick(object sender, EventArgs e)
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
        private void button3_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            this.textBox1.BackColor = Color.LightSteelBlue;
        }
    }
}
