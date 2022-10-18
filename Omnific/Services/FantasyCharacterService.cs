using Omnific.Model;

namespace Omnific.Services
{
    public class FantasyCharacterService : IFantasyCharacterService
    {
        private readonly OmnificContext _context;

        public FantasyCharacterService(OmnificContext omnificContext)
        {
            _context = omnificContext;
        }

        public FantasyCharacter CreateNewFantasyCharacter(string name, double hight, double weight, string habitat, string description, string characterBaseApha, string characterBaseBeta, string pictureURL, string powers)
        {
            var fantasyCharacter = new FantasyCharacter(name, hight, weight, habitat, description, characterBaseApha, characterBaseBeta, pictureURL, powers);

            _context.Add(fantasyCharacter);
            _context.SaveChanges();

            return fantasyCharacter;
        }

        public List<FantasyCharacter> GetAllFantasyCharacters()
        {
            var fantasyCharacter = _context.FantasyCharacters.ToList();

            return fantasyCharacter;
        }
    }
}
