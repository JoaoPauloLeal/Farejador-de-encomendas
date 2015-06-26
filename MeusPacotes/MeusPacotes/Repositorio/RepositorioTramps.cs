using MeusPacotes.Banco;
using MeusPacotes.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeusPacotes.Repositorio
{
    class RepositorioTramps
    {
        private static DataBase GetDataBase()
        {
            DataBase db = new DataBase();
            if (!db.DatabaseExists())
                db.CreateDatabase();

            return db;
        }
        public static List<EncomendasTramps> Get()
        {
            DataBase db = GetDataBase();
            var query = from salvo in db.DBSalvos orderby salvo.iTramps select salvo;

            List<EncomendasTramps> ListaSalvos = new List<EncomendasTramps>(query.AsEnumerable());
            return ListaSalvos;

        }
        public static void Adicionar(EncomendasTramps IDSalvos)
        {
            DataBase db = GetDataBase();
            db.DBSalvos.InsertOnSubmit(IDSalvos);
            db.SubmitChanges();
        }
        public static void Delete(EncomendasTramps DELSalvos)
        {
            DataBase db = GetDataBase();
            var query = from c in db.DBSalvos
                        where c.IdEncomenda == DELSalvos.IdEncomenda
                        select c;
            db.DBSalvos.DeleteOnSubmit(query.ToList()[0]);
            db.SubmitChanges();

        }
    }
}
