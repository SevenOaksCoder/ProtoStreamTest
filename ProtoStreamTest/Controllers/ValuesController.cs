using Newtonsoft.Json;
using ProtoStreamTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.IO;
using System.Net.Http;
using System.Web.Http;

namespace ProtoStreamTest.Controllers
{
    public class ValuesController : ApiController
    {
        private const string URL = "https://gist.githubusercontent.com/tiangechen/b68782efa49a16edaf07dc2cdaa855ea/raw/0c794a9717f18b094eabab2cd6a6b9a226903577/movies.csv";
        private List<MusicListViewModel> _records;

        public ValuesController()
        {
            _records = RetrieveData();
        }

        [HttpGet]
        [Route("api/get")]
        public List<MusicListViewModel> Get()
        {
            return _records;
        }

        [HttpGet]
        [Route("api/get/{id}")]
        public MusicListViewModel Get(int id)
        {
            return _records.SingleOrDefault(x => x.Id == id);
        }

        public void Post([FromBody] string value)
        {
        }

        public void Put(int id, [FromBody] string value)
        {

        }

        [HttpGet]
        [Route("api/remove/{id}")]
        public void Delete(int id)
        {
            var itemToRemove = _records.SingleOrDefault(x => x.Id == id);
            if (itemToRemove != null)
                _records.Remove(itemToRemove);
        }

        private List<MusicListViewModel> RetrieveData()
        {
            string csvData = string.Empty;
            MusicListViewModel musicList = new MusicListViewModel();
            List<MusicListViewModel> items = new List<MusicListViewModel>();
            int index = 1;

            using (WebClient wc = new WebClient())
            {
                using (StreamReader sr = new StreamReader(wc.OpenRead(URL)))
                {
                    string currentLine;
                    while ((currentLine = sr.ReadLine()) != null)
                    {
                        if (!currentLine.Contains("%"))
                        {
                            items.Add(MusicListViewModel.FromCsv(currentLine, index++));
                        }
                    }
                    items.OrderBy(x => x.Year);
                    _records = items;
                }
            }

            return items;
        }
    }
}
