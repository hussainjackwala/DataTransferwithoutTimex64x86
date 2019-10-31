
using System.Data;
namespace DataTransfer.Common
{
    class CommonFuncVar
    {
        public static string LoginName = "";

        public static bool IsValidateDS(DataSet ds)
        {
            bool isValdtds = false;
            if (ds != null)
            {
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        isValdtds = true;
                    }
                    
                }
            }
            return isValdtds;
        }

      

    }
}
