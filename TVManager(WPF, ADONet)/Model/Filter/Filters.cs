using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TVManager_WPF__ADONet_.Filter.FilterYear;
using TVManager_WPF__ADONet_.Views.Filter;
using TVManager_WPF__ADONet_.Views.Filter.FilterChannel;

namespace TVManager_WPF__ADONet_
{
    class Filters
    {
        private IFilter _filterGenre;
        private IFilter _filterChannel;
        private IFilter _filterYear;

        public Filters()
        {
            _filterGenre = new FilterGenre();
            _filterChannel = new FilterChannel();
            _filterYear = new FilterYear();
        }

        public IFilter FilterGenre { get => _filterGenre; set => _filterGenre = value; }
        public IFilter FilterChannel { get => _filterChannel; set => _filterChannel = value; }
        public IFilter FilterYear { get => _filterYear; set => _filterYear = value; }
    }
}
