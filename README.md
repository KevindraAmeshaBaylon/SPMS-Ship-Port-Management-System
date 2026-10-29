# 🚢 Ship Port Management System (SPMS)

A desktop-based Ship Port Management System developed using **C#, Windows Forms, and Microsoft SQL Server** to manage ship information, port requests, user accounts, and administrative access.

The system is designed to organize essential ship and port-related information in a centralized database, making it easier to maintain ship records, track port requests, and manage operational information.

---

## 📌 Table of Contents

- [Project Overview](#-project-overview)
- [Objectives](#-objectives)
- [Key Features](#-key-features)
- [Technologies Used](#-technologies-used)
- [System Requirements](#-system-requirements)
- [Project Structure](#-project-structure)
- [Database Design](#-database-design)
- [Database Relationships](#-database-relationships)
- [Installation and Setup](#-installation-and-setup)
- [Sample Data](#-sample-data)
- [Security Considerations](#-security-considerations)
- [Future Enhancements](#-future-enhancements)
- [Contributing](#-contributing)
- [License](#-license)

---

## 📖 Project Overview

The **Ship Port Management System (SPMS)** is a software project developed to support the management of ship records and port-related requests.

The system uses a Microsoft SQL Server database to store administrative accounts, user accounts, ship information, and ship-related requests. The database establishes a relationship between ships and their requests, allowing each request to be associated with a registered ship.

The application is intended to provide a structured approach to maintaining ship details, recording origin and destination countries, storing arrival and departure schedules, and tracking request statuses.

This project demonstrates the application of desktop application development, relational database design, SQL queries, and database connectivity using C# and SQL Server.

## 🎯 Objectives

- Maintain ship information in a centralized database.
- Store and manage administrative and user account records.
- Record ship-related requests with origin and destination details.
- Maintain arrival and departure dates and times.
- Track the status of ship requests.
- Establish relational integrity between ship records and requests.
- Demonstrate database-driven application development using C# and SQL Server.

## ✨ Key Features

### 1. Administrative Account Management
- Stores administrator IDs and usernames.
- Maintains administrative account records.
- Provides a database structure for administrative access.

### 2. User Account Management
- Stores user IDs and usernames.
- Maintains user account records separately from administrator accounts.
- Provides a foundation for user authentication.

### 3. Ship Management
- Stores ship identification numbers and ship names.
- Maintains the current recorded status of each ship.
- Uses `ShipNo` as the primary key to uniquely identify each ship.

### 4. Port Request Management
- Records unique request IDs.
- Stores the country of origin and destination.
- Associates requests with registered ships.
- Records scheduled arrival and departure dates and times.
- Maintains request statuses such as `Pending`.

### 5. Relational Database Management
- Uses primary keys to identify ships and requests.
- Implements a foreign key between ship records and requests.
- Maintains a structured database schema for managing related information.

> **Note:** These features describe the capabilities represented by the supplied database schema. Actual functionality depends on the corresponding features implemented in the C# application.

## 🛠️ Technologies Used

| Technology | Purpose |
|---|---|
| C# | Application programming language |
| Windows Forms | Desktop user interface |
| Microsoft SQL Server | Relational database management |
| SQL Server Management Studio (SSMS) | Database creation and administration |
| ADO.NET | Database connectivity, if implemented in the application |
| Microsoft Visual Studio | Application development environment |
| Git and GitHub | Version control and project hosting |

## 💻 System Requirements

- Windows operating system
- Microsoft Visual Studio with the required C# and Windows Forms workloads
- Microsoft SQL Server
- SQL Server Management Studio (SSMS)
- .NET Framework or .NET version compatible with the project
- Git (optional, for cloning the repository)

The exact .NET version and SQL Server version depend on your project configuration.

## 📂 Project Structure

The repository is organized to separate the application source code, documentation, and supporting images.

```text
SPMS-Ship-Port-Management/
│
├── README.md
├── .gitignore
├── LICENSE
│
├── screenshots/
│   └── (Application screenshots)
│
└── SPMS/
    ├── SPMS final project CSE Amesha.sln
    ├── SPMS final project CSE Amesha.csproj
    ├── Program.cs
    ├── App.config
    │
    ├── Properties/
    ├── Resources/
    │
    └── (Other .cs, .Designer.cs, and .resx files)
```

*The structure above is illustrative. File and folder names should match the actual contents of your repository.*

## 🗄️ Database Design

**Database name:** `SMPSdb`

The database is implemented in Microsoft SQL Server and consists of four tables.

### 1. `dbo.tbladmin`

Stores administrator account information.

| Column | Data Type | Description |
|---|---|---|
| `AdminID` | `VARCHAR(50)` | Administrator identifier |
| `Username` | `VARCHAR(50)` | Administrator username |
| `Password` | `VARCHAR(50)` | Administrator password field |

### 2. `dbo.tbluser`

Stores general user account information.

| Column | Data Type | Description |
|---|---|---|
| `UserID` | `VARCHAR(50)` | User identifier |
| `Username` | `VARCHAR(50)` | User username |
| `Password` | `VARCHAR(50)` | User password field |

### 3. `dbo.tblship`

Stores ship-related information.

| Column | Data Type | Description |
|---|---|---|
| `ShipNo` | `NUMERIC(18,0)` | Unique ship number and primary key |
| `ShipName` | `VARCHAR(20)` | Name of the ship |
| `Status` | `VARCHAR(50)` | Recorded ship status |

Example ship statuses in the sample data include `Docked` and `At Sea`.

### 4. `dbo.tblrequest`

Stores ship-related port requests and scheduling information.

| Column | Data Type | Description |
|---|---|---|
| `RequestID` | `NUMERIC(18,0)` | Unique request identifier and primary key |
| `FromCountry` | `VARCHAR(50)` | Country of origin |
| `ToCountry` | `VARCHAR(50)` | Destination country |
| `ShipNo` | `NUMERIC(18,0)` | Associated ship number and foreign key |
| `Arrival` | `DATETIME` | Scheduled arrival date and time |
| `Departure` | `DATETIME` | Scheduled departure date and time |
| `RequestStatus` | `VARCHAR(50)` | Current recorded request status |

## 🔗 Database Relationships

The database contains a one-to-many relationship between `tblship` and `tblrequest`.

```text
tblship
-------
ShipNo (PK)
ShipName
Status
    |
    | 1
    |
    |------< Many
              |
              v
         tblrequest
         ----------
         RequestID (PK)
         ShipNo (FK)
         FromCountry
         ToCountry
         Arrival
         Departure
         RequestStatus
```

### Relationship Explanation

- `tblship.ShipNo` is the primary key of the ship table.
- `tblrequest.RequestID` is the primary key of the request table.
- `tblrequest.ShipNo` references `tblship.ShipNo`.
- A ship can be associated with multiple requests.
- A request can reference one registered ship.
- The `ShipNo` column in `tblrequest` allows `NULL`, so a request can exist without an associated ship until one is assigned.
- The foreign key prevents a non-null ship number from referencing a ship record that does not exist.

The administrator and user tables are separate and do not have foreign key relationships in the supplied script.

## ⚙️ Installation and Setup

Follow these steps to configure the database and open the application locally.

### Step 1: Clone the Repository

Open a terminal and execute:

```bash
git clone https://github.com/YOUR-USERNAME/SPMS-Ship-Port-Management.git
```

Replace `YOUR-USERNAME` with your GitHub username and use the actual repository URL.

Alternatively, download the repository as a ZIP file from GitHub.

### Step 2: Create the Database

1. Open SQL Server Management Studio (SSMS).
2. Connect to your SQL Server instance.
3. Open a new query window.
4. Copy the database creation and table creation SQL script provided with the project.
5. Execute the script.

The script creates the `SMPSdb` database if it does not already exist, then creates the four tables and inserts sample records.

**Important:** The database creation script should be executed against an account with permission to create databases and tables.

### Step 3: Verify the Database

Run the following query in SSMS:

```sql
USE SMPSdb;
GO

SELECT * FROM dbo.tbladmin;
SELECT * FROM dbo.tbluser;
SELECT * FROM dbo.tblship;
SELECT * FROM dbo.tblrequest;
```

Confirm that the four tables exist and the sample records have been inserted.

### Step 4: Open the Visual Studio Project

1. Navigate to the `SPMS/` directory.
2. Open the `.sln` solution file in Visual Studio.
3. Allow Visual Studio to load the project.
4. Restore any required dependencies if prompted.
5. Check the project configuration and build the solution.

### Step 5: Configure the Database Connection

Ensure that the connection string in `App.config` or the relevant application code points to your SQL Server instance and the `SMPSdb` database.

For example, a Windows-authenticated connection string may look like this:

```xml
<connectionStrings>
    <add name="SPMSdb"
         connectionString="Data Source=YOUR-SERVER-NAME;Initial Catalog=SMPSdb;
