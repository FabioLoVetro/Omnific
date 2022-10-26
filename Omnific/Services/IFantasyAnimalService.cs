using Omnific.Model;

namespace Omnific.Services
{
    public interface IFantasyAnimalService
    {
        public FantasyAnimal? CreateNewFantasyAnimal(
            string name, double height, double weight, string habitat,
            string description, string pictureURL, string APIKeyInventor, string powers,
            string animalBaseAlpha, string animalBaseBeta);
        public FantasyAnimal? DeleteFantasyAnimalById(int id);
        public List<FantasyAnimal> GetFantasyAnimalByAPIKeyInventor(string APIKeyInventor);
        public FantasyAnimal? GetFantasyAnimalById(int id);
        public List<FantasyAnimal> GetFantasyAnimalByName(string name);
        public FantasyAnimal? UpdateFantasyAnimalById(int idFantasyAnimalToUpdate,
    string newName, double newHeight, double newWeight, string newHabitat,
    string newDescription, string newPictureURL, string APIKeyInventor,string newPowers,string newAnimalBaseAlpha, string newAnimalBaseBeta);
        public List<FantasyAnimal> GetAllFantasyAnimal();
    }
}
