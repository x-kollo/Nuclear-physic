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
     /*   public Ex3()
        {
            InitializeComponent();
            foreach (Elements)
            {
                Element.Visible = true;
            }
        }*/
        public event EventHandler updateEvent;
        bool[] Info = {
                                 false,false,false,false,
                                 false,false,false,false,
                             };
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
            this.Visible = false;
            this.Close();
            Form1 form1 = new Form1();
            form1.updateEvent += new EventHandler(handleUpdateEvent);
            form1.FormClosed += new FormClosedEventHandler(form1_FormClosed);
            Visible = false;
        }
    }
}
