namespace mvc_restaurante.Models
{
    public class Restaurante
    {
        private int proxPedido = 1;
        private Pedido[] pedidos = new Pedido[50];

        public bool NovoPedido(Pedido pedido)
        {
            if (pedido == null) return false;
            for (int i = 0; i < pedidos.Length; i++)
            {
                if (pedidos[i] == null)
                {
                    pedido.Id = proxPedido++;
                    pedidos[i] = pedido;
                    return true;
                }
            }
            return false; // fila cheia (50)
        }

        public Pedido BuscarPedido(int id)
        {
            foreach (var p in pedidos)
                if (p != null && p.Id == id) return p;
            return null;
        }

        public bool CancelarPedido(int id)
        {
            for (int i = 0; i < pedidos.Length; i++)
            {
                if (pedidos[i] != null && pedidos[i].Id == id)
                {
                    pedidos[i] = null;
                    return true;
                }
            }
            return false;
        }

        public Pedido[] ListarPedidos() => pedidos;

        public double SomaGeral()
        {
            double soma = 0;
            foreach (var p in pedidos)
                if (p != null) soma += p.CalcularTotal();
            return soma;
        }
    }
}
