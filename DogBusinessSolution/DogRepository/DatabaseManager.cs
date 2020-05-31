using System;
using System.Collections.Generic;
using System.Text;
using DogBusinessDB;

namespace DogRepository
{
    public class DatabaseManager
    {
        private static readonly DogBusinessContext entities;

        // Initialize and open the database connection
        static DatabaseManager()
        {
            entities = new DogBusinessContext();
        }

        // Provide an accessor to the database
        public static DogBusinessContext Instance
        {
            get
            {
                return entities;
            }
        }
    }
}