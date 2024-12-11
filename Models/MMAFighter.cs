using System.Collections.Generic;

namespace MMAApp.Models
{
    public class FighterResponse
    {
        public string Get { get; set; }
        public Parameters Parameters { get; set; }
        public List<Fighter> Response { get; set; }
    }

    public class Parameters
    {
        public string Name { get; set; }
    }

    public class Fighter
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Nickname { get; set; }
        public string Photo { get; set; }
        public string Gender { get; set; }
        public string BirthDate { get; set; }
        public string Height { get; set; }
        public string Weight { get; set; }
        public string Reach { get; set; }
        public string Stance { get; set; }
        public string Category { get; set; }
        public FighterTeam Team { get; set; }
        public FighterRecord Record { get; set; }
    }

    public class FighterRecord
    {
        public int Wins { get; set; }
        public int Losses { get; set; }
        public int Draws { get; set; }
    }

    public class FighterTeam
    {
        public string Name { get; set; }
    }


}
