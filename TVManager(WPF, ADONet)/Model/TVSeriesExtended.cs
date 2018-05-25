using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TVManager_WPF__ADONet_.Model
{
    public class TVSeriesExtended : TVSeries
    {
        private String _description;
        private String _channel;
        private List<String> _genreList = new List<string>();
        private int? _numberOfSeasons;

        public TVSeriesExtended()
        {
        }

        public TVSeriesExtended(int id, string image, string name, int? year) : base(id, image, name, year)
        {
        }

        public TVSeriesExtended(string description, string channel, List<string> genreList, int? numberOfSeasons, int id, string image, string name, int? year) : base(id, image, name, year)
        {
            Description = description;
            Channel = channel;
            GenreList = genreList;
            NumberOfSeasons = numberOfSeasons;
        }

        public String GetGenreListToString()
        {
            StringBuilder res = new StringBuilder(_genreList.Count * 5);

            foreach (var genre in _genreList)
            {
                if (res.Length > 0)
                {
                    res.Insert(res.Length, ", ");
                    res.Insert(res.Length, genre);
                }
                else
                {
                    res.Insert(res.Length, genre);
                }
            }

            return res.ToString();
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        public string Channel
        {
            get { return _channel; }
            set { _channel = value; }
        }

        public List<string> GenreList
        {
            get { return _genreList; }
            set { _genreList = value; }
        }

        public int? NumberOfSeasons
        {
            get { return _numberOfSeasons; }
            set { _numberOfSeasons = value; }
        }
    }
}
