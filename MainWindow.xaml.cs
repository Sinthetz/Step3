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
        public delegate void ComboFuncDelBWS();
        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            

            var cfuncdel = new ComboFuncDelBWS[] //работа комбобокса при выборе элемента срабатывает метод
            {
                Step3.KvadratBWS
            };

            
        }
        private static MainWindow instanceq;

        public static MainWindow Instanceq
        {
            get
            {
                if (instanceq == null)
                    instanceq = new MainWindow();
                return instanceq;
                
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
}
