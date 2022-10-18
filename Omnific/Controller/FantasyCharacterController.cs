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

        [HttpPost("/FantasyCharacter")]
        public ActionResult<FantasyCharacter> CreateFantasyCharacterController(string name, double height, double weight, string habitat, string description, string pictureURL, string APIKeyInventor, string powers)
        {
            return _iFantasyCharacterService.CreateNewFantasyCharacter(name, height, weight, habitat, description, pictureURL, APIKeyInventor, powers);
        }

        [HttpGet("/FantasyCharacter")]
        public ActionResult<IEnumerable<FantasyCharacter>> GetAllFantasyCharactersController()
        {
            return _iFantasyCharacterService.GetAllFantasyCharacters();
        }
        [HttpGet("/FantasyCharacter/APIKeyInventor")]
        public ActionResult<IEnumerable<FantasyCharacter>> GetFantasyCharacterByAPIKeyInventorController(string APIKeyInventor)
        {
            return _iFantasyCharacterService.GetFantasyCharacterByAPIKeyInventor(APIKeyInventor);
        }
        [HttpGet("/FantasyCharacter/Id")]
        public ActionResult<FantasyCharacter> GetFantasyCharacterByIdController(int id)
        {
            return _iFantasyCharacterService.GetFantasyCharacterById(id);
        }
        [HttpGet("/FantasyCharacter/Name")]
        public ActionResult<IEnumerable<FantasyCharacter>> GetFantasyCharacterByNameController(string name)
        {
            return _iFantasyCharacterService.GetFantasyCharacterByName(name);
        }
        [HttpDelete("/FantasyCharacter")]
        public ActionResult<FantasyCharacter> DeleteFantasyCharacterByIdController(int id)
        {
            return _iFantasyCharacterService.DeleteFantasyCharacterById(id);
        }
        [HttpPut("/FantasyCharacter")]
        public ActionResult<FantasyCharacter> UpdateFantasyCharacterByIdController(int idFantasyCharacterToUpdate,
    string newName, double newHeight, double newWeight, string newHabitat,
    string newDescription, string newPictureURL, string newPowers)
        {
            return _iFantasyCharacterService.UpdateFantasyCharacterById(idFantasyCharacterToUpdate,
    newName, newHeight, newWeight, newHabitat, newDescription, newPictureURL, newPowers);
        }
    }
}