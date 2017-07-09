using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarsOnline.Entities;
using System.Data.SqlClient;

namespace CarsOnline.DAL
{
 public   class CarsDAO
    {
        public void purchaseCar(UserDTO udto, CarsDTO cdto)
        {
            DBHelper db = new DBHelper();
            int uid = getUserID(udto);
            int cid = getCarID(cdto);


            string q = "insert into PurchaseRecord (UID,CID) values(" + uid + "," + cid + ")";
            int i = db.ExecuteQuery(q);



        }


        public List<CarsDTO> getRecord(UserDTO udto)
        {
            SqlDataReader dr;
            DBHelper db = new DBHelper();

            int uid = getUserID(udto);
            //int cid = getCarID(cdto);

            string q = "select * from Cars c,PurchaseRecord p,Users u where u.UID = "+uid+" and p.UID = "+uid+" and c.CID = p.CID ";
            try
            {
                dr = db.ExecuteReader(q);
                List<CarsDTO> list = new List<CarsDTO>();
                while (dr.Read())
                {
                    CarsDTO dto = new CarsDTO();
                    dto.Name = dr["CName"].ToString().Trim();
                    dto.Price = Convert.ToInt32(dr["CPrice"]);

                    list.Add(dto);
                }
                return list;

                }
            catch (Exception ex) { return null; }
        

        }
            
        




        public int getUserID(UserDTO dto)
        {
            int id = 0;
            DBHelper db = new DBHelper();
            string q = "select * from Users where Login = '" + dto.TxtLogin + "'";
            try
            {
                SqlDataReader dr = db.ExecuteReader(q);
               
                string l = "";
                while (dr.Read())
                {

                    l = dr["Login"].ToString().Trim();
                    if (dto.TxtLogin == l)
                    {
                        id = Convert.ToInt32(dr["UID"]);
                        return id;
                    }
                }
            }
            catch (Exception) { }
            return id;
        }


        public int getCarID(CarsDTO dto)
        {
            DBHelper db = new DBHelper();
            string q = "select * from Cars where CName = '" + dto.Name + "'";
            SqlDataReader dr = db.ExecuteReader(q);
            int id = 0;
            string l = "";
            while (dr.Read())
            {

                l = dr["CName"].ToString().Trim();
                if (dto.Name== l)
                {
                    id = Convert.ToInt32(dr["CID"]);
                    return id;
                }
            }
            return id;
        }


    }
}
