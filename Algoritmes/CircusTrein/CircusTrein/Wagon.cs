using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CircusTrein
{
	public class Wagon
	{
		private int Points;
		private string WagonName;
		private List<Animal> Animals = new List<Animal>();

		public Wagon(string wagonName)
		{
			Points = 0;
			WagonName = wagonName;
		}
		public override string ToString()
		{
			//string baseString = WagonName + " - Points: " + Points.ToString();
			string baseString = $"{WagonName} - Points: {Points}";
			return baseString;
		}

		public List<Animal> GetAnimalList()
		{
			return Animals;
		}
		public int AnimalAmount()
		{
			return Animals.Count;
		}
		public bool AddAnimal(Animal animal)
		{
			bool status = false;
			Size animalSize = animal.GetSize();
			bool carnivoreCheck = CarnivoreCheck(Animals);
			bool allowedCarnivore = AllowedCarnivore(animal);
			if (!CalculatePoints(this.Points, animal.GetAnimalPoints()))
			{
				status = false;
			}else if(carnivoreCheck){
				switch(animalSize)
				{
					case Size.Small:
						if(!CheckWagonForSize(Size.Small) && !CheckWagonForSize(Size.Medium) && !CheckWagonForSize(Size.Large))
						{
							status = true;
							Animals.Add(animal);
						}
						break;
					case Size.Medium:
						if (!CheckWagonForSize(Size.Medium) && !CheckWagonForSize(Size.Large))
						{
							status = true;
							Animals.Add(animal);
						}
						break;
					case Size.Large:
						if (!CheckWagonForSize(Size.Small) && !CheckWagonForSize(Size.Medium) && !CheckWagonForSize(Size.Large))
						{
							status = true;
							Animals.Add(animal);
						}
						break;
				}
			}
			else
			{
				if (allowedCarnivore)
				{
					Animals.Add(animal);
				}
			}
			if (status)
			{
				switch (animal.GetSize())
				{
					case Size.Small:
						Points = Points + 1;
						break;
					case Size.Medium:
						Points = Points + 3;
						break;
					case Size.Large:
						Points = Points + 5;
						break;
				}
			}
			return status;
		}
		public int HowManyPoints()
		{
			return this.Points;
		}
		public bool CarnivoreCheck(List<Animal> animals)
		{
			bool status = false;
			foreach(Animal animal in animals)
			{
				if(animal.GetType() == Type.Carnivore)
				{
					status = true;
					break;
				}
			}
			return status;
		}
		public bool CalculatePoints(int wagonPoints, int animalPoints)
		{
			int combinedPoints = wagonPoints + animalPoints;
			if(combinedPoints > 10)
			{
				return false;
			}
			else
			{
				return true;
			}
		}
		public bool AllowedCarnivore(Animal animal)
		{
			bool status = false;
			if(animal.GetType() == Type.Herbivore)
			{
				status = true;
			}
			else
			{
				Size size = animal.GetSize();
				switch(size)
				{
					case Size.Large:
						if(CheckWagonForSize(Size.Large) || CheckWagonForSize(Size.Medium) || CheckWagonForSize(Size.Small))
						{
							status = false;
						}
						else
						{
							status = true;
						}
						break;
					case Size.Medium:
						if (CheckWagonForSize(Size.Medium) || CheckWagonForSize(Size.Small))
						{
							status = false;
						}
						else
						{
							status = true;
						}
						break;
					case Size.Small:
						if (CheckWagonForSize(Size.Small))
						{
							status = false;
						}
						else
						{
							status = true;
						}
						break;
				}
			}
			return status;
		}
		public bool CheckWagonForSize(Size size)
		{
			bool status = false;
			bool emptyList = !Animals.Any();
			if(emptyList)
			{
				foreach (Animal animal in Animals)
				{
					if (animal.GetSize() == size)
					{
						status = true;
						break;
					}
					else
					{
						status = false;
					}
				}
			}
			else
			{
				status = true;
			}
			return status;
		}

	}
}
