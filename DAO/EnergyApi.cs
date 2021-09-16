using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using EnergyUI.Models;

namespace EnergyUI.DAO
{
    public class EnergyApi: Database
    {
        public List<Measuring> GetMeasurings(int MetersId, DateTime DateValue)
        {
            Connect();
            List<Measuring> result = new List<Measuring>();

            try
            {
                SqlCommand command = new SqlCommand("SELECT * FROM measuring_values WHERE meter_id = "+ MetersId +" AND value_dt = " + DateValue + ";", Connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {

                    Measuring record = new Measuring();
                    record.id = Convert.ToInt32(reader["id"]);
                    record.meter_id = Convert.ToInt32(reader["meter_id"]);
                    record.parameter_id = Convert.ToInt32(reader["parameter_id"]);
                    record.value = Convert.ToSingle(reader["value"]);
                    record.value_dt = Convert.ToDateTime(reader["value_dt"]);
                    result.Add(record);
                }

                reader.Close();
            }
            catch (Exception) { }
            finally { Disconnect(); }
            return result;
        }

        public List<Meters> GetMeters()
        {
            Connect();
            List<Meters> result = new List<Meters>();

            try
            {
                SqlCommand command = new SqlCommand("SELECT * FROM meters;", Connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {

                    Meters record = new Meters();
                    record.id = Convert.ToInt32(reader["id"]);
                    record.caption = Convert.ToString(reader["caption"]);
                    result.Add(record);
                }

                reader.Close();
            }
            catch (Exception) { }
            finally { Disconnect(); }
            return result;

        }

        public List<Parameters> GetParametrs()
        {
            Connect();
            List<Parameters> result = new List<Parameters>();

            try
            {
                SqlCommand command = new SqlCommand("SELECT * FROM parameters;", Connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {

                    Parameters record = new Parameters();
                    record.id = Convert.ToInt32(reader["id"]);
                    record.caption = Convert.ToString(reader["caption"]);
                    record.measure_units = Convert.ToString(reader["measure_units"]);
                    result.Add(record);
                }

                reader.Close();
            }
            catch (Exception) { }
            finally { Disconnect(); }
            return result;

        }
    }
}
