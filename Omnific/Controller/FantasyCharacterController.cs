using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Omnific.Model;
using Omnific.Services;

namespace Omnific.Controller
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [Authorize]
    public class FantasyCharacterController : ControllerBase
    {
        private IFantasyCharacterService _iFantasyCharacterService;

        public FantasyCharacterController(IFantasyCharacterService iFantasyCharacter)
        {
            _iFantasyCharacterService = iFantasyCharacter;
        }

        [HttpPost("/FantasyCharacter")]
        public ActionResult<FantasyCharacter?> CreateFantasyCharacter(
            string name, double height, double weight, string habitat, string description, string picture, string APIKeyInventor, string powers)
        {
            return _iFantasyCharacterService.CreateNewFantasyCharacter(name, height, weight, habitat, description, picture, APIKeyInventor, powers);
        }

        [HttpGet("/FantasyCharacter")]
        public ActionResult<IEnumerable<FantasyCharacter>> GetAllFantasyCharacter()
        {
            return _iFantasyCharacterService.GetAllFantasyCharacter();
        }

        [HttpGet("/FantasyCharacter/APIKeyInventor")]
        public ActionResult<IEnumerable<FantasyCharacter>> GetFantasyCharacterByAPIKeyInventor(string APIKeyInventor)
        {
            return _iFantasyCharacterService.GetFantasyCharacterByAPIKeyInventor(APIKeyInventor);
        }

        [HttpGet("/FantasyCharacter/Id")]
        public ActionResult<FantasyCharacter?> GetFantasyCharacterById(int id)
        {
            return _iFantasyCharacterService.GetFantasyCharacterById(id);
        }

        [HttpGet("/FantasyCharacter/Name")]
        public ActionResult<IEnumerable<FantasyCharacter>> GetFantasyCharacterByName(string name)
        {
            return _iFantasyCharacterService.GetFantasyCharacterByName(name);
        }

        [HttpDelete("/FantasyCharacter")]
        [Authorize(Roles = "Administrator")]
        public ActionResult<FantasyCharacter?> DeleteFantasyCharacterById(int id)
        {
            return _iFantasyCharacterService.DeleteFantasyCharacterById(id);
        }

        [HttpPut("/FantasyCharacter")]
        [Authorize(Roles = "Administrator")]
        public ActionResult<FantasyCharacter?> UpdateFantasyCharacterById(int idFantasyCharacterToUpdate,
            string newName, double newHeight, double newWeight, string newHabitat,
            string newDescription, string newPicture, string APIKeyInventor, string newPowers)
        {
            return _iFantasyCharacterService.UpdateFantasyCharacterById(idFantasyCharacterToUpdate,
                newName, newHeight, newWeight, newHabitat, newDescription, newPicture, APIKeyInventor, newPowers);
        }
    }
}