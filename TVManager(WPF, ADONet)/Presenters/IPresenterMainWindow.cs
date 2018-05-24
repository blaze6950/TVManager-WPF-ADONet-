using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TVManager_WPF__ADONet_.Model;

namespace TVManager_WPF__ADONet_.Presenters
{
    interface IPresenterMainWindow
    {
        void LoadList();        
        void ButtonFind_Click();
        void ButtonNew_Click();
        void ButtonEdit_Click(TVSeries item);
        void ComboBoxFind_TextInput(String findText);
        void ListViewItemRemove(TVSeries item);
    }
}
