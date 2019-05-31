using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Models;
using Repositories.Abstract;
using System.Configuration;

namespace Repositories.Concrete.ADO
{
    public class CarRepository : ICarRepository
    {
        private bool ExecuteNonQueryCommand(string cmd)
        {
            string connStr = ConfigurationManager.ConnectionStrings["adoConnStr"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connStr))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = cmd;

                int affeectedRows = command.ExecuteNonQuery();
                connection.Close();

                return affeectedRows > 0;
            }
        }
        
        public bool Add(tblCar car)
        {
            return ExecuteNonQueryCommand($"insert into tblCar " +
                $"(SerialNumber, Make, Model, Color, Year, CarForSale) " +
                $"values ( " +
                $"'{car.SerialNumber}', " +
                $"'{car.Make}', " +
                $"'{car.Model}', " +
                $"'{car.Color}', " +
                $"'{car.Year}', " +
                $"'{car.CarForSale}'" +
                $")");
        }

        public bool Delete(tblCar car)
        {
            return ExecuteNonQueryCommand($"delete from tblCar where Car_ID = {car.Car_ID}");
        }

        public IEnumerable<tblCar> GetAllCars()
        {
            string connStr = ConfigurationManager.ConnectionStrings["AdoConnStr"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connStr))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "select * from tblCar";

                var reader = command.ExecuteReader();

                var result = new List<tblCar>();
                while (reader.Read())
                {
                    result.Add(new tblCar
                    {
                        Car_ID = Convert.ToInt32(reader["Car_ID"].ToString()),
                        SerialNumber = reader["SerialNumber"].ToString(),
                        Make = reader["Make"].ToString(),
                        Model = reader["Model"].ToString(),
                        Color = reader["Color"].ToString(),
                        Year = Convert.ToInt16(reader["Year"]),
                        CarForSale = Convert.ToBoolean(reader["CarForSale"])
                    });
                }
                connection.Close();

                return result;
            }
        }

        public tblCar GetCar(int id)
        {
            string connStr = ConfigurationManager.ConnectionStrings["AdoConnStr"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connStr))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = $"select * from tblCar where Car_ID = {id}";

                var reader = command.ExecuteReader();

                tblCar car;
                while (reader.Read())
                {
                    car = new tblCar
                    {
                        Car_ID = Convert.ToInt32(reader["Car_ID"].ToString()),
                        SerialNumber = reader["SerialNumber"].ToString(),
                        Make = reader["Make"].ToString(),
                        Model = reader["Model"].ToString(),
                        Color = reader["Color"].ToString(),
                        Year = Convert.ToInt16(reader["Year"]),
                        CarForSale = Convert.ToBoolean(reader["CarForSale"])
                    };
                    return car;
                }
                return null;
            }
        }
        public bool Update(tblCar car)
        {
            return ExecuteNonQueryCommand($"update tblCar set " +
                $"SerialNumber = {car.SerialNumber}, " +
                $"Make = '{car.Make}', " +
                $"Model = '{car.Model}', " +
                $"Color = '{car.Color}', " +
                $"Year = '{car.Year}', " +
                $"CarForSale = '{car.CarForSale}' " +
                $"where Car_ID = {car.Car_ID}");
        }
    }
}
