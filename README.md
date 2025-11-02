🎟️ Cineplex Seat Booking & Ticket Selling System

An ASP.NET MVC web application for managing movie seat booking and ticket sales in a Cineplex environment.
This project provides a complete end-to-end workflow for browsing movies, selecting showtimes, booking seats, and purchasing tickets online.

--------------------------

🧭 Overview

This application is designed to simplify cinema operations and improve the movie-going experience by enabling customers to book tickets conveniently through an interactive web interface.

Administrators can manage movies, showtimes, halls, and seat layouts, while customers can view available seats and confirm bookings in real time.

---------------------------

🚀 Features

🎬 Movie Management – Add, edit, and list movies with posters, trailers, and details

🕐 Showtime Scheduling – Manage multiple halls and screening times

💺 Interactive Seat Booking – Visual seat map with available, booked, and selected seat indicators

💳 Ticket Purchase System – Secure booking and payment confirmation workflow

👤 User Accounts – Login and booking history for registered users

🧾 Printable E-Ticket – Auto-generated ticket with movie, seat, and timing details

🔧 Admin Dashboard – Manage movies, schedules, and bookings

---------------------------

🧩 Technologies Used
| Component          | Description                                |
| ------------------ | ------------------------------------------ |
| **Framework**      | ASP.NET MVC 5 / ASP.NET Core MVC           |
| **Language**       | C#                                         |
| **Frontend**       | HTML5, CSS3, JavaScript, Bootstrap, jQuery |
| **Database**       | SQL Server (Code First / Entity Framework) |
| **ORM**            | Entity Framework                           |
| **Authentication** | ASP.NET Identity                           |
| **IDE**            | Visual Studio                              |
| **Deployment**     | IIS / Azure Web App                        |

-----------------------

🎥 Core Functionalities
🎬 Movie Module

CRUD operations for movies

Display poster, title, genre, duration, and trailer

🕒 Showtime & Hall Management

Assign movies to specific halls and times

Manage seat capacity and layout

💺 Seat Booking Interface

Real-time seat availability display

Select and confirm multiple seats

Automatic total cost calculation

💳 Ticket Selling

Secure ticket booking and confirmation

Option to view or print e-tickets

Unique ticket ID per booking

------------------------

🧩 Database Design

Tables:

Movies

Showtimes

Halls

Seats

Bookings

Users

Relationships:

One Movie → Many Showtimes

One Showtime → Many Seats

One Booking → One Seat, One User

--------------------------------

🧠 Future Enhancements

🧾 Online Payment Gateway Integration (Stripe / SSLCommerz)

🎫 QR Code for Tickets

📱 Mobile-friendly responsive UI

🌐 Multi-Cinema Branch Management

📊 Admin Analytics Dashboard (revenue, occupancy rate)
