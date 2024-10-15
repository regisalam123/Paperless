using paperless.Data.Controllers;
using Npgsql;
using System.Data;
using paperless.Data.Controllers;

namespace paperless.Libs
{
    public class lUsermod
    {
        private lDbConn dbconn = new lDbConn();
        private BaseController bc = new BaseController();


        internal List<dynamic> ReadUser2(String iduser, String idpwd)
        {
            var cstrname = dbconn.constringName("idccore");
            var split = "||";
            var schema = "public";

            string spname = "getusermod1";
            string p1 = "@iduser" + split + iduser + split + "s";
            string p2 = "@idpwd" + split + idpwd + split + "s";

            return bc.ExecSqlWithReturnCustomSplit(cstrname, split, schema, spname, p1, p2);
        }

    }
}
