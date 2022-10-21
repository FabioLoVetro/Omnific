namespace Omnific.Model
{
    /// <summary>
    /// FantasyCharacter is a character invented by an user inventor.
    /// Generally is the result of a mix of others characters,
    /// ex: Dracat: Dragon + Cat that rapresent the base characters of it.
    /// A Fantasy Character can be composed at max with 2 base character which could be fantasy character as well.
    /// </summary>
    public class FantasyCharacter : Character
    {
        public string APIKeyInventor { get; set; }
        public string Powers { get; set; }
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name"></param>
        /// <param name="height"></param>
        /// <param name="weight"></param>
        /// <param name="habitat"></param>
        /// <param name="description"></param>
        /// <param name="pictureURL"></param>
        /// <param name="powers"></param>
        public FantasyCharacter(string name, double height, double weight, string habitat, 
            string description, string pictureURL, string APIKeyInventor, string powers) : 
            base(name, height, weight, habitat, description, pictureURL)
        {
            this.APIKeyInventor = APIKeyInventor;
            Powers = powers;
        }
    }
}
