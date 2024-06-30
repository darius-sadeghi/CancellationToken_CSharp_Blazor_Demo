This is a small demo project for how to use cancellation tokens in a C# Blazor project with a WebAPI.

I used the standard WeatherForecast example page from Microsoft and added a second version using a cancellation token.
The pages have an input field in order to simulate a search within some data. For this example there is a small delay and new randomized weather data is being returned from the API.

Using a cancellation token you will see that there will always only be shown the final result of a search even if typing several letters. Without the use of a cancellation token the results lag behind the actual typing of the user.

Please feel free to examine the code and give comments should I have missed some best practices.

In order to start the project you need to select both the CancellationToken.Client and CancellationToken.API as startup projects.
