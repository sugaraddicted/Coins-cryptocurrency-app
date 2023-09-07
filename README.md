# Coins cryptocurrency app

The Coins Application is a multi-page application built using C#, the .NET platform, and WPF technologies. It provides a user-friendly interface to explore cryptocurrency data using the CoinCap open API.

## Features

The application offers the following features:

1. **Multi-Page Navigation**: The application uses a navigation structure to move between different pages, enhancing the user experience.

2. **Top 10 Currencies**: The main page displays the top 10 cryptocurrencies based on market capitalization, providing users with a quick overview of the current market trends.

3. **Detailed Currency Information**: Users can view detailed information about a specific currency, including its price, volume, price change, and the markets where it can be purchased along with their respective prices.

4. **Currency Search**: The application allows users to search for a specific currency by name. Users can enter the currency's name and initiate a search to find the desired cryptocurrency.

5. **MVVM Architecture**: The application is built using the Model-View-ViewModel (MVVM) architecture, separating concerns and promoting maintainable and testable code.


## Project Structure

The project is structured as follows:

- `Coins.MVVM.Models`: Contains the data models used in the application.
- `Coins.MVVM.ViewModels`: Includes the view models that handle the application's logic and data interactions.
- `Coins.MVVM.Views`: Contains XAML files for the different views and pages in the application.
- `Coins.Services`: Provides service classes to interact with the CoinCap API.
- `App.xaml`: Application entry point and initialization.
- `MainWindow.xaml`: The main window of the application.






