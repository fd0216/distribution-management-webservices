using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebApplication1
{
    public class DBOperation
    {
        public static SqlConnection sqlCon;  //用于连接数据库  

        //将下面的引号之间的内容换成上面记录下的属性中的连接字符串        
          private String ConServerStr = @"Data Source=47.106.88.98,1433\SQLEXPRESS;Initial Catalog=simpleERP;Persist Security Info=True;User ID=sa;Password=Kbl@666666";
        //  private String ConServerStr = @"Data Source=FDIT;Initial Catalog=LMS;Integrated Security=True";
        //默认构造函数  
        public DBOperation()
        {
            if (sqlCon == null)
            {
                sqlCon = new SqlConnection();
                sqlCon.ConnectionString = ConServerStr;
                try
                {
                    sqlCon.Open();
                }
                catch (Exception ex)
                {
                }
            }
        }

        //关闭/销毁函数，相当于Close()  
        public void Dispose()
        {
            if (sqlCon != null)
            {
                sqlCon.Close();
                sqlCon = null;
            }
        }

        /// <summary>  
        /// 获取所有货物的信息  
        /// </summary>  
        /// <returns>所有货物信息</returns>  
        public List<string> selectAllCargoInfor()
        {
            List<string> list = new List<string>();
            try
            {
                string sql = "select * from WareTypes";
                SqlCommand cmd = new SqlCommand(sql, sqlCon);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    //将结果集信息添加到返回向量中  
                    list.Add(reader[0].ToString());
                    list.Add(reader[1].ToString());
                    list.Add(reader[2].ToString());
                    list.Add(reader[3].ToString());
                    list.Add(reader[4].ToString());
                    list.Add(reader[5].ToString());
                }
                reader.Close();
                cmd.Dispose();
            }
            catch (Exception)
            {
            }
            return list;
        }
        public List<string> selectEmployees()
        {
            List<string> list = new List<string>();
            try
            {
                string sql = "select EmployeeID,Password from Employees";
                SqlCommand cmd = new SqlCommand(sql, sqlCon);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    //将结果集信息添加到返回向量中  
                    list.Add(reader[0].ToString());
                    list.Add(reader[1].ToString());         
                }
                reader.Close();
                cmd.Dispose();
            }
            catch (Exception)
            {
            }
            return list;
        }
        public List<string> selectUsers()
        {
            List<string> list = new List<string>();
            try
            {
                string sql = "select LoginID,Password,GUID from Customers";
                SqlCommand cmd = new SqlCommand(sql, sqlCon);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    //将结果集信息添加到返回向量中  
                    list.Add(reader[0].ToString());
                    list.Add(reader[1].ToString());
                    list.Add(reader[2].ToString());
                }
                reader.Close();
                cmd.Dispose();
            }
            catch (Exception)
            {
            }
            return list;
        }
        public List<string> selectWares()
        {
            List<string> list = new List<string>();
            try
            {
                string sql = "select GUID,CustomerLoginID,Name,TotalNum from Wares";
                SqlCommand cmd = new SqlCommand(sql, sqlCon);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    //将结果集信息添加到返回向量中  
                    list.Add(reader[0].ToString());
                    list.Add(reader[1].ToString());
                    list.Add(reader[2].ToString());
                    list.Add(reader[3].ToString());
                }
                reader.Close();
                cmd.Dispose();
            }
            catch (Exception)
            {
            }
            return list;
        }
        public List<string> selectTrucks()
        {
            List<string> list = new List<string>();
            try
            {
                string sql = "select GUID,License from Trucks";
                SqlCommand cmd = new SqlCommand(sql, sqlCon);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    //将结果集信息添加到返回向量中  
                    list.Add(reader[0].ToString());
                    list.Add(reader[1].ToString());
                }
                reader.Close();
                cmd.Dispose();
            }
            catch (Exception)
            {
            }
            return list;
        }

        public List<string> selectWareHouseInfo()
        {
            List<string> list = new List<string>();
            try
            {
                string sql = "select GUID, Name from WareHouses";
                SqlCommand cmd = new SqlCommand(sql, sqlCon);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    //将结果集信息添加到返回向量中  
                    list.Add(reader[0].ToString());
                    list.Add(reader[1].ToString());
                }
                reader.Close();
                cmd.Dispose();
            }
            catch (Exception)
            {
            }
            return list;
        }
        /// <summary>  
        /// 增加一条货物信息  
        /// </summary>  
        /// <param name="Cname">货物名称</param>  
        /// <param name="Cnum">货物数量</param>  
        //public bool insertCargoInfo(string wareInfo)
        //{
        //    string[] strArray = wareInfo.Split(';')[0].Split(','); //数据
        //    string imageArray = wareInfo.Split(';')[1]; //图片

        //    string strvalue = "";
        //    byte[] data = new byte[imageArray.Length];
        //    DateTime dt = Convert.ToDateTime(strArray[strArray.Length - 1]);
        //    for (int i = 0; i < (strArray.Length - 1); i++)
        //    {
        //        if (i == (strArray.Length - 2))
        //            strvalue += "'" + strArray[i] + "'";
        //        else
        //            strvalue += "'" + strArray[i] + "', ";
        //    }

        //    byte[] binarydata = Convert.FromBase64String(imageArray);
        //    try
        //    {
        //        string sql = "insert into Wares (GUID,Name,SectionNumber,WareTypeID,Price,Weight,Length,Height,Width,Volume,Piece,TotalNum,NumPerPiece,ShipPrice,Unit,InsuranceRatio,CustomerLoginID, WareHouseID, EmployeeID,Statue,InsurancePrice,TotalPrice,Delivery,ShopNumber,DeliveryPhone,StorageTime,Photo) values (" + strvalue + ",'" + dt + "',@Photo)";
        //        SqlCommand cmd = new SqlCommand(sql, sqlCon);
        //        cmd.Parameters.Add("@Photo", SqlDbType.Binary);
        //        cmd.Parameters["@Photo"].Value = binarydata;
        //        cmd.ExecuteNonQuery();
        //        cmd.Dispose();
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        return false;
        //    }
        //}

        public bool insertCargoInfo(string wareInfo)
        {
            string strArray = wareInfo.Split(';')[0]; //数据                   
            string imageArray = wareInfo.Split(';')[1]; //图片

            string[] strTemp = strArray.Split(',');
            int i = 0, j = 0;
            if (true == insertCargoPhoto(strTemp[strTemp.Length - 2] + ";" + imageArray))
                j = 1;
            if (true == insertCargoInfo_data(strArray))
                i = 1;     
            if ((i == 1) && (j == 1))
                return true;
            else
                return false;
        }
        public bool insertCargoInfo_data(string wareInfo)
        {
            string[] strArray = wareInfo.Split(','); //数据     
            
            string strvalue = "";

            DateTime dt = Convert.ToDateTime(strArray[strArray.Length -1]);     
            for (int i = 0; i < (strArray.Length-1); i++)
            {
                if(i == (strArray.Length - 2))
                   strvalue += "'" + strArray[i] + "'";
                else
                    strvalue += "'" + strArray[i] + "',";
            }
            try
            {
                 string sql = "insert into Wares (GUID,Name,SectionNumber,WareTypeID,Price,Weight,Length,Height,Width,Volume,Piece,TotalNum,NumPerPiece,ShipPrice,Unit,InsuranceRatio,CustomerLoginID, WareHouseID, EmployeeID,Statue,InsurancePrice,TotalPrice,Delivery,ShopNumber,DeliveryPhone,Photo_GUID,StorageTime) values (" + strvalue + ",'" + dt + "')";           
                SqlCommand cmd = new SqlCommand(sql, sqlCon);       
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        /// <summary>
        /// 添加照片
        /// </summary>
        /// <param name="photo"></param>
        /// <returns></returns>
        public bool insertCargoPhoto(string photo)
        {
            string guid = photo.Split(';')[0]; //GUID
            string imageArray = photo.Split(';')[1]; //图片             
            byte[] data = new byte[imageArray.Length];        
            byte[] binarydata = Convert.FromBase64String(imageArray);
            try
            {
                string sql = "insert into Photos (GUID,Data) values ('" + guid + "',@Photo)";
                SqlCommand cmd = new SqlCommand(sql, sqlCon);
                cmd.Parameters.Add("@Photo", SqlDbType.Binary);
                cmd.Parameters["@Photo"].Value = binarydata;
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// 修改货物状态为：装车  
        /// </summary>  
        public bool updateWareStatus(string wareGUID)
        {           
            try
            {           
                string sql = "update Wares set Statue ='装车' where GUID ="+"'"+wareGUID+"'";
                SqlCommand cmd = new SqlCommand(sql, sqlCon);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        /// <summary>  
        /// 删除一条货物信息  
        /// </summary>  
        /// <param name="Cno">货物编号</param>  
        public bool deleteCargoInfo(string Cno)
        {
            try
            {
                string sql = "delete from C where Cno=" + Cno;
                SqlCommand cmd = new SqlCommand(sql, sqlCon);
                cmd.ExecuteNonQuery();
                cmd.Dispose();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}