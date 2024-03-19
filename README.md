Items Summary Report Generator

Overview:
Items Summary Report Generator is a web application developed using ASP.NET Core, Razor views, and IronPdf for generating printable PDF reports. The application loads data from a JSON file, deserializes it into C# objects, and renders it into structured PDF reports suitable for printing or sharing.

Features:
- PDF Report Generation: Utilizes IronPdf to generate PDF reports based on data retrieved from the JSON file.
- Data Loading: Loads data from a JSON file using C# and deserializes it into appropriate model objects.
- Razor Views: Employs Razor views for creating HTML templates to structure the PDF reports.
- Dynamic Content: Dynamically populates the PDF reports with data from the JSON file, including item categories, order items, and details.

Technologies Used:
- ASP.NET Core
- Razor Views
- IronPdf
- Newtonsoft.Json

How to Use:
1. Clone Repository: git clone <repository-url>
2. Install Dependencies: dotnet restore
3. Configure License: Set up IronPdf license key.
4. Run the Application: dotnet run
5. Access the Report: Navigate to /report endpoint in your web browser.
6. Generate PDF: Click the appropriate button/link to generate a PDF report.
7. View PDF: Open the generated PDF report using a PDF viewer.
