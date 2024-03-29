﻿using AppListaSupermercado.Model;

using System.Collections.ObjectModel;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppListaSupermercado.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListaProdutos : ContentPage
    {


        ObservableCollection<Produto> lista_produtos = new ObservableCollection<Produto>();


        public ListaProdutos()
        {

            InitializeComponent();

            lst_produtos.ItemsSource = lista_produtos;

        }



        /*
         private void ToolbarItem_Clicked_Novo(object sender, EventArgs e)
          {
            try
            {
               Navigation.PushAsync(new FormularioCadastro());
        
            } catch(Exception ex)
            {
                DisplayAlert("Ops", ex.Message, "OK");
           }
          }

        */
        //===============================================================//

        // O VALOR TOTAL, MAS VOU TER QUE FAZER DIFERENTE
        
           

        


        protected override void OnAppearing()
        {
            if (lista_produtos.Count == 0)
            {
                System.Threading.Tasks.Task.Run(async () =>
                {

                    List<Produto> temp = await App.Database.GetAll();

                    foreach (Produto item in temp)
                    {
                        lista_produtos.Add(item);
                    }

                    ref_carregando.IsRefreshing = false;
                });

            }
        }

        private async void MenuItem_Clicked(object sender, EventArgs e)
        {
            
            MenuItem disparador = (MenuItem)sender;


            
            Produto produto_selecionado = (Produto)disparador.BindingContext;

            
            bool confirmacao = await DisplayAlert("Tem Certeza?", "Remover Item?", "Sim", "Não");

            if (confirmacao)
            {
                await App.Database.Delete(produto_selecionado.Id);

                
                lista_produtos.Remove(produto_selecionado);
            }
        }



        //busca
        private void txt_busca_TextChanged(object sender, TextChangedEventArgs e)
        {

            string buscou = e.NewTextValue;

            System.Threading.Tasks.Task.Run(async () =>
            {
                List<Produto> temp = await App.Database.Search(buscou);

                
                lista_produtos.Clear();

                foreach (Produto item in temp)
                {
                    lista_produtos.Add(item);
                }

                ref_carregando.IsRefreshing = false;
            });
        }


      //editar (vejo bunitinho depois, não sei se da certo pq tenho que fazer o arquivo bonitinho

       
        private void lst_produtos_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            
            Navigation.PushAsync(new Edicao
            {
                BindingContext = (Produto)e.SelectedItem
            });
        }
        

        private void Btn_FormCadastro(object sender, EventArgs e)
        {
            Navigation.PushAsync(new FormularioCadastro());
        }
    }
}