using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Ejercicio2
{
    public partial class MainWindow : Window
    {
        static double contador = 0.5;
        static int contadorHijos = 1;
        private ObservableCollection<MiLista> lista { get; set; }
        public MainWindow()
        {
            InitializeComponent();

            lista = new ObservableCollection<MiLista>();
            dataGrid.ItemsSource = lista;
        }

        // Añade persona a la lista
        private void agregarPersona()
        {
            lista.Add(new MiLista
            {
                Nombre = nombre.Text,
                Apellidos = apellido.Text,
                Telefono = telefono.Text,
                CorreoElectronico = correoElectronico.Text,
                Usuario = usuario.Text,
                Hijos = numHijos.Text,
                Altura = altura.Text,
                Fecha = fecha.Text,
            });
            limpiarTexto();
        }

        // Agrega al DataGrid los datos introducidos.
        private void boton_Click(object sender, RoutedEventArgs e)
        {
            if (dataGrid.SelectedItem != null)
            {
                var persona = dataGrid.SelectedItem as MiLista;
                if (persona != null)
                {
                    persona.Nombre = nombre.Text;
                    persona.Apellidos = apellido.Text;
                    persona.Telefono = telefono.Text;
                    persona.CorreoElectronico = correoElectronico.Text;
                    persona.Usuario = usuario.Text;
                    persona.Hijos = numHijos.Text;
                    persona.Altura = altura.Text;
                    persona.Fecha = fecha.Text;

                    dataGrid.Items.Refresh();
                }
            }
            else
            {
                agregarPersona();
            }
        }

        // Borra el contenido de los TextBox.
        private void limpiarTexto()
        {
            nombre.Text = string.Empty;
            apellido.Text = string.Empty;
            telefono.Text = string.Empty;
            correoElectronico.Text = string.Empty;
            usuario.Text = string.Empty;
            numHijos.Text = string.Empty;
            checkBox.IsChecked = false;
            altura.Text = string.Empty;
            fecha.Text = string.Empty;
            hijo.Value = 0;
            listaHijos.Items.Clear();
            contHijos.Content = string.Empty;
        }

        // Selecciona la fila del DataGrid.
        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e) 
        {
                limpiarTexto();

            if (dataGrid.SelectedItem != null)
            {
                MiLista selectedItem = (MiLista)dataGrid.SelectedItem;

                // Recogemos el valor de los campos seleccionados.
                try
                {
                    nombre.Text = selectedItem.Nombre;
                    apellido.Text = selectedItem.Apellidos;
                    telefono.Text = selectedItem.Telefono;
                    correoElectronico.Text = selectedItem.CorreoElectronico;
                    usuario.Text = selectedItem.Usuario;
                    numHijos.Text = selectedItem.Hijos;
                    altura.Text = selectedItem.Altura;
                    fecha.Text = selectedItem.Fecha;
                } catch (Exception ex)
                {
                    ex.Source = "Error";
                }

                // Comprobamos que si tiene algún hijo muestre las opciones para guardar el nombre del hijo.
                int num = Int32.Parse(selectedItem.Hijos);
                if (num > 0)
                {
                    btnHijos.Opacity = 100;
                    btnHijos.IsEnabled = true;
                    nombresHijos.IsReadOnly = false;
                    nombresHijos.Opacity = 100;
                    listaHijos.Opacity = 100;
                    nombresHijos.Text = String.Empty;
                    
                    for(int i = 0; i < selectedItem.NombreHijos.Count; i++)
                    {
                        listaHijos.Items.Add(selectedItem.NombreHijos[i]);
                    }
                    

                }

                anyadir.Content = "Modificar";
                reset.Opacity = 100;
                reset.IsEnabled = true;
                contadorHijos = 1;
            }
        }

        // Resetea los campos.
        private void reset_Click(object sender, RoutedEventArgs e)
        {
            nombre.Text = string.Empty;
            apellido.Text = string.Empty;
            telefono.Text = string.Empty;
            correoElectronico.Text = string.Empty;
            usuario.Text = string.Empty;
            numHijos.Text= string.Empty;
            hijo.Value = 0;
            altura.Text = string.Empty;
            fecha.Text = string.Empty;

            anyadir.Content = "Añadir";
            dataGrid.SelectedItem = null;
        }

        // Si la checkBox de hijos está seleccionada muestra el Slider y la textBox con la cantidad de hijos.
        private void checkBox_Checked(object sender, RoutedEventArgs e)
        {
            if (checkBox.IsChecked == true)
            {
                hijo.Opacity = 100;
                numHijos.Opacity = 100;
            }
        }

        // Cambia el color del fondo cuando un textBox está seleccionado.
        private void gotFocus(object sender, RoutedEventArgs e)
        {
            panel.Background = Brushes.Aquamarine;
        }

        // Cambia el color del fondo cuando un textBox deja de estar seleccionado.
        private void lostFocus(object sender, RoutedEventArgs e)
        {
            panel.Background = Brushes.White;
        }

        // Asigna el valor del Slider a la TextBox.
        private void hijo_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            hijo.Value = Math.Round(hijo.Value, 0);
            numHijos.Text =hijo.Value.ToString();
        }

        // Aumenta la altura.
        private void Increase(object sender, RoutedEventArgs e)
        {
            if(contador <= 2.29) 
            {
                contador += 0.01;
                contador = Math.Round(contador, 2);
                altura.Text = contador.ToString();
            }
        }

        // Disminuye la altura.
        private void Decrease(object sender, RoutedEventArgs e)
        {
            if (contador >= 0.51)
            {
                contador -= 0.01;
                contador = Math.Round(contador, 2);
                altura.Text = contador.ToString();
            }
        }
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void telefono_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void correoElectronico_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }

        private void altura_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private void nombre_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void listaHijos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try {
                if (listaHijos != null && listaHijos.SelectedItems != null)
                {
                    string nombreHijoSeleccionado = listaHijos.SelectedItem.ToString();
                    nombresHijos.Text = nombreHijoSeleccionado;
                    listaHijos.SelectedItem = null;
                    listaHijos.Items.Refresh();

                }
            } catch (Exception ex) {
                ;
            }
            }

        // Botón que añade o modifica el nombre de los hijos.
        private void btnHijos_Click(object sender, RoutedEventArgs e)
        {
            var hijos = listaHijos.SelectedItem as List<string>;
            
            if (hijos != null)
            {
                hijos.Add(nombresHijos.Text);

            } else
            {
                agregarHijos();
            }
            

        }

        // Crea a los hijos.
        private void agregarHijos()
        {
            MiLista selectedItem = (MiLista)dataGrid.SelectedItem;
            int num = int.Parse(selectedItem.Hijos);

            if (contadorHijos <= num)
            {
                listaHijos.Items.Add(nombresHijos.Text);
                selectedItem.NombreHijos.Add(nombresHijos.Text);
                nombresHijos.Text = String.Empty;
                contadorHijos++;
            }

            if (contadorHijos > num)
            {
                nombresHijos.Text = "¡Ya has agregado a todos tus hijos!";
                nombresHijos.IsReadOnly = true;
                listaHijos.Items.Clear();
                contHijos.Content = string.Empty;

            }
            else
            {
                contHijos.Content = "Te faltan por ingresar\n" + (num - contadorHijos + 1) + " hijos";
            }
        }
        private void nombresHijos_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
    }

