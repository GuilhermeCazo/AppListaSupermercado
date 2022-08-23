using System;
using System.Collections.Generic;
using System.Text;

using SQLite;

namespace AppListaSupermercado.Model
{
    public class Produto
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Descricao { get; set; }
        public double Preco_Unico { get; set; }
        public double Quantidade { get; set; }
        public double Preco_Total { get; set; }


    }
}
