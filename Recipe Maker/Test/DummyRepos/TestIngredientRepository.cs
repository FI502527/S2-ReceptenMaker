using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.DummyRepos
{
    public class TestIngredientRepository : IIngredientRepository
    {
        public List<Ingredient> LoadAllIngredients()
        {
            List<Ingredient> ingredients = new List<Ingredient>();
            Ingredient ingredient1 = new Ingredient();
            ingredient1.SetId(1);
            ingredient1.SetName("Meat");
            Ingredient ingredient2 = new Ingredient();
            ingredient2.SetId(2);
            ingredient2.SetName("Bread");
            Ingredient ingredient3 = new Ingredient();
            ingredient3.SetId(3);
            ingredient3.SetName("Cheese");
            ingredients.Add(ingredient1);
            ingredients.Add(ingredient2);
            ingredients.Add(ingredient3);
            return ingredients;
        }
        public bool AddIngredient(Ingredient ingredient)
        {
            return true;
        }
        public Ingredient LoadIngredientById(int id)
        {
            Ingredient ingredient = new Ingredient();
            ingredient.SetId(id);
            ingredient.SetName("Tomato");
            ingredient.SetDescription("Red and round!");
            return ingredient;
        }
        public bool UpdateIngredient(Ingredient ingredient)
        {
            return true;
        }
        public bool DeleteIngredient(int id)
        {
            return true;
        }
    }
}
