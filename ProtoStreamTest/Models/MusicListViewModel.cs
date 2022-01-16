using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProtoStreamTest.Models
{
    public class MusicListViewModel
    {
        public int Id { get; set; }
        public string Film { get; set; }
        public string Genre { get; set; }
        public string LeadStudio { get; set; }
        public string AudienceScore { get; set; }
        public string Profitability { get; set; }
        public string RottenTomatoes { get; set; }
        public string WorldwideGross { get; set; }
        public string Year { get; set; }

        public static MusicListViewModel FromCsv(string csvLine, int index)
        {
            string[] values = csvLine.Split(',');
            MusicListViewModel data = new MusicListViewModel();
            data.Id = index++;
            data.Film = values[0];
            data.Genre = values[1];
            data.LeadStudio = values[2];
            data.AudienceScore = values[3];
            data.Profitability = values[4];
            data.RottenTomatoes = values[5];
            data.WorldwideGross = values[6];
            data.Year = values[7];
            return data;
        }
    }
}