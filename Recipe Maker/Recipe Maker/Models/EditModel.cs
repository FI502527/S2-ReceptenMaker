using BusinessObjects;
namespace Recipe_Maker.Models
{
    public class EditModel
    {
        public Recipe Recipe { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        public EditModel(Recipe recipe, List<Ingredient> ingredients)
        {
            Recipe = recipe;
            Ingredients = ingredients;
        }
    }
}
