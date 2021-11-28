using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsEF
{
    public partial class WindowsFormsEF : Form
    {
        public WindowsFormsEF()
        {
            InitializeComponent();
            ListProductos();
            txtBuscar.TextChanged += buscar;
            dgvProducto.DoubleClick += delegadoDobleclik;
            btnNuevo.Click += nuevo;
        }

        private void nuevo(object sender, EventArgs e)
        {
            FrmProducto objForm = new FrmProducto();
            objForm.StartPosition = FormStartPosition.CenterScreen;
            objForm.ShowDialog();
            ListProductos();

        }

        private void delegadoDobleclik(Object sender, EventArgs e)
        {
            DataGridViewRow fila = dgvProducto.CurrentRow;
            int filaCodigo = Convert.ToInt32(fila.Cells["Codigo"].Value);
            Datos.Producto objDatos = new Datos.Producto();
            Modelo.Producto producto = objDatos.ListarUno(filaCodigo);
            FrmProducto objForm = new FrmProducto(producto);
            objForm.StartPosition = FormStartPosition.CenterScreen;
            objForm.ShowDialog();
            ListProductos();
        }
        private void buscar (Object sender, EventArgs e)
        {
            ListProductos(txtBuscar.Text);
        }
        void ListProductos()
        {
            Datos.Producto objDatos = new Datos.Producto();
            dgvProducto.DataSource = objDatos.Listar();
        }

        void ListProductos(string letras)
        {
            Datos.Producto objDatos = new Datos.Producto();
            dgvProducto.DataSource = objDatos.Listar(letras);
        }

  
    }
}
