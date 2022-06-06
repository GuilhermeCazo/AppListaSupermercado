using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using AppListaSupermercado.Model;

namespace AppListaSupermercado.Helper
{
    public class SQLiteDatabaseHelper
    {

        readonly SQLiteAsyncConnection _conn;


        public SQLiteDatabaseHelper(string path)
        {

            _conn = new SQLiteAsyncConnection(path);
            _conn.CreateTableAsync<Produto>().Wait();
        }
        public void insert(Produto p) //PAREI AQUI, =25:46
        {

        }

        public void update(Produto p)
        {

        }

        public Task<Produto> getById(int id)
        {
            return new Produto();
        }

        public Task<List<Produto>> getAll()
        {

        }

        public void delete(int id)
        {

        }
    }
}
