using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeusPacotes.Entidades
{
    [Table(Name = "Salvos")]
    public class EncomendasTramps
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true, DbType = "INT NOT NULL Identity", AutoSync = AutoSync.OnInsert, CanBeNull = false)]
        public int iTramps { get; set; }
        
        [Column(CanBeNull = true)]
        public String IdEncomenda { get; set; }

    }
}
