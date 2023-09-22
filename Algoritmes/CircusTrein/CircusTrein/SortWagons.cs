using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CircusTrein
{
	public class SortWagons
	{
		private List<Wagon> wagons = new List<Wagon>();
		public List<Wagon> GetWagons()
		{
			return wagons;
		}
		public void StartSort(List<Animal> animals)
		{
			int wagonNumber = 1;
			AddNewWagon(wagonNumber);
			foreach (Animal animal in animals)
			{
				for (int i = 0; i < wagons.Count; i++)
				{
					Wagon wagon = wagons[i];
					bool animalAdded = wagon.AddAnimal(animal);
					if (!animalAdded)
					{
						int added = i + 1;
						if(wagons.Count == added)
						{
							wagonNumber++;
							AddNewWagon(wagonNumber);
							wagons[i + 1].AddAnimal(animal);
							break;
						}
					}
					else
					{
						break;
					}
				}
			}
		}
		public void AddNewWagon(int wagonNumber)
		{
			string wagonName = "Wagon" + wagonNumber.ToString();
			Wagon wagon = new Wagon(wagonName);
			wagons.Add(wagon);
		}
	}
}
