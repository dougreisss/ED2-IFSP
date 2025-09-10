using System;

namespace mvc_restaurante.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public double Preco { get; set; }

        public Item() { }

        public Item(int id, string descricao, double preco)
        {
            Id = id;
            Descricao = descricao;
            Preco = preco;
        }

        public override string ToString() => $"{Id} - {Descricao} - R$ {Preco:F2}";
    }
}
