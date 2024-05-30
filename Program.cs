using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROG6221_part1
{
    
        internal class Program
        {
            private static List<Recipe> recipes = new List<Recipe>();
        /// <summary>
        /// Main class
        /// </summary>
        /// <param name="args"></param>
        /// ------------------------------------------------------------------------------------------------------------///
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Recipe App!");

            while (true)
            {
                Console.WriteLine("\nOptions:");
                Console.WriteLine("1. Add a new recipe");
                Console.WriteLine("2. Display all recipes");
                Console.WriteLine("3. Display a specific recipe");
                Console.WriteLine("4. Scale a recipe");
                Console.WriteLine("5. Reset a recipe");
                Console.WriteLine("6. Delete a recipe");
                Console.WriteLine("7. Exit");

                Console.Write("Enter your choice: ");
                if (!int.TryParse(Console.ReadLine(), out int choice))
                {
                    Console.WriteLine("Invalid input! Please enter a valid integer choice.");
                    continue;
                }

                
                // clears console between every input
                Console.Clear();
                //switch that gives all the options for the recipe application
                switch (choice)
                {
                    case 1:
                        AddRecipe();
                        break;
                    case 2:
                        DisplayAllRecipes();
                        break;
                    case 3:
                        DisplaySpecificRecipe();
                        break;
                    case 4:
                        ScaleRecipe();
                        break;
                    case 5:
                        ResetRecipe();
                        break;
                    case 6:
                        DeleteRecipe();
                        break;
                    case 7:
                        Console.WriteLine("\nThank you for using the Recipe App!");
                        return;
                    default:
                        Console.WriteLine("\nInvalid choice! Please enter a valid option.");
                        break;
                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------//

        /// <summary>
        ///  Method to create a recipe by prompting the user for input
        /// </summary>
        /// <returns></returns>
        /// --------------------------------------------------------------------------------------------------------------///
        private static void AddRecipe()
        {
            Console.WriteLine("\nCreating a new recipe...");

            Console.Write("Enter recipe name: ");
            string recipeName = Console.ReadLine();

            int numIngredients;
            do
            {
                Console.Write("Enter the number of ingredients: ");
                if (!int.TryParse(Console.ReadLine(), out numIngredients) || numIngredients <= 0)
                {
                    Console.WriteLine("Invalid input! Please enter a valid positive integer for the number of ingredients.");
                }
            } while (numIngredients <= 0);

            List<Ingredient> ingredients = new List<Ingredient>();

            for (int i = 0; i < numIngredients; i++)
            {
                Console.WriteLine($"Enter details for ingredient {i + 1}:");
                Console.Write("Name: ");
                string name = Console.ReadLine();

                double quantity;
                do
                {
                    Console.Write("Quantity: ");
                    if (!double.TryParse(Console.ReadLine(), out quantity) || quantity <= 0)
                    {
                        Console.WriteLine("Invalid input! Please enter a valid numeric value for quantity.");
                    }
                } while (quantity <= 0);

                Console.Write("Unit: ");
                string unit = Console.ReadLine();

                double calories;
                do
                {
                    Console.Write("Calories: ");
                    if (!double.TryParse(Console.ReadLine(), out calories) || calories < 0)
                    {
                        Console.WriteLine("Invalid input! Please enter a valid numeric value for calories.");
                    }
                } while (calories < 0);

                Console.Write("Food Group: ");
                string foodGroup = Console.ReadLine();

                ingredients.Add(new Ingredient(name, quantity, unit, calories, foodGroup));
            }

            int numSteps;
            do
            {
                Console.Write("Enter the number of steps: ");
                if (!int.TryParse(Console.ReadLine(), out numSteps) || numSteps <= 0)
                {
                    Console.WriteLine("Invalid input! Please enter a valid positive integer for the number of steps.");
                }
            } while (numSteps <= 0);

            List<Step> steps = new List<Step>();

            for (int i = 0; i < numSteps; i++)
            {
                Console.WriteLine($"Enter step {i + 1}:");
                string description = Console.ReadLine();
                steps.Add(new Step(description));
            }

            Recipe recipe = new Recipe(recipeName, ingredients, steps);
            recipe.CaloriesExceeded += NotifyCaloriesExceeded;
            recipes.Add(recipe);

            Console.Clear();
            Console.WriteLine("\nNew recipe created successfully!");
            recipe.DisplayRecipe();
        }
        //------------------------------------------------------------------------------------------------------------------//

        /// <summary>
        ///  Method to display all recipes that have been added in alphabetical order
        /// </summary>
        /// <returns></returns>
        /// --------------------------------------------------------------------------------------------------------------///
        private static void DisplayAllRecipes()
        {
            if (recipes.Count == 0)
            {
                Console.WriteLine("\nNo recipes available.");
                return;
            }

            Console.WriteLine("\nRecipes:");
            var sortedRecipes = recipes.OrderBy(r => r.Name).ToList();
            foreach (var recipe in sortedRecipes)
            {
                Console.WriteLine(recipe.Name);
            }
        }
        //------------------------------------------------------------------------------------------------------------------//

        /// <summary>
        ///  Method to display whichever recipe the user searches
        /// </summary>
        /// <returns></returns>
        /// --------------------------------------------------------------------------------------------------------------///
        private static void DisplaySpecificRecipe()
        {
            if (recipes.Count == 0)
            {
                Console.WriteLine("\nNo recipes available.");
                return;
            }

            Console.Write("Enter the recipe name: ");
            string recipeName = Console.ReadLine();

            var recipe = recipes.FirstOrDefault(r => r.Name.Equals(recipeName, StringComparison.OrdinalIgnoreCase));
            if (recipe == null)
            {
                Console.WriteLine("\nRecipe not found.");
                return;
            }

            recipe.DisplayRecipe();
        }
        //------------------------------------------------------------------------------------------------------------------//

        /// <summary>
        ///  Method to scale a specific recipe by a factor entered by the user
        /// </summary>
        /// <returns></returns>
        /// --------------------------------------------------------------------------------------------------------------///
        private static void ScaleRecipe()
        {
            if (recipes.Count == 0)
            {
                Console.WriteLine("\nNo recipes available.");
                return;
            }

            Console.Write("Enter the recipe name to scale: ");
            string recipeName = Console.ReadLine();

            var recipe = recipes.FirstOrDefault(r => r.Name.Equals(recipeName, StringComparison.OrdinalIgnoreCase));
            if (recipe == null)
            {
                Console.WriteLine("\nRecipe not found.");
                return;
            }

            Console.Write("Enter the scaling factor (e.g., 0.5, 2): ");
            if (!double.TryParse(Console.ReadLine(), out double factor) || factor <= 0)
            {
                Console.WriteLine("Invalid input! Please enter a valid numeric value for the scaling factor.");
                return;
            }

            recipe.ScaleRecipe(factor);
            Console.Clear();
            Console.WriteLine("\nRecipe scaled successfully!");
            recipe.DisplayRecipe();
        }
        //------------------------------------------------------------------------------------------------------------------//

        /// <summary>
        ///  Method to reset a recipe to original values after its been scaled
        /// </summary>
        /// <returns></returns>
        /// --------------------------------------------------------------------------------------------------------------///
        private static void ResetRecipe()
        {
            if (recipes.Count == 0)
            {
                Console.WriteLine("\nNo recipes available.");
                return;
            }

            Console.Write("Enter the recipe name to reset: ");
            string recipeName = Console.ReadLine();

            var recipe = recipes.FirstOrDefault(r => r.Name.Equals(recipeName, StringComparison.OrdinalIgnoreCase));
            if (recipe == null)
            {
                Console.WriteLine("\nRecipe not found.");
                return;
            }

            recipe.ResetQuantities();
            Console.Clear();
            Console.WriteLine("\nRecipe quantities reset successfully!");
            recipe.DisplayRecipe();
        }
        //------------------------------------------------------------------------------------------------------------------//

        /// <summary>
        ///  Method to delete any recipe the user searches
        /// </summary>
        /// <returns></returns>
        /// --------------------------------------------------------------------------------------------------------------///
        private static void DeleteRecipe()
        {
            if (recipes.Count == 0)
            {
                Console.WriteLine("\nNo recipes available.");
                return;
            }

            Console.Write("Enter the recipe name to delete: ");
            string recipeName = Console.ReadLine();

            var recipe = recipes.FirstOrDefault(r => r.Name.Equals(recipeName, StringComparison.OrdinalIgnoreCase));
            if (recipe == null)
            {
                Console.WriteLine("\nRecipe not found.");
                return;
            }

            recipes.Remove(recipe);
            Console.Clear();
            Console.WriteLine("\nRecipe deleted successfully!");
        }
        //------------------------------------------------------------------------------------------------------------------//

        /// <summary>
        ///  Method to notify the user if the calorie count of a recipe exceeds 300
        /// </summary>
        /// <returns></returns>
        /// --------------------------------------------------------------------------------------------------------------///
        private static void NotifyCaloriesExceeded(string message)
            {
                Console.WriteLine($"\n{message}");
            }
        }
    
}
//------------------------------------------------------End of File-----------------------------------------------------------//