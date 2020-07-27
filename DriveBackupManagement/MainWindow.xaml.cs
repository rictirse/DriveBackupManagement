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

namespace DriveBackupManagement
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MapCtrl mc { get; set; } 


        public MainWindow()
        {
            InitializeComponent();

            mc = new MapCtrl("D:\\AutoIt3");

            lv_DirListView.ItemsSource = mc.Table.DefaultView;
        }

        private void btn_Click(object sender, RoutedEventArgs e)
        {
            if (!mc.IsSearchComplete) return;

            (sender as Button).IsEnabled = false;

            var c = new CompressionCtrl(mc.Table);
        }
    }
}
