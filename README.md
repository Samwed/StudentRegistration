To set up the project on your local machine->

.NET SDK (or whatever version you're using)
:->Visual Studio 2022
:->MySQL Workbench
:->NuGet Package: MySql Connector/.net

//------------------------------------
Installation Of MySql WorkBench->
Go to the official MySQL website 
Click the Downloads tab 
Scroll down to MySQL Community (GPL) Downloads 
Click MySQL Installer for Windows 
Select your operating system 
Download the file 
Open the installer 

//--------------------------------------
Open the solution in Visual Studio 2022:

Open studentRegstartion.sln in Visual Studio.

//------------------------------------------
Install SQL Connect .Net
Go to Tools > NuGet Package Manager > Manage NuGet Packages for Solution.
Search for and install MySql.Data package.

//---------------------------------------------------
Modify the appsettings.json file to match your MySQL configuration:
{
  "ConnectionStrings": {
    "DefaultConnection": "server=your-server-address;port=3306;database=studentregistration;user=root;password=password;"
  }
}
