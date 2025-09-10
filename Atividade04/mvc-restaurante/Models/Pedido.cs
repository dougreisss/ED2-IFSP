using System.Text;

namespace mvc_restaurante.Models
{
    public class Pedido
    {
        public int Id { get; set; }
        public string Cliente { get; set; }
        private Item[] itens = new Item[10];
        private int proxItemId = 1;

        public Pedido(string cliente)
        {
            Cliente = cliente;
        }

        public bool AdicionarItem(Item item)
        {
            for (int i = 0; i < itens.Length; i++)
            {
                if (itens[i] == null)
                {
                    item.Id = proxItemId++;
                    itens[i] = item;
                    return true;
                }
            }
            return false; // já tem 10 itens
        }

        public bool RemoverItem(int itemId)
        {
            for (int i = 0; i < itens.Length; i++)
            {
                if (itens[i] != null && itens[i].Id == itemId)
                {
                    itens[i] = null;
                    return true;
                }
            }
            return false;
        }

        public double CalcularTotal()
        {
            double total = 0;
            foreach (var it in itens)
                if (it != null)
                    total += it.Preco;
            return total;
        }

        public string DadosDoPedido()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Pedido #{Id} - Cliente: {Cliente}");
            sb.AppendLine("Itens:");
            foreach (var it in itens)
            {
                if (it != null) sb.AppendLine($"  {it}");
            }
            sb.AppendLine($"Total: R$ {CalcularTotal():F2}");
            return sb.ToString();
        }

        public Item[] GetItens() => itens;
    }
}
