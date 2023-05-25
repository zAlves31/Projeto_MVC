using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Console_MVC.Model
{
    public class Produto
    {
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public float Preco { get; set; }

        // caminho da pasta e do arquvio definido
        private const string PATH = "Database/Produto.csv";
        
        public Produto()
        {
            // obter o caminho da pasta
            string pasta = PATH.Split("/")[0];//"Datasabe"   

            // se nao existir uma pasta Datasabe, entao cria-se uma
            if (!Directory.Exists(pasta))
            {
                Directory.CreateDirectory(pasta);
            }

            // se nao existir um arquivo csv no caminho, entao cria-se uma
            if (!File.Exists(PATH))
            {
                File.Create(PATH);  
            }
            
           
        }
        public List<Produto> Ler()
        {
            // instanciar uma lista de produto
            List<Produto> produtos = new List<Produto>();

            // array de string que recebe cada linha do csv
            string[] linhas = File.ReadAllLines(PATH);

            // para leitura das linhas
            foreach (string item in linhas)
            {
                // antes do split
                // 001;Coca;6,50

                // array que recebe os itens da linha separado por ";"
                string[] atributos = item.Split(";");

                // apos o split
                // atributo[0] = "001"
                // atributo[1] = "Coca"
                // atributo[2] = "6,50"

                // instacia de objeto produto
                Produto p = new Produto();

                // atribuir os dados dentro de um objeto
                p.Codigo = int.Parse(atributos[0]);             
                p.Nome = atributos[1];
                p.Preco = float.Parse(atributos[2]);

                // adiciona os objetos dentro da lista
                produtos.Add(p);
            }
        
            return produtos;

        }

        // metodo para preparar a linha do csv

        public string prepararLinhaCSV(Produto p)
        {
            return $"{p.Codigo};{p.Nome};{p.Preco};";
        }

        // metodo para inserir um produto de arquivo do csv
        public void Inserir(Produto p)
        {
            // Array que vai armazenar as linhas (cada"objeto")
            string [] linhas = {prepararLinhaCSV(p)};

             //classe File. método AppendAllLines(inserir todas as linhas) passando como argumento
            //o caminho e o objeto a ser inserido(a linha)
            File.AppendAllLines(PATH, linhas);
        }
    }
}