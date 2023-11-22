using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public class RecipeObject
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public int Owner { get; private set; }
        public List<IngredientObject> Ingredients { get; private set; }
        public void AddIngredients(IngredientObject ingredient)
        {
            if (Ingredients == null)
            {
                Ingredients = new List<IngredientObject>();
            }
            Ingredients.Add(ingredient);
        }
        public void SetOwner(int owner)
        {
            Owner = owner;
        }
        public void SetName(string name)
        {
            Name = name;
        }
        public void SetId(int id)
        {
            Id = id;
        }
    }
}
