using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Kompas6API5;

namespace Steps.NET
{
    /// <summary>
    /// Логика взаимодействия для WPFBWS.xaml
    /// </summary>
    public partial class WPFBWS : UserControl
    {
        //private System.ComponentModel.IContainer components = null;
        public WPFBWS()
        {
            InitializeComponent();
            
        }
        
        

        public delegate void ComboFuncDelBWS();
        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            Step3.Visota = Convert.ToInt32(textbox2.Text);
            Step3.Shirina = Convert.ToInt32(textbox1.Text);
            Step3.IndentX = Convert.ToInt32(textbox3.Text);
            Step3.IndentY = Convert.ToInt32(textbox4.Text);
            Step3.IndentX1 = Convert.ToInt32(textbox5.Text);
            Step3.IndentY1 = Convert.ToInt32(textbox6.Text);
            Step3.IndentX2 = Convert.ToInt32(textbox7.Text);
            Step3.IndentY2 = Convert.ToInt32(textbox8.Text);
            Step3.IndentX3 = Convert.ToInt32(textbox9.Text);
            Step3.IndentY3 = Convert.ToInt32(textbox10.Text);
            Step3.IndentX4 = Convert.ToInt32(textbox11.Text);
            Step3.IndentY4 = Convert.ToInt32(textbox12.Text);
           
            var cfuncdel = new ComboFuncDelBWS[] //работа комбобокса при выборе элемента срабатывает метод
            {
                Step3.KvadratBWS
            };

            if (comboBox1.SelectedIndex >= 0)
            {
                cfuncdel[comboBox1.SelectedIndex]();
            }
            



        }
        private static WPFBWS instancewpfbws;

        public static WPFBWS Instancewpfbws
        {
            get
            {
                if (instancewpfbws == null)
                    instancewpfbws = new WPFBWS();
                return instancewpfbws;

            }
        }
       


        private KompasObject kompasObject;
        public KompasObject KompasObject
        {
            get
            {
                return kompasObject;
            }
            set
            {
                kompasObject = value;
            }
        }
        private ksDocument2D document2d;
        public ksDocument2D Document2D
        {
            get
            {
                return document2d;
            }
            set
            {
                document2d = value;
            }
        }
        
    }
    //partial class WPFBWS
    //{
    //    /// <summary>
    //    /// Required designer variable.
    //    /// </summary>
    //    private System.ComponentModel.IContainer components = null;

    //    /// <summary>
    //    /// Clean up any resources being used.
    //    /// </summary>
    //    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>

    //    //private static WPFBWS instancewpfbws;

    //    //public static WPFBWS Instancewpfbws
    //    //{
    //    //    get
    //    //    {
    //    //        if (instancewpfbws == null)
    //    //            instancewpfbws = new WPFBWS();
    //    //        return instancewpfbws;

    //    //    }
    //    //}
    //    //private KompasObject kompasObject;
    //    //public KompasObject KompasObject
    //    //{
    //    //    get
    //    //    {
    //    //        return kompasObject;
    //    //    }
    //    //    set
    //    //    {
    //    //        kompasObject = value;
    //    //    }
    //    //}
    //    //private ksDocument2D document2d;
    //    //public ksDocument2D Document2D
    //    //{
    //    //    get
    //    //    {
    //    //        return document2d;
    //    //    }
    //    //    set
    //    //    {
    //    //        document2d = value;
    //    //    }
    //    //}
    //    //protected override void Dispose(bool disposing)
    //    //{
    //    //    if (disposing && (components != null))
    //    //    {
    //    //        components.Dispose();
    //    //    }
    //    //    base.Dispose(disposing);
    //    //}

    //    #region Windows Form Designer generated code

    //    /// <summary>
    //    /// Required method for Designer support - do not modify
    //    /// the contents of this method with the code editor.
    //    /// </summary>


    //    #endregion


    //}
}
