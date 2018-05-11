﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TVManager_WPF__ADONet_.Views.Filter;

namespace TVManager_WPF__ADONet_
{
    class FilterItemGenre : IFilterItem
    {
        public String Item { get; set; }
        public bool Value { get; set; }

        public FilterItemGenre(String genre, bool value)
        {
            Value = value;
        }        
    }
}