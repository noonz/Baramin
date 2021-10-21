# Baramin

## Overview
This application is a simple app attempted MVVM structure using Xamarin Forms. It retrieves alcohol beverages from TheCocktailDB api  
and displays them in a list for the user to click and retrieve details.(https://www.thecocktaildb.com/api.php)  

## Libraries
Libraries used in this project include:  
**FlowListView:** nested scroll views  
**SQLite:** database storage  
**Firebase:** database cloud storage  

## Screenshots
<p float="left">
  <img src="./screenshots/bartender_home.png" width="300" height="600">
  <img src="./screenshots/bartender_details.png" width="300" height="600">
  <img src="./screenshots/bartender_favourites.png" width="300" height="600">
</p>

## Pages  

### Home Page  
Displays a list of cocktails using an empty search endpoint. User can click on a list item to retrieve drink details.  

### Random Drink Page  
Displays a button on the middle of the screen that allows that user to click it to retrieve drink details of a random drink.  

### Drink Details
Displays the drink image, title, category, ingredients, measures, and instructions for whichever drink details were selected.  

### Favourites Page
Displays drinks that the user selected as a favourite in the list view. Long pressing on an item allows the user to delete it.  


## Credits: Dave Nunez
