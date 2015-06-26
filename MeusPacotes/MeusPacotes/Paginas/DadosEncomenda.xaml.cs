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
using Newtonsoft.Json.Linq;

namespace MeusPacotes.Paginas
{
    public partial class DadosEncomenda : PhoneApplicationPage
    {
        public String codigo;
        //DetalhesEncomendas encomendajson = null;
        
        public DadosEncomenda()
        {
            InitializeComponent();
            
           
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (codigo != null)
                    {

                        CarregarEncomenda();
                    }
        }
        private void CarregarEncomenda()
        {
            try
            {
                
                    WebClient jsonClient = new WebClient();
                    jsonClient.DownloadStringCompleted +=
                        new DownloadStringCompletedEventHandler(DownloadStringCompleted);
                    //jsonClient.Encoding = System.Text.Encoding.GetEncoding("ISO8859-1");
                    jsonClient.Encoding = System.Text.Encoding.GetEncoding("UTF-8");
                    jsonClient.DownloadStringAsync(new Uri(@"http://developers.agenciaideias.com.br/correios/rastreamento/json/" + codigo));
                
            }
            catch
            {
                MessageBox.Show("ERRO AO CARREGAR A ENCOMENDA");
            }


        }
        private void DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            try
            {

                ParseJson(e.Result);
                
                

                
            }
            catch
            {
                MessageBox.Show("ERRO NA ENCOMENDA");
            }
        }
        private List<DetalhesEncomendas> ParseJson(string pJson)
        {

            //cria objeto para lista do tipo carro
            List<DetalhesEncomendas> encomendajson = new List<DetalhesEncomendas>();
            if (pJson != null)
            {
                //faz o parse para um tipo jobject
                JArray jobject = JArray.Parse(pJson);
                //JObject jobjectclima = (JObject)jobject["agora"];
                //JObject jobjectprevisao = (JObject)jobject["previsoes"];
                foreach (JObject item in jobject)
                {
                    DetalhesEncomendas detalhe = new DetalhesEncomendas
                    {
                        dataE = (string)item["data"],
                        localE = (string)item["local"],
                        acaoE = (string)item["acao"],
                        detalhesE = (string)item["detalhes"]
                    };
                    encomendajson.Add(detalhe);
                }
                //List<DetalhesEncomendas> CID = jobject.ToObject<List<DetalhesEncomendas>>();
                //le a lista carros
                
                //encomendajson = CID;
                listadeencomendas.ItemsSource = encomendajson;
                

            }

            return encomendajson;


        }

        private void onSelecioChange(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}