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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private delegate void ComboFuncDelBws();
        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            

            var cfuncdel = new ComboFuncDelBws[] //работа комбобокса при выборе элемента срабатывает метод
            {
                Step3.KvadratBws
            };

            
        }
        private static MainWindow _instanceq;

        public static MainWindow Instanceq
        {
            get { return _instanceq ?? (_instanceq = new MainWindow()); }
            
        }

        public KompasObject KompasObject { get; set; }

        public ksDocument2D Document2D { get; set; }
    }
}
