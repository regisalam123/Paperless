using paperless.Data.Controllers;
using paperless.Data.Models;
using paperless.Manager;
using Npgsql;
using System.Data;

namespace paperless.Libs
{
    public class lApproval
    {
        private lDbConn dbconn = new lDbConn();
        private BaseController bc = new BaseController();

        internal List<dynamic> ReadApproval(String id)
        {
            var cstrname = dbconn.constringName("idccore");
            var split = "||";
            var schema = "public";

            string spname = "getapprovallist1";
            string p1 = "@id" + split + id + split + "s";

            return bc.ExecSqlWithReturnCustomSplit(cstrname, split, schema, spname, p1);
        }

        internal List<dynamic> ReadApprovalr(String id)
        {
            var cstrname = dbconn.constringName("idccore");
            var split = "||";
            var schema = "public";

            string spname = "getapprovallistr";
            string p1 = "@id" + split + id + split + "s";

            return bc.ExecSqlWithReturnCustomSplit(cstrname, split, schema, spname, p1);
        }

        internal List<dynamic> ReadDetailR(String id)
        {
            var cstrname = dbconn.constringName("idccore");
            var split = "||";
            var schema = "public";

            string spname = "getapprovalreject1";
            string p1 = "@id" + split + id + split + "s";

            return bc.ExecSqlWithReturnCustomSplit(cstrname, split, schema, spname, p1);
        }

        internal List<dynamic> ReadDetailCk(String id)
        {
            var cstrname = dbconn.constringName("idccore");
            var split = "||";
            var schema = "public";

            string spname = "getapprovalck1";
            string p1 = "@id" + split + id + split + "s";

            return bc.ExecSqlWithReturnCustomSplit(cstrname, split, schema, spname, p1);
        }

        public string InsertApprovalCk(ApprovalCk apr)
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
                NpgsqlCommand cmd = new NpgsqlCommand("public.submitapproval1", connection, trans);
                cmd.Parameters.AddWithValue("p_id", apr.Id.ToString());
                cmd.Parameters.AddWithValue("p_approval_ck", apr.Approval.ToString());
                cmd.Parameters.AddWithValue("p_note", apr.Note.ToString());
                cmd.Parameters.AddWithValue("p_approveby", apr.Approveby.ToString());
                cmd.Parameters.AddWithValue("p_rejectby", apr.Rejectby.ToString());
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

        internal List<dynamic> ReadDetailJob(String id)
        {
            var cstrname = dbconn.constringName("idccore");
            var split = "||";
            var schema = "public";

            string spname = "getapprovaljob1";
            string p1 = "@id" + split + id + split + "s";

            return bc.ExecSqlWithReturnCustomSplit(cstrname, split, schema, spname, p1);
        }

        public string InsertApprovalJob(ApprovalJob apr)
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
                NpgsqlCommand cmd = new NpgsqlCommand("public.submitapproval2", connection, trans);
                cmd.Parameters.AddWithValue("p_id", apr.Id.ToString());
                cmd.Parameters.AddWithValue("p_approval_job", apr.Approval.ToString());


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
        internal List<dynamic> ReadApprovalJob(String id)
        {
            var cstrname = dbconn.constringName("idccore");
            var split = "||";
            var schema = "public";

            string spname = "getapprovaljob";
            string p1 = "@id" + split + id + split + "s";

            return bc.ExecSqlWithReturnCustomSplit(cstrname, split, schema, spname, p1);
        }

        internal List<dynamic> ReadApprovalIsactive(String isactive)
        {
            var cstrname = dbconn.constringName("idccore");
            var split = "||";
            var schema = "public";

            string spname = "getapprovalisactive";
            string p1 = "@isactive" + split + isactive + split + "s";

            return bc.ExecSqlWithReturnCustomSplit(cstrname, split, schema, spname, p1);
        }


        internal List<dynamic> ReadDetailCkM(String id, String appck, String appj)
        {
            var cstrname = dbconn.constringName("idccore");
            var split = "||";
            var schema = "public";

            string spname = "getapprovalckm";
            string p1 = "@id" + split + id + split + "s";
            string p2 = "@appck" + split + appck + split + "s";
            string p3 = "@appj" + split + appj + split + "s";

            return bc.ExecSqlWithReturnCustomSplit(cstrname, split, schema, spname, p1,p2,p3);
        }

        public string InsertApprovalIsA (ApprovalIsA apri)
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
                NpgsqlCommand cmd = new NpgsqlCommand("public.submitapprovalis", connection, trans);
                cmd.Parameters.AddWithValue("p_userid", apri.UserId.ToString());
                cmd.Parameters.AddWithValue("p_isactive", apri.IsActive.ToString());


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
