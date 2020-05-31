using System;
using System.Collections.Generic;

namespace DogBusinessDB
{
    public partial class Breeder
    {
        public int DogId { get; set; }
        public int DogAge { get; set; }
        public string DogName { get; set; }
        public string DogGender { get; set; }
        public string DogBreed { get; set; }
        public int LitterCount { get; set; }
        public int CurrentPuppyCount { get; set; }
        public string DogNotes { get; set; }
        public DateTime DogCreatedDate { get; set; }
    }
}
