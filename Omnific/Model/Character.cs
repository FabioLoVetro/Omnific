namespace Omnific.Model
{
    /// <summary>
    /// Class Character rapresent a general character
    /// </summary>
    public abstract class Character
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Height { get; set; }
        public double Weight { get; set; }
        public string Habitat { get; set; }
        public string Description { get; set; }
        public string PictureURL { get; set; }
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name"></param>
        /// <param name="height"></param>
        /// <param name="weight"></param>
        /// <param name="habitat"></param>
        /// <param name="description"></param>
        /// <param name="pictureURL"></param>
        public Character(string name, double height, double weight, string habitat, string description, string pictureURL)
        {
            Name = name;
            Height = height;
            Weight = weight;
            Habitat = habitat;
            Description = description;
            PictureURL = pictureURL;
        }
    }
}
