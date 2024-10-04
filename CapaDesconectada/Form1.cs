using AccesoDatos;
using CapaDesconectada.NorthwindTableAdapters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaDesconectada
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void RellenarForm(Customer cliente)
        {
            if (cliente != null)
            {
                tboxCustomerID.Text = cliente.CustomerID;
                tboxCompanyName.Text = cliente.CompanyName;
                tboxContactName.Text = cliente.ContactName;
                tboxContactTitle.Text = cliente.ContactTitle;
                tboxAddres.Text = cliente.Address;
            }
            if (cliente == null)
            {
                MessageBox.Show("objeto null ");
            }
        }

        #region No Tipado
        CustomerRepository customerRepository = new CustomerRepository();
        private void btnObtenerNotipado_Click(object sender, EventArgs e)
        {
            var cliente = customerRepository.obtenerPorID(tbBusquedaNt.Text);
            RellenarForm(cliente);
            if (cliente == null)
            {
                MessageBox.Show("El objeto es null");
            }
            if (cliente != null)
            {
                var listaClientes = new List<Customer> { cliente };
                gridNotipado.DataSource = customerRepository.ObtenerTodos();
            }

        }

        private void btnBuscarNt_Click(object sender, EventArgs e)
        {
            var cliente = customerRepository.obtenerPorID(tbBusquedaNt.Text);

            var encontrado = cliente.CompanyName;
            tbEncontrado.Text = encontrado;

            if (cliente == null)
            {
                MessageBox.Show("El objeto es null");
            }
            if (cliente != null)
            {
                var listaClientes = new List<Customer> { cliente };
                gridNotipado.DataSource = listaClientes;
                RellenarForm(cliente);
            }
        }

        private void btnInsertarCliente_Click(object sender, EventArgs e)
        {
            var cliente = CrearCliente();
            int insertados = customerRepository.InsertarCliente(cliente);
            MessageBox.Show($"{insertados} registrados");
        }

        private Customer CrearCliente()
        {
            var cliente = new Customer
            {
                CustomerID = tboxCustomerID.Text,
                CompanyName = tboxCompanyName.Text,
                ContactName = tboxContactName.Text,
                ContactTitle = tboxContactTitle.Text,
                Address = tboxAddres.Text,
            };
            MessageBox.Show(cliente.CustomerID);
            MessageBox.Show(cliente.CompanyName, "Ingresar");
            return cliente;
        }
        #endregion

        #region Tipado
        CustomersTableAdapter adaptador = new CustomersTableAdapter();
        private void btnObtenerTipado_Click(object sender, EventArgs e)
        {
            var customers = adaptador.GetData();
            gridTipado.DataSource = customers;
        }

        private void btnBuscarTipado_Click(object sender, EventArgs e)
        {
            var customer = adaptador.GetDataBy(tboxBuscarTipado.Text);
            if (customer != null)
            {
                var objeto1 = customerRepository.ExtraerInformacionCliente(customer);

                RellenarForm(objeto1);
                Console.WriteLine(customer);
            }
        }

        private void btnInsertarT_Click(object sender, EventArgs e)
        {
            var cliente = CrearCliente();
            int insertados = customerRepository.InsertarCliente(cliente);
            MessageBox.Show($"{insertados} registrados");
        }

        private void btnActualizarT_Click(object sender, EventArgs e)
        {
            var fila = adaptador.GetDataBy(tboxCustomerID.Text);

            if (fila != null)
            {
                var datoOriginal = customerRepository.ExtraerInformacionCliente(fila);
                var datosModificados = CrearCliente();
                /*adaptador.Update(
                 datosModificados.CustomerID,
                 datosModificados.CompanyName,
                 datosModificados.ContactName,
                 datosModificados.ContactTitle,
                 datosModificados.Address,
                 datosModificados.City,
                 datosModificados.Region,
                 datosModificados.PostalCode,
                 datosModificados.Country,
                 datosModificados.Phone,
                 datosModificados.Fax,
                 datoOriginal.CustomerID,
                 datoOriginal.CompanyName,
                 datoOriginal.ContactName,
                 datoOriginal.ContactTitle,
                 datoOriginal.Address,
                 datoOriginal.City,
                 datoOriginal.Region,
                 datoOriginal.PostalCode,
                 datoOriginal.Country,
                 datoOriginal.Phone,
                 datoOriginal.Fax
                 );*/
                 var filas = adaptador.ActualizarCliente(datosModificados.CustomerID,
                 datosModificados.CompanyName,
                 datosModificados.ContactName,
                 datosModificados.ContactTitle,
                 datosModificados.Address,
                 datosModificados.City,
                 datosModificados.Region,
                 datosModificados.PostalCode,
                 datosModificados.Country,
                 datosModificados.Phone,
                 datosModificados.Fax, datoOriginal.CustomerID);
                 MessageBox.Show($"{filas} filas modificadas");
            }
        }
        #endregion

        private void btnActualizarNT_Click(object sender, EventArgs e)
        {
            var cliente = CrearCliente();
            var actulaizadas = customerRepository.ActualizarCliente(cliente);
            MessageBox.Show($"{actulaizadas} filas actualizadas");
        }

    }
}
