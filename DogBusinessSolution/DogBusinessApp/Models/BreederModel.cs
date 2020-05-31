using System;

namespace DogBusinessApp.Models
{
    public class BreederModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string Breed { get; set; }
        public int LitterCount { get; set; }
        public int CurrentPuppyCount { get; set; }
        public string Notes { get; set; }
        public System.DateTime CreatedDate { get; set; }

        public DogRepository.DogRepository.BreederModel ToRepositoryModel()
        {
            var repositoryModel = new DogRepository.DogRepository.BreederModel
            {
                Age = Age,
                CreatedDate = CreatedDate,
                Gender = Gender,
                Breed = Breed,
                Id = Id,
                Name = Name,
                Notes = Notes,
                LitterCount = LitterCount,
                CurrentPuppyCount = CurrentPuppyCount
            };

            return repositoryModel;
        }

        public BreederModel Clone()
        {
            var clonedOne = (BreederModel)MemberwiseClone();
            //clonedOne.UserList = (string[])UserList.Clone(); //use this format for reference based objects (Array, List, etc)

            return clonedOne;
        }

        public static BreederModel ToModel(DogRepository.DogRepository.BreederModel repositoryModel)
        {
            var breederModel = new BreederModel
            {
                Age = repositoryModel.Age,
                CreatedDate = repositoryModel.CreatedDate,
                Gender = repositoryModel.Gender,
                Breed = repositoryModel.Breed,
                Id = repositoryModel.Id,
                Name = repositoryModel.Name,
                Notes = repositoryModel.Notes,
                LitterCount = repositoryModel.LitterCount,
                CurrentPuppyCount = repositoryModel.CurrentPuppyCount
            };

            return breederModel;
        }
    }
}
