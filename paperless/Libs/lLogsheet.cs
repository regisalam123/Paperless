using paperless.Data.Controllers;
using paperless.Data.Models;
using paperless.Manager;
using Npgsql;
using System.Data;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Metrics;

namespace paperless.Libs
{
    public class lLogsheet
    {
        private lDbConn dbconn = new lDbConn();
        private BaseController bc = new BaseController();
        private readonly IWebHostEnvironment environment;
        internal List<dynamic> ReadLogsheet(String idl)
        {
            var cstrname = dbconn.constringName("idccore");
            var split = "||";
            var schema = "public";

            string spname = "getlogsheet";
            string p1 = "@idl" + split + idl + split + "s";

            return bc.ExecSqlWithReturnCustomSplit(cstrname, split, schema, spname, p1);
        }
        internal List<dynamic> ReadItemunit(String idl)
        {
            var cstrname = dbconn.constringName("idccore");
            var split = "||";
            var schema = "public";

            string spname = "getitemunit";
            string p1 = "@idl" + split + idl + split + "s";

            return bc.ExecSqlWithReturnCustomSplit(cstrname, split, schema, spname, p1);
        }
        internal List<dynamic> ReadItemunitm(String idl)
        {
            var cstrname = dbconn.constringName("idccore");
            var split = "||";
            var schema = "public";

            string spname = "getitemunitm";
            string p1 = "@idl" + split + idl + split + "s";

            return bc.ExecSqlWithReturnCustomSplit(cstrname, split, schema, spname, p1);
        }

        internal List<dynamic> ReadLogsheetdetail(String idl)
        {
            var cstrname = dbconn.constringName("idccore");
            var split = "||";
            var schema = "public";

            string spname = "getlogsheetdetail";
            string p1 = "@idl" + split + idl + split + "s";

            return bc.ExecSqlWithReturnCustomSplit(cstrname, split, schema, spname, p1);
        }

        public string InsertLogsheet0(InputLogsheet0 ipl)
        {
            string strout = "";
            string cstrname = dbconn.constringName("idccore");
            var conn = dbconn.constringList(cstrname);
            NpgsqlTransaction trans;
            Npgsql.NpgsqlConnection connection = new Npgsql.NpgsqlConnection(conn);
            connection.Open();
            trans = connection.BeginTransaction();
            try
            {
                NpgsqlCommand cmd = new NpgsqlCommand("public.inputlogsheet0", connection, trans);
                cmd.Parameters.AddWithValue("p_id", ipl.Id.ToString());
                cmd.Parameters.AddWithValue("p_idjam", ipl.IdJam.ToString());
                cmd.Parameters.AddWithValue("p_logid", ipl.LogId.ToString());
                cmd.Parameters.AddWithValue("p_logiddescr", ipl.LogIddescr.ToString());
                cmd.Parameters.AddWithValue("p_maker", ipl.Maker.ToString());
                cmd.Parameters.AddWithValue("p_itemunitid", ipl.ItemUnitid.ToString());
                cmd.Parameters.AddWithValue("p_itemunitiddescr", ipl.ItemUnitiddescr.ToString());
                cmd.Parameters.AddWithValue("p_note", ipl.Note.ToString());
                cmd.Parameters.AddWithValue("p_kondisi", ipl.Kondisi.ToString());

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
                trans.Commit();
                strout = "success";
            }
            catch (Exception ex)
            {
                trans.Rollback();
                strout = ex.Message;
            }
            finally
            {
                if (connection.State.Equals(ConnectionState.Open))
                {
                    connection.Close();
                }
                NpgsqlConnection.ClearPool(connection);
            }
            return strout;
        }
        public string InsertLogsheet1(InputLogsheet0 ipl)
        {
            string strout = "";
            string cstrname = dbconn.constringName("idccore");
            var conn = dbconn.constringList(cstrname);
            NpgsqlTransaction trans;
            Npgsql.NpgsqlConnection connection = new Npgsql.NpgsqlConnection(conn);
            connection.Open();
            trans = connection.BeginTransaction();
            try
            {

                foreach (var row in ipl.Listlog1)
                {
                    NpgsqlCommand cmd2 = new NpgsqlCommand("public.inputlogsheet1", connection, trans);
                    cmd2.Parameters.AddWithValue("p_parentid", ipl.Id.ToString());
                    cmd2.Parameters.AddWithValue("p_line", row.Line.Value);
                    cmd2.Parameters.AddWithValue("p_uraian", row.Uraian.ToString());
                    cmd2.Parameters.AddWithValue("p_isi", row.Isi.ToString());
                    

                    cmd2.CommandType = CommandType.StoredProcedure;
                    cmd2.ExecuteNonQuery();
                }

                trans.Commit();
                strout = "success";
            }
            catch (Exception ex)
            {
                trans.Rollback();
                strout = ex.Message;
            }
            finally
            {
                if (connection.State.Equals(ConnectionState.Open))
                {
                    connection.Close();
                }
                NpgsqlConnection.ClearPool(connection);
            }
            return strout;
        }


        internal List<dynamic> ReadDatalog(String idtgl,string idlog , string iditem, string idjam)
        {
            var cstrname = dbconn.constringName("idccore");
            var split = "||";
            var schema = "public";

            string spname = "getdatalogsheetn";
            string p1 = "@idtgl" + split + idtgl + split + "dtb";
            string p2 = "@idlog" + split + idlog + split + "s";
            string p3 = "@iditem" + split + iditem + split + "s";
            string p4 = "@idjam" + split + idjam + split + "s";
           

            return bc.ExecSqlWithReturnCustomSplit(cstrname, split, schema, spname, p1,p2,p3,p4);
        }

        internal List<dynamic> Readjam(String id)
        {
            var cstrname = dbconn.constringName("idccore");
            var split = "||";
            var schema = "public";

            string spname = "getdatajam1";
            string p1 = "@id" + split + id + split + "s";
          


            return bc.ExecSqlWithReturnCustomSplit(cstrname, split, schema, spname, p1);
        }











    }

}



