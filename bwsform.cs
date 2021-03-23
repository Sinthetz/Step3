using System;
using System.Windows.Forms;
using System.Globalization;

namespace Steps.NET
{
    public partial class Bwsform : Form
    {
        private Bwsform()
        {
            InitializeComponent();
            
        }
        #region---------Main parameters--------------
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Length == 0) //кнопка не будет активна если в полях текстбокса ничего нет
            {
                button1.Enabled = false;
                button2.Enabled = false;
                button3.Enabled = false;
            }
            else
            {
                button1.Enabled = true;
                button2.Enabled = true;
                button3.Enabled = true;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text.Length == 0) //кнопка не будет активна если в полях текстбокса ничего нет
            {
                button1.Enabled = false;
                button2.Enabled = false;
                button3.Enabled = false;
            }
            else
            {
                button1.Enabled = true;
                button2.Enabled = true;
                button3.Enabled = true;
            }
        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (textBox3.Text.Length == 0) //кнопка не будет активна если в полях текстбокса ничего нет
            {
                button1.Enabled = false;
                button2.Enabled = false;
                button3.Enabled = false;
            }
            else
            {
                button1.Enabled = true;
                button2.Enabled = true;
                button3.Enabled = true;
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (textBox4.Text.Length == 0) //кнопка не будет активна если в полях текстбокса ничего нет
            {
                button1.Enabled = false;
                button2.Enabled = false;
                button3.Enabled = false;
            }
            else
            {
                button1.Enabled = true;
                button2.Enabled = true;
                button3.Enabled = true;
            }
        }


