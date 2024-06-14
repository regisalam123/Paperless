using paperless.Data.Models;
using paperless.Manager;
using Npgsql;
using System.Data;
using paperless.Data.Controllers;

namespace paperless.Libs
{
    public class lUser
    {
        private lDbConn dbconn = new lDbConn();
        private BaseController bc = new BaseController();


        internal List<dynamic> ReadUser(String iduser)
        {
            var cstrname = dbconn.constringName("idccore");
            var split = "||";
            var schema = "public";

            string spname = "getuser";
            string p1 = "@iduser" + split + iduser + split + "s";

            return bc.ExecSqlWithReturnCustomSplit(cstrname, split, schema, spname, p1);
        }

        internal List<dynamic> ReadUser2(String iduser, String idpwd)
        {
            var cstrname = dbconn.constringName("idccore");
            var split = "||";
            var schema = "public";

            string spname = "getuser1";
            string p1 = "@iduser" + split + iduser + split + "s";
            string p2 = "@idpwd" + split + idpwd + split + "s";

            return bc.ExecSqlWithReturnCustomSplit(cstrname, split, schema, spname, p1, p2);
        }

        internal List<dynamic> Read(String userid)
        {
            var cstrname = dbconn.constringName("idccore");
            var split = "||";
            var schema = "public";

            string spname = "readuser";
            string p1 = "@userid" + split + userid + split + "s";

            return bc.ExecSqlWithReturnCustomSplit(cstrname, split, schema, spname, p1);
        }
        internal List<dynamic> ReadId(String idr)
        {
            var cstrname = dbconn.constringName("idccore");
            var split = "||";
            var schema = "public";

            string spname = "readid";
            string p1 = "@idr" + split + idr + split + "s";

            return bc.ExecSqlWithReturnCustomSplit(cstrname, split, schema, spname, p1);
        }


        internal List<dynamic> ResetUsrPwd(String userid)
        {
            var cstrname = dbconn.constringName("idccore");
            var split = "||";
            var schema = "public";

            string spname = "resetusrpwd1";
            string p1 = "@userid" + split + userid + split + "s";

            return bc.ExecSqlWithReturnCustomSplit(cstrname, split, schema, spname, p1);
        }

        public string Insert(Register usr)
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
                NpgsqlCommand cmd = new NpgsqlCommand("public.inputuser", connection, trans);
#pragma warning disable CS8602 // Dereference of a possibly null reference.
#pragma warning disable CS8629 // Nullable value type may be null.
                cmd.Parameters.AddWithValue("p_userid", usr.UserId.ToString());
                cmd.Parameters.AddWithValue("p_passwd", usr.Passwd.ToString());
                cmd.Parameters.AddWithValue("p_name", usr.Name.ToString());
                cmd.Parameters.AddWithValue("p_email", usr.Email.ToString());
                cmd.Parameters.AddWithValue("p_departemen", usr.Departemen.ToString());
                cmd.Parameters.AddWithValue("p_peranan", usr.Peranan.ToString());
                cmd.Parameters.AddWithValue("p_isactive", usr.IsActive.ToString());
#pragma warning restore CS8629 // Nullable value type may be null.
#pragma warning restore CS8602 // Dereference of a possibly null reference.

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
