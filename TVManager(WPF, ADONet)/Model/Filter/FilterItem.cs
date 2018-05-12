using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TVManager_WPF__ADONet_.Views.Filter;

namespace TVManager_WPF__ADONet_.Model.Filter
{
    class FilterItem : IFilterItem
    {
        public FilterItem(string item, bool value)
        {
            Item = item;
            Value = value;
        }

        public string Item { get; set; }
        public bool Value { get; set; }
    }
}
