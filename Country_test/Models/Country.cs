using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Country_test.Models
{
    public class Country
    {
        public Name name { get; set; }
        public List<string> tld { get; set; }
        public string cca2 { get; set; }
        public string ccn3 { get; set; }
        public string cca3 { get; set; }
        public string cioc { get; set; }
        public bool independent { get; set; }
        public string status { get; set; }
        public bool unMember { get; set; }
        public Dictionary<string, Currency> currencies { get; set; }
        public Idd idd { get; set; }
        public List<string> capital { get; set; }
        public List<string> altSpellings { get; set; }
        public string region { get; set; }
        public string subregion { get; set; }
        public Dictionary<string, string> languages { get; set; }
        public Dictionary<string, Translation> translations { get; set; }
    }

    public class Name
    {
        public string common { get; set; }
        public string official { get; set; }
        public Dictionary<string, NativeName> nativeName { get; set; }
    }

    public class NativeName
    {
        public string official { get; set; }
        public string common { get; set; }
    }

    public class Currency
    {
        public string name { get; set; }
        public string symbol { get; set; }
    }

    public class Idd
    {
        public string root { get; set; }
        public List<string> suffixes { get; set; }
    }

    public class Translation
    {
        public string official { get; set; }
        public string common { get; set; }
    }

}