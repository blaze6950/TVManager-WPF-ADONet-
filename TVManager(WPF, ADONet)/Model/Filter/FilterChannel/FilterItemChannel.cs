using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TVManager_WPF__ADONet_.Views.Filter.FilterChannel
{
    class FilterItemChannel : IFilterItem
    {
        public string Item { get; set; }
        public bool Value { get; set; }

        public FilterItemChannel(string channel, bool value)
        {
            Item = channel;
            Value = value;
        }
    }
}
