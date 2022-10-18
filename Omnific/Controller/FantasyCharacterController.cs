using Microsoft.AspNetCore.Mvc;
using Omnific.Model;
using Omnific.Services;

namespace Omnific.Controller
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class FantasyCharacterController : ControllerBase
    {
        private IFantasyCharacterService _iFantasyCharacterService;

        public FantasyCharacterController(IFantasyCharacterService iFantasyCharacter) {
            _iFantasyCharacterService = iFantasyCharacter;
        }

        [HttpPost]
        public ActionResult<FantasyCharacter> CreateFantasyCharacterController(string name, double hight, double weight, string habitat, string description, string characterBase, string pictureURL, string powers)
        {
            return _iFantasyCharacterService.CreateNewFantasyCharacter(name, hight, weight, habitat, description, characterBase, pictureURL, powers);
        }

        [HttpGet]
        public ActionResult<IEnumerable<FantasyCharacter>> GetAllFantasyCharactersController()
        {
            return _iFantasyCharacterService.GetAllFantasyCharacters();
        }
    }
}
