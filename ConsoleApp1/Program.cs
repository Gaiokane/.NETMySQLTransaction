using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static MySqlConnection mysqlconn = new MySqlConnection("Host=127.0.0.1;Database=pagination;Username=qk;Password=11111");
        static MySqlCommand mysqlcmd = new MySqlCommand();
        static int str = 0;
        //static string sql = "";
        static int result = 0;
        static int lastid = 0;

        static DataSet getinfodata()
        {
            DataSet ds = new DataSet();
            mysqlcmd.CommandText = "SELECT * FROM info ORDER BY id DESC LIMIT 0,7";
            mysqlcmd.CommandType = System.Data.CommandType.Text;
            mysqlcmd.Connection = mysqlconn;
            //mysqlconn.Open();
            MySqlDataAdapter mysqlda = new MySqlDataAdapter(mysqlcmd);
            mysqlda.Fill(ds);
            return ds;
        }

        static void Main(string[] args)
        {
            try
            {
                /*mysqlconn.Open();
                mysqlcmd.Transaction = mysqlconn.BeginTransaction();

                Console.WriteLine("1.输入插入的值：");
                str = Convert.ToInt32(Console.ReadLine());
                sql = "INSERT INTO info(xxx) VALUES('" + str + "')";
                mysqlcmd = new MySqlCommand(sql, mysqlconn);
                result = mysqlcmd.ExecuteNonQuery();
                Console.WriteLine(result);
                Console.WriteLine("---------------------");

                Console.WriteLine("2.输入插入的值：");
                str = Convert.ToInt32(Console.ReadLine());
                sql = "INSERT INTO info(xxx) VALUES('" + str + "')";
                mysqlcmd = new MySqlCommand(sql, mysqlconn);
                result = mysqlcmd.ExecuteNonQuery();
                Console.WriteLine(result);

                mysqlcmd.Transaction.Commit();*/

                Console.WriteLine("1.输入插入的值：");
                str = Convert.ToInt32(Console.ReadLine());
                lastid = Convert.ToInt32(getinfodata().Tables[0].Rows[0][0].ToString());
                //Console.WriteLine("lastid:" + lastid + "\r\n" + "lastid+1:" + Convert.ToInt32(lastid + 1));
                mysqlcmd.CommandText = "INSERT INTO info VALUES('" + Convert.ToInt32(lastid + 1) + "','" + str + "')";
                mysqlcmd.CommandType = System.Data.CommandType.Text;
                mysqlcmd.Connection = mysqlconn;
                mysqlconn.Open();
                mysqlcmd.Transaction = mysqlconn.BeginTransaction();
                result = mysqlcmd.ExecuteNonQuery();
                //mysqlcmd.Transaction.Commit();
                if (result == 1)
                {
                    Console.WriteLine("插入成功");
                }
                else
                {
                    Console.WriteLine("插入失败");
                }
                Console.WriteLine("---------------------\r\n最新7条数据");
                //Console.WriteLine(getinfodata().Tables[0].Rows[0][0].ToString());
                for (int i = 0; i < getinfodata().Tables[0].Rows.Count; i++)
                {
                    for (int j = 0; j < getinfodata().Tables[0].Columns.Count; j++)
                    {
                        Console.Write(getinfodata().Tables[0].Rows[i][j].ToString() + " ");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine("---------------------");

                Console.WriteLine("2.输入插入的值：");
                str = Convert.ToInt32(Console.ReadLine());
                mysqlcmd.CommandText = "INSERT INTO info VALUES('" + Convert.ToInt32(lastid + 2) + "','" + str + "')";
                mysqlcmd.CommandType = System.Data.CommandType.Text;
                result = mysqlcmd.ExecuteNonQuery();
                //mysqlcmd.Transaction.Commit();
                if (result == 1)
                {
                    Console.WriteLine("插入成功");
                }
                else
                {
                    Console.WriteLine("插入失败");
                }
                Console.WriteLine("---------------------\r\n最新7条数据");
                //Console.WriteLine(getinfodata().Tables[0].Rows[0][0].ToString());
                for (int i = 0; i < getinfodata().Tables[0].Rows.Count; i++)
                {
                    for (int j = 0; j < getinfodata().Tables[0].Columns.Count; j++)
                    {
                        Console.Write(getinfodata().Tables[0].Rows[i][j].ToString() + " ");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine("---------------------");

                Console.WriteLine("3.输入插入的值：");
                str = Convert.ToInt32(Console.ReadLine());
                mysqlcmd.CommandText = "INSERT INTO info VALUES('" + Convert.ToInt32(lastid + 3) + "','" + str + "')";
                mysqlcmd.CommandType = System.Data.CommandType.Text;
                result = mysqlcmd.ExecuteNonQuery();
                if (result == 1)
                {
                    Console.WriteLine("插入成功");
                }
                else
                {
                    Console.WriteLine("插入失败");
                }
                Console.WriteLine("---------------------\r\n最新7条数据");
                //Console.WriteLine(getinfodata().Tables[0].Rows[0][0].ToString());
                for (int i = 0; i < getinfodata().Tables[0].Rows.Count; i++)
                {
                    for (int j = 0; j < getinfodata().Tables[0].Columns.Count; j++)
                    {
                        Console.Write(getinfodata().Tables[0].Rows[i][j].ToString() + " ");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine("---------------------");

                mysqlcmd.Transaction.Commit();
            }
            catch (Exception ex)
            {
                Console.WriteLine("-------事务执行失败 回滚-------\r\n" + ex.Message);
                mysqlcmd.Transaction.Rollback();
                //throw ex;
            }
            finally
            {
                mysqlconn.Close();
                Console.WriteLine("-------事务执行完成 提交-------");
                Console.ReadLine();
            }
        }
    }
}