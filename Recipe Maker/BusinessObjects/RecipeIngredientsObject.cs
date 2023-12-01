using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public class RecipeIngredientsObject
    {
        public int RecipeId { get; private set; }
        public List<int>? IngredientId { get; private set; }

        public RecipeIngredientsObject()
        {
            IngredientId = new List<int>();
        }

        public void SetRecipeId(int recipeId)
        {
            RecipeId = recipeId;
        }

        public void AddIngredientId(int ingredientId)
        {
            if (IngredientId == null)
            {
                IngredientId = new List<int>();
            }

            IngredientId.Add(ingredientId);
        }
    }
}
