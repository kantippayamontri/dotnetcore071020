using dotnetcore31_071020.Models;

namespace dotnetcore31_071020.Dtos.Character
{
    public class GetCharacterDto
    {
        public int Id {get; set;}
        public string Name {get; set;} = "Frodo";
        public int HitPoints {get; set;} = 100;
        public int Strength {get; set;} = 10;
        public int Intelligence {get; set;} = 10;
        public RPGClass Class {get; set;} = RPGClass.Knight;
        
    }
}