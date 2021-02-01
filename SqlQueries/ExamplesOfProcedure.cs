using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace SqlQueries
{
    class Procedure
    {
        SqlConnection cn = null;
        SqlCommand cmd = null;
        SqlDataReader dr = null;
        public int InsertWithSP()
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
                cmd = new SqlCommand("sp_InsertEmp", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                
                cmd.Parameters.Add("@ename", SqlDbType.VarChar, 20).Value = empname;
                cmd.Parameters.Add("@sal", SqlDbType.Float).Value = salary;
                cmd.Parameters.Add("@dno", SqlDbType.Int).Value = deptno;
                cn.Open();
                int i = cmd.ExecuteNonQuery();

                ShowData();
                return i;

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
        public int UpdateWithSP()
        {
            try
            {
                Console.WriteLine("Enter an exisisting  empid who update the records");
                int empid = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter empname");
                var empname = Console.ReadLine();
                Console.WriteLine("Enter salary");
                var salary = Convert.ToSingle(Console.ReadLine());
                Console.WriteLine("Enter deptno");
                var deptno = Convert.ToInt32(Console.ReadLine());
                cn = new SqlConnection("Data Source=DESKTOP-6IDKG38;Initial Catalog=WFA3DotNet;Integrated Security=True");
                cmd = new SqlCommand("sp_UpdateEmp", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@empid", SqlDbType.Int).Value = empid;
                cmd.Parameters.Add("@empname", SqlDbType.VarChar, 20).Value = empname;
                cmd.Parameters.Add("@esal", SqlDbType.Float).Value = salary;
                cmd.Parameters.Add("@deptid", SqlDbType.Int).Value = deptno;
                cn.Open();
                int i = cmd.ExecuteNonQuery();

                ShowData();
                return i;

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
        public int DeleteWithSP()
        {
            try
            {
                Console.WriteLine("Enter empid");
                int empid = Convert.ToInt32(Console.ReadLine());
                
                cn = new SqlConnection("Data Source=DESKTOP-6IDKG38;Initial Catalog=WFA3DotNet;Integrated Security=True");
                cmd = new SqlCommand("sp_DeleteEmp", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@empid", SqlDbType.Int).Value = empid;
                
                cn.Open();
                int i = cmd.ExecuteNonQuery();

                ShowData();
                return i;

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
            Console.WriteLine("1.Insert with procedures");
            Console.WriteLine("2.Update with procedures");
            Console.WriteLine("3.Delete with procedures");
            Console.WriteLine("4.Exit");
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

    }
    class ExamplesOfProcedure
    {
        static void Main()
        {
            Procedure p = new Procedure();
            p.Display();
            int choice;
            choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    p.InsertWithSP();
                    break;
                case 2:
                    p.UpdateWithSP();
                    break;
                case 3:
                    p.DeleteWithSP();
                    break;
                
                default:
                    break;
            }

        }
    }
}
    
        
    
