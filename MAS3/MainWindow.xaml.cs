using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace MAS3
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            btn1.Background = Brushes.Yellow;
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Prueba");
        }

        private void Boton2_OnClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("peps1");
        }

        private void BotonTriple(object sender, RoutedEventArgs e)
        {

        }

        private void Panel_OnClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Le diste click al panel");
        }

        private void PanelTunneling(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("vamos con este ahora ?!");
        }
    }
}
