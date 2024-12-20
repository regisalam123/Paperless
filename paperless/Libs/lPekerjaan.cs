﻿using paperless.Data.Controllers;
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
                cmd.Parameters.AddWithValue("p_typejob", pck.TypeJob.ToString());
                cmd.Parameters.AddWithValue("p_idlok", pck.Idlok.ToString());
                cmd.Parameters.AddWithValue("p_descrlok", pck.Descrlok.ToString());


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
                cmd.Parameters.AddWithValue("p_typejob", pck.TypeJob.ToString());
                cmd.Parameters.AddWithValue("p_idlok", pck.Idlok.ToString());
                cmd.Parameters.AddWithValue("p_descrlok", pck.Descrlok.ToString());

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
                cmd.Parameters.AddWithValue("p_itemunitid", fpck.ItemUnitid.ToString());
                cmd.Parameters.AddWithValue("p_itemunitiddescr", fpck.ItemUnitiddescr.ToString());
                cmd.Parameters.AddWithValue("p_idlok", fpck.Idlok.ToString());
                cmd.Parameters.AddWithValue("p_descrlok", fpck.Descrlok.ToString());

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
                cmd.Parameters.AddWithValue("p_itemunitid", fpck.ItemUnitid.ToString());
                cmd.Parameters.AddWithValue("p_itemunitiddescr", fpck.ItemUnitiddescr.ToString());
                cmd.Parameters.AddWithValue("p_idlok", fpck.Idlok.ToString());
                cmd.Parameters.AddWithValue("p_descrlok", fpck.Descrlok.ToString());


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
                    cmd2.Parameters.AddWithValue("p_itemidunit", row.ItemIdunit.ToString());



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
                    cmd2.Parameters.AddWithValue("p_itemidunit", row.ItemIdunit.ToString());



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
                cmd.Parameters.AddWithValue("p_itemunitid", fpcku.ItemUnitid.ToString());
                cmd.Parameters.AddWithValue("p_itemunitiddescr", fpcku.ItemUnitiddescr.ToString());
                cmd.Parameters.AddWithValue("p_idlok", fpcku.Idlok.ToString());
                cmd.Parameters.AddWithValue("p_descrlok", fpcku.Descrlok.ToString());

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
                    cmd2.Parameters.AddWithValue("p_itemidunit", row.ItemIdunit.ToString());



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
        public string InsertHistory(InputHistory iph)
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
                NpgsqlCommand cmd = new NpgsqlCommand("public.inputhistory", connection, trans);
                cmd.Parameters.AddWithValue("p_id", iph.Id.ToString());
                cmd.Parameters.AddWithValue("p_itemunit", iph.ItemUnit.ToString());
                cmd.Parameters.AddWithValue("p_descr", iph.Descr.ToString());
                cmd.Parameters.AddWithValue("p_jumlah", iph.Jumlah.ToString());
                cmd.Parameters.AddWithValue("p_note", iph.Note.ToString());
                cmd.Parameters.AddWithValue("p_maker", iph.Maker.ToString());
                cmd.Parameters.AddWithValue("p_updateby", iph.Updateby.ToString());

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

        public string InsertHistoryn(InputHistoryn iph)
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
                NpgsqlCommand cmd = new NpgsqlCommand("public.inputhistoryn", connection, trans);
                cmd.Parameters.AddWithValue("p_id", iph.Id.ToString());
                cmd.Parameters.AddWithValue("p_itemunit", iph.ItemUnit.ToString());
                cmd.Parameters.AddWithValue("p_itemdescr", iph.ItemDescr.ToString());
                cmd.Parameters.AddWithValue("p_jumlah", iph.Jumlah.ToString());
                cmd.Parameters.AddWithValue("p_note", iph.Note.ToString());
                cmd.Parameters.AddWithValue("p_maker", iph.Maker.ToString());
                cmd.Parameters.AddWithValue("p_approval", iph.Approval.ToString());
                cmd.Parameters.AddWithValue("p_descr", iph.Descr.ToString());

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



        internal List<dynamic> Readhistory(String iditem)
        {
            var cstrname = dbconn.constringName("idccore");
            var split = "||";
            var schema = "public";

            string spname = "gethistory";
            string p1 = "@iditem" + split + iditem + split + "s";

            return bc.ExecSqlWithReturnCustomSplit(cstrname, split, schema, spname, p1);
        }
        internal List<dynamic> LoadDetailpekerjaan (String eid)
        {
            var cstrname = dbconn.constringName("idccore");
            var split = "||";
            var schema = "public";

            string spname = "loaddetailpekerjaan";
            string p1 = "@eid" + split + eid + split + "s";

            return bc.ExecSqlWithReturnCustomSplit(cstrname, split, schema, spname, p1);
        }

        public string UpdateFormlogsheet (Formlogsheet1 fpcku)
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
                NpgsqlCommand cmd = new NpgsqlCommand("public.updateformlogsheet1", connection, trans);
                cmd.Parameters.AddWithValue("p_parentid", fpcku.ParentId.ToString());
                cmd.Parameters.AddWithValue("p_uraian", fpcku.Uraian.ToString());
                cmd.Parameters.AddWithValue("p_isi", fpcku.Isi.ToString());
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
        internal List<dynamic> Deletehistory(String eid)
        {
            var cstrname = dbconn.constringName("idccore");
            var split = "||";
            var schema = "public";

            string spname = "deletehistory";
            string p1 = "@eid" + split + eid + split + "s";

            return bc.ExecSqlWithReturnCustomSplit(cstrname, split, schema, spname, p1);
        }
        internal List<dynamic> LoadPekerjaantrx(String tanggalaw , String tanggalak, string pekdescr)
        {
            var cstrname = dbconn.constringName("idccore");
            var split = "||";
            var schema = "public";

            string spname = "loadpekerjaantrx";
            string p1 = "@tanggalaw" + split + tanggalaw + split + "dtb";
            string p2 = "@tanggalak" + split + tanggalak + split + "dtb";
            string p3 = "@pekdescr" + split + pekdescr + split + "s";

            return bc.ExecSqlWithReturnCustomSplit(cstrname, split, schema, spname, p1,p2,p3);
        }

        internal List<dynamic> ReadLokasi(String idl)
        {
            var cstrname = dbconn.constringName("idccore");
            var split = "||";
            var schema = "public";

            string spname = "getlokasi";
            string p1 = "@idl" + split + idl + split + "s";

            return bc.ExecSqlWithReturnCustomSplit(cstrname, split, schema, spname, p1);
        }

    }
}
