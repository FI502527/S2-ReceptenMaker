using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IIngredientRepository
    {
        public List<Ingredient> LoadAllIngredients();
        public bool AddIngredient(Ingredient ingredient);
        public Ingredient LoadIngredientById(int id);
        public bool UpdateIngredient(Ingredient ingredient);
        public bool DeleteIngredient(int id);
    }
}
