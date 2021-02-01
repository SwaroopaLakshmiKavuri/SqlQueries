using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace SqlQueries
{
    class Parameters
    {
        SqlConnection cn = null;
        SqlCommand cmd = null;
        SqlDataReader dr = null;
        public int InsertWithParameters()
        {
            try
            {
                Console.WriteLine("Enter empname");
                var empname = Console.ReadLine();
                Console.WriteLine("Enter salary");
                var salary = Convert.ToSingle(Console.ReadLine());
                Console.WriteLine("Enter deptno");
                var deptno = Convert.ToInt32(Console.ReadLine());
                cn = new SqlConnection("Data Source=DESKTOP-6IDKG38;Initial Catalog=WFA3DotNet;Integrated Security=True");
                cmd = new SqlCommand("insert into employeetab values(@empname,@salary,@deptno)", cn);
                cmd.Parameters.Add("@empname", SqlDbType.VarChar, 20).Value = empname;
                cmd.Parameters.Add("@salary", SqlDbType.Float).Value = salary;
                cmd.Parameters.Add("@deptno", SqlDbType.Int).Value = deptno;
                cn.Open();
                int i = cmd.ExecuteNonQuery();
                ShowData();
                return i;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 1;
            }
            finally
            {
                cn.Close();
            }
            
        }
        public int UpdateWithParameters()
        {
            try
            {
                Console.WriteLine("Enter empid");
                var empid = Console.ReadLine();
                Console.WriteLine("Enter salary");
                var salary = Convert.ToSingle(Console.ReadLine());
                cn = new SqlConnection("Data Source=DESKTOP-6IDKG38;Initial Catalog=WFA3DotNet;Integrated Security=True");
                cmd = new SqlCommand("update employeetab set salary=@salary where(empid=@empid)", cn);
                cmd.Parameters.Add("@empid", SqlDbType.Int).Value = empid;
                cmd.Parameters.Add("@salary", SqlDbType.Float).Value = salary;
                
                cn.Open();
                int i = cmd.ExecuteNonQuery();
                ShowData();
                return i;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 1;
            }
            finally
            {
                cn.Close();
            }

        }
        public int DeleteWithParameters()
        {
            try
            {
                Console.WriteLine("Enter empid");
                var empid = Console.ReadLine();
                
                cn = new SqlConnection("Data Source=DESKTOP-6IDKG38;Initial Catalog=WFA3DotNet;Integrated Security=True");
                cmd = new SqlCommand("Delete from employeetab  where(empid=@empid)", cn);
                cmd.Parameters.Add("@empid", SqlDbType.Int).Value = empid;
               

                cn.Open();
                int i = cmd.ExecuteNonQuery();
                ShowData();
                return i;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 1;
            }
            finally
            {
                cn.Close();
            }

        }
        public int SearchWithParameters()
        {
            try
            {
                Console.WriteLine("Enter empid");
                var empid = Console.ReadLine();

                cn = new SqlConnection("Data Source=DESKTOP-6IDKG38;Initial Catalog=WFA3DotNet;Integrated Security=True");
                cmd = new SqlCommand("select * from employeetab  where(empid=@empid)", cn);
                cmd.Parameters.Add("@empid", SqlDbType.Int).Value = empid;
                cn.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Console.WriteLine($" empname: {dr["empname"]}\n deptno : {dr["deptno"]}\nsalary : {dr["salary"]}");
                }
               
                return 1;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 1;
            }
            finally
            {
                cn.Close();
            }

        }
        public int ShowData()
        {
            try
            {

                Console.WriteLine("Data from the table after DML Command");
                cn = new SqlConnection("Data Source=DESKTOP-6IDKG38;Initial Catalog=WFA3DotNet;Integrated Security=True");
                cmd = new SqlCommand("Select * from EmployeeTab", cn);
                cn.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Console.WriteLine($"{dr["empid"]}\t{dr["empname"]}\t{dr["Salary"]}\t{dr["deptno"]}");
                }
                return 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
                return 1;
            }
            finally
            {
                cn.Close();
            }
        }
        public void Display()
        {
            Console.WriteLine("Enter the Value");
            Console.WriteLine();
            Console.WriteLine("1.Insert with parameters");
            Console.WriteLine("2.Update with parameters");
            Console.WriteLine("3.Delete with parameters");
            Console.WriteLine("4.Search with parameters");
            Console.WriteLine("5.Exit");
        }

    }
    class WithParameters
    {
        static void Main()
        {
            Parameters p = new Parameters();
            p.Display();
            int choice;
            choice = Convert.ToInt32(Console.ReadLine());
           
            switch (choice)
            {
                case 1:
                    p.InsertWithParameters();
                    break;
                case 2:
                    p.UpdateWithParameters();
                    break;
                case 3:
                    p.DeleteWithParameters();
                    break;
                case 4:
                    p.SearchWithParameters();
                    break;
                default:
                    break;
            }


        }
    }
}
