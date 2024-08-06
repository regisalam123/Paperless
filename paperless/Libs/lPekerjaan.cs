using paperless.Data.Controllers;
using paperless.Data.Models;
using paperless.Manager;
using Npgsql;
using System.Data;
using Microsoft.AspNetCore.Mvc;


namespace paperless.Libs
{
    public class lPekerjaan
    {
        private lDbConn dbconn = new lDbConn();
        private BaseController bc = new BaseController();
        private readonly IWebHostEnvironment environment;
        internal List<dynamic> ReadPekerjaan(String id_pekerjaan)
        {
            var cstrname = dbconn.constringName("idccore");
            var split = "||";
            var schema = "public";

            string spname = "getpekerjaan";
            string p1 = "@id_pekerjaan" + split + id_pekerjaan + split + "s";

            return bc.ExecSqlWithReturnCustomSplit(cstrname, split, schema, spname, p1);
        }
       
            internal List<dynamic> ReadFilter(String tanggalaw , string tanggalak)
            {
                var cstrname = dbconn.constringName("idccore");
                var split = "||";
                var schema = "public";

                string spname = "getfilter";
                string p1 = "@tanggalaw" + split + tanggalaw + split + "dtb";
                string p2 = "@tanggalak" + split + tanggalak + split + "dtb";

                return bc.ExecSqlWithReturnCustomSplit(cstrname, split, schema, spname, p1,p2);
            }

     
        internal List<dynamic> ReadPekerjaanUpdate(String id_pekerjaan)
        {
            var cstrname = dbconn.constringName("idccore");
            var split = "||";
            var schema = "public";

            string spname = "getpekerjaan1u";
            string p1 = "@id_pekerjaan" + split + id_pekerjaan + split + "s";

            return bc.ExecSqlWithReturnCustomSplit(cstrname, split, schema, spname, p1);
        }

        internal List<dynamic> ReadCeklistPekerjaan(String id_pekerjaan, String is_check)
        {
            var cstrname = dbconn.constringName("idccore");
            var split = "||";
            var schema = "public";

            string spname = "getceklist1";
            string p1 = "@id_pekerjaan" + split + id_pekerjaan + split + "s";
            string p2 = "@is_check" + split + is_check + split + "s";

            return bc.ExecSqlWithReturnCustomSplit(cstrname, split, schema, spname, p1,p2);
        }

        internal List<dynamic> Readjob(String id_pekerjaan)
        {
            var cstrname = dbconn.constringName("idccore");
            var split = "||";
            var schema = "public";

            string spname = "getjob";
            string p1 = "@id_pekerjaan" + split + id_pekerjaan + split + "s";
          
            return bc.ExecSqlWithReturnCustomSplit(cstrname, split, schema, spname, p1);
        }
        internal List<dynamic> Deletejoball(String id_trx)
        {
            var cstrname = dbconn.constringName("idccore");
            var split = "||";
            var schema = "public";

            string spname = "deletejoball";
            string p1 = "@id_trx" + split + id_trx + split + "s";

            return bc.ExecSqlWithReturnCustomSplit(cstrname, split, schema, spname, p1);
        }

        internal List<dynamic> Deletejob2(String id_trx2)
        {
            var cstrname = dbconn.constringName("idccore");
            var split = "||";
            var schema = "public";

            string spname = "deletejob2";
            string p1 = "@id_trx2" + split + id_trx2 + split + "s";

            return bc.ExecSqlWithReturnCustomSplit(cstrname, split, schema, spname, p1);
        }
        internal List<dynamic> Deletejob3(String id_trx3)
        {
            var cstrname = dbconn.constringName("idccore");
            var split = "||";
            var schema = "public";

            string spname = "deletejob3";
            string p1 = "@id_trx3" + split + id_trx3 + split + "s";

            return bc.ExecSqlWithReturnCustomSplit(cstrname, split, schema, spname, p1);
        }

        internal List<dynamic> Deletejob2temp(String id_trx2)
        {
            var cstrname = dbconn.constringName("idccore");
            var split = "||";
            var schema = "public";

            string spname = "deletejob2temp";
            string p1 = "@id_trx2" + split + id_trx2 + split + "s";

            return bc.ExecSqlWithReturnCustomSplit(cstrname, split, schema, spname, p1);
        }

        internal List<dynamic> Deletejob3temp(String id_trx3)
        {
            var cstrname = dbconn.constringName("idccore");
            var split = "||";
            var schema = "public";

            string spname = "deletejob3temp";
            string p1 = "@id_trx3" + split + id_trx3 + split + "s";

            return bc.ExecSqlWithReturnCustomSplit(cstrname, split, schema, spname, p1);
        }




