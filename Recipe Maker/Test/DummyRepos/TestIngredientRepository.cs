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
            return new List<Ingredient>();
        }
        public bool AddIngredient(Ingredient ingredient);
        public Ingredient LoadIngredientById(int id);
        public bool UpdateIngredient(Ingredient ingredient);
        public bool DeleteIngredient(int id);
    }
}
