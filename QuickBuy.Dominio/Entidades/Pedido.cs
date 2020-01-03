using QuickBuy.Dominio.Entidades.ObjetoDeValor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickBuy.Dominio.Entidades
{
    public class Pedido : Entidade
    {
        public int Id { get; set; }
        public DateTime DataPedido { get; set; }
        public int UsuarioID { get; set; }
        public virtual Usuario Usuario { get; set; }
        /// <summary>
        /// pode ter pelo menos um ou muitos item de pedidos
        /// </summary>
        public virtual ICollection<ItemPedido> ItensPedido { get; set; }
        public DateTime DataPrevisaoEntrega { get; set; }
        public string CEP { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string EnderecoCompleto { get; set; }
        public int NumeroEndereco { get; set; }
        public virtual FormaDePagamento FormaPagamento { get; set; }
        public int FormaPagamentoId { get; set; }

        public override void Validate()
        {
            if (!ItensPedido.Any())
            {
                LimparMensagemValidacao();
                AdicionarCritica("Crítica: Item de pedido não pode ficar vazio!");
            }
            if (string.IsNullOrEmpty(CEP))
            {
                AdicionarCritica("Crítica: CEP não pode ficar vazio!");
            }
            if(FormaPagamentoId == 0)
            {
                AdicionarCritica("Crítica: não foi informada a forma de pagamento!");
            }
        }
    }
}
