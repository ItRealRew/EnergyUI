using System.Data.SqlClient;

namespace EnergyUI.DAO
{
    public class Database
    {
        private static readonly string connectionString = @"Data Source=DESKTOP-GRIKV9R\SQLEXPRESS01;Initial Catalog=energy;Integrated Security=True;Pooling=False";

        public SqlConnection Connection { get; set; }
        public void Connect()
        {
            Connection = new SqlConnection(connectionString);
            Connection.Open();
        }

        public void Disconnect()
        {
            Connection.Close();
        }
    }
}
