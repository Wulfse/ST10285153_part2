using Microsoft.VisualStudio.TestTools.UnitTesting;
using PROG6221_part1;
using System.Collections.Generic;
using System;

namespace PROG6211_Part2_unittests
{
    [TestClass]

    /// <summary>
    /// unit test to test the total calorie calculation
    /// </summary>
    /// ---------------------------------------------------------------------------------------------------------------///
    public class RecipeTests
    {
        [TestMethod]
        public void TestTotalCaloriesCalculation()
        {
            List<Ingredient> ingredients = new List<Ingredient>
            {
                new Ingredient("Sugar", 2, "tbsp", 30, "Carbohydrate"),
                new Ingredient("Butter", 1, "tbsp", 100, "Fat"),
                new Ingredient("Flour", 1, "cup", 120, "Carbohydrate"),
            };

            List<Step> steps = new List<Step>
            {
                new Step("Mix ingredients."),
                new Step("Bake for 20 minutes.")
            };

            Recipe recipe = new Recipe("Test Recipe", ingredients, steps);
            double totalCalories = recipe.GetTotalCalories();

            Assert.AreEqual(250, totalCalories);
        }
    }
}
//-------------------------------------------------------End of Class---------------------------------------------------------//