using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Console_MVC.Model;

namespace Console_MVC.View
{
    public class ProdutoView
    {
        // metodo para exibir os dados da lista de produtos
        public void Listar(List<Produto> produto)
        {
            foreach (var item in produto)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"Codigo: {item.Codigo}");
                Console.WriteLine($"Nome: {item.Nome}");
                Console.WriteLine($"Preco: {item.Preco:C}");
                Console.WriteLine();
                Console.ResetColor();
                
                
            }
        }
        public Produto Cadastrar()
        {
            Produto novoProduto = new Produto();

            Console.WriteLine($"Informe o codigo: ");
            novoProduto.Codigo = int.Parse(Console.ReadLine());

            Console.WriteLine($"Informe o nome: ");
            novoProduto.Nome = (Console.ReadLine());

            Console.WriteLine($"Informe o preco: ");
            novoProduto.Preco = float.Parse(Console.ReadLine());

            return novoProduto;
        }
    }
}