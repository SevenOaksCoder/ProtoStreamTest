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
        const string ADDRESS = "https://gist.githubusercontent.com/tiangechen/b68782efa49a16edaf07dc2cdaa855ea/raw/0c794a9717f18b094eabab2cd6a6b9a226903577/movies.csv";


        // GET api/values
        [Route("api/get")]
        public List<MusicListViewModel> Get()
        {
            string csvData = string.Empty;
            MusicListViewModel musicList = new MusicListViewModel();
            List<MusicListViewModel> items = new List<MusicListViewModel>();
            int index = 1;

            using (WebClient wc = new WebClient())
            {
                using (StreamReader sr = new StreamReader(wc.OpenRead(ADDRESS)))
                {
                    string currentLine;
                    while ((currentLine = sr.ReadLine()) != null)
                    {
                        if (!currentLine.Contains("%"))
                        {
                            items.Add(MusicListViewModel.FromCsv(currentLine,index++));
                        }
                    }
                    items.OrderBy(x => x.Year);
                }
            }

            return items;
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
