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

        public Task<int> Insert(Produto p) //PAREI AQUI, =25:46
        {
            return _conn.InsertAsync(p);
        }



        public void Update(Produto p)
        {

            String sql = "UPDATE Produto SET NomeProduto=?, Quantidade=?, PrecoEstimado=?, PrecoPago=? WHERE id=?";

            _conn.QueryAsync<Produto>(sql, p.NomeProduto, p.Quantidade, p.PrecoEstimado, p.PrecoEstimado, p.Id);
        }


        /**
        public Task<Produto> getById(int id)
        {
            return new Produto();
        }
        **/


        public Task<List<Produto>> GetAll()
        {
            return _conn.Table<Produto>().ToListAsync();
        }

        /**
        public Task<int> Delete(int id)
        {
            return _conn.Table<Produto>().DeleteAsync(i => i.Id == id);
        }
        **/
    }
}
