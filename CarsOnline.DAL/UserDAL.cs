using CarsOnline.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsOnline.DAL
{
    public class UserDAL
    {

        public bool ifExists(UserDTO dto)
        {
            SqlDataReader dr;
            try
            {
                DBHelper db = new DBHelper();
                String q = "Select * from Users";
                 dr = db.ExecuteReader(q);
                string s = "";
                while (dr.Read())
                {
                    s = dr["Login"].ToString().Trim();
                    if (s == dto.TxtLogin)
                    {
                        dr.Close();
                        return true;
                    }

                }
                dr.Close();
                return false;
              
            }
            catch (Exception e) { Console.WriteLine(e); }
            return false;
        }


        public bool ifExistsLogin(UserDTO dto)
        {
            SqlDataReader dr;
            try
            {
                DBHelper db = new DBHelper();
                String q = "Select * from Users";
                dr = db.ExecuteReader(q);
                string s = "";
                string s2 = "";
                while (dr.Read())
                {
                    s = dr["Login"].ToString().Trim();
                    s2 =dr["Password"].ToString().Trim();
                    if (s == dto.TxtLogin&&s2==dto.TxtPassword)
                    {
                        dr.Close();
                        return true;
                    }

                }
                dr.Close();
                return false;

            }
            catch (Exception e) { Console.WriteLine(e); }
            return false;
        }



        

        public void insertUser(UserDTO dto)
        {
            try
            {
                DBHelper db = new DBHelper();
                string q = "insert into Users (Login,Password,Name) values ('" + dto.TxtLogin + "','" + dto.TxtPassword + "','" + dto.TxtName + "')";
                int i = db.ExecuteQuery(q);
            }
            catch (Exception)
            { }
        }

    }
}
