using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atividade02.Models
{
    public class Vendedores
    {
        private Vendedor[] osVendedores;
        private int max;
        private int qtde;

        public Vendedor[] OsVendedores { get => osVendedores; }
        public int Max { get => max; }
        public int Qtde { get => qtde; }

        public Vendedores(int max)
        {
            this.max = max;
            this.qtde = 0;
            inicializarVendedores();
        }
        public Vendedores() : this(10)
        {
        }


        public bool addVendedor(Vendedor vendedor)
        {
            if (this.qtde == this.max)
                return false;

            this.osVendedores[qtde++] = vendedor;
            return true;
        }
        public bool delVendedor(Vendedor vendedor)
        {
            int i = 0;

            while (i < this.max && !this.osVendedores[i].Equals(vendedor))
            {
                i++;
            }

            bool removerVendedaor = i <= this.max;

            if (removerVendedaor)
            {
                while (i < this.max - 1)
                {
                    this.osVendedores[i] = this.osVendedores[i + 1];
                    i++;
                }
                this.osVendedores[i] = new Vendedor();
                this.qtde--;
            }

            return removerVendedaor;
        }
        public Vendedor searchVendedor(Vendedor vendedor)
        {
            Vendedor vendedorResult = new Vendedor();
            int i = 0;

            while (i < this.max && !this.osVendedores[i].Equals(vendedor))
            {
                i++;
            }

            if (i < this.max)
                vendedorResult = this.osVendedores[i];

            return vendedorResult;
        }
        public double valorVendas()
        {
            double somaVendas = 0;
            foreach (var vendedor in this.osVendedores)
            {
                somaVendas += vendedor.valorVendas();
            }

            return somaVendas;
        }
        public double valorComissao()
        {
            double somaComissao = 0;
            foreach (var vendedor in this.osVendedores)
            {
                somaComissao += vendedor.valorComissao();
            }

            return somaComissao;
        }

        private void inicializarVendedores()
        {
            this.osVendedores = new Vendedor[this.max];

            for (int i = 0; i < max; i++)
            {
                this.osVendedores[i] = new Vendedor();
            }
        }
    }
}
