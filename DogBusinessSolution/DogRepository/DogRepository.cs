using DogBusinessDB;
using System.Collections.Generic;
using System.Linq;

namespace DogRepository
{

    public class DogRepository
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
        }
        public BreederModel Add(BreederModel breederModel)
        {
            var dogBusinessDb = ToDbModel(breederModel);

            DatabaseManager.Instance.Breeder.Add(dogBusinessDb);
            DatabaseManager.Instance.SaveChanges();

            breederModel = new BreederModel
            {
                Age = dogBusinessDb.DogAge,
                CreatedDate = dogBusinessDb.DogCreatedDate,
                Gender = dogBusinessDb.DogGender,
                Id = dogBusinessDb.DogId,
                Name = dogBusinessDb.DogName,
                Notes = dogBusinessDb.DogNotes,
                Breed = dogBusinessDb.DogBreed,
                LitterCount = dogBusinessDb.LitterCount,
                CurrentPuppyCount = dogBusinessDb.CurrentPuppyCount
            };
            return breederModel;
        }

        public List<BreederModel> GetAll()
        {
            // Use .Select() to map the database contacts to ContactModel
            var items = DatabaseManager.Instance.Breeder
              .Select(t => new BreederModel
              {
                  Age = t.DogAge,
                  CreatedDate = t.DogCreatedDate,
                  Gender = t.DogGender,
                  Id = t.DogId,
                  Name = t.DogName,
                  Notes = t.DogNotes,
                  Breed = t.DogBreed,
                  LitterCount = t.LitterCount,
                  CurrentPuppyCount = t.CurrentPuppyCount,

              }).ToList();

            return items;
        }

        public bool Update(BreederModel breederModel)
        {
            var original = DatabaseManager.Instance.Breeder.Find(breederModel.Id);

            if (original != null)
            {
                DatabaseManager.Instance.Entry(original).CurrentValues.SetValues(ToDbModel(breederModel));
                DatabaseManager.Instance.SaveChanges();
                return true;
            }

            return false;
        }

        public bool Remove(int dogId)
        {
            var items = DatabaseManager.Instance.Breeder
                                .Where(t => t.DogId == dogId);

            if (items.Count() == 0)
            {
                return false;
            }

            DatabaseManager.Instance.Breeder.Remove(items.First());
            DatabaseManager.Instance.SaveChanges();

            return true;
        }

        private Breeder ToDbModel(BreederModel breederModel)
        {
            var dogBusinessDb = new Breeder
            {
                DogAge = breederModel.Age,
                DogCreatedDate = breederModel.CreatedDate,
                DogGender = breederModel.Gender,
                DogId = breederModel.Id,
                DogName = breederModel.Name,
                DogNotes = breederModel.Notes,
                DogBreed = breederModel.Breed,
                LitterCount = breederModel.LitterCount,
                CurrentPuppyCount = breederModel.CurrentPuppyCount,

            };

            return dogBusinessDb;
        }
    }
}