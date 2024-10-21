using Npgsql;
using paperless.Data.Controllers;
using paperless.Data.Models;
using System.Data;

namespace paperless.Libs
{
    public class lPekerjaanmod
    {

        private lDbConn dbconn = new lDbConn();
        private BaseController bc = new BaseController();
        private readonly IWebHostEnvironment environment;
        internal List<dynamic> ReadPekerjaanmod(String idm)
        {
            var cstrname = dbconn.constringName("idccore");
            var split = "||";
            var schema = "public";

            string spname = "getpekerjaanmod";
            string p1 = "@idm" + split + idm + split + "s";

            return bc.ExecSqlWithReturnCustomSplit(cstrname, split, schema, spname, p1);
        }

        internal List<dynamic> ReadPekerjaanmoddetail(String idm)
        {
            var cstrname = dbconn.constringName("idccore");
            var split = "||";
            var schema = "public";

            string spname = "getmoddetail";
            string p1 = "@idm" + split + idm + split + "s";

            return bc.ExecSqlWithReturnCustomSplit(cstrname, split, schema, spname, p1);
        }
  
        public string Insertmod0(InputMod0 ipl)
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
                NpgsqlCommand cmd = new NpgsqlCommand("public.inputmod0", connection, trans);
                cmd.Parameters.AddWithValue("p_idm", ipl.Idm.ToString());
                cmd.Parameters.AddWithValue("p_itemid0", ipl.Itemid0.ToString());
                cmd.Parameters.AddWithValue("p_unit", ipl.Unit.ToString());
                cmd.Parameters.AddWithValue("p_lantai", ipl.Lantai.ToString());
                cmd.Parameters.AddWithValue("p_createby", ipl.CreateBy.ToString());
                cmd.Parameters.AddWithValue("p_updateby", ipl.UpdateBy.ToString());
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

        public string Insertmod1(InputMod0 ipl)
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

                foreach (var row in ipl.Listmod1)
                {
                    NpgsqlCommand cmd2 = new NpgsqlCommand("public.inputmod1", connection, trans);
                    cmd2.Parameters.AddWithValue("p_parentid", ipl.Idm.ToString());
                    cmd2.Parameters.AddWithValue("p_itemid0", ipl.Itemid0.ToString());
                    cmd2.Parameters.AddWithValue("p_itemid1", row.Itemid1.ToString());
                    cmd2.Parameters.AddWithValue("p_itemid1descr", row.Itemid1Descr.ToString());
                    cmd2.Parameters.AddWithValue("p_keadaan", row.Keadaan.ToString());
                    cmd2.Parameters.AddWithValue("p_catatan", row.Catatan.ToString());


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
        internal List<dynamic> ReadFiltermod(String tanggalaw, string tanggalak)
        {
            var cstrname = dbconn.constringName("idccore");
            var split = "||";
            var schema = "public";

            string spname = "getfiltermod";
            string p1 = "@tanggalaw" + split + tanggalaw + split + "dtb";
            string p2 = "@tanggalak" + split + tanggalak + split + "dtb";

            return bc.ExecSqlWithReturnCustomSplit(cstrname, split, schema, spname, p1, p2);
        }
        internal List<dynamic> ReadFiltertrxmod(String idtrx)
        {
            var cstrname = dbconn.constringName("idccore");
            var split = "||";
            var schema = "public";

            string spname = "getfiltertrxmod";
            string p1 = "@idtrx" + split + idtrx + split + "s";
           /* string p2 = "@tanggal" + split + tanggal + split + "dtb";
            string p3 = "@createby" + split + createby + split + "s";
*/
            return bc.ExecSqlWithReturnCustomSplit(cstrname, split, schema, spname, p1);
        }

        public string Updatemod0(ModUpdate0 ipl)
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
                NpgsqlCommand cmd = new NpgsqlCommand("public.updatemod", connection, trans);
                cmd.Parameters.AddWithValue("p_idm", ipl.Idm.ToString());
                cmd.Parameters.AddWithValue("p_itemid0", ipl.Itemid0.ToString());
                cmd.Parameters.AddWithValue("p_unit", ipl.Unit.ToString());
                cmd.Parameters.AddWithValue("p_lantai", ipl.Lantai.ToString());
                cmd.Parameters.AddWithValue("p_updateby", ipl.UpdateBy.ToString());
                cmd.Parameters.AddWithValue("p_note", ipl.Note.ToString());
                cmd.Parameters.AddWithValue("p_parentid", ipl.Idm.ToString());
                cmd.Parameters.AddWithValue("p_itemid1", ipl.Itemid1.ToString());
                cmd.Parameters.AddWithValue("p_itemid1descr", ipl.Itemid1Descr.ToString());
                cmd.Parameters.AddWithValue("p_keadaan", ipl.Keadaan.ToString());
                cmd.Parameters.AddWithValue("p_catatan", ipl.Catatan.ToString());


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

        public string Insertsessionmod(ModSession ipl)
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
                NpgsqlCommand cmd = new NpgsqlCommand("public.inputsessionmod", connection, trans);
                cmd.Parameters.AddWithValue("p_userid", ipl.UserId.ToString());
                cmd.Parameters.AddWithValue("p_nama", ipl.Nama.ToString());
                cmd.Parameters.AddWithValue("p_peranan", ipl.Peranan.ToString());
                cmd.Parameters.AddWithValue("p_eticket", ipl.Eticket.ToString());
                cmd.Parameters.AddWithValue("p_status", ipl.Status.ToString());
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

        internal List<dynamic> GetSessionmod(String userid, string status)
        {
            var cstrname = dbconn.constringName("idccore");
            var split = "||";
            var schema = "public";

            string spname = "getsessionmod";
            string p1 = "@userid" + split + userid + split + "s";
            string p2 = "@status" + split + status + split + "s";
           
            return bc.ExecSqlWithReturnCustomSplit(cstrname, split, schema, spname, p1, p2);
        }
        public string Updatesessionmod(ModSession ipl)
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
                NpgsqlCommand cmd = new NpgsqlCommand("public.updatesessionmod", connection, trans);
                cmd.Parameters.AddWithValue("p_userid", ipl.UserId.ToString());
                cmd.Parameters.AddWithValue("p_nama", ipl.Nama.ToString());
                cmd.Parameters.AddWithValue("p_peranan", ipl.Peranan.ToString());
                cmd.Parameters.AddWithValue("p_eticket", ipl.Eticket.ToString());
                cmd.Parameters.AddWithValue("p_status", ipl.Status.ToString());
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







    }
}
