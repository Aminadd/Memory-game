using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace memory_game
{
    public partial class Form1 : Form
    {
       public static bool kreni { get; set; }
        Random random = new Random();
        List<string> brojevi = new List<string>()
        {
            "1","1","2","2","3","3","4","4","5","5",
            "6","6","7","7","8","8","9","9","10","10"
        };

        Label prvaKliknuta, drugaKliknuta;
        public Form1()
        {
            InitializeComponent();
            DodeliIkonePoljima();
        }    

        private void label_Click(object sender, EventArgs e)
        {
            if (kreni == true)
            {
                if (prvaKliknuta != null && drugaKliknuta != null)
                    return;

                Label kliknutaLabela = sender as Label;

                if (kliknutaLabela == null)
                    return;
                if (kliknutaLabela.ForeColor == Color.Black)
                    return;
                if (prvaKliknuta == null)
                {
                    prvaKliknuta = kliknutaLabela;
                    prvaKliknuta.ForeColor = Color.Black;
                    return;
                }

                drugaKliknuta = kliknutaLabela;
                drugaKliknuta.ForeColor = Color.Black;

                proveriPobednika();

                if (prvaKliknuta.Text == drugaKliknuta.Text)
                {
                    prvaKliknuta = null;
                    drugaKliknuta = null;
                }
                else
                    timer1.Start();
            } 
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();

            prvaKliknuta.ForeColor = prvaKliknuta.BackColor;
            drugaKliknuta.ForeColor = drugaKliknuta.BackColor;

            prvaKliknuta = null;
            drugaKliknuta = null; 
        }

        private void proveriPobednika()
        {
            Label label;

            for (int i = 0; i < tableLayoutPanel1.Controls.Count; i++)
            {
                label = tableLayoutPanel1.Controls[i] as Label;
                if (label != null && label.ForeColor == label.BackColor)
                    return;
            }
            MessageBox.Show("Pronasli ste sve");
            Close();        
        }

        private void button1_Click(object sender, EventArgs e)
        {
            kreni = true;  
        }

        private void button2_Click(object sender, EventArgs e)
        {
            kreni = false;
        }

        private void DodeliIkonePoljima()
        {
            Label label;
            int nasumicniBroj;
            
            for(int i = 0; i < tableLayoutPanel1.Controls.Count; i++)
            {
                if (tableLayoutPanel1.Controls[i] is Label)
                    label = (Label)tableLayoutPanel1.Controls[i];
                else
                    continue;

                nasumicniBroj = random.Next(0, brojevi.Count);
                label.Text = brojevi[nasumicniBroj];

                brojevi.RemoveAt(nasumicniBroj);
            } 
        }

      
    }
}