        internal List<dynamic> ReadAllCeklist(String id_user, String id_pekerjaan, String is_check)
        {
            var cstrname = dbconn.constringName("idccore");
            var split = "||";
            var schema = "public";

            string spname = "getallceklist1";
            string p1 = "@id_user" + split + id_user + split + "s";
            string p2 = "@id_pekerjaan" + split + id_pekerjaan + split + "s";
            string p3 = "@is_check" + split + is_check + split + "s";

            return bc.ExecSqlWithReturnCustomSplit(cstrname, split, schema, spname, p1, p2,p3);
        }


        public string InsertCeklistPekerjaannonck(Pekerjaannonck pck)
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
                NpgsqlCommand cmd = new NpgsqlCommand("public.inputceklist1old", connection, trans);
                cmd.Parameters.AddWithValue("p_id", pck.Id.ToString());
                cmd.Parameters.AddWithValue("p_pekerjaanid", pck.PekerjaanId.ToString());
                cmd.Parameters.AddWithValue("p_pekerjaaniddescr", pck.PekerjaanIdDescr.ToString());
                cmd.Parameters.AddWithValue("p_maker", pck.Maker.ToString());
                cmd.Parameters.AddWithValue("p_foto", pck.Foto.ToString());
                cmd.Parameters.AddWithValue("p_itemunitid", pck.ItemUnitid.ToString());
                cmd.Parameters.AddWithValue("p_itemunitiddescr", pck.ItemUnitiddescr.ToString());


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


        [NonAction]
      

        public string InsertCeklistPekerjaan1(Pekerjaanck2 pck)
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
                NpgsqlCommand cmd = new NpgsqlCommand("public.inputceklist1", connection, trans);

              

                cmd.Parameters.AddWithValue("p_id", pck.Id.ToString());
                cmd.Parameters.AddWithValue("p_pekerjaanid", pck.PekerjaanId.ToString());
                cmd.Parameters.AddWithValue("p_pekerjaaniddescr", pck.PekerjaanIdDescr.ToString());
                cmd.Parameters.AddWithValue("p_maker", pck.Maker.ToString());
                cmd.Parameters.AddWithValue("p_foto",pck.Id.ToString()+"_C01.jpeg");
                cmd.Parameters.AddWithValue("p_foto2",pck.Id.ToString() + "_C02.jpeg");
                cmd.Parameters.AddWithValue("p_itemunitid", pck.ItemUnitid.ToString());
                cmd.Parameters.AddWithValue("p_itemunitiddescr", pck.ItemUnitiddescr.ToString());

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

        public string InsertCeklistPekerjaan2(Pekerjaanck2 pck)
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
             
