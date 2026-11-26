using System;
using System.Collections.Generic;
using System.Globalization;

namespace MERCADINHO
{
    internal class ServicoUI
    {
        // Lucca Stern Bianchi, Arthur D Lucca Araújo Dos Santos
        // Murilo Queiroz Cardoso, Renato Henrique Leme De Alcântara

        public static Cupom.ItemCupom ObterItemCupom(int numCupom, List<Produto> produtos, string cod, string qtd)
        {
            Produto produtoEncontrado = produtos.Find(produto => produto.EAN13.Equals(cod)) ?? throw new Exception("Produto não encontrado.");
            
            if (double.TryParse(qtd, NumberStyles.Any, CultureInfo.InvariantCulture, out double quantidade))
            {
                if (quantidade > 0 && quantidade <= produtoEncontrado.Estoque)
                {
                    return new Cupom.ItemCupom(numCupom, produtoEncontrado, quantidade);
                }
                else if (quantidade <= 0)
                {
                    throw new Exception("A quantidade deve ser positiva.");
                }
                else
                {
                    throw new Exception($"Estoque insuficiente. Saldo atual: {produtoEncontrado.Estoque}");
                }
            }
            else
            {
                throw new Exception("Formato de quantidade inválido. Use ponto '.' como separador decimal.");
            }
        }

        public static void ImprimirCupom(Cupom cupom)
        {
            Console.WriteLine("\n=============================================");
            Console.WriteLine($"| Lojinha do IFSP Cubatão                    |");
            Console.WriteLine($"| Número: {cupom.Numero:000000}              |");
            Console.WriteLine($"| Data/Hora: {cupom.Emissao}");
            Console.WriteLine($"| Cliente (CPF): {cupom.Cliente}");
            Console.WriteLine("---------------------------------------------");

            int numItem = 0;
            foreach (Cupom.ItemCupom item in cupom.Itens)
            {
                numItem++;
                double valorItem = item.CalcularValorItem();
                Console.WriteLine($"| Item {numItem:00}: {item.Item.EAN13} - {item.Item.Descricao} {item.Quantidade.ToString("f2", CultureInfo.InvariantCulture)} X {valorItem.ToString("f2", CultureInfo.InvariantCulture)}");
            }

            Console.WriteLine("---------------------------------------------");
            Console.WriteLine($"| Total itens: {cupom.Itens.Count}");
            Console.WriteLine($"| Total valor: {cupom.CalcularValorTotal().ToString("f2", CultureInfo.InvariantCulture)}");
            Console.WriteLine("=============================================");
        }
    }
}