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
                                 false,false,false,false,false,false,
                                 false,false,false,false,false,false,
                                 false,false,false,false,false,false,
                                 false,false,false,false,false,false,
                                 false,false,false,false,false,false,
                                 false,false,false,false,false,false,
                             };
        public Izotop(int I_Begin, int I_End, int Limit, string I_Name)
        {
            InitializeComponent();
            Button[] buttons = 
            {
                button0,button1,button2,button3,button4,button5,
                button6,button7,button8,button9,button10,button11,
                button12,button13,button14,button15,button16,button17,
                button18,button19,button20,button21,button22,button23,
                button24,button25,button26,button27,button28,button29,
                button30,button31,button32,button33,button34,button35,
            };
            int i = I_Begin;
            foreach (Button btt in buttons)
            {
                if(i <= I_End)
                {
                    btt.Text = i + I_Name;
                    btt.Visible = true;
                    IzotopShown[i - I_Begin] = true;
                    i++;
                }
            }       
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
