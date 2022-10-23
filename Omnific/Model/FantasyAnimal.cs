
using System.Xml.Linq;

namespace Omnific.Model
{
    /// <summary>
    /// FantasyAnimal is a character invented by an user inventor.
    /// Generally is the result of a mix of others animal,
    /// ex: Dracat: Dragon + Cat that rapresent the base characters of it.
    /// A Fantasy animal can be composed at max with 2 base animal which could be fantasy animal as well.
    /// </summary>

    public class FantasyAnimal : Character
    {
        public string APIKeyInventor { get; set; }
        public string Powers { get; set; }
        public string AnimalBaseAlpha { get; set; }
        public string AnimalBaseBeta { get; set; }
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="Height"></param>
        /// <param name="Weight"></param>
        /// <param name="Habitat"></param>
        /// <param name="Description"></param>
        /// <param name="PictureURL"></param>
        /// <param name="APIKeyInventor"></param>
        /// <param name="Powers"></param>
        /// <param name="animalBaseAlpha"></param>
        /// <param name="animalBaseBeta"></param>
        public FantasyAnimal(string Name, double Height, double Weight, string Habitat,
            string Description, string PictureURL, string APIKeyInventor, string Powers,
            string animalBaseAlpha, string animalBaseBeta) : base(
                Name, Height, Weight, Habitat, Description, PictureURL)
        {
            this.APIKeyInventor = APIKeyInventor;
            this.Powers = Powers;
            AnimalBaseAlpha = animalBaseAlpha;
            AnimalBaseBeta = animalBaseBeta;
        }
    }
}