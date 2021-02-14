using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Company_Lesson_7.Models;

namespace Company_Lesson_7.ViewModels
{
    class DB_Connect
    {
        /*public static IConfiguration Configuration { get; } = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", false, true)
            .Build();
        //public static string ConnectionString => Configuration.GetConnectionString("Default");
        private static string connection_string;
        private const string __SqlInsertDepatment = @"INSERT INTO [dbo].[Depatment] (Title) VALUES (N'{0}')";
        private const string __SqlInsertPosition = @"INSERT INTO [dbo].[Position] (Title, TypeOfPositionId) VALUES (N'{0}', '{1}')";
        private const string __SqlInsertTypeOfPosition = @"INSERT INTO [dbo].[TypeOfPosition] (Title) VALUES (N'{0}')";
        private const string __SqlInsertEmployee = @"INSERT INTO [dbo].[Employee] (Surname, Name, MiddleName, PositionId, DepatmentId)VALUES (N'{0}', N'{1}', N'{2}', '{3}', '{4}')";
        private const string __SqlUpdateDepatment = @"UPDATE [dbo].[Depatment] SET Title = (N'{1}') WHERE Id = ('{0}')";
        private const string __SqlUpdatePosition = @"UPDATE [dbo].[Position] SET Title = (N'{1}'), TypeOfPositionId = ('{2}') WHERE Id = ('{0}')";
        private const string __SqlUpdateTypeOfPosition = @"UPDATE [dbo].[TypeOfPosition] SET Title = (N'{1}') WHERE Id = ('{0}')";
        private const string __SqlUpdateEmployee = @"UPDATE [dbo].[Employee] SET Surname = (N'{1}'), Name = (N'{2}'), MiddleName = (N'{3}'), PositionId = ('{4}'), DepatmentId = ('{5}') WHERE Id = ('{0}')";
        private const string __SqlDeleteDepatment = @"DELETE [dbo].[Depatment] WHERE Id = ('{0}')";
        private const string __SqlDeletePosition = @"DELETE [dbo].[Position] WHERE Id = ('{0}')";
        private const string __SqlDeleteTypeOfPosition = @"DELETE [dbo].[TypeOfPosition] WHERE Id = ('{0}')";
        private const string __SqlDeleteEmployee = @"DELETE [dbo].[Employee] WHERE Id = ('{0}')";
        private const string __SqlCreateDataBaseCompany = @"DROP DATABASE IF EXIST Company_{0};
            CREATE DATABASE Company_{0};
            USE Company_{0};
            CREATE TABLE [dbo].[Depatment] (
            [Id]    INT     IDENTITY(1, 1)      NOT NULL,
            [Title] NVARCHAR (50) NOT NULL,
            PRIMARY KEY CLUSTERED ([Id] ASC)
            );
            CREATE TABLE [dbo].[Employee] (
            [Id]          INT      IDENTITY(1, 1)     NOT NULL,
            [Surname]     NVARCHAR (50) NOT NULL,
            [Name]        NVARCHAR (50) NOT NULL,
            [MiddleName]  NVARCHAR (50) NOT NULL,
            [PositionId]  INT           NOT NULL,
            [DepatmentId] INT           NOT NULL,
            PRIMARY KEY CLUSTERED ([Id] ASC)
            );
            CREATE TABLE [dbo].[Position] (
            [Id]               INT     IDENTITY(1, 1)      NOT NULL,
            [Title]            NVARCHAR (50) NOT NULL,
            [TypeOfPositionId] INT           NOT NULL,
            PRIMARY KEY CLUSTERED ([Id] ASC)
            );
            CREATE TABLE [dbo].[TypeOfPosition] (
            [Id]    INT      IDENTITY(1, 1)     NOT NULL,
            [Title] NVARCHAR (50) NOT NULL,
            PRIMARY KEY CLUSTERED ([Id] ASC)
            );";
        private const string __SqlCreateDataBaseCompanyNames = @"CREATE DATABASE Company_Names;
            USE Company_Names;
            CREATE TABLE [dbo].[CompanyName] (
            [Id]    INT      IDENTITY(1, 1)     NOT NULL,
            [Title] NVARCHAR (50) NOT NULL,
            PRIMARY KEY CLUSTERED ([Id] ASC)
            );";
        //public DB_Connect(string nameDb)
        //{
            //var connection_string_builder = new SqlConnectionStringBuilder(Configuration.GetConnectionString("Default"));
            //connection_string_builder.InitialCatalog = $"Company_{nameDb}";
            ////connection_string = connection_string_builder.ConnectionString;
            //SqlConnection myConn = new SqlConnection("Server=localhost;Integrated security=SSPI;database=master");
            //"Data Source=(localdb)\\MSSQLLocalDB;InitialCatalog=Company"
        //}
        public DB_Connect()
        {
            connection_string = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Company";
            
        }
        
        #region Create_db
        public void CreateDbAndConStrBuild(string nameDb)
        {
            //var connection_string_builder = new SqlConnectionStringBuilder(Configuration.GetConnectionString("Default"));
            //connection_string_builder.InitialCatalog = $"master";
            connection_string = "Data Source=(localdb)\\MSSQLLocalDB;InitialCatalog=master";//connection_string_builder.ConnectionString;
            using var connection = GetOpenedConnection();
            var command = new SqlCommand(string.Format(__SqlCreateDataBaseCompany, nameDb), connection);
            command.ExecuteNonQuery();
            connection.Close();
            //connection_string_builder.InitialCatalog = $"Company_{nameDb}";
            connection_string = "Data Source=(localdb)\\MSSQLLocalDB;InitialCatalog=Company_Example";//connection_string_builder.ConnectionString;
        }
        #endregion
        #region Add_db
        public Depatment AddBdDepatment(string title)
        {
            const string sql_select_end_value = @"SELECT * FROM [dbo].[Depatment] WHERE Id = (SELECT MAX(id) FROM [dbo].[Depatment])";
            using var connection = GetOpenedConnection();
            var command = new SqlCommand(string.Format(__SqlInsertDepatment, title), connection);
            command.ExecuteNonQuery();
            var select_command = new SqlCommand(sql_select_end_value, connection);
            using var reader = select_command.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();
                return new Depatment((int)reader["Id"], (string)reader["Title"]);
            }
            return null;
        }
        public TypeOfPosition AddBdTypeOfPosition(string title)
        {
            const string sql_select_end_value = @"SELECT * FROM [dbo].[TypeOfPosition] WHERE Id = (SELECT MAX(id) FROM [dbo].[TypeOfPosition])";
            using var connection = GetOpenedConnection();
            var command = new SqlCommand(string.Format(__SqlInsertTypeOfPosition, title), connection);
            command.ExecuteNonQuery();
            var select_command = new SqlCommand(sql_select_end_value, connection);
            using var reader = select_command.ExecuteReader();
            if (reader.HasRows) 
            {
                reader.Read();
                return new TypeOfPosition((int)reader["Id"], (string)reader["Title"]); 
            }
            return null;
            
        }
        public Position AddBdPosition(string title, int topId)
        {
            const string sql_select_end_value = @"SELECT * FROM [dbo].[Position] WHERE Id = (SELECT MAX(id) FROM [dbo].[Position])";
            using var connection = GetOpenedConnection();
            var command = new SqlCommand(string.Format(__SqlInsertPosition, title, topId), connection);
            command.ExecuteNonQuery();
            var select_command = new SqlCommand(sql_select_end_value, connection);
            using var reader = select_command.ExecuteReader();
            if (reader.HasRows) 
            {
                reader.Read();
                return new Position((int)reader["Id"], (string)reader["Title"], (int)reader["TypeOfPositionId"]);
            }
            return null;
        }
        public Employee AddBdEmployee(string surname, string name, string middlename, int positonId, int depatmentId)
        {
            const string sql_select_end_value = @"SELECT * FROM [dbo].[Employee] WHERE Id = (SELECT MAX(id) FROM [dbo].[Employee])";
            using var connection = GetOpenedConnection();
            var command = new SqlCommand(string.Format(__SqlInsertEmployee, surname, name, middlename, positonId, depatmentId), connection);
            command.ExecuteNonQuery();
            var select_command = new SqlCommand(sql_select_end_value, connection);
            using var reader = select_command.ExecuteReader();
            if (reader.HasRows) 
            {
                reader.Read();
                return new Employee((int)reader["Id"], (string)reader["Surname"], (string)reader["Name"], (string)reader["MiddleName"], (int)reader["PositionId"], (int)reader["DepatmentId"]);
            }
            return null;
        }
        #endregion
        #region Update_db
        public void UpdateBdDepatment(int id, string title)
        {
            using var connection = GetOpenedConnection();
            var command = new SqlCommand(string.Format(__SqlUpdateDepatment, id, title), connection);
            command.ExecuteNonQuery();
        }
        public void UpdateBdTypeOfPosition(int id, string title)
        {
            using var connection = GetOpenedConnection();
            var command = new SqlCommand(string.Format(__SqlUpdateTypeOfPosition, id, title), connection);
            command.ExecuteNonQuery();
        }
        public void UpdateBdPosition(int id, string title, int topId)
        {
            using var connection = GetOpenedConnection();
            var command = new SqlCommand(string.Format(__SqlUpdatePosition, id, title, topId), connection);
            command.ExecuteNonQuery();
        }
        public void UpdateBdEmployee(int id, string surname, string name, string middlename, int positonId, int depatmentId)
        {
            using var connection = GetOpenedConnection();
            var command = new SqlCommand(string.Format(__SqlUpdateEmployee, id, surname, name, middlename, positonId, depatmentId), connection);
            command.ExecuteNonQuery();
        }
        #endregion
        #region Delete_db
        public void DeleteBdDepatment(int id)
        {
            using var connection = GetOpenedConnection();
            var command = new SqlCommand(string.Format(__SqlDeleteDepatment, id), connection);
            command.ExecuteNonQuery();
        }
        public void DeleteBdTypeOfPosition(int id)
        {
            using var connection = GetOpenedConnection();
            var command = new SqlCommand(string.Format(__SqlDeleteTypeOfPosition, id), connection);
            command.ExecuteNonQuery();
        }
        public void DeleteBdPosition(int id)
        {
            using var connection = GetOpenedConnection();
            var command = new SqlCommand(string.Format(__SqlDeletePosition, id), connection);
            command.ExecuteNonQuery();
        }
        public void DeleteBdEmployee(int id)
        {
            using var connection = GetOpenedConnection();
            var command = new SqlCommand(string.Format(__SqlDeleteEmployee, id), connection);
            command.ExecuteNonQuery();
        }
        #endregion
        #region Load_db
        public IEnumerable<Position> DbGetPosition()
        {
            const string sql_select_end_value = @"SELECT * FROM [dbo].[Position]";
            using var connection = GetOpenedConnection();
            var select_command = new SqlCommand(sql_select_end_value, connection);
            using var reader = select_command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    yield return new Position((int)reader["Id"], (string)reader["Title"], (int)reader["TypeOfPositionId"]);
                }
                
            }
        }
        public IEnumerable<TypeOfPosition> DbGetTypeOfPosition()
        {
            const string sql_select_end_value = @"SELECT * FROM [dbo].[TypeOfPosition]";
            using var connection = GetOpenedConnection();
            var select_command = new SqlCommand(sql_select_end_value, connection);
            using var reader = select_command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    yield return new TypeOfPosition((int)reader["Id"], (string)reader["Title"]);
                }

            }
        }
        public IEnumerable<Depatment> DbGetDepatment()
        {
            const string sql_select_end_value = @"SELECT * FROM [dbo].[Depatment]";
            using var connection = GetOpenedConnection();
            var select_command = new SqlCommand(sql_select_end_value, connection);
            using var reader = select_command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    yield return new Depatment((int)reader["Id"], (string)reader["Title"]);
                }

            }
        }
        public IEnumerable<Employee> DbGetEmployee()
        {
            const string sql_select_end_value = @"SELECT * FROM [dbo].[Employee]";
            using var connection = GetOpenedConnection();
            var select_command = new SqlCommand(sql_select_end_value, connection);
            using var reader = select_command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    yield return new Employee((int)reader["Id"], (string)reader["Surname"], (string)reader["Name"], 
                        (string)reader["MiddleName"], (int)reader["PositionId"], (int)reader["DepatmentId"]);
                }

            }


        }
        #endregion
        public static SqlConnection GetOpenedConnection()
        {
            var connection = new SqlConnection(connection_string);
            connection.Open();
            return connection;
        }*/
    }
}
