using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CircusTrein
{
	public class Animal
	{
		private Type Type;
		private Size Size;
		private string Name;

		public override string ToString()
		{
			string baseString = Type.ToString() + " - " + Size.ToString() + " - " + Name; 
			return baseString;
		}
		public Animal(Type type, Size size, string name)
		{
			this.Type = type;
			this.Size = size;
			this.Name = name;
		}
		public Size GetSize()
		{
			return this.Size;
		}
		public Type GetType()
		{
			return this.Type;
		}
		public int GetAnimalPoints()
		{
			int animalPoints = 0;
			switch (GetSize())
			{
				case Size.Small:
					animalPoints = 1;
					break;
				case Size.Medium:
					animalPoints = 3;
					break;
				case Size.Large:
					animalPoints = 5;
					break;
			}
			return animalPoints;
		}
	}
}
