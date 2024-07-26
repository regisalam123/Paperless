using paperless.Data.Controllers;
using paperless.Data.Models;
using paperless.Manager;
using Npgsql;
using System.Data;
using Microsoft.AspNetCore.Mvc;

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
        public string InsertLogsheet1(InputLogsheet1 ipl)
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
                NpgsqlCommand cmd = new NpgsqlCommand("public.inputlogsheet1", connection, trans);
                cmd.Parameters.AddWithValue("p_parentid", ipl.ParentId.ToString());
                cmd.Parameters.AddWithValue("p_line", ipl.Line.Value);
                cmd.Parameters.AddWithValue("p_uraian", ipl.Uraian.ToString());
                cmd.Parameters.AddWithValue("p_isi", ipl.Isi.ToString());
                cmd.Parameters.AddWithValue("p_keterangan", ipl.Keterangan.ToString());
          
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

        internal List<dynamic> ReadDatalog(String idtgl,string idjam, string maker)
        {
            var cstrname = dbconn.constringName("idccore");
            var split = "||";
            var schema = "public";

            string spname = "getdatalogsheet";
            string p1 = "@idtgl" + split + idtgl + split + "dtb";
            string p2 = "@idjam" + split + idjam + split + "s";
            string p3 = "@maker" + split + maker + split + "s";

            return bc.ExecSqlWithReturnCustomSplit(cstrname, split, schema, spname, p1,p2,p3);
        }










    }

}



