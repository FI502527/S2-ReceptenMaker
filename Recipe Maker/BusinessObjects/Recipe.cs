using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public class Recipe
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public int Owner { get; private set; }
        public List<Ingredient> Ingredients { get; private set; }
        public string Description { get; private set; }
        public void AddIngredients(Ingredient ingredient)
        {
            if (Ingredients == null)
            {
                Ingredients = new List<Ingredient>();
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
        public void SetDesc(string desc)
        {
            Description = desc;
        }
        public void SetIngredients(List<Ingredient> ingredients)
        {
            Ingredients = ingredients;
        }
    }
}
