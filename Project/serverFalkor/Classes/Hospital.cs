using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Runtime.Intrinsics.Arm;
using static serverFalkor.Classes.Department;
using static serverFalkor.Classes.Floor;
using static serverFalkor.Classes.Table;

namespace FalkorTest.Classes
{
    public class Hospital
    {
        public static List<floor> GetFloors()
        {
            List<floor> floors = new List<floor>();
            try
            {
                using (SqlConnection cn = new SqlConnection
                    ("Data Source=DESKTOP-E68S884\\SQLEXPRESS;Initial Catalog=_MedicalTests;Integrated Security=true")
)
                {
                    using (var cm = new SqlCommand("getFloors", cn) { CommandType = CommandType.StoredProcedure })
                    {
                        cn.Open();
                        cm.Parameters.Add(new SqlParameter("@department_id", null));

                        using (SqlDataReader rdr = cm.ExecuteReader())
                        {
                            while (rdr.Read())
                            {
                                floors.Add(new floor { Id = rdr.GetInt32("floor_id"), Name = (string)rdr["floor_desc"] });
                            }
                            rdr.Close();
                        }
                        cn.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);

            }
            return floors;
        }

        public static List<departments> GetDepartmentsByFloor(int floorId)
        {
            List<departments> departments = new List<departments>();
            try
            {
                using (SqlConnection cn = new SqlConnection
                    ("Data Source=DESKTOP-E68S884\\SQLEXPRESS;Initial Catalog=_MedicalTests;Integrated Security=true")
)
                {
                    //"Trusted_Connection=True;TrustServerCertificate=True;Server=./SQLEXPRESS;database=_MedicalTests;
                    using (var cm = new SqlCommand("getDepartments", cn) { CommandType = CommandType.StoredProcedure })
                    {
                        cn.Open();
                        cm.Parameters.Add(new SqlParameter("@floor_id", floorId));

                        using (SqlDataReader rdr = cm.ExecuteReader())
                        {
                            while (rdr.Read())
                            {
                                departments.Add(new departments { Id = rdr.GetInt32("department_id"), Department_desc = (string)rdr["department_desc"] });
                            }
                            rdr.Close();
                        }
                        cn.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);

            }
            return departments;
        }

        public static List<table> GetTable(int floorId, int departmentId)
        {
            List<table> table = new List<table>();
            try
            {
                using (SqlConnection cn = new SqlConnection
                    ("Data Source=DESKTOP-E68S884\\SQLEXPRESS;Initial Catalog=_MedicalTests;Integrated Security=true"))
                {


                    using (SqlCommand cm = new SqlCommand("getDataQueue", cn) { CommandType = CommandType.StoredProcedure })
                    {


                        cn.Open();
                        cm.Parameters.Add(new SqlParameter("@date", new DateTime(2022, 2, 18)));
                        cm.Parameters.Add(new SqlParameter("@floor_id", floorId));
                        cm.Parameters.Add(new SqlParameter("@department_id", departmentId));
                        DataSet dataset = new DataSet();
                        SqlDataAdapter adapter = new SqlDataAdapter(cm);
                        adapter.Fill(dataset);
                        table objEmp = new table();
                        List<table> empList = new List<table>();
                        foreach (DataRow dr in dataset.Tables[0].Rows)
                        {
                            empList.Add(new table
                            {
                                 row_num = (int)Convert.ToInt64(dr["row_num"]),
                                    patientId = Convert.ToString(dr["patient_id"]),
                                    fullName = Convert.ToString(dr["fullName"]),
                                    patientPhone = Convert.ToString(dr["patient_phone"]),
                                    disguisedName = Convert.ToString(dr["disguised_name"]),
                                    queuNumber = Convert.ToString(dr["queue_number"]),
                                    doctorName = Convert.ToString(dr["Doctor_Name"]),

                                    payer = Convert.ToString(dr["payer"]),

                                    scheduledTime = (TimeSpan)dr["schedule_time"],
                                    scheduledTimeInterval = (TimeSpan)dr["scheduled_time_interval"],
                                     cirorogia = Convert.ToString(dr["כירורגיה"]),
                                    mos = Convert.ToString(dr["מוס"]),
                                    eyes = Convert.ToString(dr["עיניים"]),
                                    lashes = Convert.ToString(dr["עפעפיים"])

                                
                            });
                        }
                    };



                }

                //        using (SqlDataReader rdr = cm.ExecuteReader())
                //        {

                //            while (rdr.Read())
                //            {


                //                table.Add(new table
                //                {
                //                    row_num = (int)rdr.GetInt64(0),
                //                    patientId = (string)rdr[1],
                //                    fullName = (string)rdr[2],
                //                    patientPhone = (string)rdr[3],
                //                    disguisedName = (string)rdr[4],
                //                    queuNumber = (string)rdr[5],
                //                    doctorName = (string)rdr[6],
                //                    payer = (string)rdr[7],
                //                    scheduledTime = (TimeSpan)rdr[8],
                //                    scheduledTimeInterval = (TimeSpan)rdr[9],
                //                    cirorogia = (string)rdr[10],
                //                    mos = (string)rdr[11],
                //                    eyes = (string)rdr[12],
                //                    lashes = (string)rdr[13],
                //                });
                //            }
                //            rdr.Close();
                //        }
                //        cn.Close();
                //    }
                //}
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);

            }
            return table;
        }
    }
}





