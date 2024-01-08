using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business;
using Test.DummyRepos;

namespace Test.UnitTests
{
    [TestClass]
    public class IngredientTests
    {
        [TestMethod]
        public void LoadIngredientsTest()
        {
            // Arrange
            TestIngredientRepository repository = new TestIngredientRepository();
            IngredientService ingredientService = new IngredientService(repository);

            // Act
            List<Ingredient> ingredients = ingredientService.GetAllIngredients();

            // Assert
            Assert.AreEqual(3, ingredients.Count);
        }
        [TestMethod]
        public void AddIngredientsTest()
        {
            // Arrange
            TestIngredientRepository repository = new TestIngredientRepository();
            IngredientService ingredientService = new IngredientService(repository);
            Ingredient ingredient = new Ingredient();
            ingredient.SetId(1);
            ingredient.SetName("Pepper");

            // Act
            bool check = ingredientService.AddIngredient(ingredient);

            // Assert
            Assert.IsTrue(check);
        }
        [TestMethod]
        public void GetIngredientTest()
        {
            // Arrange
            TestIngredientRepository repository = new TestIngredientRepository();
            IngredientService ingredientService = new IngredientService(repository);
            int id = 1;

            // Act
            Ingredient fetchedIngredient = ingredientService.GetIngredientById(id);

            // Assert
            Assert.AreEqual(id, fetchedIngredient.Id);
        }
        [TestMethod]
        public void UpdateIngredientTest()
        {
            // Arrange
            TestIngredientRepository repository = new TestIngredientRepository();
            IngredientService ingredientService = new IngredientService(repository);
            Ingredient ingredient = new Ingredient();
            ingredient.SetId(1);
            ingredient.SetName("Pepper");

            // Act
            bool check = ingredientService.EditIngredient(ingredient);

            // Assert
            Assert.IsTrue(check);
        }
        [TestMethod]
        public void DeleteIngredientTest()
        {
            // Arrange
            TestIngredientRepository repository = new TestIngredientRepository();
            IngredientService ingredientService = new IngredientService(repository);
            int id = 1;

            // Act
            bool check = ingredientService.DeleteIngredient(id);

            // Assert
            Assert.IsTrue(check);
        }
    }
}
