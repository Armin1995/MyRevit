using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RevitExportTool.ViewModel
{
    class RevitExportViewModel : ViewModelBase
    {
        #region 字段
        private static RevitExportViewModel instance = null;
        private string revitFilePath = string.Empty;
        #endregion

        #region 属性
        public static RevitExportViewModel Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new RevitExportViewModel();
                }
                return instance;
            }
        }

        public string RevitFilePath
        {
            get { return revitFilePath; }
            set
            {
                revitFilePath = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region Command
        public RelayCommand SelectRevitFileCommand { get; set; }
        #endregion

        #region 方法
        public void InitData()
        {
            SelectRevitFileCommand = new RelayCommand(o => this.SelectRevitFile());
        }

        public void ClearData()
        {

        }

        public void SelectRevitFile()
        {
            RevitFilePath = "123";
        }
        #endregion
    }
}
