using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using MeusPacotes.Resources;
using MeusPacotes.Paginas;
using MeusPacotes.Entidades;
using MeusPacotes.Repositorio;

namespace MeusPacotes
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();

            // Sample code to localize the ApplicationBar
            //BuildLocalizedApplicationBar();
        }

        private void vaiparapagedetalhes(object sender, EventArgs e)
        {
            
            NavigationService.Navigate(new Uri("/Paginas/DadosEncomenda.xaml", UriKind.Relative));
        }
        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            DadosEncomenda page = e.Content as DadosEncomenda;
            if (page != null)
            {
                page.codigo = TxtCodigo.Text;
            }

        }
        private void vaiparapagerastrear(object sender, EventArgs e)
        {
            try
            {
                EncomendasTramps Riot = new EncomendasTramps
                {
                    IdEncomenda = TxtCodigo.Text

                };
                if (Riot != null)
                {
                    RepositorioTramps.Adicionar(Riot);
                    MessageBox.Show("Encomenda Adicionada");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Ops nada selecionado");
            }
            //NavigationService.Navigate(new Uri("/Paginas/MinhasEncomenda.xaml", UriKind.Relative));
        }

        private void vaiparapagerastreios(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/Paginas/MinhasEncomendas.xaml", UriKind.Relative));
        }

        private void vaiparapagesobre(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/Paginas/Sobre.xaml", UriKind.Relative));
        }

        private void clicklimpa(object sender, System.Windows.Input.GestureEventArgs e)
        {
            TxtCodigo.Text = "";
        }

        // Sample code for building a localized ApplicationBar
        //private void BuildLocalizedApplicationBar()
        //{
        //    // Set the page's ApplicationBar to a new instance of ApplicationBar.
        //    ApplicationBar = new ApplicationBar();

        //    // Create a new button and set the text value to the localized string from AppResources.
        //    ApplicationBarIconButton appBarButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/appbar.add.rest.png", UriKind.Relative));
        //    appBarButton.Text = AppResources.AppBarButtonText;
        //    ApplicationBar.Buttons.Add(appBarButton);

        //    // Create a new menu item with the localized string from AppResources.
        //    ApplicationBarMenuItem appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBarMenuItemText);
        //    ApplicationBar.MenuItems.Add(appBarMenuItem);
        //}
    }
}