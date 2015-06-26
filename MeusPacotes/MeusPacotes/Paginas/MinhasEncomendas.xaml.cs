using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using MeusPacotes.Entidades;
using MeusPacotes.Repositorio;

namespace MeusPacotes.Paginas
{
    public partial class MinhasEncomendas : PhoneApplicationPage
    {
        EncomendasTramps enc;
        public MinhasEncomendas()
        {
            InitializeComponent();
            Reflesh();
        }

        private void onSelecioChange(object sender, SelectionChangedEventArgs e)
        {
            enc = (sender as ListBox).SelectedItem as EncomendasTramps;
        }
        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            DadosEncomenda page = e.Content as DadosEncomenda;

            if (page != null)
            {
                page.codigo = enc.IdEncomenda;
            }
        }
        private void Reflesh()
        {
            List<EncomendasTramps> EncoTramps = RepositorioTramps.Get();
            listFAVORITOS.ItemsSource = EncoTramps;
        }

        private void vaiparapagedetalhes(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/Paginas/DadosEncomenda.xaml", UriKind.Relative));
        }

        private void deleta(object sender, EventArgs e)
        {
            if (MessageBox.Show("Retirar do Faro ?") == MessageBoxResult.OK)
            {
                RepositorioTramps.Delete(enc);
                Reflesh();
                MessageBox.Show("AuAu se foi");
            }
            else
                MessageBox.Show("AuAu feliz");
            
        }
    }
}