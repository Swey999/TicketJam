# TicketJam

![GitHub issues](https://img.shields.io/github/issues/Swey999/TicketJam)
![GitHub license](https://img.shields.io/github/license/Swey999/ticketjam)
![GitHub stars](https://img.shields.io/github/stars/Swey999/ticketjam)

TicketJam is a C# application developed in Visual Studio for managing ticket sales and orders. It provides a structured system for ticket availability, inventory control, and concurrency, supporting smooth ticket sales while preventing overselling and ensuring database integrity.

## Table of Contents

- [Project Overview](#project-overview)
- [Features](#features)
- [Installation](#installation)
- [Usage](#usage)
- [Testing](#testing)
- [Contributing](#contributing)
- [License](#license)

## Project Overview

TicketJam enables efficient management of ticket availability and sales across multiple event sections. The application enforces sales rules such as date-based ticket availability, inventory restrictions, and preventing multiple customers from purchasing the last available ticket.

## Features

- **Ticket Management**: Create, update, and manage tickets with start and end date-based availability and section assignments.
- **Order Processing**: Place orders with multiple tickets from different sections, validated for inventory availability and date range.
- **Inventory Control**: Enforce inventory limits to prevent overselling and maintain minimum stock levels.
- **Concurrency Handling**: Prevent duplicate purchases of the last available ticket.
- **Database Integration**: Supports SQL Server for order and ticket data persistence.

## Installation

To get started with TicketJam on your local machine, follow these steps:

1. **Clone the repository**:

    ```bash
    git clone https://github.com/yourusername/ticketjam.git
    ```

2. **Open the project in Visual Studio**:

    - Launch Visual Studio and go to `File > Open > Project/Solution`.
    - Select the `TicketJam.sln` file.

3. **Restore NuGet packages**:

    - Right-click the solution in **Solution Explorer** and select **Restore NuGet Packages** to install all dependencies.

4. **Configure the database**:

    - In `appsettings.json`, set up your SQL Server connection string.

5. **Initialize the database (if using Entity Framework)**:

    - Open **Package Manager Console** in Visual Studio and run:

        ```bash
        Update-Database
        ```

6. **Run the application**:

    - Press `F5` or go to **Debug > Start Debugging**.

## Usage

1. **Create and Manage Tickets**: Admin users can add tickets with start and end dates and assign them to specific event sections.
2. **Place Orders**: Users can select tickets from multiple sections. TicketJam validates ticket availability and inventory before completing the order.
3. **Inventory Management**: The system enforces minimum inventory levels and blocks simultaneous purchases of the last available ticket by multiple users.

## Testing

To ensure core features function correctly and meet business requirements, TicketJam includes automated test cases. To run tests:

1. Open **Test Explorer** in Visual Studio (`Test > Test Explorer`).
2. Run tests by selecting **Run All Tests** or individual test cases.

### Test Coverage

Test cases include:
- Adding tickets to an order
- Validating ticket availability within a set date range
- Enforcing minimum inventory
- Preventing multiple users from purchasing the last ticket concurrently

## Contributing

Contributions are welcome! If you’d like to contribute to TicketJam, please follow these steps:

1. **Fork the repository** on GitHub.
2. **Clone your forked repository**:

    ```bash
    git clone https://github.com/yourusername/ticketjam.git
    ```

3. **Create a new branch** for your feature or fix:

    ```bash
    git checkout -b feature-name
    ```

4. **Commit your changes** and **push the branch** to your fork:

    ```bash
    git add .
    git commit -m "Add feature"
    git push origin feature-name
    ```

5. **Submit a pull request** on GitHub for review.

Please include tests for any new functionality and follow the existing code style.

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.
