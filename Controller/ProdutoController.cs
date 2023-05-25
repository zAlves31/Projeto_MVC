using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Console_MVC.Model;
using Console_MVC.View;

namespace Console_MVC.Controller
{
    public class ProdutoController
    {
        //instância de objeto produto e produtoView
        Produto produto = new Produto();
        ProdutoView produtoView = new ProdutoView();

        //método controlador para acessar a listagem de produtos
        public void ListarProdutos()
        {
            //lista de produtos que recebe os itens obtidos pelo método Ler da model
            List<Produto> produtos = produto.Ler();

            //chamada do metodo de exibicao (VIEW) recebendo como argumento a 
            produtoView.Listar(produtos);
        }

        // Metodo controlado para acessar o cadastro de produtos
        public void CadastrarProduto()
        {
            // Chamada para view que recebe cada objeto a ser inserido no csv
            Produto novoProduto = produtoView.Cadastrar();

            // chamada para a model para inserir esse objeto no csv
            produto.Inserir(novoProduto);
        }
    }

}