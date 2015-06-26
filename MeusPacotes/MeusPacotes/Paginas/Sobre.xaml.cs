using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Microsoft.Phone.Tasks;

namespace MeusPacotes.Paginas
{
    public partial class Sobre : PhoneApplicationPage
    {
        public Sobre()
        {
            InitializeComponent();
        }

        private void Button_Click_Loja(object sender, RoutedEventArgs e)
        {
            MarketplaceReviewTask task = new MarketplaceReviewTask();
            task.Show();
        }

        private void AvaliaTxt(object sender, System.Windows.Input.GestureEventArgs e)
        {
            MarketplaceReviewTask task = new MarketplaceReviewTask();
            task.Show();
        }
    }
}