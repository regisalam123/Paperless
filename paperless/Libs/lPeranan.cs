using paperless.Data.Controllers;
using paperless.Data.Models;
using paperless.Manager;
using Npgsql;
using System.Data;


namespace paperless.Libs
{
    public class lPeranan
    {
        private lDbConn dbconn = new lDbConn();
        private BaseController bc = new BaseController();

        internal List<dynamic> ReadPeranan(String idperanan)
        {
            var cstrname = dbconn.constringName("idccore");
            var split = "||";
            var schema = "public";

            string spname = "getperanan1";
            string p1 = "@idperanan" + split + idperanan + split + "s";

            return bc.ExecSqlWithReturnCustomSplit(cstrname, split, schema, spname, p1);
        }


        internal List<dynamic> ReadPeriode(String id, string uraianid)
        {
            var cstrname = dbconn.constringName("idccore");
            var split = "||";
            var schema = "public";

            string spname = "getperiode1";
            string p1 = "@id" + split + id + split + "s";
            string p2 = "@uraianid" + split + uraianid + split + "s";

            return bc.ExecSqlWithReturnCustomSplit(cstrname, split, schema, spname, p1,p2);
        }






    }







}
