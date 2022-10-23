
using Omnific.Model;

namespace Omnific.Services
{
    /// <summary>
    /// public class FantasyAnimalService : IFantasyAnimalService
    /// </summary>
    public class FantasyAnimalService : IFantasyAnimalService
    {
        /// <summary>
        /// The context
        /// </summary>
        private readonly OmnificContext _context;
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="omnificContext"></param>
        public FantasyAnimalService(OmnificContext omnificContext)
        {
            _context = omnificContext;
        }
        /// <summary>
        /// public FantasyAnimal? CreateNewFantasyAnimal(string name, double height, double weight, string habitat, string description, string pictureURL, string powers, string animalBaseAlpha, string animalBaseBeta)
        /// Creates and returns a new fantasy animal,
        /// null if is not possible create one
        /// </summary>
        /// <param name="name"></param>
        /// <param name="height"></param>
        /// <param name="weight"></param>
        /// <param name="habitat"></param>
        /// <param name="description"></param>
        /// <param name="pictureURL"></param>
        /// <param name="powers"></param>
        /// <param name="animalBaseAlpha"></param>
        /// <param name="animalBaseBeta"></param>
        /// <returns></returns>
        public FantasyAnimal? CreateNewFantasyAnimal(
            string Name, double Height, double Weight, string Habitat,
            string Description, string PictureURL, string Powers,
            string animalBaseAlpha, string animalBaseBeta)
        {
            var userLoggedIn = _context.Users.FirstOrDefault(user => user.Id == (_context.Logs.ToList().ElementAt(0).IdUser));
            // if the user is not logged in return null
            if (userLoggedIn == null) return null;
            string APIKeyInventor = userLoggedIn.ApiKey;
            var fantasyAnimal = new FantasyAnimal(
                Name, Height, Weight, Habitat, Description, PictureURL,
                APIKeyInventor, Powers, animalBaseAlpha, animalBaseBeta);

            _context.Add(fantasyAnimal);
            _context.SaveChanges();
            //if the user is a viewer, set it as inventor
            if (userLoggedIn.UserType == UserType.Viewer) userLoggedIn.UserType = UserType.Inventor;

            return fantasyAnimal;
        }
        /// <summary>
        /// public FantasyAnimal? DeleteFantasyAnimalById(int id)
        /// delete and return a fantasy animal by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public FantasyAnimal? DeleteFantasyAnimalById(int id)
        {
            //retrieve the logged in user
            var userLoggedIn = _context.Users.FirstOrDefault(user => user.Id == (_context.Logs.ToList().ElementAt(0).IdUser));
            FantasyAnimal? fantasyAnimal = this.GetFantasyAnimalById(id);
            // if the user is not logged in return null
            if (userLoggedIn != null
                && fantasyAnimal != null
                && (userLoggedIn.IsUserAdministrator() || userLoggedIn.ApiKey == fantasyAnimal.APIKeyInventor))
            {
                _context.Remove(fantasyAnimal);
                _context.SaveChanges();
                return fantasyAnimal;
            }
            return null;
        }
        /// <summary>
        /// public List<FantasyAnimal> GetAllFantasyAnimal()
        /// returns all the fantasy animals in a list
        /// </summary>
        /// <returns></returns>
        public List<FantasyAnimal> GetAllFantasyAnimal()
        {
            var fantasyAnimal = _context.FantasyAnimals.ToList();
            return fantasyAnimal;
        }
        /// <summary>
        /// public List<FantasyAnimal> GetFantasyAnimalByAPIKeyInventor(string APIKeyInventor)
        /// return the fantasy animal by APIKeyInventor,
        /// null if is not exists the APIKeyInventor
        /// </summary>
        /// <param name="APIKeyInventor"></param>
        /// <returns></returns>
        public List<FantasyAnimal> GetFantasyAnimalByAPIKeyInventor(string APIKeyInventor)
        {
            var fantasyAnimal = _context.FantasyAnimals.Where(f => f.APIKeyInventor == APIKeyInventor).ToList();
            return fantasyAnimal;
        }
        /// <summary>
        /// public FantasyAnimal? GetFantasyAnimalById(int id)
        /// returns the fantasy animal by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public FantasyAnimal? GetFantasyAnimalById(int id)
        {
            var fantasyAnimal = _context.FantasyAnimals.FirstOrDefault(f => f.Id == id);
            return fantasyAnimal;
        }
        /// <summary>
        /// public List<FantasyAnimal> GetFantasyAnimalByName(string name)
        /// returns the fantasy animal by name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public List<FantasyAnimal> GetFantasyAnimalByName(string name)
        {
            var fantasyAnimal = _context.FantasyAnimals.Where(fc => fc.Name == name).ToList();
            return fantasyAnimal;
        }

        public FantasyAnimal? UpdateFantasyAnimalById(int idFantasyAnimalToUpdate,
    string newName, double newHeight, double newWeight, string newHabitat,
    string newDescription, string newPictureURL, string newPowers, string newAnimalBaseAlpha, string newAnimalBaseBeta)
        {
            //retrieve the logged in user
            var userLoggedIn = _context.Users.FirstOrDefault(user => user.Id == (_context.Logs.ToList().ElementAt(0).IdUser));
            FantasyAnimal? fantasyAnimal = this.GetFantasyAnimalById(idFantasyAnimalToUpdate);
            // if the user is not logged in return null
            if (userLoggedIn != null
                && fantasyAnimal != null
                && (userLoggedIn.IsUserAdministrator() || userLoggedIn.ApiKey == fantasyAnimal.APIKeyInventor))
            {
                fantasyAnimal.Name = newName;
                fantasyAnimal.Height = newHeight;
                fantasyAnimal.Weight = newWeight;
                fantasyAnimal.Habitat = newHabitat;
                fantasyAnimal.Description = newDescription;
                fantasyAnimal.PictureURL = newPictureURL;
                fantasyAnimal.Powers = newPowers;
                fantasyAnimal.AnimalBaseAlpha = newAnimalBaseAlpha;
                fantasyAnimal.AnimalBaseBeta = newAnimalBaseBeta;
                _context.SaveChanges();
                return fantasyAnimal;
            }
            return null;
        }
    }
}