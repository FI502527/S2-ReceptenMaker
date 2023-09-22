using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CircusTrein;

namespace CircusTrein
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Animal animal1 = new Animal(Type.Carnivore, Size.Small, "A");
			Animal animal2 = new Animal(Type.Herbivore, Size.Medium, "B");
			Animal animal3 = new Animal(Type.Herbivore, Size.Medium, "C");
			Animal animal4 = new Animal(Type.Herbivore, Size.Large, "D");
			Animal animal5 = new Animal(Type.Herbivore, Size.Large, "E");
			List<Animal> animals = new List<Animal>();
			animals.Add(animal1);
			animals.Add(animal2);
			animals.Add(animal3);
			animals.Add(animal4);
			animals.Add(animal5);
			SortWagons Sorter = new SortWagons();

			Sorter.StartSort(animals);
			List<Wagon> wagons = Sorter.GetWagons();
			foreach (Wagon wagon in wagons)
			{
				Console.WriteLine(wagon.ToString());
				int animalAmount = wagon.AnimalAmount();
				if(animalAmount > 0)
				{
					foreach (Animal animal in wagon.GetAnimalList())
					{
						Console.WriteLine(animal.ToString());
					}
				}
			}
		}
	}
}