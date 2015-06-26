using MeusPacotes.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeusPacotes.Banco
{
    public class DataBase : DataContext
    {
        public static string DBConnectionString =
                "Data Source = 'isostore:DBtramps.sdf'";
        public DataBase()
            : base(DBConnectionString)
        {

        }
        public Table<EncomendasTramps> DBSalvos
        {
            get { return this.GetTable<EncomendasTramps>(); }
        }
    }
}
