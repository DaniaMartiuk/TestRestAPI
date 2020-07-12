using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]/")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        List<string> words = new List<string>() { 
            "Hello",
            "World",
            "It's",
            "Only"
        };

        //string path_words = "words/";

        [HttpGet]
        [Route("words/{id?}/")]
        public string GetWordById(int? id)
        {
            try
            {
                return words[(int)id];
            }
            catch(Exception e)
            {
                return e.Message;
            }
        }
        
        [HttpPost]
        [Route("words/")]
        public string AddWord([FromBody]string word )
        {
            try 
            {
                words.Add(word);
                return $"added {word}\nid {words.Count - 1}";
            }
            catch(Exception e)
            {
                return e.Message;
            }
        }
        [HttpDelete]
        [Route("words/{id?}/")]
        public string DeleteWord(int? id)
        {
            try
            {
                words.RemoveAt((int)id);
                return "Deleted by id " + id;
            }
            catch(Exception e)
            {
                return e.Message;
            }
        }

        [HttpGet]
        [Route("words/")]
        public IEnumerable<string> GetWords()
        {
            return words;
        }
        public string Home()
        {
            return "It's home page!";
        }
        [HttpGet] 
        [Route("hi/")]
        [Route("hello/")]
        public string Hello()
        {
            return "Hello World!";
        }
    }
}