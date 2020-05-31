using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace DogBusinessApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static DogRepository.DogRepository dogRepository;

        static App()
        {
            dogRepository = new DogRepository.DogRepository();
        }

        public static DogRepository.DogRepository DogRepository
        {
            get
            {
                return dogRepository;
            }
        }
    }
}
