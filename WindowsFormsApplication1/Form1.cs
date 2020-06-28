using System;
using System.IO;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.Generic;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        static public Dictionary<string, Double> period = new Dictionary<string, Double>();
        static public Dictionary<string, Double> mass = new Dictionary<string, Double>();
        Double[] AtomMass = 
        {
            1.007,4.002602,6.941,9.0121,10.811,
            12.0096,14.007,15.99,18.99,20.17,22.98, 24.30,26.98,28.08,30.97,
            32.06,35.45,39.94,39.09,40.078,44.95,47.8, 50.94,51.99,54.93,55.84,
            58.93,58.69//Ni
        };
        Double[] Periods = { //in secs 
            -1, 0,0,387892800, // H1-H3
            0,0, //He3-He4
            91E-24,370E-24,0,0,0.8403,0.1783,2E-21,3.7E-21,1.35E-21,0.00875,1E-8, // Li4-Li14
            5E-21,4598208,6.7E-17,0,43835040000596,	13.81,0.02149,2.7E-21,0.00484,200E-8,200E-8,0, //Be5-Be17
            0,350E-21,0.77,800E-21,0,0,0.0202,0.01732,0.0125,0.00987,190E-12,0.00508,26E-8,0.00292, //B6-B19
            1200,0,0,180701280002,//C11-C14
            600,0,0, // N13-N15
            -1,//O
            0,410E-24,11E-21,64.49,6586.25,234E-8,0,11.163,4.158,4.23,2.23,0.4,0.05,0.0102,0.0049,40E-8,2.6E-8,260E-8,0.001, //F14-F31
            9E-21,0.1092,1.672,17.296,0,0,0,37.24,202.8,0.602,0.197,0.032,0.0183,0.0156,0.0058,0.0034,0.0035,260E-8,0.001, //Ne16-Ne34
            1.3E-21,40E-8,0.4479,22.49,82078747.2,244E-8,0,53852.4,0.0202,59.1,	1.077,0.301,0.0305,0.0449,0.0484,0.017,0.0129,0.0081,0.0055,0.0015,260E-8,0.001, //Na18-Na37 
            0,0.0908,0.122,3.8755,11.317,0,0,0,567.48,1254.9,1.30,0.335,0.23,0.086,0.0905,0.02,0.07,0.0039,0.04,0.001,260E-8,0.001, //Mg19-Mg40
            35E-8,59E-8,0.47,0.35,2.053,0.1313,	7.183,22611312000307,6.3452,0,134.484,393.6,3.60,0.644,0.0317,200E-8,0.0417,0.0563,0.0386,0.09,0.0107,0.0076,0.0076,0.01,0.002,0.0001,170E-8,//Al21-Al43
            0.029,0.042,0.14,0.22,2.234,4.16,0,0,0,9438,5361120000,6.18,2.77,0.78,0.45,0.09,0.09,0.0475,0.033,0.02,0.013,0.015,0.01, //Si22-Si44
            0,30E-8,0.0437,0.26,0.2703,4.142,149.88,0,1232323.2,2189376,12.43,47.3,5.6,2.31, 0.64,0.19,0.53,0.1,0.0485,0.0365,0.0185,0.008,0.004,0, //P24-P47
            0.01,0.0155,0.125,0.187,1.178,2.572,0,0,0,7560864,0,303,10218,11.5,8.8,1.99,1.013,0.26,480E-8,0.1,0.068,0.05,0.02,0.01,200E-8,//S26-S49
            0,20E-8,30E-8,0.15,0.298,2.511,1.5264,1920,0,9492336000129,0,2234.4,0.715,3336,81,38.4,6.8,3.07,0.56,0.4,0.232,0.101,0.1,0.05,0.02,0.002,//Cl28-Cl51
            20E-8,0.014,0.098,0,0.173,0.845,1,775,0,3027456,0,8483184000,0,6576.6,1037534400,322.2,712.2,21.48,8.4,0.58,0.5,0.17,0.085,0.06,0.01,0.003,//Ar30-Ar53
            0,39356928000535256,//K39-K40
            3216672000043,0,0,0,14054688,0, //Ca41-Ca46
            0,0.318,7239456,//Sc45-Sc47
            1892160000,11088,0,0,0,0,0,345.6,102,//Ti44-Ti52
            1380110.4,28425600,4.7304000000643337E+24,0,//V48-V51
            0,2393496,0,0,0,209.82,//Cr50-Cr55
            483062.4,1266,117944640001604,26959392,0,//Mn52-Mn55
            29790,45.9,510.6,//Fe52-Fe54
            0,166235716.8,//Сo59-Co60
            0,2396736000032.5,0,0,0,3156753600,0//Ni58-Ni64


      };
        public Form1()
        {
           InitializeComponent();

           for (int i = 1; i < 28; i++) // // 29 to NameOfElements.Lenght;
           {
               for (int j = IzotopsBegin[i - 1]; j <= IzotopsEnd[i - 1]; j++)
                   period.Add(NameOfElements[i] + j, Periods[i + j - 1]);
           }
           for (int i = 0; i < 28; i++)  // 29 to NameOfElements.Lenght;
               mass.Add(NameOfElements[i], AtomMass[i]);
        }

        bool[] IzotopAccessTable ={ //DONE 17
        true,true,true,true,true,true,true,false,true,true,true,true,true,true,true, //15 
        true,true,true,true,true,true,true,true,true,true,true,true,true,false,false,
        false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,
        false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,
        false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,
        false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,
        false,true,false,false,false,false,false,false,false,false,false,false,false,false,false,
        false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,
        false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,
        false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,

        };

        int[] IzotopsBegin = {
        1,3, 4, 5, 6,11,13,0,14,16,18,19,21,22,24,26,28,30,39,41,45,44,48,50,52,52,59,58
         };
        int[] IzotopsEnd = {
        3,4,14,17,19,14,15,0,31,34,37,40,43,44,47,49,51,53,40,46,47,52,51,55,55,54,60,64
         };
        string[] TimeParams = { "-1", "-1", "-1", "-1", "-1", "-1" };
     
        int SelectedElement;
        Int32 ex = 0;
        
        string[] NameOfElements = {
            " ","H","He",
            "Li","Be","B","C","N","O","F","Ne",
            "Na","Mg","Al","Si","P","S","Cl","Ar",
            "K", "Ca","Sc","Ti","V","Cr","Mn","Fe","Co","Ni",
            "Cu", "Zn","Ga","Ge","As","Se","Br","Kr",
            "Rb","Sr","Y","Zr","Nb","Mo","Tc","Ru","Rh","Pd",
            "Ag","Cd","In","Sn","Sb","Te","I","Xe",
            "Cs","Ba","La",/*Написати лантаноїди*/
            "Hf","Ta","W","Re","Os","Ir","Pt",
            "Au","Hg","Ti","Pb","Bi","Po","At","Rn",
            "Fr","Ra","Ac",/*актиноїди*/
            "Rf","Db","Sg","Bh","Hs","Mt","Ds",
            "Rg","Cn","Nh","Fl","Mc","Lv","Ts","Og"
        };
        
        string[] FullNameOfElement = {
        
        "Гідроген", "Гелій", "Літій","Берилій","Бор","Вуглець","Азот","Кисень",
        "Фтор","Неон","Натрій","Магній","Алюміній","Силіцій","Фосфор","Сульфур","Хлор",
        "Аргон","Калій","Кальцій","Скандій","Титан","Ванадій","Хром","Манган","Ферум",
        "Кобальт","Нікель","Купрум","Цинк","Галій","Германій","Арсен","Селен","Бром","Криптон",
        "Рубідій","Стронцій","Ітрій","Цирконій","Ніобій","Молібден","Технецій","Рутеній","Родій",
        "Паладій","Аргентум","Кадмій","Індій","Станум","Стибій","Телур","Йод","Ксенон","Цезій",
        "Барій",
        "Лантан","Церій","Празеодим","Неодим","Прометій","Самарій","Європій","Гадоліній","Тербій",
        "Диспрозій","Гольмій","Ербій","Тулій","Ітербій","Лютецій",
        "Гафній","Тантал","Вольфрам","Реній","Осмій","Іридій","Платина","Аурум","Ртуть","Талій",
        "Плюмбум", "Бісмут","Полоній","Астат","Радон","Францій","Радій",
        "Актиній","Торій","Протактиній","Уран","Нептуній","Плутоній","Америцій","Кюрій","Берклій","Каліфорній",
        "Ейнштейній","Фермій","Менделевій","Нобелій","Лоуренсій",
        "Резерфордій","Дубній","Сіборгій","Борій","Гасій","Майтнерій","Дармштадтій","Рентгеній","Коперницій","Ніхоній","Флеровій",
        "Московій","Ліверморій","Теннессин","Оганесон"
        };

        //хммм може в періоди замутити тіпа <час_розпаду>*<ізотоп_і_назва_елемента> і убибати *-> або <-* 
        //і смотря шо треба,чи назву чи період шукати так по масиву  
        //P.S 3:54 сверх генільні мислі Богдана     

                
        double[] energypernucleon =
        {
            1.1,//H
            7.074,//He
            5.606,
            6.463,
            6.928,
            7.68,
            7.475,
            7.976,
            7.779,
            7.972,
            8.112,
            8.26,
            8.332,//Al
            8.38,
            8.481,
            8.583,
            8.57,
            8.614,
            8.576,
            8.6,
            8.619,
            8.723,
            8.696,
            8.776,
            8.765,
            8.79,
            8.768,
            8.765,//Ni
        };
        string[] TextBoxTip = {
            " ", "МАССА (г)", "РОКИ", "ДНІ","ГОДИНИ","СЕКУНДИ"
        };

        public event EventHandler updateEvent;
        void form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Visible = true;
        }
        void handleUpdateEvent(object sender, EventArgs e)
        {
            this.BackColor = Color.Red;
        }
        void ShowCodingForm(int I_Begin, int I_End)
        {
            period.Clear();
            mass.Clear();
            Izotop form2 = new Izotop(IzotopsBegin[SelectedElement], IzotopsEnd[SelectedElement], IzotopsEnd[SelectedElement] - IzotopsBegin[SelectedElement] + 1,NameOfElements[SelectedElement+1]);    
            form2.updateEvent += new EventHandler(handleUpdateEvent);
            form2.FormClosed += new FormClosedEventHandler(form2_FormClosed);
            Visible = false;
            form2.Show();
        }
        private void button90_Click(object sender, EventArgs e)
        {
            pictureBox1.Visible = false;
            button95.Visible = true;
            button94.Visible = true;
            button93.Visible = true;
            button90.Visible = false;
        }
        private void Button95_Click(object sender, EventArgs e)
        {
            pictureBox1.Visible = false;
            string Addres = "img\\";
            Addres = Addres + NameOfElements[SelectedElement + 1] + "_A.jpg";
            string curFile = @"c:\git\Nuclear-physic\WindowsFormsApplication1\bin\Debug\img\";
            curFile = curFile + NameOfElements[SelectedElement + 1] + "_A.jpg";
            if (File.Exists(curFile))
            {
                pictureBox1.Image = Image.FromFile(Addres);
                pictureBox1.Visible = true;
                button95.Visible = false;
                button94.Visible = false;
                button93.Visible = false;
                button90.Visible = true;
            }
            else
            {
                Addres = "img\\";
                Addres = Addres + "error.jpg";
                pictureBox1.Image = Image.FromFile(Addres);
                pictureBox1.Visible = true;
                button95.Visible = false;
                button94.Visible = false;
                button93.Visible = false;
                button90.Visible = true;
            }
        }

        private void Button94_Click(object sender, EventArgs e)
        {
            pictureBox1.Visible = false;
            string Addres = "img\\";
            Addres = Addres + NameOfElements[SelectedElement + 1] + "_H.jpg";
            string curFile = @"c:\git\Nuclear-physic\WindowsFormsApplication1\bin\Debug\img\";
            curFile = curFile + NameOfElements[SelectedElement + 1] + "_H.jpg";
            if (File.Exists(curFile))
            {
                pictureBox1.Image = Image.FromFile(Addres);
                pictureBox1.Visible = true;
                button95.Visible = false;
                button94.Visible = false;
                button93.Visible = false;
                button90.Visible = true;
            }
            else
            {
                Addres = "img\\";
                Addres = Addres + "error.jpg";
                pictureBox1.Image = Image.FromFile(Addres);
                pictureBox1.Visible = true;
                button95.Visible = false;
                button94.Visible = false;
                button93.Visible = false;
                button90.Visible = true;
            }
        }

        private void Button93_Click(object sender, EventArgs e)
        {
            pictureBox1.Visible = false;
            string Addres = "img\\";
            Addres = Addres + NameOfElements[SelectedElement + 1] + "_T.jpg";
            string curFile = @"c:\git\Nuclear-physic\WindowsFormsApplication1\bin\Debug\img\";
            curFile = curFile + NameOfElements[SelectedElement + 1] + "_T.jpg";
            if (File.Exists(curFile))
            {
                pictureBox1.Image = Image.FromFile(Addres);
                pictureBox1.Visible = true;
                button95.Visible = false;
                button94.Visible = false;
                button93.Visible = false;
                button90.Visible = true;
            }
            else
            {
                Addres = "img\\";
                Addres = Addres + "error.jpg";
                pictureBox1.Image = Image.FromFile(Addres);
                pictureBox1.Visible = true;
                button95.Visible = false;
                button94.Visible = false;
                button93.Visible = false;
                button90.Visible = true;
            }
        }
        Int32 ex2 = 0;
        private void OnClickButton_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            for (int i = 1; i <= 135; i++)
            {
                if (btn == button57)
                {
                    panel2.Visible = false;
                    if (panel1.Visible == true)
                        panel1.Visible = false;
                    else panel1.Visible = true;
                    break;
                }
                if(btn == button75)
                {
                    panel1.Visible = false;
                    if (panel2.Visible == true)
                        panel2.Visible = false;
                    else panel2.Visible = true;
                    break;
                }
                else
                {
                    panel1.Visible = false;
                    panel2.Visible = false;
                }
                if (btn.Name == ("button" + i))
                {
                    if (btn.TabIndex == 998 || btn.TabIndex == 999)
                        break;
                    button91.Text = FullNameOfElement[btn.TabIndex].ToUpper();
                    button91.BackColor = btn.BackColor;
                    button83.Text = btn.Text;
                    button83.BackColor = btn.BackColor;
                    SelectedElement = btn.TabIndex;
                    izotopbtn.Text = Program.Element;
                    izotopbtn.BackColor = Color.LightSkyBlue;
                    ex2 = i;
                    break;
                }
            }
            for (int i = 0; i <= 135; i++)
            {
                if (IzotopAccessTable[SelectedElement] == true) button89.Visible = true;
                else button89.Visible = false;
            }
            button95.Visible = true;
            button94.Visible = true;
            button93.Visible = true;
            pictureBox1.Visible = false; 
        }
        private void button89_Click(object sender, EventArgs e)
        {
            ShowCodingForm(IzotopsBegin[SelectedElement], IzotopsEnd[SelectedElement]);
        }

        private void OnTextBox_Enter(object sender, EventArgs e)
        {
            TextBox tbx = (TextBox)sender;
            tbx.Text = null;
            button84.Enabled = true;
        }
        private void OnTextBox_Leave(object sender, EventArgs e)
        {
            TextBox tbx = (TextBox)sender;

            for (int i = 1; i <= 5; i++)
            {
                if (tbx.Name == ("textBox" + i))
                {
                    if (tbx.Text != "")
                    {
                        button84.Enabled = true;

                        //    break;
                    }
                    else tbx.Text = TextBoxTip[i];
                }
            }
        }
        private void OnTextBox_Change(object sender, EventArgs e)
        {
            TextBox tbx = (TextBox)sender;

            if (tbx.Name == "textBox1" && tbx.Text != null) TimeParams[1] = textBox1.Text;
            if (tbx.Name == "textBox2" && tbx.Text != null) TimeParams[2] = textBox2.Text;
            if (tbx.Name == "textBox3" && tbx.Text != null) TimeParams[3] = textBox3.Text;
            if (tbx.Name == "textBox4" && tbx.Text != null) TimeParams[4] = textBox4.Text;
            if (tbx.Name == "textBox5" && tbx.Text != null) TimeParams[5] = textBox5.Text;
        }

        private void button84_Click(object sender, EventArgs e)    //result line
        {
            switch(ex)
            {
                case 1:
                {
                    Double C_Years, C_Days, C_Hours;
                    C_Years = Convert.ToDouble(TimeParams[2]) * 365 * 24 * 60 * 60;
                    //     C_Month = Convert.ToInt32(TimeParams[2]) * 24 * 60 * 60;
                    C_Days = Convert.ToDouble(TimeParams[3]) * 24 * 60 * 60;
                    C_Hours = Convert.ToDouble(TimeParams[4]) * 60 * 60;

                    //4.5 = період з Period[]
                    //238 поняв шо
                    //timeparams[1] = маса

                    // час треба перевести в секунди
                    // 0.235 молярна маса
                    Double Result;
                    Result = (6.02 * 1E23); // скільки атомів в заданій масі
                    Result = ((Convert.ToDouble(TimeParams[1]) / 1000) / (mass[NameOfElements[SelectedElement + 1]] / 1000)) * Result;
                    Double N0 = Result;
      
                    Double time = C_Years + C_Days + C_Hours + Convert.ToDouble(TimeParams[5]);
                    if (Program.Element == null)
                    {
                        label8.Text = "ВИБЕРІТЬ ІЗОТОП!";
                        label8.Visible = true;
                        break;
                    }
                    if(period[Program.Element] == 0)
                    {
                        label8.Text = "ІЗОТОП СТАБІЛЬНИЙ!";
                        label8.Visible = true;
                        break;
                    }
                    Double ttime = period[Program.Element];
                    Double temp = (Math.Pow(2.71828182846, (time*-0.69 / ttime)));
                    Result = N0 - (N0 * temp); // N0 * temp - скільки НЕ роспалось

                    if ((N0 * temp) <= 1 || Result < 1E-1)
                    {
                        label8.Text = "ВСІ ЯДРА РОЗПАЛИСЬ";
                        label8.Visible = true;
                    }
                    else if ((N0 * temp) > 0)
                    {
                        label8.Text = "РОЗПАДЕТЬСЯ: " + Convert.ToString(Result) + " ЯДЕР\nЗАЛИШИТЬСЯ: " + Convert.ToString(N0 * temp);
                        label8.Visible = true;
                    }
                 
                    break;
                }
                case 2:
                {
                    double Result;
                    Result = Convert.ToDouble(TimeParams[1]);
                    Result *= energypernucleon[ex2-1];
                    label8.Text = "Енергія на нуклон буде дорівнювати: " + Convert.ToString(Result)+"MeB";
                    label8.Visible = true;
                    break;
                }
                default:
                    break;
            }
           
        }

        private void button85_Click(object sender, EventArgs e)
        {
            textBox1.Visible = true;
            textBox2.Visible = true;
            textBox3.Visible = true;
            textBox4.Visible = true;
            textBox5.Visible = true;
            label6.Visible = true;
            button84.Visible = true;
            button85.Visible = false;
            button86.Visible = false;
            button87.Visible = false;
            button88.Visible = true;
            ex = 1;
        }

        private void button88_Click(object sender, EventArgs e)
        {
            /* hide buttons EX  */
            textBox1.Visible = false;
            textBox2.Visible = false;
            textBox3.Visible = false;
            textBox4.Visible = false;
            textBox5.Visible = false;
            label6.Visible = false;
            label8.Visible = false;
            button84.Visible = false;
            button85.Visible = true;
            button86.Visible = true;
            button87.Visible = true;
            button88.Visible = false;
            button84.Visible = false;
            ex = 0;
        }

        private void button86_Click(object sender, EventArgs e)
        {
            //ex 2.
            textBox1.Visible = true;
            textBox2.Visible = false;
            textBox3.Visible = false;
            textBox4.Visible = false;
            textBox5.Visible = false;
            label6.Visible = false;
            button84.Visible = false;
            button85.Visible = false;
            button86.Visible = false;
            button87.Visible = false;
            button88.Visible = true;
            button84.Visible = true;
            ex = 2;
        }
        void form3_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Visible = true;
        }
        void Showform3()
        {
            Ex3 form3 = new Ex3();
      
            form3.updateEvent += new EventHandler(handleUpdateEvent);
            form3.FormClosed += new FormClosedEventHandler(form3_FormClosed);
            this.Visible = false;
            form3.Show();
        }
        private void button87_Click(object sender, EventArgs e)
        {
            Showform3();
        }
     /*   private void FormClick(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = false;
            try
            {
                this.Controls["infopanel"].Visible = false;
                this.Controls["infopanel_shadow"].Visible = false;
                for (int i = 0; i < 10; i++)
                {
                    this.Controls["infotext" + i.ToString()].Visible = false;
                    this.Controls["infocolored" + i.ToString()].Visible = false;
                }
            }
            catch { }
        }*/

        private void інформаціяToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(this.Controls.ContainsKey("infopanel") == false)
            {
                Panel[] info_colored_panel = new Panel[10];
                Label[] info_text = new Label[10];

                for (int i = 0; i < 10; i++)
                {
                    info_text[i] = new Label();
                    info_text[i].Location = new Point(588, 37 + (i * 3) + (25 * i));
                    info_text[i].ForeColor = Color.Black;
                    info_text[i].BackColor = Color.LightGray;
                    info_text[i].Name = "infotext" + i.ToString();
                    info_text[i].Font = new Font("Consolas", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
                }
                for (int i = 0; i < 10; i++)
                {
                    info_colored_panel[i] = new Panel();
                    info_colored_panel[i].Location = new Point(558, 33 + (i * 3) + 25 * i);
                    info_colored_panel[i].Size = new Size(25, 25);
                    info_colored_panel[i].BackColor = Color.Green;
                    info_colored_panel[i].Name = "infocolored" + i.ToString();
                }
                info_text[0].Text = "ЛУЖНІ МЕТАЛИ";
                info_text[1].Text = "ЛУЖНОЗЕМЕЛЬНІ МЕТАЛИ";
                info_text[2].Text = "НАПІВМЕТАЛИ";
                info_text[3].Text = "МЕТАЛИ";
                info_text[4].Text = "ПЕРЕХІДНІ МЕТАЛИ";
                info_text[5].Text = "НЕМЕТАЛИ";
                info_text[6].Text = "ГАЛОГЕНИ";
                info_text[7].Text = "ІНЕРТНІ ГАЗИ";
                info_text[8].Text = "ЛАНТАНАЇДИ";
                info_text[9].Text = "АКТИНОЇДИ";


                info_colored_panel[0].BackColor = Color.Crimson;
                info_colored_panel[1].BackColor = Color.Gold;
                info_colored_panel[2].BackColor = Color.Olive;
                info_colored_panel[3].BackColor = Color.Silver;
                info_colored_panel[4].BackColor = Color.Khaki;
                info_colored_panel[5].BackColor = Color.LawnGreen;
                info_colored_panel[6].BackColor = Color.Yellow;
                info_colored_panel[7].BackColor = Color.Aqua;
                info_colored_panel[8].BackColor = Color.MediumOrchid;
                info_colored_panel[9].BackColor = Color.MediumPurple;

                Panel infopanel = new Panel();
                infopanel.Location = new Point(555, 30);
                infopanel.Size = new Size(240, 284);
                infopanel.BackColor = Color.LightGray;
                infopanel.Name = "infopanel";
                Panel infopanel_shadow = new Panel();
                infopanel_shadow.Location = new Point(554, 29);
                infopanel_shadow.Size = new Size(242, 286);
                infopanel_shadow.BackColor = Color.Crimson;
                infopanel_shadow.Name = "infopanel_shadow";

                for (int i = 0; i < 10; i++)
                {
                    infopanel.Controls.Add(info_colored_panel[i]);
                    this.Controls.Add(info_colored_panel[i]);
                }

                for (int i = 0; i < 10; i++)
                {
                    infopanel.Controls.Add(info_text[i]);
                    this.Controls.Add(info_text[i]);
                }

                this.Controls.Add(infopanel);
                this.Controls.Add(infopanel_shadow);  
            }
            else
            {
                this.Controls["infopanel"].Visible = true;
                this.Controls["infopanel_shadow"].Visible = true;
                for (int i = 0; i < 10; i++)
                {
                    this.Controls["infotext" + i.ToString()].Visible = true;
                    this.Controls["infocolored" + i.ToString()].Visible = true;
                }
            }
            button125.Visible = true;
        }
        private void button125_Click(object sender, EventArgs e)
        {
                panel1.Visible = false;
                panel2.Visible = false;
                try
                {
                    this.Controls["infopanel"].Visible = false;
                    this.Controls["infopanel_shadow"].Visible = false;
                    for (int i = 0; i < 10; i++)
                    {
                        this.Controls["infotext" + i.ToString()].Visible = false;
                        this.Controls["infocolored" + i.ToString()].Visible = false;
                    }
                }
                catch { }
            button125.Visible = false;
        }
    }
}
