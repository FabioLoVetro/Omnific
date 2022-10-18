using Omnific.Model;

namespace Omnific.Services
{
    public interface IFantasyCharacterService
    {
        public FantasyCharacter CreateNewFantasyCharacter(string name, double hight, double weight, string habitat, string description, string characterBase, string pictureURL, string powers);
        public List<FantasyCharacter> GetAllFantasyCharacters();
    }
}
