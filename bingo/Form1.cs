using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bingo
{
    public partial class Form1 : Form
    {
        int[] delimitacao1 = new int[] { 1, 16, 31, 46, 61 };
        int[] delimitacao2 = new int[] { 16, 31, 46, 61, 76 };
        List<int> verificaAleatorio1 = new List<int>(5);
        List<int> verificaAleatorio2 = new List<int>(5);
        
       
        
        List<int> sorteios = new List<int>(75);
        Label[,] cartela1;
        Label[,] cartela2;

        
        public Form1()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            preencherCartelas();
            timer1.Enabled = true;
            button1.Enabled = false;
   
        }

        private void preencherCartelas()
        {
            Random random = new Random();
            cartela2 = new Label[5, 5] {{ c1, c6, c11, c16, c21 },{ c2, c7, c12, c17, c22},{ c3, c8, c13, c18, c23}, { c4, c9, c14, c19, c24 }, { c5, c10, c15, c20, c25} };
            cartela1 = new Label[5, 5] {{ p1, p6, p11, p16, p21 },{ p2, p7, p12, p17, p22},{ p3, p8, p13, p18, p23}, { p4, p9, p14, p19, p24 }, { p5, p10, p15, p20, p25} };
            for (int i = 0; i < 5; i++)
            {

                for (int j = 0; j < 5; j++)
                {
                    int aleatorio1 = random.Next(delimitacao1[i], delimitacao2[i]);
                    int aleatorio2 = random.Next(delimitacao1[i], delimitacao2[i]);
                    if ((verificaAleatorio1.Contains(aleatorio1) == false) && (verificaAleatorio2.Contains(aleatorio2) == false))
                    {
                        verificaAleatorio1.Add(aleatorio1);
                        cartela1[i, j].Text = aleatorio1.ToString();
                        cartela1[i, j].ForeColor = Color.Black;
                        p13.ForeColor = Color.Red;

                        verificaAleatorio2.Add(aleatorio2);  
                        cartela2[i, j].Text = aleatorio2.ToString();
                        cartela2[i, j].ForeColor = Color.Black;
                        c13.ForeColor = Color.Red;

                    }
                    else
                    {
                        j--;
                    }

                }
                verificaAleatorio1.Clear();
                verificaAleatorio2.Clear();

            }           
        }
    
        private Boolean Marcar(Label[,] car)
        {
            for (int r = 0; r < 5; r++)
            { 
                for (int a = 0; a < 5; a++)
                {
                    if (car[r, a].Text == label51.Text)
                    {
                        car[r, a].ForeColor = Color.Red;
                        return true;
                    }

                }
            }

            return false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Random random = new Random();
            
            for (int i = 0; i < 1; i++)
            {
                int aleatorio = random.Next(1, 76);
                if ((sorteios.Contains(aleatorio) == false))
                {
                    sorteios.Add(aleatorio);
                    
                    label51.Text = aleatorio.ToString();
                }
                else
                {
                    --i;
                }
            }
         
            if (c1.ForeColor == Color.Red && c2.ForeColor == Color.Red && c3.ForeColor == Color.Red && c4.ForeColor == Color.Red && c5.ForeColor == Color.Red || c6.ForeColor == Color.Red && c7.ForeColor == Color.Red && c8.ForeColor == Color.Red && c9.ForeColor == Color.Red && c10.ForeColor == Color.Red || c11.ForeColor == Color.Red && c12.ForeColor == Color.Red && c13.ForeColor == Color.Red && c14.ForeColor == Color.Red && c15.ForeColor == Color.Red || c16.ForeColor == Color.Red && c17.ForeColor == Color.Red && c18.ForeColor == Color.Red && c19.ForeColor == Color.Red && c20.ForeColor == Color.Red || c21.ForeColor == Color.Red && c22.ForeColor == Color.Red && c23.ForeColor == Color.Red && c24.ForeColor == Color.Red && c25.ForeColor == Color.Red || c1.ForeColor == Color.Red && c6.ForeColor == Color.Red && c11.ForeColor == Color.Red && c16.ForeColor == Color.Red && c21.ForeColor == Color.Red || c2.ForeColor == Color.Red && c7.ForeColor == Color.Red && c12.ForeColor == Color.Red && c17.ForeColor == Color.Red && c22.ForeColor == Color.Red || c3.ForeColor == Color.Red && c8.ForeColor == Color.Red && c13.ForeColor == Color.Red && c18.ForeColor == Color.Red && c23.ForeColor == Color.Red || c4.ForeColor == Color.Red && c9.ForeColor == Color.Red && c14.ForeColor == Color.Red && c19.ForeColor == Color.Red && c24.ForeColor == Color.Red || c5.ForeColor == Color.Red && c10.ForeColor == Color.Red && c15.ForeColor == Color.Red && c20.ForeColor == Color.Red && c25.ForeColor == Color.Red || c1.ForeColor == Color.Red && c7.ForeColor == Color.Red && c13.ForeColor == Color.Red && c19.ForeColor == Color.Red && c25.ForeColor == Color.Red || c5.ForeColor == Color.Red && c9.ForeColor == Color.Red && c13.ForeColor == Color.Red && c17.ForeColor == Color.Red && c21.ForeColor == Color.Red)
            {
                timer1.Enabled = false;
                
                if (MessageBox.Show("Você perdeu para a maquina \n Deseja jogar novamente ?", "PC ganhou", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    preencherCartelas();
                    timer1.Enabled = true;
                    button1.Enabled = false;
                    sorteios.Clear();
                }
                else
                {
                    Application.Exit();
                }
         
            }
            
      
            Marcar(cartela2);

        }

        private void labelx_Click(object sender, EventArgs e)
        {
            Label caixasTexto = sender as Label;


            if (sorteios.Contains(int.Parse(caixasTexto.Text)))
            {
                caixasTexto.ForeColor = Color.Red;
            }
            else
            {
                caixasTexto.ForeColor = Color.Black;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
                     
            if (p1.ForeColor == Color.Red && p2.ForeColor == Color.Red && p3.ForeColor == Color.Red && p4.ForeColor == Color.Red && p5.ForeColor == Color.Red || p6.ForeColor == Color.Red && p7.ForeColor == Color.Red && p8.ForeColor == Color.Red && p9.ForeColor == Color.Red && p10.ForeColor == Color.Red || p11.ForeColor == Color.Red && p12.ForeColor == Color.Red && p13.ForeColor == Color.Red && p14.ForeColor == Color.Red && p15.ForeColor == Color.Red || p16.ForeColor == Color.Red && p17.ForeColor == Color.Red && p18.ForeColor == Color.Red && p19.ForeColor == Color.Red && p20.ForeColor == Color.Red || p21.ForeColor == Color.Red && p22.ForeColor == Color.Red && p23.ForeColor == Color.Red && p24.ForeColor == Color.Red && p25.ForeColor == Color.Red || p1.ForeColor == Color.Red && p6.ForeColor == Color.Red && p11.ForeColor == Color.Red && p16.ForeColor == Color.Red && p21.ForeColor == Color.Red || p2.ForeColor == Color.Red && p7.ForeColor == Color.Red && p12.ForeColor == Color.Red && p17.ForeColor == Color.Red && p22.ForeColor == Color.Red || p3.ForeColor == Color.Red && p8.ForeColor == Color.Red && p13.ForeColor == Color.Red && p18.ForeColor == Color.Red && p23.ForeColor == Color.Red || p4.ForeColor == Color.Red && p9.ForeColor == Color.Red && p14.ForeColor == Color.Red && p19.ForeColor == Color.Red && p24.ForeColor == Color.Red || p5.ForeColor == Color.Red && p10.ForeColor == Color.Red && p15.ForeColor == Color.Red && p20.ForeColor == Color.Red && p25.ForeColor == Color.Red || p1.ForeColor == Color.Red && p7.ForeColor == Color.Red && p13.ForeColor == Color.Red && p19.ForeColor == Color.Red && p25.ForeColor == Color.Red || p5.ForeColor == Color.Red && p9.ForeColor == Color.Red && p13.ForeColor == Color.Red && p17.ForeColor == Color.Red && p21.ForeColor == Color.Red)
            {
                timer1.Enabled = false;
                if (MessageBox.Show("Você ganhou! Quem ganha não leva nada, mas parabéns", "Ganhou", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    preencherCartelas();
                    timer1.Enabled = true;
                    button1.Enabled = false;
                    sorteios.Clear();
                }
                else
                {
                    Application.Exit();
                }      
            }
            else
            {
                MessageBox.Show("Para de graça","Tu não ganho nada não");
            }
         
        }
    }
}
