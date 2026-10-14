**Power7 - E-Commerce Store ⚡**

Power7 is an online store specializing in premium energy-boosting products: energy drinks, pre-workout supplements, specialty coffee, and natural vitamin juices. Built for young adults and athletes, focusing on a clean UI, fast checkout, and mobile-first experience.

**👥 Team**

**Ponoran Claudiu Mihai** - Storefront & User Management (A1, A2, A4, A8, A11, A12)
**Oprea Iulian Marian** - Purchase Flow, Payment & Administration (A3, A5, A6, A7, A9, A10)


**🛠️ Technology Stack**

**Frontend**: HTML5, CSS, Bootstrap 5, JavaScript
**Backend**: C# in .NET 10 
**Database**: SQLite / PostgreSQL (via Entity Framework Core)
**Payments**: Stripe (Test Mode)
**Environment & Tests**: Docker Compose, xUnit

To run this app you need Docker installed

1. Start the application - the store will be available at http://localhost:8080
    docker compose up -d --build 

2. Running tests 
    docker compose exec app dotnet test

**AI TOOLS USAGE DECLARATION**
    Claude/Gemini - used to help at the presentations (correct spelling and some ideas), sometimes used in coding (giving ideas, debugging) 
