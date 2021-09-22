using RegistroCompleto2.BLL;
using RegistroCompleto2.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace RegistroCompleto2.UI.Registros
{
    /// <summary>
    /// Interaction logic for rUsuarios.xaml
    /// </summary>
    public partial class rUsuarios : Window
    {
        private Usuarios usuarios = new Usuarios();
        public rUsuarios()
        {
            InitializeComponent();
            this.DataContext = usuarios;

            nivelComboBox.ItemsSource = RolesBLL.GetRoles();
            nivelComboBox.SelectedValuePath = "RolID";
            nivelComboBox.DisplayMemberPath = "Descripcion";
        }

        private void Limpiar()
        {
            this.usuarios = new Usuarios();
            this.DataContext = usuarios;

            idTextBox.Text = " ";
            nombreTextBox.Text = " ";
            aliasTextBox.Text = " ";
            emailTextBox.Text = " ";
            claveTextBox.Text = " ";
            fechaCreacionDatePicker.SelectedDate = DateTime.Now;
        }

        private bool Validar()
        {
            bool esvalido = true;

            if (idTextBox.Text.Length == 0)
            {
                esvalido = false;
                MessageBox.Show("ID no puede estar vacio", "Fallo", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            if (nombreTextBox.Text.Length == 0)
            {
                esvalido = false;
                MessageBox.Show("Nombre no puede estar vacia", "Fallo", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            if (aliasTextBox.Text.Length == 0)
            {
                esvalido = false;
                MessageBox.Show("Alias no puede estar vacia", "Fallo", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            if (emailTextBox.Text.Length == 0)
            {
                esvalido = false;
                MessageBox.Show("Email no puede estar vacia", "Fallo", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            if (claveTextBox.Text.Length == 0)
            {
                esvalido = false;
                MessageBox.Show("clave no puede estar vacia", "Fallo", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            if (fechaCreacionDatePicker.Text.Length == 0)
            {
                esvalido = false;
                MessageBox.Show("La fecha no puede estar vacia", "Fallo", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            return esvalido;
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            var rol = UsuariosBLL.Buscar(Convert.ToInt32(idTextBox.Text));

            if (rol != null)
            {
                aliasTextBox.Text = usuarios.alias;
                nombreTextBox.Text = usuarios.nombres;
                emailTextBox.Text = usuarios.email;
                claveTextBox.Text = usuarios.clave;
                fechaCreacionDatePicker.SelectedDate = usuarios.fechaingreso;

                this.usuarios = rol;
            }
            else
            {
                this.usuarios = new Usuarios();
            }
            this.DataContext = this.usuarios;
        }

        private void nuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private void guardarButton_Click(object sender, RoutedEventArgs e)
        {
            if (!Validar())
                return;

            usuarios.alias = aliasTextBox.Text;
            usuarios.nombres = nombreTextBox.Text;
            usuarios.email = emailTextBox.Text;
            usuarios.clave = claveTextBox.Text;
            usuarios.fechaingreso = fechaCreacionDatePicker.SelectedDate.Value;
     
            var paso = UsuariosBLL.Guardar(usuarios);
            if (paso)
            {
                Limpiar();
                MessageBox.Show("Guardado con exito", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("No se pudo guardar", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void eliminarButton_Click(object sender, RoutedEventArgs e)
        {
            if (UsuariosBLL.Eliminar(Convert.ToInt32(idTextBox.Text)))
            {
                Limpiar();
                MessageBox.Show("Registro Eliminado", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);

            }
            else
            {
                MessageBox.Show("No fue posible Eliminar", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}

