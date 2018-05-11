using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TVManager_WPF__ADONet_.Views.Filter;

namespace TVManager_WPF__ADONet_.Filter.FilterYear
{
    class FilterItemYear : IFilterItem
    {
        public string Item { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool Value { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public FilterItemYear(string item, bool value)
        {
            Item = item;
            Value = value;
        }
    }
}
