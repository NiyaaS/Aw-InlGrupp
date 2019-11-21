using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace graph_tutorial.ViewModels
{
    public class FieldValues
    {
        public string Title { get; set; }
        public DateTime Time { get; set; }
        public string Description{ get; set; }
        public string Adress{ get; set; }
        public List<string> Peoples{ get; set; }
    }
}