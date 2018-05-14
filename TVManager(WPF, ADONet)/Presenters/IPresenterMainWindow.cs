using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TVManager_WPF__ADONet_.Presenters
{
    interface IPresenterMainWindow
    {
        void LoadList();        
        void ButtonFind_Click();
        void ButtonNew_Click();
        void ComboBoxFind_TextInput(String findText);
    }
}
