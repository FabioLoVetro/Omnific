
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
        /// <param name="name"></param>
        /// <param name="height"></param>
        /// <param name="weight"></param>
        /// <param name="habitat"></param>
        /// <param name="description"></param>
        /// <param name="pictureURL"></param>
        /// <param name="APIKeyInventor"></param>
        /// <param name="powers"></param>
        /// <param name="animalBaseAlpha"></param>
        /// <param name="animalBaseBeta"></param>
        public FantasyAnimal(string name, double height, double weight, string habitat,
            string description, string pictureURL, string APIKeyInventor, string powers,
            string animalBaseAlpha, string animalBaseBeta) : base(
                name, height, weight, habitat, description, pictureURL)
        {
            this.APIKeyInventor = APIKeyInventor;
            this.Powers = powers;
            AnimalBaseAlpha = animalBaseAlpha;
            AnimalBaseBeta = animalBaseBeta;
        }
    }
}