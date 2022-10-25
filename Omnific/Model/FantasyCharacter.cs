namespace Omnific.Model
{
    /// <summary>
    /// FantasyCharacter is a character invented by an user inventor.
    /// Generally is a characters like magician, witch.
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
        /// <param name="picture"></param>
        /// <param name="APIKeyInventor"></param>
        /// <param name="powers"></param>
        public FantasyCharacter(
            string name, double height, double weight, string habitat,
            string description, string picture, string APIKeyInventor, string powers)
            :base(name, height, weight, habitat, description, picture)
        {
            this.APIKeyInventor = APIKeyInventor;
            this.Powers = powers;
        }
    }
}
