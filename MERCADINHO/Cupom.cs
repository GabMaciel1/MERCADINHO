using System;
using System.Collections.Generic;

namespace MERCADINHO
{
    class Cupom
    {
        // Lucca Stern Bianchi, Arthur D Lucca Araújo Dos Santos
        // Murilo Queiroz Cardoso, Renato Henrique Leme De Alcântara

        public int Numero;
        public DateTime Emissao;
        public string Cliente;
        public List<ItemCupom> Itens = new List<ItemCupom>();

        public Cupom()
        {
            Numero = CupomDAL.ObterProxCupom();
            Emissao = DateTime.Now;
            Cliente = string.Empty;
        }

        public Cupom(int num, DateTime emissao, string cpf)
        {
            Numero = num;
            Emissao = emissao;
            Cliente = cpf;
        }

        public double CalcularValorTotal()
        {
            double valorTotal = 0;
            foreach (ItemCupom item in Itens)
            {
                valorTotal += item.CalcularValorItem();
            }
            return valorTotal;
        }

        public (int index, double quantidade) AdicionarItem(ItemCupom itemAdicionado)
        {
            if (Itens.Contains(itemAdicionado))
            {
                int ind = Itens.IndexOf(itemAdicionado);

                Itens[ind].Quantidade += itemAdicionado.Quantidade;

                itemAdicionado.Item.Estoque -= itemAdicionado.Quantidade;

                return (ind, Itens[ind].Quantidade);
            }
            else
            {
                Itens.Add(itemAdicionado);

                itemAdicionado.Item.Estoque -= itemAdicionado.Quantidade;

                return (-1, itemAdicionado.Quantidade);
            }
        }

        public void FecharCupom()
        {
            Console.WriteLine("Venda Concluída");
        }

#pragma warning disable CS0659 // O tipo substitui Object. Equals (objeto o), mas não substitui o Object.GetHashCode()
        internal class ItemCupom
#pragma warning restore CS0659 // O tipo substitui Object. Equals (objeto o), mas não substitui o Object.GetHashCode()
        {
            public int NumeroCupom;
            public Produto Item;
            public double Quantidade;

            public ItemCupom() { }

            public ItemCupom(int num, Produto item, double quantidade)
            {
                NumeroCupom = num;
                Item = item;
                Quantidade = quantidade;
            }

            public double CalcularValorItem()
            {
                return Quantidade * Item.Preco;
            }

            public override bool Equals(object obj)
            {
                ItemCupom other = obj as ItemCupom;
                return Item.EAN13.Equals(other.Item.EAN13);
            }

            public override string ToString()
            {
                return $"{Item.EAN13}-{Item.Descricao, -17} {Quantidade, 5:f2} {Item.Unidade, -3} x {Item.Preco, 6:f2} = {CalcularValorItem(), 6:f2}";
            }

            
        }
    }
}