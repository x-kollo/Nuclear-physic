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

    public partial class Izotop : Form
    {
        public event EventHandler updateEvent;

        string[] NameOfElements = {                                         
            " ","H","He",
            "Li","Be","B","C","N","O","F","Ne",
            "Na","Mg","Al","Si","P","S","Cl","Ar",
            "K", "Ca","Sc","Ti","V","Cr","Mn","Fe","Co","Ni",
            "Cu", "Zn","Ga","Ge","As","Se","Br","Kr",
            "Rb","Sr","Y","Zr","Nb","Mo","Tc",
            "Ag","Cd","In","Sn","Sb","Te","I","Xe",
            "Cs","Ba","*La","Hf","Ta","W","Re",
            "Au","Hg","Ti","Pb","Bi","Po","At","Rn",
        };

        public int I_Begin;
        public int I_End;
        public int Limit;
        public string I_Name;
        bool[] IzotopShown = {
                                 false,false,false,
                                 false,false,false,
                                 false,false,false
                             };
        public Izotop(int I_Begin, int I_End, int Limit, string I_Name)
        {
            InitializeComponent();
            for (int i = I_Begin; i <= I_End; i++)
            {

                if (button0.TabIndex == 0 && Limit > 0 && IzotopShown[0] == false)
                {
                    button0.Text = i + I_Name;
                    button0.Visible = true;
                    Limit--;
                    IzotopShown[0] = true;
                }
                else if (button1.TabIndex == 1 && Limit > 0 && IzotopShown[1] == false)
                {
                    button1.Text = i + I_Name;
                    button1.Visible = true;
                    Limit--;
                    IzotopShown[1] = true;
                }
                else if (button2.TabIndex == 2 && Limit > 0 && IzotopShown[2] == false)
                {
                    button2.Text = i + I_Name;
                    button2.Visible = true;
                    Limit--;
                    IzotopShown[2] = true;
                }
                else if (button3.TabIndex == 3 && Limit > 0 && IzotopShown[3] == false)
                {
                    button3.Text = i + I_Name;
                    button3.Visible = true;
                    Limit--;
                    IzotopShown[3] = true;
                }
                else if (button4.TabIndex == 4 && Limit > 0 && IzotopShown[4] == false)
                {
                    button4.Text = i + I_Name;
                    button4.Visible = true;
                    Limit--;
                    IzotopShown[4] = true;
                }
                else if (button5.TabIndex == 5 && Limit > 0 && IzotopShown[5] == false)
                {
                    button5.Text = i + I_Name;
                    button5.Visible = true;
                    Limit--;
                    IzotopShown[5] = true;
                }
                else if (button6.TabIndex == 6 && Limit > 0 && IzotopShown[6] == false)
                {
                    button6.Text = i + I_Name;
                    button6.Visible = true;
                    Limit--;
                    IzotopShown[6] = true;
                }
                else if (button7.TabIndex == 7 && Limit > 0 && IzotopShown[7] == false)
                {
                    button7.Text = i + I_Name;
                    button7.Visible = true;
                    Limit--;
                    IzotopShown[7] = true;
                }
                else if (button8.TabIndex == 8 && Limit > 0 && IzotopShown[8] == false)
                {
                    button8.Text = i + I_Name;
                    button8.Visible = true;
                    Limit--;
                    IzotopShown[8] = true;
                }

            }
           // button1.Text = NameOfElements[]
        }
        void form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Visible = false;
        }
        void handleUpdateEvent(object sender, EventArgs e)
        {
            this.BackColor = Color.Red;
        }
        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button88_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            this.Close();
            Form1 form1 = new Form1();

            form1.updateEvent += new EventHandler(handleUpdateEvent);
            form1.FormClosed += new FormClosedEventHandler(form1_FormClosed);
            Visible = false;
        }

    }
}
