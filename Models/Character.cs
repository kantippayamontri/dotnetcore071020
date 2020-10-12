namespace dotnetcore31_071020.Models
{
    public class Character
    {
        public int Id {get; set;}
        public string Name {get; set;} = "Frodo";
        public int HitPoints {get; set;} = 100;
        public int Strength {get; set;} = 10;
        public int Intelligence {get; set;} = 10;
        public RPGClass Class {get; set;} = RPGClass.Knight;
        public User user {get; set;} //for add relation
    }
}