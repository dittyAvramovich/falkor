using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace FalkorTest.Classes
{
    public class Hospital
    {
        public static List<string> GetFloors1()
        {
            List<string> floors = new List<string>();
            using (SqlConnection conn = new SqlConnection("Server=DESKTOP-E68S884;SQLEXPRESS;DataBase=Northwind;Integrated Security=SSPI"))
            {
                conn.Open();

                // 1.  create a command object identifying the stored procedure
                SqlCommand cmd = new SqlCommand("CustOrderHist", conn);

                // 2. set the command object so it knows to execute a stored procedure
                cmd.CommandType = CommandType.StoredProcedure;

                // 3. add parameter to command, which will be passed to the stored procedure
                cmd.Parameters.Add(new SqlParameter("@CustomerID", null));

                // execute the command
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    // iterate through results, printing each to console
                    while (rdr.Read())
                    {
                        floors.Add(rdr.ToString());
                        Console.WriteLine("Product: {0,-35} Total: {1,2}", rdr["ProductName"], rdr["Total"]);
                    }
                }
            }

            return floors;
        
    }

        public static List<string> GetDepartmentsByFloor(int floorId)
        {
            List<string> departments = new List<string>();
            using (SqlConnection conn = new SqlConnection("Server=DESKTOP-E68S884;SQLEXPRESS;DataBase=Northwind;Integrated Security=SSPI"))
            {
                conn.Open();

                // 1.  create a command object identifying the stored procedure
                SqlCommand cmd = new SqlCommand("CustOrderHist", conn);

                // 2. set the command object so it knows to execute a stored procedure
                cmd.CommandType = CommandType.StoredProcedure;

                // 3. add parameter to command, which will be passed to the stored procedure
                cmd.Parameters.Add(new SqlParameter("@FloorId", floorId));

                // execute the command
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    // iterate through results, printing each to console
                    while (rdr.Read())
                    {
                        departments.Add(rdr.ToString());
                    }
                }
            }

            return departments;

        }

        public static List<string> GetTable(int floorId, int departmentId)
        {
            List<string> departments = new List<string>();
            using (SqlConnection conn = new SqlConnection("Server=DESKTOP-E68S884;SQLEXPRESS;DataBase=Northwind;Integrated Security=SSPI"))
            {
                conn.Open();

                // 1.  create a command object identifying the stored procedure
                SqlCommand cmd = new SqlCommand("CustOrderHist", conn);

                // 2. set the command object so it knows to execute a stored procedure
                cmd.CommandType = CommandType.StoredProcedure;

                // 3. add parameter to command, which will be passed to the stored procedure
                cmd.Parameters.Add(new SqlParameter("@FloorId", floorId));

                // execute the command
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    // iterate through results, printing each to console
                    while (rdr.Read())
                    {
                        departments.Add(rdr.ToString());
                    }
                }
            }

            return departments;

        }

    }
}





//public static List<ContentSearch> Get(string searchValue, string TextFalse, string TextTrue)
//{
//    List<ContentSearch> contentSearchs = new List<ContentSearch>();
//    try
//    {
//        string connectionString = ConfigurationUtil.ConnectionStrings("QFlowDB").ConnectionString;
//        using (SqlConnection cn = new SqlConnection(connectionString))
//        {
//            using (var cm = new SqlCommand("[cqf].[ContentTextSearch]", cn) { CommandType = CommandType.StoredProcedure })
//            {
//                cn.Open();
//                string UserName = HttpContext.Current.User.Identity.Name;
//                cm.Parameters.Add(new SqlParameter("@UserName", UserName));
//                cm.Parameters.Add(new SqlParameter("@SearchValue", searchValue));
//                cm.Parameters.Add(new SqlParameter("@TextFalse", TextFalse));
//                cm.Parameters.Add(new SqlParameter("@TextTrue", TextTrue));
//                using (var dr = cm.ExecuteReader(CommandBehavior.SingleResult))
//                {
//                    while (dr.Read())
//                    {
//                        TemplateObjectType etype = (TemplateObjectType)Convert.ToInt32(dr["ObjectType"]);
//                        contentSearchs.Add(new ContentSearch
//                        {
//                            Value = dr["Value"].ToString(),
//                            LanguageCode = dr["LanguageCode"].ToString(),
//                            ContentTemplateId = Convert.ToInt32(dr["ContentTemplateId"]),
//                            ObjectId = Convert.ToInt32(dr["ObjectId"]),
//                            ObjectType = etype.ToString(),
//                            ObjectName = dr["ObjectName"].ToString(),
//                            ParameterName = dr["ParameterName"].ToString(),
//                            Description = dr["DescriptionObject"].ToString(),
//                            IsContentItem = Convert.ToBoolean(dr["IsContentItem"]),
//                            NumberPage = dr["PageNum"].ToString()

//                        }); ;

//                    }
//                    dr.Close();
//                }
//                cn.Close();
//            }
//        }
//    }
//    catch (Exception ex)
//    {
//        EventLogEntry ev = new EventLogEntry(EventLogEntryType.Error, "ContentSearchAPI.DAL.ContentSearchRepository.Get", ex.ToString(), 0, 0);
//        EventLog.Write(ref ev);
//    }
//    return contentSearchs;
//}
