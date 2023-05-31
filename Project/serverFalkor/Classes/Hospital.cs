using System.Data;
using System.Data.SqlClient;
using static serverFalkor.Classes.Department;
using static serverFalkor.Classes.Floor;

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
        public static DataTable GetTable1(int floorId, int departmentId)
        {

            try
            {
                using (SqlConnection cn = new SqlConnection
                    ("Data Source=DESKTOP-E68S884\\SQLEXPRESS;Initial Catalog=_MedicalTests;Integrated Security=true"))
                {


                    using (SqlCommand cm = new SqlCommand("getDataQueue1", cn) { CommandType = CommandType.StoredProcedure })
                    {


                        cn.Open();
                        cm.Parameters.Add(new SqlParameter("@date", new DateTime(2022, 2, 18)));
                        cm.Parameters.Add(new SqlParameter("@floor_id", floorId));
                        if (departmentId != 0)
                            cm.Parameters.Add(new SqlParameter("@department_id", departmentId));
                        DataSet dataset = new DataSet();
                        SqlDataAdapter adapter = new SqlDataAdapter(cm);
                        adapter.Fill(dataset);
                        return dataset.Tables[0];

                    };

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);

            }
            return null;
        }
    }
}
