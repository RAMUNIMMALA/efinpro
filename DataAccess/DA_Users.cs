using System;
using System.Collections.Generic;
using System.Data;
using Models;
using PagedList;

namespace DataAccess
{
    public class DA_Users : Utility
    {
        List<Users> listuser = null;
        Users _users = null;
        DataSet dtuser = null;

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
        /// <summary>
        /// Description :Verify User Login  
        /// Name:Sruthi A
        /// </summary>
        public Users VerifyUserLogin(string UserMailID, string Password)
        {
            _users = new Users();
            try
            {
                IDbDataParameter[] arrParameter = new IDbDataParameter[]{
                     DB_UTILITY.CreateParameter("@iMailId",DbType.String, ParameterDirection.Input,UserMailID),
                     DB_UTILITY.CreateParameter("@iPassword", DbType.String, ParameterDirection.Input,Password)
             };
                dtuser = DB_UTILITY.RunSP("USP_FETCH_USERSLOGIN", arrParameter);
                if (ValidateResultSet(dtuser))
                {
                    _users = OBJECT_UTILITY.GetConvert<Users>(dtuser.Tables[0]);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _users;
        }
    }
}
