using System;
using System.Collections.Generic;

namespace MMAApp.Models
{
    public class FightResponse
    {
        public List<Fight> Response { get; set; } = new List<Fight>();
    }

    public class Fight
    {
        public string Slug { get; set; }
        public DateTime Date { get; set; }
        public string Time { get; set; }
        public string Category { get; set; }
        public Fighters Fighters { get; set; }
    }

    public class Fighters
    {
        public FighterInfo First { get; set; }
        public FighterInfo Second { get; set; }
    }

    public class FighterInfo
    {
        public string Name { get; set; }
        public string Logo { get; set; }
        public bool Winner { get; set; }
    }
}
