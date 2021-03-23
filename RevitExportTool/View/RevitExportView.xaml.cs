using RevitExportTool.ViewModel;
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

namespace RevitExportTool.View
{
    /// <summary>
    /// RevitExportView.xaml 的交互逻辑
    /// </summary>
    public partial class RevitExportView : Window
    {
        public RevitExportView()
        {
            InitializeComponent();

            this.DataContext = RevitExportViewModel.Instance;

            this.Loaded += RevitExportView_Loaded;
            this.Closed += RevitExportView_Closed;
        }

        private void RevitExportView_Loaded(object sender, RoutedEventArgs e)
        {
            if (RevitExportViewModel.Instance != null)
            {
                RevitExportViewModel.Instance.InitData();
            }
        }

        private void RevitExportView_Closed(object sender, EventArgs e)
        {
            if (RevitExportViewModel.Instance != null)
            {
                RevitExportViewModel.Instance.ClearData();
            }
        }
    }
}
