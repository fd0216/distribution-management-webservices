using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace WebApplication1
{
    /// <summary>
    /// WebService1 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {
        DBOperation dbOperation = new DBOperation();     
        [WebMethod(Description = "查询员工信息")]
        public List<string> selectAllEmployeeInfo()
        {
            return dbOperation.selectEmployees();
        }
        [WebMethod(Description = "查询用户信息")]
        public List<string> selectAllCustomerInfo()
        {
            return dbOperation.selectUsers();
        }
        [WebMethod(Description = "查询货车信息")]
        public List<string> selectTrucks()
        {
            return dbOperation.selectTrucks();
        }
        [WebMethod(Description = "获取货物类型的信息")]
        public List<string> selectAllCargoInfor()
        {
            return dbOperation.selectAllCargoInfor();
        }
        [WebMethod(Description = "获取仓库的信息")]
        public List<string> selectWareHouseInfo()
        {
            return dbOperation.selectWareHouseInfo();
        }
        [WebMethod(Description = "获取货物的信息")]
        public List<string> selectWares()
        {
            return dbOperation.selectWares();
        }
        [WebMethod(Description = "更新货物状态")]
        public bool updateWareStatue(string wareGUID)
        {
            return dbOperation.updateWareStatus(wareGUID);
        }
        [WebMethod(Description = "增加一条货物信息")]
        public bool insertCargoInfo(string wareInfo)
        {  
            return dbOperation.insertCargoInfo(wareInfo);
        }      
        [WebMethod(Description = "删除一条货物信息")]
        public bool deleteCargoInfo(string Cno)
        {
            return dbOperation.deleteCargoInfo(Cno);
        }
    }
}
