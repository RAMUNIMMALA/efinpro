using System;
using System.Collections.Generic;
using System.Data;
using Models;
using PagedList;



namespace DataAccess
{    
   public class DA_Users :Utility
    {      
        List<Users> listuser = null;
        /// <summary>
        /// Description:To get the active user list from database
        /// Name:Bhargav krishna
        /// </summary>
        
        public List<Users> GetUsers()
        {
            try
            {
                IDbDataParameter[] arrParameter = new IDbDataParameter[] { };
                dsResultSet = DB_UTILITY.RunSP("USP_FETCH_USERSLIST", arrParameter);
                if (ValidateResultSet(dsResultSet))
                {
                    listuser = OBJECT_UTILITY.GetConvertCollection<Users>(dsResultSet.Tables[0]);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return listuser;
        }
    }
}
