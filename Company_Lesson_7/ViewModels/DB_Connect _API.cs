using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Company_Lesson_7.Models;
using System.Net.Http;
using System.Net.Http.Json;

namespace Company_Lesson_7.ViewModels
{
    class DB_Connect_API
    {
        public static IConfiguration Configuration { get; } = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", false, true)
            .Build();
        private HttpClient http = new HttpClient
        {
            BaseAddress = new Uri(Configuration["WebApi"])
        };
        private const string __SqlInsertDepatment = @"api/Depatments/add/{0}";
        private const string __SqlInsertPosition = @"api/Positions/add/{0}/{1}";
        private const string __SqlInsertTypeOfPosition = @"api/TypeOfPositions/add/{0}";
        private const string __SqlInsertEmployee = @"api/Employees/add/{0}/{1}/{2}/{3}'/{4}";
        private const string __SqlUpdateDepatment = @"api/Depatments/update/{0}/{1}";
        private const string __SqlUpdatePosition = @"api/Positions/update/{0}/{1}/{2}";
        private const string __SqlUpdateTypeOfPosition = @"api/TypeOfPositions/update/{0}/{1}";
        private const string __SqlUpdateEmployee = @"api/Employees/update/{0}/{1}/{2}/{3}/{4}/{5}";
        private const string __SqlDeleteDepatment = @"api/Depatments/remove/{0}";
        private const string __SqlDeletePosition = @"api/Positions/remove/{0}";
        private const string __SqlDeleteTypeOfPosition = @"api/TypeOfPositions/remove/{0}";
        private const string __SqlDeleteEmployee = @"api/Employees/remove/{0}";
        
        public DB_Connect_API()
        {
            //var http = new HttpClient
            //{
                //BaseAddress = new Uri(Configuration["WebApi"])
            //};

        }
              
        #region Add_db
        public Depatment AddBdDepatment(Depatment dep)
        {
            http.PostAsJsonAsync<Depatment>("api/Depatments", dep);
            return http.GetFromJsonAsync<Depatment>("api/Depatments/getEndDepatment").Result;
            
        }
        public TypeOfPosition AddBdTypeOfPosition(TypeOfPosition top)
        {
            http.PostAsJsonAsync<TypeOfPosition>("api/TypeOfPositions", top);
            return http.GetFromJsonAsync<TypeOfPosition>("api/TypeOfPositions/getEndTypeOfPosition").Result;
        }
        public Position AddBdPosition(Position pos)
        {
            http.PostAsJsonAsync<Position>("api/Positions", pos);
            return http.GetFromJsonAsync<Position>("api/Positions/getEndPosition").Result;
        }
        public Employee AddBdEmployee(Employee empl)
        {
            http.PostAsJsonAsync<Employee>("api/Employees", empl);
            return http.GetFromJsonAsync<Employee>("api/Employees/getEndEmployee").Result;
        }
        #endregion
        #region Update_db
        public void UpdateBdDepatment(Depatment dep)
        {
            http.PutAsJsonAsync($"api/Depatments/{dep.Id}", dep);
        }
        public void UpdateBdTypeOfPosition(TypeOfPosition top)
        {
            http.PutAsJsonAsync($"api/TypeOfPositions/{top.Id}", top);
        }
        public void UpdateBdPosition(Position pos)
        {
            http.PutAsJsonAsync($"api/Positions/{pos.Id}", pos);
        }
        public void UpdateBdEmployee(Employee empl)
        {
            http.PutAsJsonAsync($"api/Employees/{empl.Id}", empl);
        }
        #endregion
        #region Delete_db
        public void DeleteBdDepatment(int id)
        {
            http.DeleteAsync($"api/Depatments/{id}");
        }
        public void DeleteBdTypeOfPosition(int id)
        {
            http.DeleteAsync($"api/TypeOfPositions/{id}");
        }
        public void DeleteBdPosition(int id)
        {
            http.DeleteAsync($"api/Positions/{id}");
        }
        public void DeleteBdEmployee(int id)
        {
            http.DeleteAsync($"api/Employees/{id}");
        }
        #endregion
        #region Load_db
        public IEnumerable<Position> DbGetPosition()
        {
            return http.GetFromJsonAsync<Position[]>("api/Positions").Result;
        }
        public IEnumerable<TypeOfPosition> DbGetTypeOfPosition()
        {
            return http.GetFromJsonAsync<TypeOfPosition[]>("api/TypeOfPositions").Result;
        }
        public IEnumerable<Depatment> DbGetDepatment()
        {
            return http.GetFromJsonAsync<Depatment[]>("api/Depatments").Result;
        }
        public IEnumerable<Employee> DbGetEmployee()
        {
            return http.GetFromJsonAsync<Employee[]>("api/Employees").Result;
        }
        #endregion
        
    }
}
