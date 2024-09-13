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

        #region No Tipado
        CustomerRepository customerRepository = new CustomerRepository();
        private void btnObtenerNotipado_Click(object sender, EventArgs e)
        {
            gridNotipado.DataSource = customerRepository.ObtenerTodos();
        }

        private void btnBuscarNt_Click(object sender, EventArgs e)
        {
            var cliente = customerRepository.obtenerPorID(tbBusquedaNt.Text);

            var encontrado = cliente.CompanyName;
            tbEncontrado.Text = encontrado;
        }
        #endregion

        #region Tipado
        CustomersTableAdapter adaptador = new CustomersTableAdapter();
        private void btnObtenerTipado_Click(object sender, EventArgs e)
        {
            var customers = adaptador.GetData();
            gridTipado.DataSource = customers;
        }
        #endregion
    }
}
