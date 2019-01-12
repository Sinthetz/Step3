using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.CompilerServices;
using Kompas6API5;
using Kompas6Constants;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms.VisualStyles;
using KAPITypes;
using KompasAPI7;
namespace Steps.NET
{
    public partial class Automation : Form
    {

        public Automation()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
        public delegate void ComboFuncDel(); //делегат для комбобокса для перечисления
        public void button1_Click(object sender, EventArgs e)
        {                 
            Step3.Visota = Convert.ToInt32(textBox2.Text);
            Step3.Shirina = Convert.ToInt32(textBox1.Text);
            
            var cfuncdel = new ComboFuncDel[] //работа комбобокса при выборе элемента срабатывает метод
            {
                Step3.WorkDocument, Step3.Econom2, Step3.Econom3, Step3.Econom4, Step3.Econom5, Step3.Econom6,
                Step3.Econom7, Step3.Econom8, Step3.Econom9, Step3.Econom10, Step3.Econom11, Step3.Econom12,
                Step3.Econom13, Step3.Econom14, Step3.Econom15, Step3.Econom16, Step3.Econom17, Step3.Econom18,
                Step3.Econom19, Step3.Econom20, Step3.Econom21, Step3.Econom22, Step3.Econom23, Step3.Econom24,
                Step3.Econom25, Step3.Econom26, Step3.Econom27, Step3.Econom28, Step3.Econom29, Step3.Econom30,
                Step3.Econom31, Step3.Econom32, Step3.Econom33, Step3.Econom34, Step3.Econom35,/* Step3.Econom36,
                Step3.Econom37,*/ Step3.Econom38, Step3.Econom39,/* Step3.Econom40, Step3.Econom41,*/ Step3.Econom42,
                Step3.Econom43, Step3.Econom44, Step3.Econom45, Step3.Econom46, Step3.Econom47, Step3.Econom48,
                Step3.Econom49, Step3.Econom50, Step3.Econom51, Step3.Econom52, Step3.Econom53,/* Step3.Econom54,
                Step3.Econom55,*/ Step3.Econom56,/* Step3.Econom57, Step3.Econom58,*/ Step3.Econom59,/* Step3.Econom60,*/
                Step3.Econom61, Step3.Econom62, Step3.Econom63,/* Step3.Econom64, Step3.Econom65, */Step3.Econom66,
                Step3.Econom67, Step3.Econom68, Step3.Econom69, /*Step3.Econom70, Step3.Econom71, Step3.Econom72,*/
                Step3.Econom73, /*Step3.Econom74, Step3.Econom75, Step3.Econom76, */Step3.Econom77, Step3.Econom78,
                Step3.Econom79,/* Step3.Econom80, Step3.Econom81, */Step3.Econom82, Step3.Econom83, 
                /*Step3.Vclassic1,
                Step3.Vclassic2, Step3.Vclassic3, Step3.Vclassic4, Step3.Vclassic5, Step3.Vclassic6, Step3.Vclassic7,
                Step3.Vclassic8, Step3.Vclassic9, Step3.Vclassic10, Step3.Vclassic11, Step3.Vclassic12,
                Step3.Vclassic13, Step3.Vclassic14, Step3.Vclassic15, Step3.Vclassic16, Step3.Vclassic17,
                Step3.Vclassic18, Step3.Vclassic19, Step3.Vclassic20, Step3.Vclassic21, Step3.Vclassic22,
                Step3.Vclassic23, Step3.Vclassic24, Step3.Vclassic25, Step3.Vclassic26, Step3.Vclassic27,
                Step3.Vclassic28, Step3.Vclassic29, Step3.Vclassic30, Step3.Vclassic31, Step3.Vclassic32,
                Step3.Vclassic33, Step3.Vclassic34, Step3.Vclassic35, Step3.Vclassic36, Step3.Vclassic37,
                Step3.Vclassic38, Step3.Vclassic39, Step3.Vclassic40, Step3.Vclassic41, Step3.Vclassic42,
                Step3.Vclassic43, Step3.Vclassic44, Step3.Vclassic45, Step3.Vclassic46, Step3.Vclassic47,
                Step3.Vclassic48, Step3.Vclassic49, Step3.Vclassic50, Step3.Vclassic51, Step3.Vclassic52,
                Step3.Vclassic53, Step3.Vclassic54, Step3.Vclassic55, Step3.Vclassic56, Step3.Vclassic57,
                Step3.Vclassic58, Step3.Vclassic59, Step3.Vclassic60, Step3.Vclassic61, Step3.Vclassic62,
                Step3.Vclassic63, Step3.Vclassic64, Step3.Vclassic65, Step3.Vclassic66, Step3.Vclassic67,
                Step3.Vclassic68, Step3.Vclassic69, Step3.Vclassic70, Step3.Vclassic71, Step3.Vclassic72,
                Step3.Vclassic73, Step3.Vclassic74, Step3.Vclassic75, Step3.Vclassic76, Step3.Vclassic77,
                Step3.Vclassic78, Step3.Vclassic79, Step3.Vclassic80, Step3.Vclassic81, Step3.Vclassic82,
                Step3.Vclassic83, Step3.Vclassic84, Step3.Vclassic85, Step3.Vclassic86, Step3.Vclassic87,
                Step3.Vclassic88, Step3.Vclassic89, Step3.Vclassic90, Step3.Vclassic91, Step3.Vclassic92,
                Step3.Vclassic93, Step3.Vclassic94, Step3.Vclassic95, Step3.Vclassic96, Step3.Vclassic97,
                Step3.Vclassic98, Step3.Vclassic99, Step3.Vclassic100, Step3.Vclassic101, Step3.Vclassic102,
                Step3.Vclassic103, Step3.Vclassic104, Step3.Vclassic105, Step3.Vclassic106, Step3.Vclassic107,
                Step3.Vclassic108, Step3.Vclassic109, Step3.Vclassic110, Step3.Vclassic111, Step3.Vclassic112,
                Step3.Vclassic113, Step3.Vclassic114, Step3.Vclassic115, Step3.Vclassic116, Step3.Vclassic117,
                Step3.Vclassic118, Step3.Vclassic119, Step3.Vclassic120, Step3.Vclassic121, Step3.Vclassic122,
                Step3.Vclassic123*/
            };
            if (comboBox1.SelectedIndex >= 0)
            {
                cfuncdel[comboBox1.SelectedIndex]();
            }
            Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Length == 0) //кнопка не будет активна если в полях текстбокса ничего нет
            {
                button1.Enabled = false;
            }
            else
            {
                button1.Enabled = true;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text.Length == 0) //кнопка не будет активна если в полях текстбокса ничего нет
            {
                button1.Enabled = false;
            }
            else
            {
                button1.Enabled = true;
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= '0' && e.KeyChar <= '9' || e.KeyChar == (char)Keys.Back) //можно печатать только цифры и стирать их
            {
               e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= '0' && e.KeyChar <= '9' || e.KeyChar == (char)Keys.Back) //можно печатать только цифры и стирать их
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
    }
}
