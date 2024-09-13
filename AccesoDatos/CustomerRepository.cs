using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos
{
    public class CustomerRepository
    {
        public DataTable ObtenerTodos()
        {
            DataTable dataTable = new DataTable();

            String select = "";
            select = select + "SELECT [CustomerID] " + "\n";
            select = select + "      ,[CompanyName] " + "\n";
            select = select + "      ,[ContactName] " + "\n";
            select = select + "      ,[ContactTitle] " + "\n";
            select = select + "      ,[Address] " + "\n";
            select = select + "      ,[City] " + "\n";
            select = select + "      ,[Region] " + "\n";
            select = select + "      ,[PostalCode] " + "\n";
            select = select + "      ,[Country] " + "\n";
            select = select + "      ,[Phone] " + "\n";
            select = select + "      ,[Fax] " + "\n";
            select = select + "  FROM [dbo].[Customers]";

            SqlDataAdapter adapter = new SqlDataAdapter(select, DataBase.ConnectionString);
            adapter.Fill(dataTable);

            return dataTable;
        }

        public Customer obtenerPorID(string id)
        {
            using (var conexion = DataBase.GetSqlConnection())
            {
                var dataTable = new DataTable();

                String selectPorId = "";
                selectPorId = selectPorId + "SELECT [CustomerID] " + "\n";
                selectPorId = selectPorId + "      ,[CompanyName] " + "\n";
                selectPorId = selectPorId + "      ,[ContactName] " + "\n";
                selectPorId = selectPorId + "      ,[ContactTitle] " + "\n";
                selectPorId = selectPorId + "      ,[Address] " + "\n";
                selectPorId = selectPorId + "      ,[City] " + "\n";
                selectPorId = selectPorId + "      ,[Region] " + "\n";
                selectPorId = selectPorId + "      ,[PostalCode] " + "\n";
                selectPorId = selectPorId + "      ,[Country] " + "\n";
                selectPorId = selectPorId + "      ,[Phone] " + "\n";
                selectPorId = selectPorId + "      ,[Fax] " + "\n";
                selectPorId = selectPorId + "  FROM [dbo].[Customers] " + "\n";
                selectPorId = selectPorId + "  WHERE CustomerID = @CustomerID";
                using (SqlCommand comando = new SqlCommand(selectPorId, conexion))
                {
                    comando.Parameters.AddWithValue("@CustomerID", id);
                    SqlDataAdapter adapter = new SqlDataAdapter(comando);
                    adapter.Fill(dataTable);
                    var cliente = ExtraerInformacionCliente(dataTable);
                    return cliente;
                }
            }
        }

        public Customer ExtraerInformacionCliente(DataTable table)
        {
            Customer customer = new Customer();
            foreach (DataRow fila in table.Rows)
            {
                customer.CustomerID = fila.Field<String>("CustomerID");
                customer.CompanyName = fila.Field<String>("CompanyName");
                customer.ContactName = fila.Field<String>("ContactName");
                customer.ContactTitle = fila.Field<String>("ContactTitle");
                customer.Address = fila.Field<String>("Address");
                customer.City = fila.Field<String>("City");
                customer.Region = fila.Field<String>("Region");
                customer.PostalCode = fila.Field<String>("PostalCode");
                customer.Country = fila.Field<String>("Country");
                customer.Phone = fila.Field<String>("Phone");
                customer.Fax = fila.Field<String>("Fax");
            }
            return customer;
        }
    }
}
