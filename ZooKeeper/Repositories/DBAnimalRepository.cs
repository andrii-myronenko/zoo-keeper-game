using System;
using System.Collections.ObjectModel;
using System.Linq;
using ZooKeeper.DatabaseContexts;
using ZooKeeper.Models;
using ZooKeeper.Helpers;
using ZooKeeper.Animals;

namespace ZooKeeper.Repositories
{
    class DBAnimalRepository
    {
        private static readonly DBAnimalContext _context = new DBAnimalContext();

        public static ObservableCollection<Animal> GetAnimals(User user)
        {
            var dbAnimals = user.Animals;
            ObservableCollection<Animal> animals = new ObservableCollection<Animal>();
            foreach(DBAnimal animal in dbAnimals)
            {
                animals.Add(AnimalsStore.GetAnimal(animal.Type, animal.Name, animal.Color, animal.UserId));
            }
            return animals;
        }

        public static void SaveAnimal(Animal animal)
        {
            DBAnimal dbAnimal = new DBAnimal(animal.Name, (int)animal.AnimalType, (int)animal.Color, animal.UserId);
            _context.Animals.Add(dbAnimal);
            _context.SaveChanges();
        }
    }
}
