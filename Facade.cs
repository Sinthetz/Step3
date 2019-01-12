using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace Steps.NET
{
    public partial class Facade : Form
    {
        public Facade()
        {
            InitializeComponent();
        }

        
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

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

        private void textBox1_TextChanged_1(object sender, EventArgs e)
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
        public delegate void ComboFuncDelFacade();
        private void button1_Click(object sender, EventArgs e)
        {
            Step3.Visota = Convert.ToInt32(textBox2.Text);
            Step3.Shirina = Convert.ToInt32(textBox1.Text);
            Step3.IndentX = Convert.ToInt32(textBox3.Text);
            Step3.IndentY = Convert.ToInt32(textBox4.Text);

            var cfuncdel = new ComboFuncDelFacade[] //работа комбобокса при выборе элемента срабатывает метод
            {
                Step3.ArcaDv,Step3.ArcaOd,Step3.Kvadrat,Step3.Vosmiugolnik,Step3.Tango,Step3.Elegant,Step3.Kapriz,Step3.Venecia,
                Step3.KievskayaDv,Step3.Kvadro,Step3.KlassikaDv,Step3.KlassikaOd,Step3.ZigzagLeft,Step3.ZigzagRight,
                Step3.DuetLeft,Step3.DuetRight,Step3.KvadratDv,Step3.Kletka,Step3.Lzheviborka,Step3.PolosiBokovie,Step3.PolosiDv,
                Step3.Riv_era,Step3.StrelaLeft,Step3.StrelaRight,Step3.StrelaDvLeft,Step3.StrelaDvRight,Step3.Tehno,Step3.TrioLeft,
                Step3.TrioRight,Step3.Universal,Step3.TehnoKrupnii,Step3.TehnoMelkii,Step3.Elegant1,Step3.Elegant2,Step3.KvadratSPryamimUglom,
                Step3.KvadratnayaViborka,Step3.LzheviborkaKvadratnaya,Step3.Neapol
            };
            if (comboBox1.SelectedIndex >= 0)
            {
                cfuncdel[comboBox1.SelectedIndex]();
            }
            Close();

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

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
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
