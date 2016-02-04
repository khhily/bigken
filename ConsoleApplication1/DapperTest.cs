using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Dapper;

namespace ConsoleApplication1
{
    public class DapperTest
    {
        const string GoodsDbConnString = "data source=112.124.16.233;user id=sa;password=hsweimob123;initial catalog=goodsdb;";

        public SqlConnection OpenConnection()
        {
            SqlConnection connection = new SqlConnection(GoodsDbConnString);
            connection.Open();
            return connection;
        }

        public class GoodsModel
        {
            public long Id { get; set; }
            public string Name { get; set; }
        }

        public void TestQuery(long maxId)
        {
            using (var conn = OpenConnection())
            {
                var r = conn.Query<GoodsModel>(@"select top 10 x.id,x.name from dbo.goods_1 x with(nolock) where id>@id;", new { id = maxId });

                foreach (var item in r)
                {
                    Console.WriteLine(item.Id + "\t" + item.Name);
                }
            }
        }
    }
}
