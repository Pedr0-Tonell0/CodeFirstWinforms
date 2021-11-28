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
    public partial class FrmProducto : Form
    {
        Datos.Producto objDatos = new Datos.Producto();
        public FrmProducto()
        {
            InitializeComponent();
            btnAgregar.Click += botones;
            btnCerrar.Click += botones;
            btnModificar.Enabled = false; 
            btnEliminar.Enabled = false;

        }
        public FrmProducto(Modelo.Producto produ)
        {
            InitializeComponent();
            lblContenidoCodigo.Text = produ.Codigo.ToString();
            txtNombre.Text = produ.Nombre;
            txtPrecio.Text = produ.Precio.ToString();
            //subscribimos los click de los botones
            btnCerrar.Click += botones;
            btnEliminar.Click += botones;
            btnModificar.Click += botones;
            btnAgregar.Enabled = false;
        }

        private void botones(object sender, EventArgs e)
        {
            Button opcion = sender as Button;
            switch (opcion.Name)
            {
                case "btnCerrar":
                    Close();
                    break;
                case "btnEliminar":
                    Modelo.Producto produEliminar = new Modelo.Producto();
                    produEliminar.Codigo = Convert.ToInt32(lblContenidoCodigo.Text);
                    if (MessageBox.Show($"¿ Esta seguro de eliminar el producto {produEliminar.Codigo} ?", "Eliminar producto", MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        objDatos.Eliminar(produEliminar.Codigo);
                        MessageBox.Show($"Producto {produEliminar.Codigo} eliminado!");
                    }
                    break;
                case "btnAgregar":
                    Modelo.Producto produNuevo = new Modelo.Producto();
                    produNuevo.Nombre = txtNombre.Text;
                    produNuevo.Precio = Convert.ToDouble(txtPrecio.Text);
                    objDatos.Agregar(produNuevo);
                    MessageBox.Show($"Producto {produNuevo.Nombre} agregado!");
                    break;
                case "btnModificar":
                    Modelo.Producto produModificar = new Modelo.Producto();
                    produModificar.Codigo = Convert.ToInt32(lblContenidoCodigo.Text);
                    produModificar.Nombre = txtNombre.Text;
                    produModificar.Precio = Convert.ToDouble(txtPrecio.Text);
                    objDatos.Modificar(produModificar);
                    MessageBox.Show($"Producto {produModificar.Codigo} modificado!");
                    break;
                default:
                    break;
            }
        }
    }
}
