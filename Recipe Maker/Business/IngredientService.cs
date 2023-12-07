using BusinessObjects;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class IngredientService
    {
        private readonly IIngredientRepository ingredientRepository;
        public IngredientService(IIngredientRepository ingredientRepository)
        {
            this.ingredientRepository = ingredientRepository;
        }
        public List<Ingredient> GetAllIngredients()
        {
            List<Ingredient> allIngredients = ingredientRepository.LoadAllIngredients();
            return allIngredients;
        }
        public bool AddIngredient(Ingredient ingredient)
        {
            return ingredientRepository.AddIngredient(ingredient);
        }
        public Ingredient GetIngredientById(int id)
        {
            return ingredientRepository.LoadIngredientById(id);
        }
        public bool EditIngredient(Ingredient ingredient)
        {
            return ingredientRepository.UpdateIngredient(ingredient);
        }
    }
}
