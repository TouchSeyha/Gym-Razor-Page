# Fitness Hub

Welcome to Fitness Hub, a comprehensive web application designed to manage your fitness journey. This project is built using modern web technologies to provide a seamless and responsive user experience. Below, you'll find an overview of the project, the technologies used, and how to get started.

## Project Overview

Fitness Hub is a web application that offers a range of features to support your fitness journey, including:

- **Member Management**: Easily manage member information, including personal details, contact information, and membership status.
- **Class Scheduling**: Schedule and manage fitness classes, including session types, dates, times, and capacity.
- **Coach and Supervisor Management**: Manage information about coaches and supervisors, including their specializations, working hours, and contact details.
- **Facility Booking**: Book and manage gym facilities, including gym halls and equipment.
- **Personalized Fitness Plans**: Create and manage personalized fitness plans for members.

## Technologies Used

Fitness Hub is built using the following technologies:

- **ASP.NET Core Razor Pages**: For building dynamic, data-driven web pages.
- **Bootstrap**: For responsive design and styling.
- **jQuery**: For interactive elements and client-side scripting.
- **Entity Framework Core**: For data management and database interactions.
- **SQL Server**: For database management.

## Getting Started

To get started with Fitness Hub, follow these steps:

1. **Clone the Repository**: Clone the repository to your local machine using the following command:
   
    ```
   git clone https://github.com/your-username/fitness-hub.git
    ```


2. **Install Dependencies**: Navigate to the project directory and install the required dependencies using the .NET CLI:

    ```
      cd fitness-hub
      dotnet restore
    ```


3. **Update Database Connection**: Update the database connection string in the `appsettings.json` file to match your SQL Server configuration.

4. **Apply Migrations**: Apply the database migrations to create the necessary tables:

    ```
    dotnet ef database update
    ```

   
5. **Run the Application**: Start the application using the .NET CLI:

    ```
    dotnet run
    ```


6. **Access the Application**: Open your web browser and navigate to `http://localhost:5000` to access Fitness Hub.

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for more information.
