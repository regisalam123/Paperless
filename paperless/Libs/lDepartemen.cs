using paperless.Data.Controllers;
using paperless.Data.Models;
using paperless.Manager;
using Npgsql;
using System.Data;


namespace paperless.Libs
{
    public class lDepartemen
    {
        private lDbConn dbconn = new lDbConn();
        private BaseController bc = new BaseController();

        internal List<dynamic> ReadDepartemen(String iddepartemen)
        {
            var cstrname = dbconn.constringName("idccore");
            var split = "||";
            var schema = "public";

            string spname = "getdepartemen1";
            string p1 = "@iddepartemen" + split + iddepartemen + split + "s";

            return bc.ExecSqlWithReturnCustomSplit(cstrname, split, schema, spname, p1);
        }
    }
}