        private delegate void ComboFuncDelBws();
        private void button1_Click(object sender, EventArgs e)
        {
            Step3.Visota = Convert.ToInt32(textBox2.Text);
            Step3.Shirina = Convert.ToInt32(textBox1.Text);
            Step3.IndentX = Convert.ToInt32(textBox3.Text);
            Step3.IndentY = Convert.ToInt32(textBox4.Text);
            Step3.IndentX1 = Convert.ToInt32(textBox5.Text);
            Step3.IndentY1 = Convert.ToInt32(textBox6.Text);
            Step3.IndentX2 = Convert.ToInt32(textBox7.Text);
            Step3.IndentY2 = Convert.ToInt32(textBox8.Text);
            Step3.IndentX3 = Convert.ToInt32(textBox9.Text);
            Step3.IndentY3 = Convert.ToInt32(textBox10.Text);
            Step3.IndentX4 = Convert.ToInt32(textBox11.Text);
            Step3.IndentY4 = Convert.ToInt32(textBox12.Text);

            var cfuncdel = new ComboFuncDelBws[] //работа комбобокса при выборе элемента срабатывает метод
            {
                Step3.KvadratBws,Step3.KvadratBws2,Step3.KvadratBws3,Step3.KvadratBws4,
            };

            if (comboBox1.SelectedIndex >= 0)
            {
                cfuncdel[comboBox1.SelectedIndex]();
            }

            Close();
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                checkBox1.Visible = true;
                checkBox2.Visible = false;
                checkBox3.Visible = false;
                checkBox4.Visible = false;
                checkBox7.Visible = true;
                label5.Visible = true;
                label6.Visible = true;
                label7.Visible = false;
                label8.Visible = false;
                label9.Visible = false;
                label10.Visible = false;
                label11.Visible = false;
                label12.Visible = false;
                textBox5.Visible = true;
                textBox6.Visible = true;
                textBox7.Visible = false;
                textBox8.Visible = false;
                textBox9.Visible = false;
                textBox10.Visible = false;
                textBox11.Visible = false;
                textBox12.Visible = false;
                textBox14.Visible = true;
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                checkBox1.Visible = true;
                checkBox2.Visible = true;
                checkBox3.Visible = false;
                checkBox4.Visible = false;
                checkBox7.Visible = true;
                label5.Visible = true;
                label6.Visible = true;
                label7.Visible = true;
                label8.Visible = true;
                label9.Visible = false;
                label10.Visible = false;
                label11.Visible = false;
                label12.Visible = false;
                textBox5.Visible = true;
                textBox6.Visible = true;
                textBox7.Visible = true;
                textBox8.Visible = true;
                textBox9.Visible = false;
                textBox10.Visible = false;
                textBox11.Visible = false;
                textBox12.Visible = false;
                textBox14.Visible = true;
            }
            else if (comboBox1.SelectedIndex == 2)
            {
                checkBox1.Visible = true;
                checkBox2.Visible = true;
                checkBox3.Visible = true;
                checkBox4.Visible = false;
                checkBox7.Visible = true;
                label5.Visible = true;
                label6.Visible = true;
                label7.Visible = true;
                label8.Visible = true;
                label9.Visible = true;
                label10.Visible = true;
                label11.Visible = false;
                label12.Visible = false;
                textBox5.Visible = true;
                textBox6.Visible = true;
                textBox7.Visible = true;
                textBox8.Visible = true;
                textBox9.Visible = true;
                textBox10.Visible = true;
                textBox11.Visible = false;
                textBox12.Visible = false;
                textBox14.Visible = true;
            }
            else if (comboBox1.SelectedIndex == 3)
            {
                checkBox1.Visible = true;
                checkBox2.Visible = true;
                checkBox3.Visible = true;
                checkBox4.Visible = true;
                checkBox7.Visible = true;
                label5.Visible = true;
                label6.Visible = true;
                label7.Visible = true;
                label8.Visible = true;
                label9.Visible = true;
                label10.Visible = true;
                label11.Visible = true;
                label12.Visible = true;
                textBox5.Visible = true;
                textBox6.Visible = true;
                textBox7.Visible = true;
                textBox8.Visible = true;
                textBox9.Visible = true;
                textBox10.Visible = true;
                textBox11.Visible = true;
                textBox12.Visible = true;
                textBox14.Visible = true;
            }
            else
            {
                checkBox1.Visible = false;
                checkBox2.Visible = false;
                checkBox3.Visible = false;
                checkBox4.Visible = false;
                checkBox7.Visible = false;
                label5.Visible = false;
                label6.Visible = false;
                label7.Visible = false;
                label8.Visible = false;
                label9.Visible = false;
                label10.Visible = false;
                label11.Visible = false;
                label12.Visible = false;
                textBox5.Visible = false;
                textBox6.Visible = false;
                textBox7.Visible = false;
                textBox8.Visible = false;
                textBox9.Visible = false;
                textBox10.Visible = false;
                textBox11.Visible = false;
                textBox12.Visible = false;
                textBox14.Visible = false;
            }
        }
        
        #endregion

        #region------Advanced parameters-------------

        private void groupBox1_Enter(object sender, EventArgs e)
        {
            
            
        }
        public void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            


        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == false)
            {
                textBox7.Enabled = false;
                textBox8.Enabled = false;
            }
            else
            {
                textBox7.Enabled = true;
                textBox8.Enabled = true;
            }
            
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked == false)
            {
                textBox9.Enabled = false;
                textBox10.Enabled = false;
            }
            else
            {
                textBox9.Enabled = true;
                textBox10.Enabled = true;
            }
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked == false)
            {
                textBox11.Enabled = false;
                textBox12.Enabled = false;
            }
            else
            {
                textBox11.Enabled = true;
                textBox12.Enabled = true;
            }
        }

        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {
            textBox14.Enabled = checkBox4.Checked;
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if (textBox5.Text.Length == 0 && checkBox1.Checked) //кнопка не будет активна если в полях текстбокса ничего нет
            {
                button1.Enabled = false;
                button2.Enabled = false;
                button3.Enabled = false;
            }
            else
            {
                button1.Enabled = true;
                button2.Enabled = true;
                button3.Enabled = true;
            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            if (textBox6.Text.Length == 0 && checkBox1.Checked) 
            {
                button1.Enabled = false;
                button2.Enabled = false;
                button3.Enabled = false;
            }
            else
            {
                button1.Enabled = true;
                button2.Enabled = true;
                button3.Enabled = true;
            }
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            if (textBox7.Text.Length == 0 && checkBox2.Checked) 
            {
                button1.Enabled = false;
                button2.Enabled = false;
                button3.Enabled = false;
            }
            else
            {
                button1.Enabled = true;
                button2.Enabled = true;
                button3.Enabled = true;
            }
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            if (textBox8.Text.Length == 0 && checkBox2.Checked) 
            {
                button1.Enabled = false;
                button2.Enabled = false;
                button3.Enabled = false;
            }
            else
            {
                button1.Enabled = true;
                button2.Enabled = true;
                button3.Enabled = true;
            }
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            if (textBox9.Text.Length == 0 && checkBox3.Checked) 
            {
                button1.Enabled = false;
                button2.Enabled = false;
                button3.Enabled = false;
            }
            else
            {
                button1.Enabled = true;
                button2.Enabled = true;
                button3.Enabled = true;
            }
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            if (textBox10.Text.Length == 0 && checkBox3.Checked) 
            {
                button1.Enabled = false;
                button2.Enabled = false;
                button3.Enabled = false;
            }
            else
            {
                button1.Enabled = true;
                button2.Enabled = true;
                button3.Enabled = true;
            }
        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {
            if (textBox11.Text.Length == 0 && checkBox4.Checked) 
            {
                button1.Enabled = false;
                button2.Enabled = false;
                button3.Enabled = false;
            }
            else
            {
                button1.Enabled = true;
                button2.Enabled = true;
                button3.Enabled = true;
            }
        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {
            if (textBox12.Text.Length == 0 && checkBox4.Checked) 
            {
                button1.Enabled = false;
                button2.Enabled = false;
                button3.Enabled = false;
            }
            else
            {
                button1.Enabled = true;
                button2.Enabled = true;
                button3.Enabled = true;
            }
        }
        private void textBox14_TextChanged(object sender, EventArgs e)
        {
            if (textBox14.Text.Length == 0 && checkBox7.Checked) 
            {
                button1.Enabled = false;
                button2.Enabled = false;
                button3.Enabled = false;
            }
            else
            {
                button1.Enabled = true;
                button2.Enabled = true;
                button3.Enabled = true;
            }
        }
        #endregion

        #region------KEYPRESS--------
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

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBox9_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBox10_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBox11_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBox12_KeyPress(object sender, KeyPressEventArgs e)
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



        #endregion

        private void checkBox1_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked == false)
            {

                textBox5.Enabled = false;
                textBox6.Enabled = false;
            }
            else
            {

                textBox5.Enabled = true;
                textBox6.Enabled = true;
            }
        }
        
        private void textBox13_TextChanged(object sender, EventArgs e)//счетчик количества размеров, созданных для просчитывания
        {
            
            
        }
        private void button2_Click(object sender, EventArgs e)
        {
            textBox13.Text = Convert.ToString(value: Convert.ToInt32(value: textBox13.Text) + 1);
            Step3.Visota = Convert.ToInt32(value: textBox2.Text);
            Step3.Shirina = Convert.ToInt32(value: textBox1.Text);
            var sRazmer = Convert.ToString(value: $"{Step3.Shirina}x{Step3.Visota}");
            
            listBox1.Items.Add(item: sRazmer);
            listBox2.Items.Add(item: Step3.Visota.ToString(CultureInfo.InvariantCulture));
            listBox3.Items.Add(item: Step3.Shirina.ToString(CultureInfo.InvariantCulture));


        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e) //кнопка очистить все
        {
            listBox1.Items.Clear();
            textBox13.Text = "0";
            
        }

        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e) //метод удаления из листбокса по двойному клику
        {
            listBox1.Items.Remove(listBox1.SelectedItem);

            textBox13.Text = Convert.ToString(Convert.ToInt32(textBox13.Text) - 1);
        }

        private void button3_Click(object sender, EventArgs e) //реализация кнопки построить все
        {
            Step3.IndentX = Convert.ToInt32(textBox3.Text);
            Step3.IndentY = Convert.ToInt32(textBox4.Text);
            Step3.IndentX1 = Convert.ToInt32(textBox5.Text);
            Step3.IndentY1 = Convert.ToInt32(textBox6.Text);
            Step3.IndentX2 = Convert.ToInt32(textBox7.Text);
            Step3.IndentY2 = Convert.ToInt32(textBox8.Text);
            Step3.IndentX3 = Convert.ToInt32(textBox9.Text);
            Step3.IndentY3 = Convert.ToInt32(textBox10.Text);
            Step3.IndentX4 = Convert.ToInt32(textBox11.Text);
            Step3.IndentY4 = Convert.ToInt32(textBox12.Text);
            Step3.Visota = Convert.ToInt32(listBox2.Items.ToString());
            Step3.Shirina = Convert.ToInt32(listBox3.Items.ToString());
            

            //Convert.ToInt32(listBox1.SelectedItem.ToString());
            //textBox15.Text = Convert.ToString(listBox1.Items[0]);

            var cfuncdel = new ComboFuncDelBws[] 
            {
                Step3.KvadratBws,Step3.KvadratBws2,Step3.KvadratBws3,Step3.KvadratBws4,
            };

            if (comboBox1.SelectedIndex >= 0)
            {
                cfuncdel[comboBox1.SelectedIndex]();
            }

            

            Close();
        }

        private void textBox15_TextChanged(object sender, EventArgs e)
        {

        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
