using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
namespace cuRotitaDeLaMouse
{
    public partial class Form1 : Form
    {
        int poz, raza, cx, cy;
        int[,] coord;
        int nr = 36;// numarul de pozitii posibile ale butonului
        public Form1()
        {
            
            double  unghi=360.0/nr, ur=3.1415*unghi/180;

            InitializeComponent();
            poz = 0;
            raza = 100; //raza cercului pe care se misca butonul
            coord = new int[nr,2]; // vector cu coordonatele posibile ale butonului
            cx = this.Width / 2;    // centrul cercului cx- poz pe oriz, cy - pe verticala
            cy = this.Height / 2;
            for(int i=0; i<nr; i++)// calculez coordonatele pozibile
            {
                coord[i, 0] = (int)(cx + raza * Math.Sin(i * ur));
                coord[i, 1] = (int)(cy + raza * Math.Cos(i * ur));
            }
            b1.Top = coord[poz, 1];// pornesc de la prima coordonata
            b1.Left = coord[poz, 0];
            this.MouseWheel += MyMouseWheel;// adaug functia pentru evenimentul de miscare a rotitei
        }
        private void MyMouseWheel(object sender, System.Windows.Forms.MouseEventArgs e)
        {// e functia pentru miscare a rotitei
            if (e.Delta > 0) poz++; // directia de miscare
            else poz--;
            poz = (poz + nr) % nr; // calculez pozitia in vector
            b1.Top = coord[poz, 1]; // mut butonul
            b1.Left = coord[poz, 0];
            Form1.ActiveForm.Text = "x= "+coord[poz,0].ToString(); // doar pentru verificare
        }
           
        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
   
        
    }

