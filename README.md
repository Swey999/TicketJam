# TicketJam


TicketJam is a C# application developed in Visual Studio for managing ticket sales and orders. It provides a structured system for ticket availability, inventory control, and concurrency, supporting smooth ticket sales while preventing overselling and ensuring database integrity.

## Usage

1. **Create and Manage Tickets**: Admin users can add tickets with start and end dates and assign them to specific event sections.
2. **Place Orders**: Users can select tickets from multiple sections. TicketJam validates ticket availability and inventory before completing the order.
3. **Inventory Management**: The system enforces minimum inventory levels and blocks simultaneous purchases of the last available ticket by multiple users.
