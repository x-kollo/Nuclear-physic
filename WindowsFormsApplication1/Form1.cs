using System;
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
            "Rb","Sr","Y","Zr","Nb","Mo","Tc",
            "Ag","Cd","In","Sn","Sb","Te","I","Xe",
            "Cs","Ba","*La","Hf","Ta","W","Re","Os","Ir","Pt",
            "Au","Hg","Ti","Pb","Bi","Po","At","Rn",
            "Fr","Ra","*Ac","Unq","Unp","Unh","Uns","Uno","Une","Unn"
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
        private void HideTable()
        {
            button1.Visible = false;
            button2.Visible = false;
            button3.Visible = false;
            button4.Visible = false;
            button5.Visible = false;
            button6.Visible = false;
            button7.Visible = false;
            button8.Visible = false;
            button9.Visible = false;
            button10.Visible = false;
            button11.Visible = false;
            button12.Visible = false;
            button13.Visible = false;
            button14.Visible = false;
            button15.Visible = false;
            button16.Visible = false;
            button17.Visible = false;
            button18.Visible = false;
            button19.Visible = false;
            button20.Visible = false;
            button21.Visible = false;
            button22.Visible = false;
            button23.Visible = false;
            button24.Visible = false;
            button25.Visible = false;
            button26.Visible = false;
            button27.Visible = false;
            button28.Visible = false;
            button29.Visible = false;
            button30.Visible = false;
            button31.Visible = false;
            button32.Visible = false;
            button33.Visible = false;
            button34.Visible = false;
            button35.Visible = false;
            button36.Visible = false;
            button37.Visible = false;
            button38.Visible = false;
            button39.Visible = false;
            button40.Visible = false;
            button41.Visible = false;
            button42.Visible = false;
            button43.Visible = false;
            button44.Visible = false;
            button45.Visible = false;
            button46.Visible = false;
            button47.Visible = false;
            button48.Visible = false;
            button49.Visible = false;
            button50.Visible = false;
            button51.Visible = false;
            button52.Visible = false;
            button53.Visible = false;
            button54.Visible = false;
            button55.Visible = false;
            button56.Visible = false;
            button57.Visible = false;
            button58.Visible = false;
            button59.Visible = false;
            button60.Visible = false;
            button61.Visible = false;
            button62.Visible = false;
            button63.Visible = false;
            button64.Visible = false;
            button65.Visible = false;
            button66.Visible = false;
            button67.Visible = false;
            button68.Visible = false;
            button69.Visible = false;
            button70.Visible = false;
            button71.Visible = false;
            button72.Visible = false;
            button73.Visible = false;
            button74.Visible = false;
            button75.Visible = false;
            button76.Visible = false;
            button77.Visible = false;
            button78.Visible = false;
            button79.Visible = false;
            button80.Visible = false;
            button81.Visible = false;
            button82.Visible = false;
            button83.Visible = false;
            button84.Visible = false;
            button85.Visible = false;
            button86.Visible = false;
            button87.Visible = false;
            button88.Visible = false;
            
        }  
        private void ShowTable()
        {
            button1.Visible = true;
            button2.Visible = true;
            button3.Visible = true;
            button4.Visible = true;
            button5.Visible = true;
            button6.Visible = true;
            button7.Visible = true;
            button8.Visible = true;
            button9.Visible = true;
            button10.Visible = true;
            button11.Visible = true;
            button12.Visible = true;
            button13.Visible = true;
            button14.Visible = true;
            button15.Visible = true;
            button16.Visible = true;
            button17.Visible = true;
            button18.Visible = true;
            button19.Visible = true;
            button20.Visible = true;
            button21.Visible = true;
            button22.Visible = true;
            button23.Visible = true;
            button24.Visible = true;
            button25.Visible = true;
            button26.Visible = true;
            button27.Visible = true;
            button28.Visible = true;
            button29.Visible = true;
            button30.Visible = true;
            button31.Visible = true;
            button32.Visible = true;
            button33.Visible = true;
            button34.Visible = true;
            button35.Visible = true;
            button36.Visible = true;
            button37.Visible = true;
            button38.Visible = true;
            button39.Visible = true;
            button40.Visible = true;
            button40.Visible = true;
            button41.Visible = true;
            button42.Visible = true;
            button43.Visible = true;
            button44.Visible = true;
            button45.Visible = true;
            button46.Visible = true;
            button47.Visible = true;
            button48.Visible = true;
            button49.Visible = true;
            button50.Visible = true;
            button51.Visible = true;
            button52.Visible = true;
            button53.Visible = true;
            button54.Visible = true;
            button55.Visible = true;
            button56.Visible = true;
            button57.Visible = true;
            button58.Visible = true;
            button59.Visible = true;
            button60.Visible = true;
            button61.Visible = true;
            button62.Visible = true;
            button63.Visible = true;
            button64.Visible = true;
            button65.Visible = true;
            button66.Visible = true;
            button67.Visible = true;
            button68.Visible = true;
            button69.Visible = true;
            button70.Visible = true;
            button71.Visible = true;
            button72.Visible = true;
            button73.Visible = true;
            button74.Visible = true;
            button75.Visible = true;
            button76.Visible = true;
            button77.Visible = true;
            button78.Visible = true;
            button79.Visible = true;
            button80.Visible = true;
            button81.Visible = true;
            button82.Visible = true;
            button83.Visible = true;
            button84.Visible = true;
            button85.Visible = true;
            button86.Visible = true;
            button87.Visible = true;
            button88.Visible = true;
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            this.button13 = new System.Windows.Forms.Button();
            this.button14 = new System.Windows.Forms.Button();
            this.button15 = new System.Windows.Forms.Button();
            this.button16 = new System.Windows.Forms.Button();
            this.button17 = new System.Windows.Forms.Button();
            this.button18 = new System.Windows.Forms.Button();
            this.button19 = new System.Windows.Forms.Button();
            this.button20 = new System.Windows.Forms.Button();
            this.button21 = new System.Windows.Forms.Button();
            this.button22 = new System.Windows.Forms.Button();
            this.button23 = new System.Windows.Forms.Button();
            this.button24 = new System.Windows.Forms.Button();
            this.button25 = new System.Windows.Forms.Button();
            this.button26 = new System.Windows.Forms.Button();
            this.button27 = new System.Windows.Forms.Button();
            this.button28 = new System.Windows.Forms.Button();
            this.button29 = new System.Windows.Forms.Button();
            this.button30 = new System.Windows.Forms.Button();
            this.button31 = new System.Windows.Forms.Button();
            this.button32 = new System.Windows.Forms.Button();
            this.button33 = new System.Windows.Forms.Button();
            this.button34 = new System.Windows.Forms.Button();
            this.button35 = new System.Windows.Forms.Button();
            this.button36 = new System.Windows.Forms.Button();
            this.button37 = new System.Windows.Forms.Button();
            this.button38 = new System.Windows.Forms.Button();
            this.button39 = new System.Windows.Forms.Button();
            this.button40 = new System.Windows.Forms.Button();
            this.button41 = new System.Windows.Forms.Button();
            this.button42 = new System.Windows.Forms.Button();
            this.button43 = new System.Windows.Forms.Button();
            this.button45 = new System.Windows.Forms.Button();
            this.button44 = new System.Windows.Forms.Button();
            this.button46 = new System.Windows.Forms.Button();
            this.button47 = new System.Windows.Forms.Button();
            this.button48 = new System.Windows.Forms.Button();
            this.button49 = new System.Windows.Forms.Button();
            this.button50 = new System.Windows.Forms.Button();
            this.button51 = new System.Windows.Forms.Button();
            this.button52 = new System.Windows.Forms.Button();
            this.button53 = new System.Windows.Forms.Button();
            this.button54 = new System.Windows.Forms.Button();
            this.button55 = new System.Windows.Forms.Button();
            this.button56 = new System.Windows.Forms.Button();
            this.button57 = new System.Windows.Forms.Button();
            this.button58 = new System.Windows.Forms.Button();
            this.button59 = new System.Windows.Forms.Button();
            this.button60 = new System.Windows.Forms.Button();
            this.button61 = new System.Windows.Forms.Button();
            this.button62 = new System.Windows.Forms.Button();
            this.button63 = new System.Windows.Forms.Button();
            this.button64 = new System.Windows.Forms.Button();
            this.button65 = new System.Windows.Forms.Button();
            this.button66 = new System.Windows.Forms.Button();
            this.button67 = new System.Windows.Forms.Button();
            this.button68 = new System.Windows.Forms.Button();
            this.button69 = new System.Windows.Forms.Button();
            this.button70 = new System.Windows.Forms.Button();
            this.button71 = new System.Windows.Forms.Button();
            this.button72 = new System.Windows.Forms.Button();
            this.button73 = new System.Windows.Forms.Button();
            this.button74 = new System.Windows.Forms.Button();
            this.button75 = new System.Windows.Forms.Button();
            this.button76 = new System.Windows.Forms.Button();
            this.button77 = new System.Windows.Forms.Button();
            this.button78 = new System.Windows.Forms.Button();
            this.button79 = new System.Windows.Forms.Button();
            this.button80 = new System.Windows.Forms.Button();
            this.button81 = new System.Windows.Forms.Button();
            this.button82 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label9 = new System.Windows.Forms.Label();
            this.button83 = new System.Windows.Forms.Button();
            this.button85 = new System.Windows.Forms.Button();
            this.button86 = new System.Windows.Forms.Button();
            this.button87 = new System.Windows.Forms.Button();
            this.button88 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button89 = new System.Windows.Forms.Button();
            this.button93 = new System.Windows.Forms.Button();
            this.button94 = new System.Windows.Forms.Button();
            this.button95 = new System.Windows.Forms.Button();
            this.button90 = new System.Windows.Forms.Button();
            this.button91 = new System.Windows.Forms.Button();
            this.button84 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.izotopbtn = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button109 = new System.Windows.Forms.Button();
            this.button108 = new System.Windows.Forms.Button();
            this.button107 = new System.Windows.Forms.Button();
            this.button104 = new System.Windows.Forms.Button();
            this.button105 = new System.Windows.Forms.Button();
            this.button106 = new System.Windows.Forms.Button();
            this.button101 = new System.Windows.Forms.Button();
            this.button102 = new System.Windows.Forms.Button();
            this.button103 = new System.Windows.Forms.Button();
            this.button98 = new System.Windows.Forms.Button();
            this.button99 = new System.Windows.Forms.Button();
            this.button100 = new System.Windows.Forms.Button();
            this.button97 = new System.Windows.Forms.Button();
            this.button96 = new System.Windows.Forms.Button();
            this.button92 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button110 = new System.Windows.Forms.Button();
            this.button111 = new System.Windows.Forms.Button();
            this.button112 = new System.Windows.Forms.Button();
            this.button113 = new System.Windows.Forms.Button();
            this.button114 = new System.Windows.Forms.Button();
            this.button115 = new System.Windows.Forms.Button();
            this.button116 = new System.Windows.Forms.Button();
            this.button117 = new System.Windows.Forms.Button();
            this.button118 = new System.Windows.Forms.Button();
            this.button119 = new System.Windows.Forms.Button();
            this.button120 = new System.Windows.Forms.Button();
            this.button121 = new System.Windows.Forms.Button();
            this.button122 = new System.Windows.Forms.Button();
            this.button123 = new System.Windows.Forms.Button();
            this.button124 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Pink;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(48, 46);
            this.button1.TabIndex = 0;
            this.button1.Text = "H";
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.OnClickButton_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Pink;
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button2.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button2.Location = new System.Drawing.Point(390, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(48, 46);
            this.button2.TabIndex = 1;
            this.button2.Text = "He";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.OnClickButton_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Pink;
            this.button3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button3.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button3.Location = new System.Drawing.Point(12, 64);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(48, 46);
            this.button3.TabIndex = 2;
            this.button3.Text = "Li";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.OnClickButton_Click);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.Pink;
            this.button4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button4.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button4.Location = new System.Drawing.Point(66, 64);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(48, 46);
            this.button4.TabIndex = 3;
            this.button4.Text = "Be";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.OnClickButton_Click);
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.Khaki;
            this.button5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button5.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button5.Location = new System.Drawing.Point(120, 64);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(48, 46);
            this.button5.TabIndex = 4;
            this.button5.Text = "B";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.OnClickButton_Click);
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.Khaki;
            this.button6.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button6.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button6.Location = new System.Drawing.Point(174, 64);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(48, 46);
            this.button6.TabIndex = 5;
            this.button6.Text = "C";
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Click += new System.EventHandler(this.OnClickButton_Click);
            // 
            // button7
            // 
            this.button7.BackColor = System.Drawing.Color.Khaki;
            this.button7.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button7.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button7.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button7.Location = new System.Drawing.Point(228, 64);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(48, 46);
            this.button7.TabIndex = 6;
            this.button7.Text = "N";
            this.button7.UseVisualStyleBackColor = false;
            this.button7.Click += new System.EventHandler(this.OnClickButton_Click);
            // 
            // button8
            // 
            this.button8.BackColor = System.Drawing.Color.Khaki;
            this.button8.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button8.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button8.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button8.Location = new System.Drawing.Point(282, 64);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(48, 46);
            this.button8.TabIndex = 7;
            this.button8.Text = "O";
            this.button8.UseVisualStyleBackColor = false;
            this.button8.Click += new System.EventHandler(this.OnClickButton_Click);
            // 
            // button9
            // 
            this.button9.BackColor = System.Drawing.Color.Khaki;
            this.button9.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button9.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button9.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button9.Location = new System.Drawing.Point(336, 64);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(48, 46);
            this.button9.TabIndex = 8;
            this.button9.Text = "F";
            this.button9.UseVisualStyleBackColor = false;
            this.button9.Click += new System.EventHandler(this.OnClickButton_Click);
            // 
            // button10
            // 
            this.button10.BackColor = System.Drawing.Color.Khaki;
            this.button10.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button10.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button10.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button10.Location = new System.Drawing.Point(390, 64);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(48, 46);
            this.button10.TabIndex = 9;
            this.button10.Text = "Ne";
            this.button10.UseVisualStyleBackColor = false;
            this.button10.Click += new System.EventHandler(this.OnClickButton_Click);
            // 
            // button11
            // 
            this.button11.BackColor = System.Drawing.Color.Pink;
            this.button11.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button11.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button11.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button11.Location = new System.Drawing.Point(12, 116);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(48, 46);
            this.button11.TabIndex = 10;
            this.button11.Text = "Na";
            this.button11.UseVisualStyleBackColor = false;
            this.button11.Click += new System.EventHandler(this.OnClickButton_Click);
            // 
            // button12
            // 
            this.button12.BackColor = System.Drawing.Color.Pink;
            this.button12.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button12.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button12.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button12.Location = new System.Drawing.Point(66, 116);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(48, 46);
            this.button12.TabIndex = 11;
            this.button12.Text = "Mg";
            this.button12.UseVisualStyleBackColor = false;
            this.button12.Click += new System.EventHandler(this.OnClickButton_Click);
            // 
            // button13
            // 
            this.button13.BackColor = System.Drawing.Color.Khaki;
            this.button13.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button13.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button13.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button13.Location = new System.Drawing.Point(120, 116);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(48, 46);
            this.button13.TabIndex = 12;
            this.button13.Text = "Al";
            this.button13.UseVisualStyleBackColor = false;
            this.button13.Click += new System.EventHandler(this.OnClickButton_Click);
            // 
            // button14
            // 
            this.button14.BackColor = System.Drawing.Color.Khaki;
            this.button14.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button14.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button14.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button14.Location = new System.Drawing.Point(174, 116);
            this.button14.Name = "button14";
            this.button14.Size = new System.Drawing.Size(48, 46);
            this.button14.TabIndex = 13;
            this.button14.Text = "Si";
            this.button14.UseVisualStyleBackColor = false;
            this.button14.Click += new System.EventHandler(this.OnClickButton_Click);
            // 
            // button15
            // 
            this.button15.BackColor = System.Drawing.Color.Khaki;
            this.button15.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button15.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button15.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button15.Location = new System.Drawing.Point(228, 116);
            this.button15.Name = "button15";
            this.button15.Size = new System.Drawing.Size(48, 46);
            this.button15.TabIndex = 14;
            this.button15.Text = "P";
            this.button15.UseVisualStyleBackColor = false;
            this.button15.Click += new System.EventHandler(this.OnClickButton_Click);
            // 
            // button16
            // 
            this.button16.BackColor = System.Drawing.Color.Khaki;
            this.button16.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button16.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button16.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button16.Location = new System.Drawing.Point(282, 116);
            this.button16.Name = "button16";
            this.button16.Size = new System.Drawing.Size(48, 46);
            this.button16.TabIndex = 15;
            this.button16.Text = "S";
            this.button16.UseVisualStyleBackColor = false;
            this.button16.Click += new System.EventHandler(this.OnClickButton_Click);
            // 
            // button17
            // 
            this.button17.BackColor = System.Drawing.Color.Khaki;
            this.button17.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button17.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button17.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button17.Location = new System.Drawing.Point(336, 116);
            this.button17.Name = "button17";
            this.button17.Size = new System.Drawing.Size(48, 46);
            this.button17.TabIndex = 16;
            this.button17.Text = "Cl";
            this.button17.UseVisualStyleBackColor = false;
            this.button17.Click += new System.EventHandler(this.OnClickButton_Click);
            // 
            // button18
            // 
            this.button18.BackColor = System.Drawing.Color.Khaki;
            this.button18.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button18.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button18.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button18.Location = new System.Drawing.Point(390, 116);
            this.button18.Name = "button18";
            this.button18.Size = new System.Drawing.Size(48, 46);
            this.button18.TabIndex = 17;
            this.button18.Text = "Ar";
            this.button18.UseVisualStyleBackColor = false;
            this.button18.Click += new System.EventHandler(this.OnClickButton_Click);
            // 
            // button19
            // 
            this.button19.BackColor = System.Drawing.Color.Pink;
            this.button19.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button19.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button19.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button19.Location = new System.Drawing.Point(12, 168);
            this.button19.Name = "button19";
            this.button19.Size = new System.Drawing.Size(48, 46);
            this.button19.TabIndex = 18;
            this.button19.Text = "K";
            this.button19.UseVisualStyleBackColor = false;
            this.button19.Click += new System.EventHandler(this.OnClickButton_Click);
            // 
            // button20
            // 
            this.button20.BackColor = System.Drawing.Color.Pink;
            this.button20.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button20.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button20.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button20.Location = new System.Drawing.Point(66, 168);
            this.button20.Name = "button20";
            this.button20.Size = new System.Drawing.Size(48, 46);
            this.button20.TabIndex = 19;
            this.button20.Text = "Ca";
            this.button20.UseVisualStyleBackColor = false;
            this.button20.Click += new System.EventHandler(this.OnClickButton_Click);
            // 
            // button21
            // 
            this.button21.BackColor = System.Drawing.Color.PaleGreen;
            this.button21.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button21.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button21.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button21.Location = new System.Drawing.Point(120, 168);
            this.button21.Name = "button21";
            this.button21.Size = new System.Drawing.Size(48, 46);
            this.button21.TabIndex = 20;
            this.button21.Text = "Sc";
            this.button21.UseVisualStyleBackColor = false;
            this.button21.Click += new System.EventHandler(this.OnClickButton_Click);
            // 
            // button22
            // 
            this.button22.BackColor = System.Drawing.Color.PaleGreen;
            this.button22.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button22.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button22.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button22.Location = new System.Drawing.Point(174, 168);
            this.button22.Name = "button22";
            this.button22.Size = new System.Drawing.Size(48, 46);
            this.button22.TabIndex = 21;
            this.button22.Text = "Ti";
            this.button22.UseVisualStyleBackColor = false;
            this.button22.Click += new System.EventHandler(this.OnClickButton_Click);
            // 
            // button23
            // 
            this.button23.BackColor = System.Drawing.Color.PaleGreen;
            this.button23.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button23.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button23.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button23.Location = new System.Drawing.Point(228, 168);
            this.button23.Name = "button23";
            this.button23.Size = new System.Drawing.Size(48, 46);
            this.button23.TabIndex = 22;
            this.button23.Text = "V";
            this.button23.UseVisualStyleBackColor = false;
            this.button23.Click += new System.EventHandler(this.OnClickButton_Click);
            // 
            // button24
            // 
            this.button24.BackColor = System.Drawing.Color.PaleGreen;
            this.button24.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button24.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button24.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button24.Location = new System.Drawing.Point(282, 168);
            this.button24.Name = "button24";
            this.button24.Size = new System.Drawing.Size(48, 46);
            this.button24.TabIndex = 23;
            this.button24.Text = "Cr";
            this.button24.UseVisualStyleBackColor = false;
            this.button24.Click += new System.EventHandler(this.OnClickButton_Click);
            // 
            // button25
            // 
            this.button25.BackColor = System.Drawing.Color.PaleGreen;
            this.button25.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button25.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button25.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button25.Location = new System.Drawing.Point(336, 168);
            this.button25.Name = "button25";
            this.button25.Size = new System.Drawing.Size(48, 46);
            this.button25.TabIndex = 24;
            this.button25.Text = "Mn";
            this.button25.UseVisualStyleBackColor = false;
            this.button25.Click += new System.EventHandler(this.OnClickButton_Click);
            // 
            // button26
            // 
            this.button26.BackColor = System.Drawing.Color.LightSkyBlue;
            this.button26.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button26.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button26.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button26.Location = new System.Drawing.Point(390, 168);
            this.button26.Name = "button26";
            this.button26.Size = new System.Drawing.Size(48, 46);
            this.button26.TabIndex = 25;
            this.button26.Text = "Fe";
            this.button26.UseVisualStyleBackColor = false;
            this.button26.Click += new System.EventHandler(this.OnClickButton_Click);
            // 
            // button27
            // 
            this.button27.BackColor = System.Drawing.Color.LightSkyBlue;
            this.button27.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button27.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button27.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button27.Location = new System.Drawing.Point(444, 168);
            this.button27.Name = "button27";
            this.button27.Size = new System.Drawing.Size(48, 46);
            this.button27.TabIndex = 26;
            this.button27.Text = "Co";
            this.button27.UseVisualStyleBackColor = false;
            this.button27.Click += new System.EventHandler(this.OnClickButton_Click);
            // 
            // button28
            // 
            this.button28.BackColor = System.Drawing.Color.LightSkyBlue;
            this.button28.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button28.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button28.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button28.Location = new System.Drawing.Point(498, 168);
            this.button28.Name = "button28";
            this.button28.Size = new System.Drawing.Size(48, 46);
            this.button28.TabIndex = 27;
            this.button28.Text = "Ni";
            this.button28.UseVisualStyleBackColor = false;
            this.button28.Click += new System.EventHandler(this.OnClickButton_Click);
            // 
            // button29
            // 
            this.button29.BackColor = System.Drawing.Color.Orchid;
            this.button29.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button29.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button29.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button29.Location = new System.Drawing.Point(12, 220);
            this.button29.Name = "button29";
            this.button29.Size = new System.Drawing.Size(48, 46);
            this.button29.TabIndex = 28;
            this.button29.Text = "Cu";
            this.button29.UseVisualStyleBackColor = false;
            this.button29.Click += new System.EventHandler(this.OnClickButton_Click);
            // 
            // button30
            // 
            this.button30.BackColor = System.Drawing.Color.Orchid;
            this.button30.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button30.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button30.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button30.Location = new System.Drawing.Point(66, 220);
            this.button30.Name = "button30";
            this.button30.Size = new System.Drawing.Size(48, 46);
            this.button30.TabIndex = 29;
            this.button30.Text = "Zn";
            this.button30.UseVisualStyleBackColor = false;
            this.button30.Click += new System.EventHandler(this.OnClickButton_Click);
            // 
            // button31
            // 
            this.button31.BackColor = System.Drawing.Color.Khaki;
            this.button31.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button31.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button31.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button31.Location = new System.Drawing.Point(120, 220);
            this.button31.Name = "button31";
            this.button31.Size = new System.Drawing.Size(48, 46);
            this.button31.TabIndex = 30;
            this.button31.Text = "Ga";
            this.button31.UseVisualStyleBackColor = false;
            this.button31.Click += new System.EventHandler(this.OnClickButton_Click);
            // 
            // button32
            // 
            this.button32.BackColor = System.Drawing.Color.Khaki;
            this.button32.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button32.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button32.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button32.Location = new System.Drawing.Point(174, 220);
            this.button32.Name = "button32";
            this.button32.Size = new System.Drawing.Size(48, 46);
            this.button32.TabIndex = 31;
            this.button32.Text = "Ge";
            this.button32.UseVisualStyleBackColor = false;
            this.button32.Click += new System.EventHandler(this.OnClickButton_Click);
            // 
            // button33
            // 
            this.button33.BackColor = System.Drawing.Color.Khaki;
            this.button33.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button33.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button33.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button33.Location = new System.Drawing.Point(228, 220);
            this.button33.Name = "button33";
            this.button33.Size = new System.Drawing.Size(48, 46);
            this.button33.TabIndex = 32;
            this.button33.Text = "As";
            this.button33.UseVisualStyleBackColor = false;
            this.button33.Click += new System.EventHandler(this.OnClickButton_Click);
            // 
            // button34
            // 
            this.button34.BackColor = System.Drawing.Color.Khaki;
            this.button34.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button34.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button34.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button34.Location = new System.Drawing.Point(282, 220);
            this.button34.Name = "button34";
            this.button34.Size = new System.Drawing.Size(48, 46);
            this.button34.TabIndex = 33;
            this.button34.Text = "Se";
            this.button34.UseVisualStyleBackColor = false;
            this.button34.Click += new System.EventHandler(this.OnClickButton_Click);
            // 
            // button35
            // 
            this.button35.BackColor = System.Drawing.Color.Khaki;
            this.button35.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button35.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button35.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button35.Location = new System.Drawing.Point(336, 220);
            this.button35.Name = "button35";
            this.button35.Size = new System.Drawing.Size(48, 46);
            this.button35.TabIndex = 34;
            this.button35.Text = "Br";
            this.button35.UseVisualStyleBackColor = false;
            this.button35.Click += new System.EventHandler(this.OnClickButton_Click);
            // 
            // button36
            // 
            this.button36.BackColor = System.Drawing.Color.Khaki;
            this.button36.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button36.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button36.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button36.Location = new System.Drawing.Point(390, 220);
            this.button36.Name = "button36";
            this.button36.Size = new System.Drawing.Size(48, 46);
            this.button36.TabIndex = 35;
            this.button36.Text = "Kr";
            this.button36.UseVisualStyleBackColor = false;
            this.button36.Click += new System.EventHandler(this.OnClickButton_Click);
            // 
            // button37
            // 
            this.button37.BackColor = System.Drawing.Color.Pink;
            this.button37.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button37.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button37.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button37.Location = new System.Drawing.Point(12, 272);
            this.button37.Name = "button37";
            this.button37.Size = new System.Drawing.Size(48, 46);
            this.button37.TabIndex = 36;
            this.button37.Text = "Rb";
            this.button37.UseVisualStyleBackColor = false;
            this.button37.Click += new System.EventHandler(this.OnClickButton_Click);
            // 
            // button38
            // 
            this.button38.BackColor = System.Drawing.Color.Pink;
            this.button38.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button38.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button38.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button38.Location = new System.Drawing.Point(66, 272);
            this.button38.Name = "button38";
            this.button38.Size = new System.Drawing.Size(48, 46);
            this.button38.TabIndex = 37;
            this.button38.Text = "Sr";
            this.button38.UseVisualStyleBackColor = false;
            this.button38.Click += new System.EventHandler(this.OnClickButton_Click);
            // 
            // button39
            // 
            this.button39.BackColor = System.Drawing.Color.PaleGreen;
            this.button39.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button39.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button39.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button39.Location = new System.Drawing.Point(120, 272);
            this.button39.Name = "button39";
            this.button39.Size = new System.Drawing.Size(48, 46);
            this.button39.TabIndex = 38;
            this.button39.Text = "Y";
            this.button39.UseVisualStyleBackColor = false;
            this.button39.Click += new System.EventHandler(this.OnClickButton_Click);
            // 
            // button40
            // 
            this.button40.BackColor = System.Drawing.Color.PaleGreen;
            this.button40.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button40.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button40.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button40.Location = new System.Drawing.Point(174, 272);
            this.button40.Name = "button40";
            this.button40.Size = new System.Drawing.Size(48, 46);
            this.button40.TabIndex = 39;
            this.button40.Text = "Zr";
            this.button40.UseVisualStyleBackColor = false;
            this.button40.Click += new System.EventHandler(this.OnClickButton_Click);
            // 
            // button41
            // 
            this.button41.BackColor = System.Drawing.Color.PaleGreen;
            this.button41.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button41.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button41.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button41.Location = new System.Drawing.Point(228, 272);
            this.button41.Name = "button41";
            this.button41.Size = new System.Drawing.Size(48, 46);
            this.button41.TabIndex = 40;
            this.button41.Text = "Nb";
            this.button41.UseVisualStyleBackColor = false;
            this.button41.Click += new System.EventHandler(this.OnClickButton_Click);
            // 
            // button42
            // 
            this.button42.BackColor = System.Drawing.Color.PaleGreen;
            this.button42.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button42.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button42.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button42.Location = new System.Drawing.Point(282, 272);
            this.button42.Name = "button42";
            this.button42.Size = new System.Drawing.Size(48, 46);
            this.button42.TabIndex = 41;
            this.button42.Text = "Mo";
            this.button42.UseVisualStyleBackColor = false;
            this.button42.Click += new System.EventHandler(this.OnClickButton_Click);
            // 
            // button43
            // 
            this.button43.BackColor = System.Drawing.Color.PaleGreen;
            this.button43.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button43.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button43.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button43.Location = new System.Drawing.Point(336, 272);
            this.button43.Name = "button43";
            this.button43.Size = new System.Drawing.Size(48, 46);
            this.button43.TabIndex = 42;
            this.button43.Text = "Tc";
            this.button43.UseVisualStyleBackColor = false;
            this.button43.Click += new System.EventHandler(this.OnClickButton_Click);
            // 
            // button45
            // 
            this.button45.BackColor = System.Drawing.Color.LightSkyBlue;
            this.button45.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button45.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button45.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button45.Location = new System.Drawing.Point(390, 272);
            this.button45.Name = "button45";
            this.button45.Size = new System.Drawing.Size(48, 46);
            this.button45.TabIndex = 43;
            this.button45.Text = "Ru";
            this.button45.UseVisualStyleBackColor = false;
            this.button45.Click += new System.EventHandler(this.OnClickButton_Click);
            // 
            // button44
            // 
            this.button44.BackColor = System.Drawing.Color.LightSkyBlue;
            this.button44.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button44.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button44.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button44.Location = new System.Drawing.Point(444, 272);
            this.button44.Name = "button44";
            this.button44.Size = new System.Drawing.Size(48, 46);
            this.button44.TabIndex = 44;
            this.button44.Text = "Rh";
            this.button44.UseVisualStyleBackColor = false;
            this.button44.Click += new System.EventHandler(this.OnClickButton_Click);
            // 
            // button46
            // 
            this.button46.BackColor = System.Drawing.Color.LightSkyBlue;
            this.button46.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button46.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button46.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button46.Location = new System.Drawing.Point(498, 272);
            this.button46.Name = "button46";
            this.button46.Size = new System.Drawing.Size(48, 46);
            this.button46.TabIndex = 45;
            this.button46.Text = "Pd";
            this.button46.UseVisualStyleBackColor = false;
            this.button46.Click += new System.EventHandler(this.OnClickButton_Click);
            // 
            // button47
            // 
            this.button47.BackColor = System.Drawing.Color.Orchid;
            this.button47.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button47.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button47.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button47.Location = new System.Drawing.Point(12, 324);
            this.button47.Name = "button47";
            this.button47.Size = new System.Drawing.Size(48, 46);
            this.button47.TabIndex = 46;
            this.button47.Text = "Ag";
            this.button47.UseVisualStyleBackColor = false;
            this.button47.Click += new System.EventHandler(this.OnClickButton_Click);
            // 
            // button48
            // 
            this.button48.BackColor = System.Drawing.Color.Orchid;
            this.button48.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button48.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button48.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button48.Location = new System.Drawing.Point(66, 324);
            this.button48.Name = "button48";
            this.button48.Size = new System.Drawing.Size(48, 46);
            this.button48.TabIndex = 47;
            this.button48.Text = "Cd";
            this.button48.UseVisualStyleBackColor = false;
            this.button48.Click += new System.EventHandler(this.OnClickButton_Click);
            // 
            // button49
            // 
            this.button49.BackColor = System.Drawing.Color.Khaki;
            this.button49.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button49.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button49.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button49.Location = new System.Drawing.Point(120, 324);
            this.button49.Name = "button49";
            this.button49.Size = new System.Drawing.Size(48, 46);
            this.button49.TabIndex = 48;
            this.button49.Text = "In";
            this.button49.UseVisualStyleBackColor = false;
            this.button49.Click += new System.EventHandler(this.OnClickButton_Click);
            // 
            // button50
            // 
            this.button50.BackColor = System.Drawing.Color.Khaki;
            this.button50.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button50.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button50.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button50.Location = new System.Drawing.Point(174, 324);
            this.button50.Name = "button50";
            this.button50.Size = new System.Drawing.Size(48, 46);
            this.button50.TabIndex = 49;
            this.button50.Text = "Sn";
            this.button50.UseVisualStyleBackColor = false;
            this.button50.Click += new System.EventHandler(this.OnClickButton_Click);
            // 
            // button51
            // 
            this.button51.BackColor = System.Drawing.Color.Khaki;
            this.button51.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button51.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button51.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button51.Location = new System.Drawing.Point(228, 324);
            this.button51.Name = "button51";
            this.button51.Size = new System.Drawing.Size(48, 46);
            this.button51.TabIndex = 50;
            this.button51.Text = "Sb";
            this.button51.UseVisualStyleBackColor = false;
            this.button51.Click += new System.EventHandler(this.OnClickButton_Click);
            // 
            // button52
            // 
            this.button52.BackColor = System.Drawing.Color.Khaki;
            this.button52.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button52.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button52.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button52.Location = new System.Drawing.Point(282, 324);
            this.button52.Name = "button52";
            this.button52.Size = new System.Drawing.Size(48, 46);
            this.button52.TabIndex = 51;
            this.button52.Text = "Te";
            this.button52.UseVisualStyleBackColor = false;
            this.button52.Click += new System.EventHandler(this.OnClickButton_Click);
            // 
            // button53
            // 
            this.button53.BackColor = System.Drawing.Color.Khaki;
            this.button53.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button53.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button53.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button53.Location = new System.Drawing.Point(336, 324);
            this.button53.Name = "button53";
            this.button53.Size = new System.Drawing.Size(48, 46);
            this.button53.TabIndex = 52;
            this.button53.Text = "I";
            this.button53.UseVisualStyleBackColor = false;
            this.button53.Click += new System.EventHandler(this.OnClickButton_Click);
            // 
            // button54
            // 
            this.button54.BackColor = System.Drawing.Color.Khaki;
            this.button54.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button54.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button54.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button54.Location = new System.Drawing.Point(390, 324);
            this.button54.Name = "button54";
            this.button54.Size = new System.Drawing.Size(48, 46);
            this.button54.TabIndex = 53;
            this.button54.Text = "Xe";
            this.button54.UseVisualStyleBackColor = false;
            this.button54.Click += new System.EventHandler(this.OnClickButton_Click);
            // 
            // button55
            // 
            this.button55.BackColor = System.Drawing.Color.Pink;
            this.button55.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button55.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button55.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button55.Location = new System.Drawing.Point(12, 376);
            this.button55.Name = "button55";
            this.button55.Size = new System.Drawing.Size(48, 46);
            this.button55.TabIndex = 54;
            this.button55.Text = "Cs";
            this.button55.UseVisualStyleBackColor = false;
            this.button55.Click += new System.EventHandler(this.OnClickButton_Click);
            // 
            // button56
            // 
            this.button56.BackColor = System.Drawing.Color.Pink;
            this.button56.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button56.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button56.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button56.Location = new System.Drawing.Point(66, 376);
            this.button56.Name = "button56";
            this.button56.Size = new System.Drawing.Size(48, 46);
            this.button56.TabIndex = 55;
            this.button56.Text = "Ba";
            this.button56.UseVisualStyleBackColor = false;
            this.button56.Click += new System.EventHandler(this.OnClickButton_Click);
            // 
            // button57
            // 
            this.button57.BackColor = System.Drawing.Color.PaleGreen;
            this.button57.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button57.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button57.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button57.Location = new System.Drawing.Point(120, 376);
            this.button57.Name = "button57";
            this.button57.Size = new System.Drawing.Size(48, 46);
            this.button57.TabIndex = 999;
            this.button57.Text = "*La";
            this.button57.UseVisualStyleBackColor = false;
            this.button57.Click += new System.EventHandler(this.OnClickButton_Click);
            // 
            // button58
            // 
            this.button58.BackColor = System.Drawing.Color.PaleGreen;
            this.button58.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button58.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button58.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button58.Location = new System.Drawing.Point(174, 376);
            this.button58.Name = "button58";
            this.button58.Size = new System.Drawing.Size(48, 46);
            this.button58.TabIndex = 71;
            this.button58.Text = "Hf";
            this.button58.UseVisualStyleBackColor = false;
            this.button58.Click += new System.EventHandler(this.OnClickButton_Click);
            // 
            // button59
            // 
            this.button59.BackColor = System.Drawing.Color.PaleGreen;
            this.button59.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button59.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button59.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button59.Location = new System.Drawing.Point(228, 376);
            this.button59.Name = "button59";
            this.button59.Size = new System.Drawing.Size(48, 46);
            this.button59.TabIndex = 72;
            this.button59.Text = "Ta";
            this.button59.UseVisualStyleBackColor = false;
            this.button59.Click += new System.EventHandler(this.OnClickButton_Click);
            // 
            // button60
            // 
            this.button60.BackColor = System.Drawing.Color.PaleGreen;
            this.button60.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button60.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button60.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button60.Location = new System.Drawing.Point(282, 376);
            this.button60.Name = "button60";
            this.button60.Size = new System.Drawing.Size(48, 46);
            this.button60.TabIndex = 73;
            this.button60.Text = "W";
            this.button60.UseVisualStyleBackColor = false;
            this.button60.Click += new System.EventHandler(this.OnClickButton_Click);
            // 
            // button61
            // 
            this.button61.BackColor = System.Drawing.Color.PaleGreen;
            this.button61.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button61.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button61.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button61.Location = new System.Drawing.Point(336, 376);
            this.button61.Name = "button61";
            this.button61.Size = new System.Drawing.Size(48, 46);
            this.button61.TabIndex = 74;
            this.button61.Text = "Re";
            this.button61.UseVisualStyleBackColor = false;
            this.button61.Click += new System.EventHandler(this.OnClickButton_Click);
            // 
            // button62
            // 
            this.button62.BackColor = System.Drawing.Color.LightSkyBlue;
            this.button62.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button62.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button62.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button62.Location = new System.Drawing.Point(390, 376);
            this.button62.Name = "button62";
            this.button62.Size = new System.Drawing.Size(48, 46);
            this.button62.TabIndex = 75;
            this.button62.Text = "Os";
            this.button62.UseVisualStyleBackColor = false;
            this.button62.Click += new System.EventHandler(this.OnClickButton_Click);
            // 
            // button63
            // 
            this.button63.BackColor = System.Drawing.Color.LightSkyBlue;
            this.button63.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button63.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button63.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button63.Location = new System.Drawing.Point(444, 376);
            this.button63.Name = "button63";
            this.button63.Size = new System.Drawing.Size(48, 46);
            this.button63.TabIndex = 76;
            this.button63.Text = "Ir";
            this.button63.UseVisualStyleBackColor = false;
            this.button63.Click += new System.EventHandler(this.OnClickButton_Click);
            // 
            // button64
            // 
            this.button64.BackColor = System.Drawing.Color.LightSkyBlue;
            this.button64.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button64.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button64.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button64.Location = new System.Drawing.Point(498, 376);
            this.button64.Name = "button64";
            this.button64.Size = new System.Drawing.Size(48, 46);
            this.button64.TabIndex = 77;
            this.button64.Text = "Pt";
            this.button64.UseVisualStyleBackColor = false;
            this.button64.Click += new System.EventHandler(this.OnClickButton_Click);
            // 
            // button65
            // 
            this.button65.BackColor = System.Drawing.Color.Orchid;
            this.button65.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button65.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button65.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button65.Location = new System.Drawing.Point(66, 428);
            this.button65.Name = "button65";
            this.button65.Size = new System.Drawing.Size(48, 46);
            this.button65.TabIndex = 79;
            this.button65.Text = "Hg";
            this.button65.UseVisualStyleBackColor = false;
            this.button65.Click += new System.EventHandler(this.OnClickButton_Click);
            // 
            // button66
            // 
            this.button66.BackColor = System.Drawing.Color.Orchid;
            this.button66.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button66.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button66.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button66.Location = new System.Drawing.Point(12, 428);
            this.button66.Name = "button66";
            this.button66.Size = new System.Drawing.Size(48, 46);
            this.button66.TabIndex = 78;
            this.button66.Text = "Au";
            this.button66.UseVisualStyleBackColor = false;
            this.button66.Click += new System.EventHandler(this.OnClickButton_Click);
            // 
            // button67
            // 
            this.button67.BackColor = System.Drawing.Color.Khaki;
            this.button67.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button67.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button67.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button67.Location = new System.Drawing.Point(120, 428);
            this.button67.Name = "button67";
            this.button67.Size = new System.Drawing.Size(48, 46);
            this.button67.TabIndex = 80;
            this.button67.Text = "Ti";
            this.button67.UseVisualStyleBackColor = false;
            this.button67.Click += new System.EventHandler(this.OnClickButton_Click);
            // 
            // button68
            // 
            this.button68.BackColor = System.Drawing.Color.Khaki;
            this.button68.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button68.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button68.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button68.Location = new System.Drawing.Point(174, 428);
            this.button68.Name = "button68";
            this.button68.Size = new System.Drawing.Size(48, 46);
            this.button68.TabIndex = 81;
            this.button68.Text = "Pb";
            this.button68.UseVisualStyleBackColor = false;
            this.button68.Click += new System.EventHandler(this.OnClickButton_Click);
            // 
            // button69
            // 
            this.button69.BackColor = System.Drawing.Color.Khaki;
            this.button69.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button69.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button69.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button69.Location = new System.Drawing.Point(228, 427);
            this.button69.Name = "button69";
            this.button69.Size = new System.Drawing.Size(48, 46);
            this.button69.TabIndex = 82;
            this.button69.Text = "Bi";
            this.button69.UseVisualStyleBackColor = false;
            this.button69.Click += new System.EventHandler(this.OnClickButton_Click);
            // 
            // button70
            // 
            this.button70.BackColor = System.Drawing.Color.Khaki;
            this.button70.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button70.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button70.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button70.Location = new System.Drawing.Point(282, 428);
            this.button70.Name = "button70";
            this.button70.Size = new System.Drawing.Size(48, 46);
            this.button70.TabIndex = 83;
            this.button70.Text = "Po";
            this.button70.UseVisualStyleBackColor = false;
            this.button70.Click += new System.EventHandler(this.OnClickButton_Click);
            // 
            // button71
            // 
            this.button71.BackColor = System.Drawing.Color.Khaki;
            this.button71.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button71.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button71.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button71.Location = new System.Drawing.Point(336, 427);
            this.button71.Name = "button71";
            this.button71.Size = new System.Drawing.Size(48, 46);
            this.button71.TabIndex = 84;
            this.button71.Text = "At";
            this.button71.UseVisualStyleBackColor = false;
            this.button71.Click += new System.EventHandler(this.OnClickButton_Click);
            // 
            // button72
            // 
            this.button72.BackColor = System.Drawing.Color.Khaki;
            this.button72.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button72.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button72.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button72.Location = new System.Drawing.Point(390, 427);
            this.button72.Name = "button72";
            this.button72.Size = new System.Drawing.Size(48, 46);
            this.button72.TabIndex = 85;
            this.button72.Text = "Rn";
            this.button72.UseVisualStyleBackColor = false;
            this.button72.Click += new System.EventHandler(this.OnClickButton_Click);
            // 
            // button73
            // 
            this.button73.BackColor = System.Drawing.Color.Pink;
            this.button73.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button73.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button73.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button73.Location = new System.Drawing.Point(12, 480);
            this.button73.Name = "button73";
            this.button73.Size = new System.Drawing.Size(48, 46);
            this.button73.TabIndex = 86;
            this.button73.Text = "Fr";
            this.button73.UseVisualStyleBackColor = false;
            this.button73.Click += new System.EventHandler(this.OnClickButton_Click);
            // 
            // button74
            // 
            this.button74.BackColor = System.Drawing.Color.Pink;
            this.button74.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button74.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button74.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button74.Location = new System.Drawing.Point(66, 480);
            this.button74.Name = "button74";
            this.button74.Size = new System.Drawing.Size(48, 46);
            this.button74.TabIndex = 87;
            this.button74.Text = "Ra";
            this.button74.UseVisualStyleBackColor = false;
            this.button74.Click += new System.EventHandler(this.OnClickButton_Click);
            // 
            // button75
            // 
            this.button75.BackColor = System.Drawing.Color.LightSkyBlue;
            this.button75.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button75.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button75.Font = new System.Drawing.Font("Consolas", 11.25F);
            this.button75.Location = new System.Drawing.Point(120, 481);
            this.button75.Name = "button75";
            this.button75.Size = new System.Drawing.Size(48, 46);
            this.button75.TabIndex = 998;
            this.button75.Text = "**Ac";
            this.button75.UseVisualStyleBackColor = false;
            this.button75.Click += new System.EventHandler(this.OnClickButton_Click);
            // 
            // button76
            // 
            this.button76.BackColor = System.Drawing.Color.LightSkyBlue;
            this.button76.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button76.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button76.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button76.Location = new System.Drawing.Point(174, 479);
            this.button76.Name = "button76";
            this.button76.Size = new System.Drawing.Size(48, 46);
            this.button76.TabIndex = 103;
            this.button76.Text = "Rf";
            this.button76.UseVisualStyleBackColor = false;
            this.button76.Click += new System.EventHandler(this.OnClickButton_Click);
            // 
            // button77
            // 
            this.button77.BackColor = System.Drawing.Color.LightSkyBlue;
            this.button77.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button77.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button77.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button77.Location = new System.Drawing.Point(228, 479);
            this.button77.Name = "button77";
            this.button77.Size = new System.Drawing.Size(48, 46);
            this.button77.TabIndex = 104;
            this.button77.Text = "Db";
            this.button77.UseVisualStyleBackColor = false;
            this.button77.Click += new System.EventHandler(this.OnClickButton_Click);
            // 
            // button78
            // 
            this.button78.BackColor = System.Drawing.Color.LightSkyBlue;
            this.button78.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button78.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button78.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button78.Location = new System.Drawing.Point(282, 479);
            this.button78.Name = "button78";
            this.button78.Size = new System.Drawing.Size(48, 46);
            this.button78.TabIndex = 105;
            this.button78.Text = "Sg";
            this.button78.UseVisualStyleBackColor = false;
            this.button78.Click += new System.EventHandler(this.OnClickButton_Click);
            // 
            // button79
            // 
            this.button79.BackColor = System.Drawing.Color.LightSkyBlue;
            this.button79.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button79.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button79.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button79.Location = new System.Drawing.Point(336, 479);
            this.button79.Name = "button79";
            this.button79.Size = new System.Drawing.Size(48, 46);
            this.button79.TabIndex = 106;
            this.button79.Text = "Bh";
            this.button79.UseVisualStyleBackColor = false;
            this.button79.Click += new System.EventHandler(this.OnClickButton_Click);
            // 
            // button80
            // 
            this.button80.BackColor = System.Drawing.Color.LightSkyBlue;
            this.button80.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button80.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button80.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button80.Location = new System.Drawing.Point(390, 479);
            this.button80.Name = "button80";
            this.button80.Size = new System.Drawing.Size(48, 46);
            this.button80.TabIndex = 107;
            this.button80.Text = "Hs";
            this.button80.UseVisualStyleBackColor = false;
            this.button80.Click += new System.EventHandler(this.OnClickButton_Click);
            // 
            // button81
            // 
            this.button81.BackColor = System.Drawing.Color.LightSkyBlue;
            this.button81.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button81.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button81.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button81.Location = new System.Drawing.Point(444, 478);
            this.button81.Name = "button81";
            this.button81.Size = new System.Drawing.Size(48, 46);
            this.button81.TabIndex = 108;
            this.button81.Text = "Mt";
            this.button81.UseVisualStyleBackColor = false;
            this.button81.Click += new System.EventHandler(this.OnClickButton_Click);
            // 
            // button82
            // 
            this.button82.BackColor = System.Drawing.Color.LightSkyBlue;
            this.button82.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button82.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button82.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button82.Location = new System.Drawing.Point(498, 478);
            this.button82.Name = "button82";
            this.button82.Size = new System.Drawing.Size(48, 46);
            this.button82.TabIndex = 109;
            this.button82.Text = "Ds";
            this.button82.UseVisualStyleBackColor = false;
            this.button82.Click += new System.EventHandler(this.OnClickButton_Click);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.textBox1.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox1.Location = new System.Drawing.Point(759, 432);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(78, 27);
            this.textBox1.TabIndex = 82;
            this.textBox1.Text = "МАССА (г)";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox1.Visible = false;
            this.textBox1.TextChanged += new System.EventHandler(this.OnTextBox_Change);
            this.textBox1.Enter += new System.EventHandler(this.OnTextBox_Enter);
            this.textBox1.Leave += new System.EventHandler(this.OnTextBox_Leave);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(750, 404);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(450, 22);
            this.label6.TabIndex = 92;
            this.label6.Text = "РОЗРАХУНОК КІЛЬКОСТІ МОЛЕКУЛ, ЩО РОЗПАДЕТЬСЯ";
            this.label6.Visible = false;
            // 
            // textBox3
            // 
            this.textBox3.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox3.Location = new System.Drawing.Point(918, 432);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(65, 27);
            this.textBox3.TabIndex = 95;
            this.textBox3.Text = "ДНІ";
            this.textBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox3.Visible = false;
            this.textBox3.TextChanged += new System.EventHandler(this.OnTextBox_Change);
            this.textBox3.Enter += new System.EventHandler(this.OnTextBox_Enter);
            this.textBox3.Leave += new System.EventHandler(this.OnTextBox_Leave);
            // 
            // textBox4
            // 
            this.textBox4.BackColor = System.Drawing.SystemColors.Window;
            this.textBox4.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox4.Location = new System.Drawing.Point(988, 432);
            this.textBox4.Margin = new System.Windows.Forms.Padding(2);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(65, 27);
            this.textBox4.TabIndex = 96;
            this.textBox4.Text = "ГОДИНИ";
            this.textBox4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox4.Visible = false;
            this.textBox4.TextChanged += new System.EventHandler(this.OnTextBox_Change);
            this.textBox4.Enter += new System.EventHandler(this.OnTextBox_Enter);
            this.textBox4.Leave += new System.EventHandler(this.OnTextBox_Leave);
            // 
            // textBox5
            // 
            this.textBox5.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox5.Location = new System.Drawing.Point(1060, 432);
            this.textBox5.MaxLength = 4;
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(73, 27);
            this.textBox5.TabIndex = 97;
            this.textBox5.Tag = "";
            this.textBox5.Text = "CЕКУНДИ";
            this.textBox5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox5.Visible = false;
            this.textBox5.TextChanged += new System.EventHandler(this.OnTextBox_Change);
            this.textBox5.Enter += new System.EventHandler(this.OnTextBox_Enter);
            this.textBox5.Leave += new System.EventHandler(this.OnTextBox_Leave);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(822, 480);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(90, 20);
            this.label8.TabIndex = 102;
            this.label8.Text = "РЕЗУЛЬТАТ";
            this.label8.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(631, -2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(529, 369);
            this.pictureBox1.TabIndex = 103;
            this.pictureBox1.TabStop = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.Location = new System.Drawing.Point(971, 624);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(72, 20);
            this.label9.TabIndex = 104;
            this.label9.Text = "ЕЛЕМЕНТ";
            // 
            // button83
            // 
            this.button83.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.button83.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button83.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button83.Location = new System.Drawing.Point(1102, 574);
            this.button83.Name = "button83";
            this.button83.Size = new System.Drawing.Size(48, 46);
            this.button83.TabIndex = 105;
            this.button83.Text = " ";
            this.button83.UseVisualStyleBackColor = false;
            // 
            // button85
            // 
            this.button85.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button85.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button85.Location = new System.Drawing.Point(756, 462);
            this.button85.Name = "button85";
            this.button85.Size = new System.Drawing.Size(120, 42);
            this.button85.TabIndex = 108;
            this.button85.Text = "КІЛЬКІСТЬ МОЛЕКУЛ";
            this.button85.UseVisualStyleBackColor = true;
            this.button85.Click += new System.EventHandler(this.button85_Click);
            // 
            // button86
            // 
            this.button86.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button86.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button86.Location = new System.Drawing.Point(887, 462);
            this.button86.Name = "button86";
            this.button86.Size = new System.Drawing.Size(120, 42);
            this.button86.TabIndex = 109;
            this.button86.Text = "ЕНЕРГІЯ ЗВ\'ЯЗКУ";
            this.button86.UseVisualStyleBackColor = true;
            this.button86.Click += new System.EventHandler(this.button86_Click);
            // 
            // button87
            // 
            this.button87.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button87.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button87.Location = new System.Drawing.Point(1013, 462);
            this.button87.Name = "button87";
            this.button87.Size = new System.Drawing.Size(120, 42);
            this.button87.TabIndex = 110;
            this.button87.Text = "ПЕРЕВІД";
            this.button87.UseVisualStyleBackColor = true;
            this.button87.Click += new System.EventHandler(this.button87_Click);
            // 
            // button88
            // 
            this.button88.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button88.Location = new System.Drawing.Point(1060, 527);
            this.button88.Name = "button88";
            this.button88.Size = new System.Drawing.Size(73, 27);
            this.button88.TabIndex = 111;
            this.button88.Text = "<< НАЗАД";
            this.button88.UseVisualStyleBackColor = true;
            this.button88.Visible = false;
            this.button88.Click += new System.EventHandler(this.button88_Click);
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox2.Location = new System.Drawing.Point(843, 432);
            this.textBox2.Name = "textBox2";
            this.textBox2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textBox2.Size = new System.Drawing.Size(69, 27);
            this.textBox2.TabIndex = 94;
            this.textBox2.Text = "РОКИ";
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox2.Visible = false;
            this.textBox2.TextChanged += new System.EventHandler(this.OnTextBox_Change);
            this.textBox2.Enter += new System.EventHandler(this.OnTextBox_Enter);
            this.textBox2.Leave += new System.EventHandler(this.OnTextBox_Leave);
            // 
            // button89
            // 
            this.button89.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.button89.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button89.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button89.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button89.Location = new System.Drawing.Point(120, 12);
            this.button89.Name = "button89";
            this.button89.Size = new System.Drawing.Size(229, 46);
            this.button89.TabIndex = 113;
            this.button89.Text = "ВІДКРИТИ ТАБЛИЦЮ ІЗОТОПІВ";
            this.button89.UseVisualStyleBackColor = false;
            this.button89.Visible = false;
            this.button89.Click += new System.EventHandler(this.button89_Click);
            // 
            // button93
            // 
            this.button93.BackColor = System.Drawing.Color.OliveDrab;
            this.button93.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button93.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button93.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button93.Location = new System.Drawing.Point(753, 315);
            this.button93.Name = "button93";
            this.button93.Size = new System.Drawing.Size(377, 52);
            this.button93.TabIndex = 114;
            this.button93.Text = "ТЕРМОДИНАМІЧНІ ВЛАСТИВОСТІ";
            this.button93.UseVisualStyleBackColor = false;
            this.button93.Click += new System.EventHandler(this.Button93_Click);
            // 
            // button94
            // 
            this.button94.BackColor = System.Drawing.Color.OliveDrab;
            this.button94.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button94.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button94.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button94.Location = new System.Drawing.Point(753, 256);
            this.button94.Name = "button94";
            this.button94.Size = new System.Drawing.Size(377, 53);
            this.button94.TabIndex = 115;
            this.button94.Text = "ХІМІЧНІ ВЛАСТИВОСТІ";
            this.button94.UseVisualStyleBackColor = false;
            this.button94.Click += new System.EventHandler(this.Button94_Click);
            // 
            // button95
            // 
            this.button95.BackColor = System.Drawing.Color.OliveDrab;
            this.button95.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button95.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button95.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button95.Location = new System.Drawing.Point(753, 198);
            this.button95.Name = "button95";
            this.button95.Size = new System.Drawing.Size(377, 52);
            this.button95.TabIndex = 116;
            this.button95.Text = "ВЛАСТИВОСТІ АТОМА";
            this.button95.UseVisualStyleBackColor = false;
            this.button95.Click += new System.EventHandler(this.Button95_Click);
            // 
            // button90
            // 
            this.button90.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button90.Location = new System.Drawing.Point(1056, 373);
            this.button90.Name = "button90";
            this.button90.Size = new System.Drawing.Size(77, 28);
            this.button90.TabIndex = 117;
            this.button90.Text = "<< НАЗАД";
            this.button90.UseVisualStyleBackColor = true;
            this.button90.Visible = false;
            this.button90.Click += new System.EventHandler(this.button90_Click);
            // 
            // button91
            // 
            this.button91.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.button91.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button91.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button91.Location = new System.Drawing.Point(887, 574);
            this.button91.Name = "button91";
            this.button91.Size = new System.Drawing.Size(209, 46);
            this.button91.TabIndex = 118;
            this.button91.Text = " ";
            this.button91.UseVisualStyleBackColor = false;
            // 
            // button84
            // 
            this.button84.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.button84.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button84.Enabled = false;
            this.button84.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button84.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button84.ForeColor = System.Drawing.Color.Black;
            this.button84.Location = new System.Drawing.Point(889, 525);
            this.button84.Name = "button84";
            this.button84.Size = new System.Drawing.Size(118, 29);
            this.button84.TabIndex = 107;
            this.button84.Text = "РОЗРАХУВАТИ";
            this.button84.UseVisualStyleBackColor = false;
            this.button84.Visible = false;
            this.button84.Click += new System.EventHandler(this.button84_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(827, 624);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 20);
            this.label1.TabIndex = 119;
            this.label1.Text = "ІЗОТОП";
            // 
            // izotopbtn
            // 
            this.izotopbtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.izotopbtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.izotopbtn.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.izotopbtn.Location = new System.Drawing.Point(825, 575);
            this.izotopbtn.Name = "izotopbtn";
            this.izotopbtn.Size = new System.Drawing.Size(56, 46);
            this.izotopbtn.TabIndex = 120;
            this.izotopbtn.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel1.Controls.Add(this.button109);
            this.panel1.Controls.Add(this.button108);
            this.panel1.Controls.Add(this.button107);
            this.panel1.Controls.Add(this.button104);
            this.panel1.Controls.Add(this.button105);
            this.panel1.Controls.Add(this.button106);
            this.panel1.Controls.Add(this.button101);
            this.panel1.Controls.Add(this.button102);
            this.panel1.Controls.Add(this.button103);
            this.panel1.Controls.Add(this.button98);
            this.panel1.Controls.Add(this.button99);
            this.panel1.Controls.Add(this.button100);
            this.panel1.Controls.Add(this.button97);
            this.panel1.Controls.Add(this.button96);
            this.panel1.Controls.Add(this.button92);
            this.panel1.Location = new System.Drawing.Point(174, 373);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(335, 80);
            this.panel1.TabIndex = 121;
            this.panel1.Visible = false;
            // 
            // button109
            // 
            this.button109.BackColor = System.Drawing.Color.LightCoral;
            this.button109.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button109.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button109.Font = new System.Drawing.Font("Consolas", 12.75F);
            this.button109.Location = new System.Drawing.Point(293, 3);
            this.button109.Name = "button109";
            this.button109.Size = new System.Drawing.Size(35, 32);
            this.button109.TabIndex = 63;
            this.button109.Text = "Gd";
            this.button109.UseVisualStyleBackColor = false;
            this.button109.Click += new System.EventHandler(this.OnClickButton_Click);
            // 
            // button108
            // 
            this.button108.BackColor = System.Drawing.Color.LightCoral;
            this.button108.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button108.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button108.Font = new System.Drawing.Font("Consolas", 12.75F);
            this.button108.Location = new System.Drawing.Point(211, 41);
            this.button108.Name = "button108";
            this.button108.Size = new System.Drawing.Size(35, 32);
            this.button108.TabIndex = 69;
            this.button108.Text = "Yb";
            this.button108.UseVisualStyleBackColor = false;
            this.button108.Click += new System.EventHandler(this.OnClickButton_Click);
            // 
            // button107
            // 
            this.button107.BackColor = System.Drawing.Color.LightCoral;
            this.button107.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button107.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button107.Font = new System.Drawing.Font("Consolas", 12.75F);
            this.button107.Location = new System.Drawing.Point(170, 41);
            this.button107.Name = "button107";
            this.button107.Size = new System.Drawing.Size(35, 32);
            this.button107.TabIndex = 68;
            this.button107.Text = "Tm";
            this.button107.UseVisualStyleBackColor = false;
            this.button107.Click += new System.EventHandler(this.OnClickButton_Click);
            // 
            // button104
            // 
            this.button104.BackColor = System.Drawing.Color.LightCoral;
            this.button104.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button104.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button104.Font = new System.Drawing.Font("Consolas", 12.75F);
            this.button104.Location = new System.Drawing.Point(129, 41);
            this.button104.Name = "button104";
            this.button104.Size = new System.Drawing.Size(35, 32);
            this.button104.TabIndex = 67;
            this.button104.Text = "Er";
            this.button104.UseVisualStyleBackColor = false;
            this.button104.Click += new System.EventHandler(this.OnClickButton_Click);
            // 
            // button105
            // 
            this.button105.BackColor = System.Drawing.Color.LightCoral;
            this.button105.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button105.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button105.Font = new System.Drawing.Font("Consolas", 12.75F);
            this.button105.Location = new System.Drawing.Point(89, 41);
            this.button105.Name = "button105";
            this.button105.Size = new System.Drawing.Size(35, 32);
            this.button105.TabIndex = 66;
            this.button105.Text = "Ho";
            this.button105.UseVisualStyleBackColor = false;
            this.button105.Click += new System.EventHandler(this.OnClickButton_Click);
            // 
            // button106
            // 
            this.button106.BackColor = System.Drawing.Color.LightCoral;
            this.button106.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button106.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button106.Font = new System.Drawing.Font("Consolas", 12.75F);
            this.button106.Location = new System.Drawing.Point(48, 41);
            this.button106.Name = "button106";
            this.button106.Size = new System.Drawing.Size(35, 32);
            this.button106.TabIndex = 65;
            this.button106.Text = "Dy";
            this.button106.UseVisualStyleBackColor = false;
            this.button106.Click += new System.EventHandler(this.OnClickButton_Click);
            // 
            // button101
            // 
            this.button101.BackColor = System.Drawing.Color.LightCoral;
            this.button101.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button101.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button101.Font = new System.Drawing.Font("Consolas", 12.75F);
            this.button101.Location = new System.Drawing.Point(7, 41);
            this.button101.Name = "button101";
            this.button101.Size = new System.Drawing.Size(35, 32);
            this.button101.TabIndex = 64;
            this.button101.Text = "Tb";
            this.button101.UseVisualStyleBackColor = false;
            this.button101.Click += new System.EventHandler(this.OnClickButton_Click);
            // 
            // button102
            // 
            this.button102.BackColor = System.Drawing.Color.LightCoral;
            this.button102.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button102.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button102.Font = new System.Drawing.Font("Consolas", 12.75F);
            this.button102.Location = new System.Drawing.Point(252, 41);
            this.button102.Name = "button102";
            this.button102.Size = new System.Drawing.Size(35, 32);
            this.button102.TabIndex = 70;
            this.button102.Text = "Lu";
            this.button102.UseVisualStyleBackColor = false;
            this.button102.Click += new System.EventHandler(this.OnClickButton_Click);
            // 
            // button103
            // 
            this.button103.BackColor = System.Drawing.Color.LightCoral;
            this.button103.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button103.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button103.Font = new System.Drawing.Font("Consolas", 12.75F);
            this.button103.Location = new System.Drawing.Point(252, 3);
            this.button103.Name = "button103";
            this.button103.Size = new System.Drawing.Size(35, 32);
            this.button103.TabIndex = 62;
            this.button103.Text = "Eu";
            this.button103.UseVisualStyleBackColor = false;
            this.button103.Click += new System.EventHandler(this.OnClickButton_Click);
            // 
            // button98
            // 
            this.button98.BackColor = System.Drawing.Color.LightCoral;
            this.button98.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button98.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button98.Font = new System.Drawing.Font("Consolas", 12.75F);
            this.button98.Location = new System.Drawing.Point(211, 3);
            this.button98.Name = "button98";
            this.button98.Size = new System.Drawing.Size(35, 32);
            this.button98.TabIndex = 61;
            this.button98.Text = "Sm";
            this.button98.UseVisualStyleBackColor = false;
            this.button98.Click += new System.EventHandler(this.OnClickButton_Click);
            // 
            // button99
            // 
            this.button99.BackColor = System.Drawing.Color.LightCoral;
            this.button99.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button99.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button99.Font = new System.Drawing.Font("Consolas", 12.75F);
            this.button99.Location = new System.Drawing.Point(170, 3);
            this.button99.Name = "button99";
            this.button99.Size = new System.Drawing.Size(35, 32);
            this.button99.TabIndex = 60;
            this.button99.Text = "Pm";
            this.button99.UseVisualStyleBackColor = false;
            this.button99.Click += new System.EventHandler(this.OnClickButton_Click);
            // 
            // button100
            // 
            this.button100.BackColor = System.Drawing.Color.LightCoral;
            this.button100.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button100.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button100.Font = new System.Drawing.Font("Consolas", 12.75F);
            this.button100.Location = new System.Drawing.Point(129, 3);
            this.button100.Name = "button100";
            this.button100.Size = new System.Drawing.Size(35, 32);
            this.button100.TabIndex = 59;
            this.button100.Text = "Nd";
            this.button100.UseVisualStyleBackColor = false;
            this.button100.Click += new System.EventHandler(this.OnClickButton_Click);
            // 
            // button97
            // 
            this.button97.BackColor = System.Drawing.Color.LightCoral;
            this.button97.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button97.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button97.Font = new System.Drawing.Font("Consolas", 12.75F);
            this.button97.Location = new System.Drawing.Point(89, 3);
            this.button97.Name = "button97";
            this.button97.Size = new System.Drawing.Size(35, 32);
            this.button97.TabIndex = 58;
            this.button97.Text = "Pr";
            this.button97.UseVisualStyleBackColor = false;
            this.button97.Click += new System.EventHandler(this.OnClickButton_Click);
            // 
            // button96
            // 
            this.button96.BackColor = System.Drawing.Color.LightCoral;
            this.button96.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button96.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button96.Font = new System.Drawing.Font("Consolas", 12.75F);
            this.button96.Location = new System.Drawing.Point(48, 3);
            this.button96.Name = "button96";
            this.button96.Size = new System.Drawing.Size(35, 32);
            this.button96.TabIndex = 57;
            this.button96.Text = "Ce";
            this.button96.UseVisualStyleBackColor = false;
            this.button96.Click += new System.EventHandler(this.OnClickButton_Click);
            // 
            // button92
            // 
            this.button92.BackColor = System.Drawing.Color.LightCoral;
            this.button92.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button92.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button92.Font = new System.Drawing.Font("Consolas", 12.75F);
            this.button92.Location = new System.Drawing.Point(7, 3);
            this.button92.Name = "button92";
            this.button92.Size = new System.Drawing.Size(35, 32);
            this.button92.TabIndex = 56;
            this.button92.Text = "La";
            this.button92.UseVisualStyleBackColor = false;
            this.button92.Click += new System.EventHandler(this.OnClickButton_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel2.Controls.Add(this.button110);
            this.panel2.Controls.Add(this.button111);
            this.panel2.Controls.Add(this.button112);
            this.panel2.Controls.Add(this.button113);
            this.panel2.Controls.Add(this.button114);
            this.panel2.Controls.Add(this.button115);
            this.panel2.Controls.Add(this.button116);
            this.panel2.Controls.Add(this.button117);
            this.panel2.Controls.Add(this.button118);
            this.panel2.Controls.Add(this.button119);
            this.panel2.Controls.Add(this.button120);
            this.panel2.Controls.Add(this.button121);
            this.panel2.Controls.Add(this.button122);
            this.panel2.Controls.Add(this.button123);
            this.panel2.Controls.Add(this.button124);
            this.panel2.Location = new System.Drawing.Point(174, 459);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(335, 80);
            this.panel2.TabIndex = 122;
            this.panel2.Visible = false;
            // 
            // button110
            // 
            this.button110.BackColor = System.Drawing.Color.MediumPurple;
            this.button110.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button110.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button110.Font = new System.Drawing.Font("Consolas", 12.75F);
            this.button110.Location = new System.Drawing.Point(293, 3);
            this.button110.Name = "button110";
            this.button110.Size = new System.Drawing.Size(35, 32);
            this.button110.TabIndex = 95;
            this.button110.Text = "Cm";
            this.button110.UseVisualStyleBackColor = false;
            this.button110.Click += new System.EventHandler(this.OnClickButton_Click);
            // 
            // button111
            // 
            this.button111.BackColor = System.Drawing.Color.MediumPurple;
            this.button111.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button111.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button111.Font = new System.Drawing.Font("Consolas", 12.75F);
            this.button111.Location = new System.Drawing.Point(211, 41);
            this.button111.Name = "button111";
            this.button111.Size = new System.Drawing.Size(35, 32);
            this.button111.TabIndex = 101;
            this.button111.Text = "No";
            this.button111.UseVisualStyleBackColor = false;
            this.button111.Click += new System.EventHandler(this.OnClickButton_Click);
            // 
            // button112
            // 
            this.button112.BackColor = System.Drawing.Color.MediumPurple;
            this.button112.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button112.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button112.Font = new System.Drawing.Font("Consolas", 12.75F);
            this.button112.Location = new System.Drawing.Point(170, 41);
            this.button112.Name = "button112";
            this.button112.Size = new System.Drawing.Size(35, 32);
            this.button112.TabIndex = 100;
            this.button112.Text = "Md";
            this.button112.UseVisualStyleBackColor = false;
            this.button112.Click += new System.EventHandler(this.OnClickButton_Click);
            // 
            // button113
            // 
            this.button113.BackColor = System.Drawing.Color.MediumPurple;
            this.button113.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button113.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button113.Font = new System.Drawing.Font("Consolas", 12.75F);
            this.button113.Location = new System.Drawing.Point(129, 41);
            this.button113.Name = "button113";
            this.button113.Size = new System.Drawing.Size(35, 32);
            this.button113.TabIndex = 99;
            this.button113.Text = "Fm";
            this.button113.UseVisualStyleBackColor = false;
            this.button113.Click += new System.EventHandler(this.OnClickButton_Click);
            // 
            // button114
            // 
            this.button114.BackColor = System.Drawing.Color.MediumPurple;
            this.button114.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button114.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button114.Font = new System.Drawing.Font("Consolas", 12.75F);
            this.button114.Location = new System.Drawing.Point(89, 41);
            this.button114.Name = "button114";
            this.button114.Size = new System.Drawing.Size(35, 32);
            this.button114.TabIndex = 98;
            this.button114.Text = "Es";
            this.button114.UseVisualStyleBackColor = false;
            this.button114.Click += new System.EventHandler(this.OnClickButton_Click);
            // 
            // button115
            // 
            this.button115.BackColor = System.Drawing.Color.MediumPurple;
            this.button115.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button115.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button115.Font = new System.Drawing.Font("Consolas", 12.75F);
            this.button115.Location = new System.Drawing.Point(48, 41);
            this.button115.Name = "button115";
            this.button115.Size = new System.Drawing.Size(35, 32);
            this.button115.TabIndex = 97;
            this.button115.Text = "Cf";
            this.button115.UseVisualStyleBackColor = false;
            this.button115.Click += new System.EventHandler(this.OnClickButton_Click);
            // 
            // button116
            // 
            this.button116.BackColor = System.Drawing.Color.MediumPurple;
            this.button116.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button116.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button116.Font = new System.Drawing.Font("Consolas", 12.75F);
            this.button116.Location = new System.Drawing.Point(7, 41);
            this.button116.Name = "button116";
            this.button116.Size = new System.Drawing.Size(35, 32);
            this.button116.TabIndex = 96;
            this.button116.Text = "Bk";
            this.button116.UseVisualStyleBackColor = false;
            this.button116.Click += new System.EventHandler(this.OnClickButton_Click);
            // 
            // button117
            // 
            this.button117.BackColor = System.Drawing.Color.MediumPurple;
            this.button117.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button117.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button117.Font = new System.Drawing.Font("Consolas", 12.75F);
            this.button117.Location = new System.Drawing.Point(252, 41);
            this.button117.Name = "button117";
            this.button117.Size = new System.Drawing.Size(35, 32);
            this.button117.TabIndex = 102;
            this.button117.Text = "Lr";
            this.button117.UseVisualStyleBackColor = false;
            this.button117.Click += new System.EventHandler(this.OnClickButton_Click);
            // 
            // button118
            // 
            this.button118.BackColor = System.Drawing.Color.MediumPurple;
            this.button118.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button118.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button118.Font = new System.Drawing.Font("Consolas", 12.75F);
            this.button118.Location = new System.Drawing.Point(252, 3);
            this.button118.Name = "button118";
            this.button118.Size = new System.Drawing.Size(35, 32);
            this.button118.TabIndex = 94;
            this.button118.Text = "Am";
            this.button118.UseVisualStyleBackColor = false;
            this.button118.Click += new System.EventHandler(this.OnClickButton_Click);
            // 
            // button119
            // 
            this.button119.BackColor = System.Drawing.Color.MediumPurple;
            this.button119.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button119.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button119.Font = new System.Drawing.Font("Consolas", 12.75F);
            this.button119.Location = new System.Drawing.Point(211, 3);
            this.button119.Name = "button119";
            this.button119.Size = new System.Drawing.Size(35, 32);
            this.button119.TabIndex = 93;
            this.button119.Text = "Pu";
            this.button119.UseVisualStyleBackColor = false;
            this.button119.Click += new System.EventHandler(this.OnClickButton_Click);
            // 
            // button120
            // 
            this.button120.BackColor = System.Drawing.Color.MediumPurple;
            this.button120.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button120.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button120.Font = new System.Drawing.Font("Consolas", 12.75F);
            this.button120.Location = new System.Drawing.Point(170, 3);
            this.button120.Name = "button120";
            this.button120.Size = new System.Drawing.Size(35, 32);
            this.button120.TabIndex = 92;
            this.button120.Text = "Np";
            this.button120.UseVisualStyleBackColor = false;
            this.button120.Click += new System.EventHandler(this.OnClickButton_Click);
            // 
            // button121
            // 
            this.button121.BackColor = System.Drawing.Color.MediumPurple;
            this.button121.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button121.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button121.Font = new System.Drawing.Font("Consolas", 12.75F);
            this.button121.Location = new System.Drawing.Point(129, 3);
            this.button121.Name = "button121";
            this.button121.Size = new System.Drawing.Size(35, 32);
            this.button121.TabIndex = 91;
            this.button121.Text = "U";
            this.button121.UseVisualStyleBackColor = false;
            this.button121.Click += new System.EventHandler(this.OnClickButton_Click);
            // 
            // button122
            // 
            this.button122.BackColor = System.Drawing.Color.MediumPurple;
            this.button122.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button122.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button122.Font = new System.Drawing.Font("Consolas", 12.75F);
            this.button122.Location = new System.Drawing.Point(89, 3);
            this.button122.Name = "button122";
            this.button122.Size = new System.Drawing.Size(35, 32);
            this.button122.TabIndex = 90;
            this.button122.Text = "Pa";
            this.button122.UseVisualStyleBackColor = false;
            this.button122.Click += new System.EventHandler(this.OnClickButton_Click);
            // 
            // button123
            // 
            this.button123.BackColor = System.Drawing.Color.MediumPurple;
            this.button123.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button123.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button123.Font = new System.Drawing.Font("Consolas", 12.75F);
            this.button123.Location = new System.Drawing.Point(48, 3);
            this.button123.Name = "button123";
            this.button123.Size = new System.Drawing.Size(35, 32);
            this.button123.TabIndex = 89;
            this.button123.Text = "Th";
            this.button123.UseVisualStyleBackColor = false;
            this.button123.Click += new System.EventHandler(this.OnClickButton_Click);
            // 
            // button124
            // 
            this.button124.BackColor = System.Drawing.Color.MediumPurple;
            this.button124.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button124.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button124.Font = new System.Drawing.Font("Consolas", 12.75F);
            this.button124.Location = new System.Drawing.Point(7, 3);
            this.button124.Name = "button124";
            this.button124.Size = new System.Drawing.Size(35, 32);
            this.button124.TabIndex = 88;
            this.button124.Text = "Ac";
            this.button124.UseVisualStyleBackColor = false;
            this.button124.Click += new System.EventHandler(this.OnClickButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 575);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 17);
            this.label2.TabIndex = 1000;
            this.label2.Text = "Автори:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(77, 574);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(124, 17);
            this.label3.TabIndex = 1001;
            this.label3.Text = "Денис Корольчук";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(77, 592);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 17);
            this.label4.TabIndex = 1002;
            this.label4.Text = "Новак Богдан";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 621);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(252, 17);
            this.label5.TabIndex = 1003;
            this.label5.Text = "Alma mater: NU LP KI-14 2019-2020 ©";
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(1184, 642);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.izotopbtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button91);
            this.Controls.Add(this.button90);
            this.Controls.Add(this.button95);
            this.Controls.Add(this.button94);
            this.Controls.Add(this.button93);
            this.Controls.Add(this.button89);
            this.Controls.Add(this.button88);
            this.Controls.Add(this.button87);
            this.Controls.Add(this.button86);
            this.Controls.Add(this.button85);
            this.Controls.Add(this.button84);
            this.Controls.Add(this.button83);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button82);
            this.Controls.Add(this.button81);
            this.Controls.Add(this.button80);
            this.Controls.Add(this.button79);
            this.Controls.Add(this.button78);
            this.Controls.Add(this.button77);
            this.Controls.Add(this.button76);
            this.Controls.Add(this.button75);
            this.Controls.Add(this.button74);
            this.Controls.Add(this.button73);
            this.Controls.Add(this.button72);
            this.Controls.Add(this.button71);
            this.Controls.Add(this.button70);
            this.Controls.Add(this.button69);
            this.Controls.Add(this.button68);
            this.Controls.Add(this.button67);
            this.Controls.Add(this.button66);
            this.Controls.Add(this.button65);
            this.Controls.Add(this.button64);
            this.Controls.Add(this.button63);
            this.Controls.Add(this.button62);
            this.Controls.Add(this.button61);
            this.Controls.Add(this.button60);
            this.Controls.Add(this.button59);
            this.Controls.Add(this.button58);
            this.Controls.Add(this.button57);
            this.Controls.Add(this.button56);
            this.Controls.Add(this.button55);
            this.Controls.Add(this.button54);
            this.Controls.Add(this.button53);
            this.Controls.Add(this.button52);
            this.Controls.Add(this.button51);
            this.Controls.Add(this.button50);
            this.Controls.Add(this.button49);
            this.Controls.Add(this.button48);
            this.Controls.Add(this.button47);
            this.Controls.Add(this.button46);
            this.Controls.Add(this.button44);
            this.Controls.Add(this.button45);
            this.Controls.Add(this.button43);
            this.Controls.Add(this.button42);
            this.Controls.Add(this.button41);
            this.Controls.Add(this.button40);
            this.Controls.Add(this.button39);
            this.Controls.Add(this.button38);
            this.Controls.Add(this.button37);
            this.Controls.Add(this.button36);
            this.Controls.Add(this.button35);
            this.Controls.Add(this.button34);
            this.Controls.Add(this.button33);
            this.Controls.Add(this.button32);
            this.Controls.Add(this.button31);
            this.Controls.Add(this.button30);
            this.Controls.Add(this.button29);
            this.Controls.Add(this.button28);
            this.Controls.Add(this.button27);
            this.Controls.Add(this.button26);
            this.Controls.Add(this.button25);
            this.Controls.Add(this.button24);
            this.Controls.Add(this.button23);
            this.Controls.Add(this.button22);
            this.Controls.Add(this.button21);
            this.Controls.Add(this.button20);
            this.Controls.Add(this.button19);
            this.Controls.Add(this.button18);
            this.Controls.Add(this.button17);
            this.Controls.Add(this.button16);
            this.Controls.Add(this.button15);
            this.Controls.Add(this.button14);
            this.Controls.Add(this.button13);
            this.Controls.Add(this.button12);
            this.Controls.Add(this.button11);
            this.Controls.Add(this.button10);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NUCLEAR PHYSIC";
            this.Click += new System.EventHandler(this.FormClick);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
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

            pictureBox1.Image = Image.FromFile(Addres);        
            pictureBox1.Visible = true;
            button95.Visible = false;
            button94.Visible = false;
            button93.Visible = false;
            button90.Visible = true;
        }

        private void Button94_Click(object sender, EventArgs e)
        {
            pictureBox1.Visible = false;
            string Addres = "img\\";

            Addres = Addres + NameOfElements[SelectedElement + 1] + "_H.jpg";

            pictureBox1.Image = Image.FromFile(Addres);
            pictureBox1.Visible = true;
            button95.Visible = false;
            button94.Visible = false;
            button93.Visible = false;
            button90.Visible = true;
        }

        private void Button93_Click(object sender, EventArgs e)
        {
            pictureBox1.Visible = false;
            string Addres = "img\\";

            Addres = Addres + NameOfElements[SelectedElement + 1] + "_T.jpg";

            pictureBox1.Image = Image.FromFile(Addres);
            pictureBox1.Visible = true;
            button95.Visible = false;
            button94.Visible = false;
            button93.Visible = false;
            button90.Visible = true;
        }
        Int32 ex2 = 0;
        private void OnClickButton_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            for (int i = 1; i <= 125; i++)
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
            for (int i = 0; i <= 125; i++)
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
        private void FormClick(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = false;
        }
    }
}
