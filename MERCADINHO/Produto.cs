using System;

namespace MERCADINHO
{
    internal class Produto
    {
        // Lucca Stern Bianchi, Arthur D Lucca Araújo Dos Santos
        // Murilo Queiroz Cardoso, Renato Henrique Leme De Alcântara

        public string EAN13;
        public string Descricao;
        public string Unidade;
        public double Preco;
        public double Estoque;

        public Produto() { }

        public Produto(string cod, string descricao, string unidade, double preco, double estoque)
        {
            EAN13 = cod;
            Descricao = descricao;
            Unidade = unidade;
            Preco = preco;
            Estoque = estoque;
        }
    }
}