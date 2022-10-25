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
        public ActionResult<FantasyAnimal?> CreateFantasyAnimalController(
            string name, double height, double weight, string habitat,
            string description, string picture, string powers,
            string animalBaseAlpha, string animalBaseBeta)
        {
            return _iFantasyAnimalService.CreateNewFantasyAnimal(
                name, height, weight, habitat, description, picture, powers,
                animalBaseAlpha, animalBaseBeta);
        }

        [HttpGet("/FantasyAnimal")]
        public ActionResult<IEnumerable<FantasyAnimal>> GetAllFantasyAnimalsController()
        {
            return _iFantasyAnimalService.GetAllFantasyAnimal();
        }

        [HttpGet("/FantasyAnimal/APIKeyInventor")]
        public ActionResult<IEnumerable<FantasyAnimal>> GetFantasyAnimalByAPIKeyInventorController(string APIKeyInventor)
        {
            return _iFantasyAnimalService.GetFantasyAnimalByAPIKeyInventor(APIKeyInventor);
        }

        [HttpGet("/FantasyAnimal/Id")]
        public ActionResult<FantasyAnimal?> GetFantasyAnimalByIdController(int id)
        {
            return _iFantasyAnimalService.GetFantasyAnimalById(id);
        }

        [HttpGet("/FantasyAnimal/Name")]
        public ActionResult<IEnumerable<FantasyAnimal>> GetFantasyAnimalByNameController(string name)
        {
            return _iFantasyAnimalService.GetFantasyAnimalByName(name);
        }

        [HttpDelete("/FantasyAnimal")]
        public ActionResult<FantasyAnimal?> DeleteFantasyAnimalByIdController(int id)
        {
            return _iFantasyAnimalService.DeleteFantasyAnimalById(id);
        }

        [HttpPut("/FantasyAnimal")]
        public ActionResult<FantasyAnimal?> UpdateFantasyAnimalByIdController(
            int idFantasyAnimalToUpdate,
            string newName, double newHeight, double newWeight, string newHabitat,
            string newDescription, string newPictureURL, string newPowers,
            string newAnimalBaseAlpha, string newAnimalBaseBeta)
        {
            return _iFantasyAnimalService.UpdateFantasyAnimalById(idFantasyAnimalToUpdate,
                newName, newHeight, newWeight, newHabitat, newDescription, newPictureURL, newPowers,
                newAnimalBaseAlpha, newAnimalBaseBeta);
        }
    }
}