using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace SqlQueries
{
    class WithoutParameters
    {
        SqlConnection cn = null;
        SqlCommand cmd = null;
        SqlDataReader dr = null;
        

        public int InsertOneRow()
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
                cmd = new SqlCommand("Insert into employeetab values('" + empname + "'," + salary + "," + deptno + ")", cn);
                cn.Open();
                int i = cmd.ExecuteNonQuery();
                Console.WriteLine("One row added to the table");
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
        public int DeleteOneRow()
        {
            try
            {

                cn = new SqlConnection("Data Source=DESKTOP-6IDKG38;Initial Catalog=WFA3DotNet;Integrated Security=True");
                cmd = new SqlCommand("Delete from employeetab  where empid=8", cn);
                cn.Open();
                int i = cmd.ExecuteNonQuery();
                Console.WriteLine("One row deleted");
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
        public int UpdateOneRow()
        {
            try
            {

                Console.WriteLine("Enter eid");
                int empid = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter deptno");
                int deptno = Convert.ToInt32(Console.ReadLine());
                cn = new SqlConnection("Data Source=DESKTOP-6IDKG38;Initial Catalog=WFA3DotNet;Integrated Security=True");
                cmd = new SqlCommand("update employeetab set deptno=" + deptno + "where empid=" + empid + "", cn);


                cn.Open();
                int i = cmd.ExecuteNonQuery();
                Console.WriteLine("One row updated to the table");
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
        public int SearchOneRow()
        {
            try
            {
                Console.WriteLine("Enter empname : ");
                var empid = Console.ReadLine();

                cn = new SqlConnection("Data Source=DESKTOP-6IDKG38;Initial Catalog=WFA3DotNet;Integrated Security=True");
                cmd = new SqlCommand("Select * from EmployeeTab where empname='" + empid + "'", cn);
                cn.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Console.WriteLine($" empname: {dr["empname"]}\n deptno : {dr["deptno"]}\nsalary : {dr["salary"]}");
                }
                ShowData();
                return 1;
            }
            catch (SqlException ex)
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
            Console.WriteLine("1.Insert");
            Console.WriteLine("2.Delete");
            Console.WriteLine("3.Update");
            Console.WriteLine("4.Search");
            Console.WriteLine("5.Exit");
        }
        
    }
    class Program
    {
        static void Main(string[] args)
        {
            WithoutParameters p = new WithoutParameters();
            int choice;
           p.Display();
            choice = Convert.ToInt32(Console.ReadLine());
            switch(choice)
            {
                case 1:
                   p.InsertOneRow();
                    break;
                case 2:
                    p.DeleteOneRow();
                    break;
                case 3:
                    p.UpdateOneRow();
                    break;
                case 4:
                    p.SearchOneRow();
                    break;
                default:
                    break;
            }

           
        }
    }
}
