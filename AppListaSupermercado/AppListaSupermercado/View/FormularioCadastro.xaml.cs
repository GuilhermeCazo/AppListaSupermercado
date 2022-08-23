using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppListaSupermercado.Model;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppListaSupermercado.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FormularioCadastro : ContentPage
    {
        public FormularioCadastro()
        {
            InitializeComponent();
        }


        private async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            try
            {
                /**
                 * Preenchendo o model Produto com os dados informados na interface gráfica.
                 */
                Produto p = new Produto
                {
                    Descricao = txt_descricao.Text,
                    Preco_Unico = Convert.ToDouble(txt_preco_unico.Text),
                    Quantidade = Convert.ToDouble(txt_quantidade.Text),
                };


                /**
                 * Chamando o método insert da SQLiteDatabaseHelper para fazer a inseração do
                 * novo registro no arquivo db3 com os dados da model preenchida acima. O await
                 * denota que o código deve esperar o insert para prosseguir.
                 */
                await App.Database.Insert(p);


                /**
                 * Avisando o usuário que deu certo.
                 */
                await DisplayAlert("Sucesso!", "Produto Cadastrado", "OK");


                /**
                 * Navegando para a tela de listagem. 
                 */
                await Navigation.PushAsync(new ListaProdutos());
            }
            catch (Exception ex)
            {
                await DisplayAlert("Ops", ex.Message, "OK");
            }
        }

        //botão de ir pra lista
        private void Btn_ListaProdutos(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ListaProdutos());
        }

    }
}