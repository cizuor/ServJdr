using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;


namespace JDR.BDD
{
    class Connection
    {
        private static Connection connection = null;
        private NpgsqlConnection conn;


        private String serveur = "127.0.0.1";
        private String port = "5432";
        private String user = "postgres";
        private String pass = "circet";
        private String dbName = "JDR";



        public static Connection GetConnection()
        {
            if (connection == null)
            {
                connection = new Connection();
            }
            return connection;
        }


        private Connection()
        {
            string connstring = String.Format("Server={0};Port={1};" +
                    "User Id={2};Password={3};Database={4};",
                    serveur, port, user,
                    pass, dbName);
            conn = new NpgsqlConnection(connstring);
            
        }

        public DataTable GetTableSql(String sql, out DataSet ds, out NpgsqlDataAdapter da)
        {
            conn.Open();
            ds = null;
            da = null;
            try
            {
                ds = new DataSet();
                da = new NpgsqlDataAdapter(sql, conn);
                ds.Reset();
                da.Fill(ds);
                conn.Close();
                return ds.Tables[0];
            }
            catch
            {
                conn.Close();
                return null;
            }
            
        }


        public Boolean ExecuteQuery(String sql, out DataSet ds, out NpgsqlDataAdapter da)
        {
            conn.Open();
            ds = null;
            da = null;
            try
            {
                ds = new DataSet();
                da = new NpgsqlDataAdapter(sql, conn);
                ds.Reset();
                da.Fill(ds);
                conn.Close();
                return true;
            }
            catch(Exception ex)
            {
                conn.Close();
                return false;
            }

        }


        public int SubmitDataSetChanges(NpgsqlDataAdapter m_DataAdapter , DataSet m_DataSet)
        {
            conn.Open();
            NpgsqlCommandBuilder cb = new NpgsqlCommandBuilder(m_DataAdapter as NpgsqlDataAdapter);
            m_DataAdapter.InsertCommand = cb.GetInsertCommand();
            m_DataAdapter.DeleteCommand = cb.GetDeleteCommand();
            m_DataAdapter.UpdateCommand = cb.GetUpdateCommand();
            DataTable table = m_DataSet.Tables[0];
            int response = m_DataAdapter.Update(table);
            conn.Close();
            return response;
        }



        public DataTable GetTable(String nomTable, out DataSet ds, out NpgsqlDataAdapter da )
        {
            String sql = "select * from bdd." + nomTable;
            ds = null;
            da = null;
            return this.GetTableSql(sql, out ds, out da);
        }

        public DataTable GetLigneFromTable(String nomTable,int id, out DataSet ds, out NpgsqlDataAdapter da)
        {
            String sql = "select * from bdd." + nomTable + " where id = "+id ;
            ds = null;
            da = null;
            return this.GetTableSql(sql, out ds, out da);
        }

        /*public DataTable GetStatFrom(String nomTable,int id, out DataSet ds, out NpgsqlDataAdapter da)
        {
            String sql = "select * from bdd." + nomTable + " join bdd.stat" + nomTable + " on " + nomTable +".id = stat" + nomTable + ".id_" + nomTable + " where id = "+id;
            ds = null;
            da = null;
            return this.GetTableSql(sql, out ds, out da);
        }*/

        public DataTable GetStatFrom(String nomTable, int id, out DataSet ds, out NpgsqlDataAdapter da)
        {
            String sql = "select * from bdd.stat" + nomTable + " where id_"+ nomTable + " = " + id;
            ds = null;
            da = null;
            return this.GetTableSql(sql, out ds, out da);
        }

        public DataTable GetStatCalculé(int id, out DataSet ds, out NpgsqlDataAdapter da)
        {
            String sql = "select * from bdd.statcalculer  where id_stat = " + id;
            ds = null;
            da = null;
            return this.GetTableSql(sql, out ds, out da);
        }


        public DataTable GetJointureFrom(String nomTable1, String nomTable2, int id, out DataSet ds, out NpgsqlDataAdapter da)
        {
            String sql = "select * from bdd." + nomTable2 + nomTable1+ " join bdd."+ nomTable2 +"  on " + nomTable2 + ".id = "+ nomTable2 + nomTable1 + ".id_" + nomTable2 + " where id_"+ nomTable1 + " = " + id;
            ds = null;
            da = null;
            return this.GetTableSql(sql, out ds, out da);
        }

    }
}