                foreach (var row in pck.ListCeklist)
                {
                    NpgsqlCommand cmd2 = new NpgsqlCommand("public.inputceklist2", connection, trans);
                    cmd2.Parameters.AddWithValue("p_parentid", pck.Id.ToString());
                    cmd2.Parameters.AddWithValue("p_line", row.Line.Value);
                    cmd2.Parameters.AddWithValue("p_idmasterck", row.IdMasterCk.ToString());
                    cmd2.Parameters.AddWithValue("p_descrmasterck", row.DescrMasterCk.ToString());
                    cmd2.Parameters.AddWithValue("p_status", row.Status.ToString());

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


        internal List<dynamic> ReadFormPekerjaan(String id)
        {
            var cstrname = dbconn.constringName("idccore");
            var split = "||";
            var schema = "public";

            string spname = "getformpekerjaan1";
            string p1 = "@id" + split + id + split + "s";

            return bc.ExecSqlWithReturnCustomSplit(cstrname, split, schema, spname, p1);
        }
        internal List<dynamic> LoadDataLama2 (String id_trx2)
        {
            var cstrname = dbconn.constringName("idccore");
            var split = "||";
            var schema = "public";

            string spname = "loaddatalama2";
            string p1 = "@id_trx2" + split + id_trx2 + split + "s";

            return bc.ExecSqlWithReturnCustomSplit(cstrname, split, schema, spname, p1);
        }
        internal List<dynamic> LoadDataLama3(String id_trx3)
        {
            var cstrname = dbconn.constringName("idccore");
            var split = "||";
            var schema = "public";

            string spname = "loaddatalama3";
            string p1 = "@id_trx3" + split + id_trx3 + split + "s";

            return bc.ExecSqlWithReturnCustomSplit(cstrname, split, schema, spname, p1);
        }

        internal List<dynamic> LoadDataTemp2(String id_trx2)
        {
            var cstrname = dbconn.constringName("idccore");
            var split = "||";
            var schema = "public";

            string spname = "loaddatatemp2";
            string p1 = "@id_trx2" + split + id_trx2 + split + "s";

            return bc.ExecSqlWithReturnCustomSplit(cstrname, split, schema, spname, p1);
        }
        internal List<dynamic> LoadDataTemp3(String id_trx3)
        {
            var cstrname = dbconn.constringName("idccore");
            var split = "||";
            var schema = "public";

            string spname = "loaddatatemp3";
            string p1 = "@id_trx3" + split + id_trx3 + split + "s";

            return bc.ExecSqlWithReturnCustomSplit(cstrname, split, schema, spname, p1);
        }



        internal List<dynamic> ReadPendingPekerjaan(String id)
        {
            var cstrname = dbconn.constringName("idccore");
            var split = "||";
            var schema = "public";

            string spname = "getpendingjob";
            string p1 = "@id" + split + id + split + "s";

            return bc.ExecSqlWithReturnCustomSplit(cstrname, split, schema, spname, p1);
        }


        internal List<dynamic> ReadFormCeklist(String id)
        {
            var cstrname = dbconn.constringName("idccore");
            var split = "||";
            var schema = "public";

            string spname = "getformceklist1";
            string p1 = "@id" + split + id + split + "s";

            return bc.ExecSqlWithReturnCustomSplit(cstrname, split, schema, spname, p1);
        }

        internal List<dynamic> ReadAllFormCeklist(String id, String id_pekerjaan, String uraian)
        {
            var cstrname = dbconn.constringName("idccore");
            var split = "||";
            var schema = "public";

            string spname = "getformceklist2";
            string p1 = "@id" + split + id + split + "s";
            string p2 = "@id_pekerjaan" + split + id_pekerjaan + split + "s";
            string p3 = "@uraian" + split + uraian + split + "s";

            return bc.ExecSqlWithReturnCustomSplit(cstrname, split, schema, spname, p1, p2, p3);
        }
        
        public string InsertCeklistFormPekerjaan1(FormPekerjaanck2 fpck)
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
                NpgsqlCommand cmd = new NpgsqlCommand("public.inputformceklist1", connection, trans);
                cmd.Parameters.AddWithValue("p_id", fpck.Id.ToString());
                cmd.Parameters.AddWithValue("p_pekerjaanid", fpck.PekerjaanId.ToString());
                cmd.Parameters.AddWithValue("p_uraianid", fpck.UraianId.ToString());
                cmd.Parameters.AddWithValue("p_uraiandescr", fpck.UraianDescr.ToString());
                cmd.Parameters.AddWithValue("p_status", fpck.Status.ToString());
                cmd.Parameters.AddWithValue("p_foto3", fpck.Id.ToString() + "_P01.jpeg");
                cmd.Parameters.AddWithValue("p_foto4", fpck.Id.ToString() + "_P02.jpeg");
                cmd.Parameters.AddWithValue("p_foto5", fpck.Id.ToString() + "_P03.jpeg");

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


        public string SaveCeklistFormPekerjaan1(FormPekerjaanck2 fpck)
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
                NpgsqlCommand cmd = new NpgsqlCommand("public.saveformceklist1", connection, trans);
                cmd.Parameters.AddWithValue("p_id", fpck.Id.ToString());
                cmd.Parameters.AddWithValue("p_pekerjaanid", fpck.PekerjaanId.ToString());
                cmd.Parameters.AddWithValue("p_uraianid", fpck.UraianId.ToString());
                cmd.Parameters.AddWithValue("p_uraiandescr", fpck.UraianDescr.ToString());
                cmd.Parameters.AddWithValue("p_status", fpck.Status.ToString());
                cmd.Parameters.AddWithValue("p_foto3", fpck.Id.ToString() + "_P01.jpeg");
                cmd.Parameters.AddWithValue("p_foto4", fpck.Id.ToString() + "_P02.jpeg");
                cmd.Parameters.AddWithValue("p_foto5", fpck.Id.ToString() + "_P03.jpeg");

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




        public string InsertCeklistFormPekerjaan2(FormPekerjaanck2 fpck)
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

                foreach (var row in fpck.Kondisi)
                {
                    NpgsqlCommand cmd2 = new NpgsqlCommand("public.inputformceklist2", connection, trans);
                    cmd2.Parameters.AddWithValue("p_parentid", fpck.Id.ToString());
                    cmd2.Parameters.AddWithValue("p_itemid", row.ItemId.ToString());
                    cmd2.Parameters.AddWithValue("p_itemdescr", row.ItemDescr.ToString());
                    cmd2.Parameters.AddWithValue("p_line", row.Line.Value);
                    cmd2.Parameters.AddWithValue("p_baik", row.Baik.ToString());
                    cmd2.Parameters.AddWithValue("p_kurang_baik", row.KurangBaik.ToString());
                    cmd2.Parameters.AddWithValue("p_uraianid", row.UraianId.ToString());
                    cmd2.Parameters.AddWithValue("p_uraianiddescr", row.UraianIddescr.ToString());
                    cmd2.Parameters.AddWithValue("p_cid", row.CId.ToString());
                    cmd2.Parameters.AddWithValue("p_cdescr", row.CDescr.ToString());
                    cmd2.Parameters.AddWithValue("p_cline", row.CLine.Value);
                    cmd2.Parameters.AddWithValue("p_note", row.Note.ToString());



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

        public string SaveCeklistFormPekerjaan2(FormPekerjaanck2 fpck)
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

                foreach (var row in fpck.Kondisi)
                {
                    NpgsqlCommand cmd2 = new NpgsqlCommand("public.saveformceklist2", connection, trans);
                    cmd2.Parameters.AddWithValue("p_parentid", fpck.Id.ToString());
                    cmd2.Parameters.AddWithValue("p_itemid", row.ItemId.ToString());
                    cmd2.Parameters.AddWithValue("p_itemdescr", row.ItemDescr.ToString());
                    cmd2.Parameters.AddWithValue("p_line", row.Line.Value);
                    cmd2.Parameters.AddWithValue("p_baik", row.Baik.ToString());
                    cmd2.Parameters.AddWithValue("p_kurang_baik", row.KurangBaik.ToString());
                    cmd2.Parameters.AddWithValue("p_uraianid", row.UraianId.ToString());
                    cmd2.Parameters.AddWithValue("p_uraianiddescr", row.UraianIddescr.ToString());
                    cmd2.Parameters.AddWithValue("p_cid", row.CId.ToString());
                    cmd2.Parameters.AddWithValue("p_cdescr", row.CDescr.ToString());
                    cmd2.Parameters.AddWithValue("p_cline", row.CLine.Value);
                    cmd2.Parameters.AddWithValue("p_note", row.Note.ToString());



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






        public string UpdateCeklistFormPekerjaan1(FormPekerjaanck2u fpcku)
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
                NpgsqlCommand cmd = new NpgsqlCommand("public.updateformceklist1", connection, trans);
                cmd.Parameters.AddWithValue("p_id", fpcku.Id.ToString());
                cmd.Parameters.AddWithValue("p_pekerjaanid", fpcku.PekerjaanId.ToString());
                cmd.Parameters.AddWithValue("p_uraianid", fpcku.UraianId.ToString());
                cmd.Parameters.AddWithValue("p_uraiandescr", fpcku.UraianDescr.ToString());
                cmd.Parameters.AddWithValue("p_status", fpcku.Status.ToString());
                cmd.Parameters.AddWithValue("p_foto3", fpcku.Id.ToString() + "_P01.jpeg");
                cmd.Parameters.AddWithValue("p_foto4", fpcku.Id.ToString() + "_P02.jpeg");
                cmd.Parameters.AddWithValue("p_foto5", fpcku.Id.ToString() + "_P03.jpeg");
                cmd.Parameters.AddWithValue("p_updateby", fpcku.Updateby.ToString());

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

        public string UpdateCeklistFormPekerjaan2(FormPekerjaanck2u fpcku)
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

                foreach (var row in fpcku.Kondisi)
                {
                    NpgsqlCommand cmd2 = new NpgsqlCommand("public.updateformceklist2", connection, trans);
                    cmd2.Parameters.AddWithValue("p_parentid", fpcku.Id.ToString());
                    cmd2.Parameters.AddWithValue("p_itemid", row.ItemId.ToString());
                    cmd2.Parameters.AddWithValue("p_itemdescr", row.ItemDescr.ToString());
                    cmd2.Parameters.AddWithValue("p_line", row.Line.Value);
                    cmd2.Parameters.AddWithValue("p_baik", row.Baik.ToString());
                    cmd2.Parameters.AddWithValue("p_kurang_baik", row.KurangBaik.ToString());
                    cmd2.Parameters.AddWithValue("p_uraianid", row.UraianId.ToString());
                    cmd2.Parameters.AddWithValue("p_uraianiddescr", row.UraianIddescr.ToString());
                    cmd2.Parameters.AddWithValue("p_cid", row.CId.ToString());
                    cmd2.Parameters.AddWithValue("p_cdescr", row.CDescr.ToString());
                    cmd2.Parameters.AddWithValue("p_cline", row.CLine.Value);
                    cmd2.Parameters.AddWithValue("p_note", row.Note.ToString());



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

    }
}
