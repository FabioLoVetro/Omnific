namespace Omnific.Model
{
    public abstract class Character
    {
        public int Id { get; set; }
        public string APIKeyInventor { get; set; }
        public string Name { get; set; }
        public double Hight { get; set; }
        public double Weight { get; set; }
        public string Habitat { get; set; }
        public string Description { get; set; }
        public string CharacterBase { get; set; }
        public string PictureURL { get; set; }
        public string Powers { get; set; }

        public Character(string name, double hight, double weight, string habitat, string description, string characterBase, string pictureURL, string powers)
        {
            APIKeyInventor = "UID-APIK";
            Name = name;
            Hight = hight;
            Weight = weight;
            Habitat = habitat;
            Description = description;
            CharacterBase = characterBase;
            PictureURL = pictureURL;
            Powers = powers;
        }
    }
}
