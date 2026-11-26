using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.Remoting.Messaging;
using System.Threading;
using System.Windows.Forms;

namespace MERCADINHO
{
    public partial class Form1 : Form
    {
        // Lucca Stern Bianchi, Arthur D Lucca Araújo Dos Santos
        // Murilo Queiroz Cardoso, Renato Henrique Leme De Alcântara

        List<Produto> listaProdutos;
        Cupom cupom;
        double total = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                listaProdutos = ServicoDAL.ObterTabelaProdutos();

                listaProdutos.Sort((prod1, prod2) =>
                    prod1.EAN13.CompareTo(prod2.EAN13));

                cupom = new Cupom();

                PerguntaCPF();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erro ao conectar com o banco de dados: " + ex.Message,
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

                Close();
            }
        }
        /* {
             List<string> linhasProdutos = ServicoDAL.ObterTabelaProdutos();

             listaProdutos = new List<Produto>();

             foreach (string linha in linhasProdutos)
             {
                 string[] campos = linha.Split(',');

                 if (campos.Length >= 5)
                 {
                     try
                     {
                         string cod = campos[0].Trim();
                         string descricao = campos[1].Trim();
                         string unidade = campos[2].Trim();
                         double preco = double.Parse(campos[3].Trim(), CultureInfo.InvariantCulture);
                         double estoque = double.Parse(campos[4].Trim(), CultureInfo.InvariantCulture);

                         listaProdutos.Add(new Produto(cod, descricao, unidade, preco, estoque));
                     }
                     catch (FormatException ex)
                     {
                         MessageBox.Show($"Erro: {ex.Message}", "Aviso",
                                         MessageBoxButtons.OK, MessageBoxIcon.Information);
                         break;

                     }
                 }
             }


             listaProdutos.Sort((prod1, prod2) => prod1.EAN13.CompareTo(prod2.EAN13));

             cupom = new Cupom();

             PerguntaCPF();
         }*/

        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                Cupom.ItemCupom itemAdicionado = ServicoUI.ObterItemCupom(cupom.Numero, listaProdutos, textCod.Text, textUnd.Text);
                var (index, qtd) = cupom.AdicionarItem(itemAdicionado);
                if (!buttonFinalizar.Enabled)
                {
                    buttonFinalizar.Enabled = true;
                    listBoxCarrinho.Items.Clear();
                }
                string prodStr = $"{itemAdicionado.Item.EAN13} - {itemAdicionado.Item.Descricao,-17} | {qtd, 5:f2} {itemAdicionado.Item.Unidade, -3} X R$ {itemAdicionado.Item.Preco, 5:f2}";
                if (index >= 0)
                {
                    listBoxCarrinho.Items[index] = prodStr;
                }
                else
                {
                    listBoxCarrinho.Items.Add(prodStr);
                }
                total += itemAdicionado.Quantidade * itemAdicionado.Item.Preco;
                labelPreco.Text = $"R$ {total, 6:f2}";
                textCod.Text = "";
                textUnd.Text = "";
                Console.Beep();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro: {ex.Message}", "Aviso",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                textCod.Text = "";
                textUnd.Text = "";
            }
        }

        private void Button2_Click(object sender, EventArgs e)
            
        {
            if (cupom.Itens.Count == 0)
            {
                MessageBox.Show("Adicione pelo menos um produto.",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                return;
            }

            bool gravacaoSucesso = CupomDAL.GravarCupom(cupom);

            if (!gravacaoSucesso)
            {
                return;
            }

            cupom.FecharCupom();

            WriteCupom();

            MessageBox.Show(
                "Venda concluída com sucesso!\nObrigado pela compra!\nVolte Sempre!",
                "Venda finalizada",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );

            buttonReiniciar.Enabled = true;
            buttonFinalizar.Enabled = false;
            buttonAdd.Enabled = false;
            textCod.Enabled = false;
            textUnd.Enabled = false;
        }
        /*  {
              bool gravacaoSucesso = CupomDAL.GravarCupom(cupom);

              if (gravacaoSucesso)
              {
                  WriteCupom();
              }
              else
              {
                  MessageBox.Show("Atenção: Não foi possível imprimir o cupom devido a um erro na gravação.",
                                  "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
              }

              cupom.FecharCupom();

              ServicoDAL.GravarTabelaProdutos(listaProdutos);

              WriteCupom();

              MessageBox.Show("Obrigado pela compra!\nVolte Sempre!", "Aviso",
                              MessageBoxButtons.OK, MessageBoxIcon.Information);
              buttonReiniciar.Enabled = true;
              buttonFinalizar.Enabled = false;
              buttonAdd.Enabled = false;
              textCod.Enabled = false;
              textUnd.Enabled = false;
          }*/

        private void Button3_Click(object sender, EventArgs e)
        {
            cupom.Cliente = textCliente.Text;
            buttonAdd.Enabled = true;
            textCod.Enabled = true;
            textUnd.Enabled = true;
            listBoxCarrinho.Items.Clear();
            listBoxCarrinho.Items.Add("Escaneie o produto");
            buttonEntrar.Enabled = false;
            textCliente.Enabled = false;
        }

        private void WriteCupom()
        {
            string linha = "------------------------------------------------------------------------";
            listBoxCarrinho.Items.Clear();
            listBoxCarrinho.Items.Add(linha);
            listBoxCarrinho.Items.Add($"|                            Mercado Federal                           |");
            listBoxCarrinho.Items.Add(linha);
            int i = 0;

            cupom.Itens.Sort((item1, item2) => item1.Item.Descricao.CompareTo(item2.Item.Descricao));
            foreach (Cupom.ItemCupom item in cupom.Itens)
            {
                listBoxCarrinho.Items.Add($"| Item {++i:00}: {item} |");
            }
            listBoxCarrinho.Items.Add(linha);
            listBoxCarrinho.Items.Add($"| Total itens: {i,2} {"Total valor:",42} R$ {total,6:f2} |");
            listBoxCarrinho.Items.Add(linha);
        }

        private void Reiniciar()
        {
            cupom = new Cupom();
            listBoxCarrinho.Items.Clear();
            listBoxCarrinho.Items.Add($"Venda Nº {cupom.Numero}. Informe o CPF do Cliente.");
            textCliente.Enabled = true;
            textCliente.Text = "";
            buttonEntrar.Enabled = true;
            buttonFinalizar.Enabled = false;
            buttonReiniciar.Enabled = false;
            textCod.Text = "";
            textCod.Enabled = false;
            textUnd.Text = "";
            textUnd.Enabled = false;
            total = 0;
            labelPreco.Text = "R$   0,00";
            PerguntaCPF();
        }

        private void PerguntaCPF()
        {
            DialogResult resposta = MessageBox.Show($"CPF na nota?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (resposta == DialogResult.Yes)
            {

                listBoxCarrinho.Items.Clear();
                listBoxCarrinho.Items.Add($"Venda Nº {cupom.Numero}. Informe o CPF do Cliente.");
            }
            else
            {
                listBoxCarrinho.Items.Clear();
                listBoxCarrinho.Items.Add($"Venda Nº {cupom.Numero}. Escaneie o produto.");
                textCod.Enabled = true;
                textCliente.Enabled = false;
                textUnd.Enabled = true;
                buttonEntrar.Enabled = false;
                if (!modeSwitch.Checked)
                {
                    buttonAdd.Enabled = true;
                }
                else
                {
                    buttonAdd.Enabled = false;
                    textUnd.Enabled = false;
                }
            }
        }

        private void buttonReiniciar_Click(object sender, EventArgs e)
        {
            Reiniciar();
        }

        private void textCod_TextChanged(object sender, EventArgs e)
        {
            if (modeSwitch.Checked)
            {
                if (textCod.Text.Length == 13)
                {
                    try
                    {
                        Cupom.ItemCupom itemAdicionado = ServicoUI.ObterItemCupom(cupom.Numero, listaProdutos, textCod.Text, "1");
                        var (index, qtd) = cupom.AdicionarItem(itemAdicionado);
                        if (!buttonFinalizar.Enabled)
                        {
                            buttonFinalizar.Enabled = true;
                            listBoxCarrinho.Items.Clear();
                        }
                        string prodStr = $"{itemAdicionado.Item.EAN13} - {itemAdicionado.Item.Descricao,-17} | {qtd,5:f2} {itemAdicionado.Item.Unidade,-3} X R$ {itemAdicionado.Item.Preco,5:f2}";
                        if (index >= 0)
                        {
                            listBoxCarrinho.Items[index] = prodStr;
                        }
                        else
                        {
                            listBoxCarrinho.Items.Add(prodStr);
                        }
                        total += itemAdicionado.Quantidade * itemAdicionado.Item.Preco;
                        labelPreco.Text = $"R$ {total,6:f2}";
                        textCod.Text = "";
                        textUnd.Text = "";
                        Console.Beep();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Erro: {ex.Message}", "Aviso",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                        textCod.Text = "";
                        textUnd.Text = "";
                    }
                }
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (modeSwitch.Checked)
            {
                textUnd.Enabled = false;
                buttonAdd.Enabled = false;
            }
            else
            {
                textUnd.Enabled = true;
                buttonAdd.Enabled = true;
            }
        }
    }
}
