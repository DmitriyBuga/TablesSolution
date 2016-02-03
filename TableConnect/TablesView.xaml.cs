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
using System.Windows.Shapes;

namespace TableConnect.View
{
    /// <summary>
    /// Interaction logic for TablesView.xaml
    /// </summary>
    public partial class TablesView : Window
    {
        public TablesView()
        {
            InitializeComponent();
        }
        private void btnAppend_Click(object sender, RoutedEventArgs e)
        {
            ConnectionForm oConnect = new ConnectionForm();
            oConnect.Owner = this;
            oConnect.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterOwner;
            oConnect.ShowDialog();

        }
    }
}
