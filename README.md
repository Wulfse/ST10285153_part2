Recipe App
Welcome to the Recipe App! This console application allows you to manage and interact with recipes by adding, displaying, scaling, resetting, and deleting them. Follow the instructions below to get started.

Features
Add a new recipe: Create a new recipe by specifying the name, ingredients, and steps.
Display all recipes: View a list of all recipes sorted by name.
Display a specific recipe: Search and display a recipe by its name.
Scale a recipe: Scale the quantities of ingredients in a recipe by a given factor.
Reset a recipe: Reset the quantities of ingredients in a recipe to their original values.
Delete a recipe: Remove a recipe from the list.
Usage
Adding a Recipe
Run the application.
Select the option to add a new recipe by entering 1.
Follow the prompts to enter the recipe name, ingredients, and steps.
Displaying All Recipes
Run the application.
Select the option to display all recipes by entering 2.
Displaying a Specific Recipe
Run the application.
Select the option to display a specific recipe by entering 3.
Enter the name of the recipe you want to view.
Scaling a Recipe
Run the application.
Select the option to scale a recipe by entering 4.
Enter the name of the recipe you want to scale.
Enter the scaling factor (e.g., 2 for double, 0.5 for half).
Resetting a Recipe
Run the application.
Select the option to reset a recipe by entering 5.
Enter the name of the recipe you want to reset.
Deleting a Recipe
Run the application.
Select the option to delete a recipe by entering 6.
Enter the name of the recipe you want to delete.
Exiting the Application
Run the application.
Select the option to exit the application by entering 7.
Code Overview
Program Class
Main Method: The entry point of the application. Displays the menu and handles user input.
AddRecipe Method: Prompts the user to add a new recipe with ingredients and steps.
DisplayAllRecipes Method: Displays all recipes sorted by name.
DisplaySpecificRecipe Method: Displays a specific recipe by name.
ScaleRecipe Method: Scales the ingredients of a recipe by a given factor.
ResetRecipe Method: Resets the ingredients of a recipe to their original quantities.
DeleteRecipe Method: Deletes a recipe by name.
NotifyCaloriesExceeded Method: Notifies the user if the total calories of a recipe exceed 300.
Recipe Class
Properties: Name, Ingredients, Steps, OriginalQuantities.
Constructor: Initializes a new recipe with name, ingredients, and steps.
DisplayRecipe Method: Displays the recipe details.
GetTotalCalories Method: Calculates and returns the total calories of the recipe.
ScaleRecipe Method: Scales the ingredients by a given factor.
ResetQuantities Method: Resets the ingredient quantities to their original values.
Ingredient Class
Properties: Name, Quantity, Unit, Calories, FoodGroup.
Constructor: Initializes a new ingredient with the specified details.
Step Class
Properties: Description.
Constructor: Initializes a new step with the specified description.
Requirements
.NET Framework or .NET Core
How to Run
Clone or download the repository.
Open the solution in Visual Studio or your preferred C# development environment.
Build and run the project.
Follow the on-screen prompts to interact with the Recipe App.
