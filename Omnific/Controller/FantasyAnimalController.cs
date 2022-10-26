using Microsoft.AspNetCore.Mvc;
using Omnific.Model;
using Omnific.Services;

namespace Omnific.Controller
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class FantasyAnimalController : ControllerBase
    {
        private IFantasyAnimalService _iFantasyAnimalService;

        public FantasyAnimalController(IFantasyAnimalService iFantasyAnimal)
        {
            _iFantasyAnimalService = iFantasyAnimal;
        }

        [HttpPost("/FantasyAnimal")]
        public ActionResult<FantasyAnimal?> CreateFantasyAnimal(
            string name, double height, double weight, string habitat,
            string description, string picture, string APIKeyInventor, string powers,
            string animalBaseAlpha, string animalBaseBeta)
        {
            return _iFantasyAnimalService.CreateNewFantasyAnimal(
                name, height, weight, habitat, description, picture, APIKeyInventor, powers,
                animalBaseAlpha, animalBaseBeta);
        }

        [HttpGet("/FantasyAnimal")]
        public ActionResult<IEnumerable<FantasyAnimal>> GetAllFantasyAnimal()
        {
            return _iFantasyAnimalService.GetAllFantasyAnimal();
        }

        [HttpGet("/FantasyAnimal/APIKeyInventor")]
        public ActionResult<IEnumerable<FantasyAnimal>> GetFantasyAnimalByAPIKeyInventor(string APIKeyInventor)
        {
            return _iFantasyAnimalService.GetFantasyAnimalByAPIKeyInventor(APIKeyInventor);
        }

        [HttpGet("/FantasyAnimal/Id")]
        public ActionResult<FantasyAnimal?> GetFantasyAnimalById(int id)
        {
            return _iFantasyAnimalService.GetFantasyAnimalById(id);
        }

        [HttpGet("/FantasyAnimal/Name")]
        public ActionResult<IEnumerable<FantasyAnimal>> GetFantasyAnimalByName(string name)
        {
            return _iFantasyAnimalService.GetFantasyAnimalByName(name);
        }

        [HttpDelete("/FantasyAnimal")]
        public ActionResult<FantasyAnimal?> DeleteFantasyAnimalById(int id)
        {
            return _iFantasyAnimalService.DeleteFantasyAnimalById(id);
        }

        [HttpPut("/FantasyAnimal")]
        public ActionResult<FantasyAnimal?> UpdateFantasyAnimalById(
            int idFantasyAnimalToUpdate,
            string newName, double newHeight, double newWeight, string newHabitat,
            string newDescription, string newPicture, string newAPIKeyInventor, string newPowers,
            string newAnimalBaseAlpha, string newAnimalBaseBeta)
        {
            return _iFantasyAnimalService.UpdateFantasyAnimalById(idFantasyAnimalToUpdate,
                newName, newHeight, newWeight, newHabitat, newDescription, newPicture,  newAPIKeyInventor, newPowers,
                newAnimalBaseAlpha, newAnimalBaseBeta);
        }
    }
}