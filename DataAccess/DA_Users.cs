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
        /// <summary>
        /// Description :Insert User into Database 
        /// Name:AjayKumar J
        /// </summary>
        public Users CreateUser(Users usr)
        {
            Users _user = null;
            try
            {
                IDbDataParameter[] arrparams = new IDbDataParameter[]{
                    DB_UTILITY.CreateParameter("@ic_FirstName",DbType.String,ParameterDirection.Input,usr.FirstName),
                    DB_UTILITY.CreateParameter("@ic_LastName",DbType.String,ParameterDirection.Input,usr.LastName),
                    DB_UTILITY.CreateParameter("@ic_MailID",DbType.String,ParameterDirection.Input,usr.MailID),
                    DB_UTILITY.CreateParameter("@ic_Password",DbType.String,ParameterDirection.Input,getRandomAlphaNumericstring()),
                    DB_UTILITY.CreateParameter("@ic_ContactNumber",DbType.String,ParameterDirection.Input,usr.ContactNumber),
                    DB_UTILITY.CreateParameter("@ic_Role",DbType.Int16,ParameterDirection.Input,"1"),
                };
                dsResultSet = DB_UTILITY.RunSP("USP_INSERT_NEWUSER", arrparams);
                if (ValidateResultSet(dsResultSet))
                {
                    _user = OBJECT_UTILITY.GetConvert<Users>(dsResultSet.Tables[0]);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _user;
        }
        public string getRandomAlphaNumericstring()
        {
            string PasswordLength = "8";
            string NewPassword = "";
            string allowedChars = "";
            allowedChars += "1,2,3,4,5,6,7,8,9,0";
            allowedChars += "A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z,";
            allowedChars += "a,b,c,d,e,f,g,h,i,j,k,l,m,n,o,p,q,r,s,t,u,v,w,x,y,z,";
            char[] sep = { ',' };
            string[] arr = allowedChars.Split(sep);
            string IDString = "";
            string temp = "";
            Random rand = new Random();
            for (int i = 0; i < Convert.ToInt32(PasswordLength); i++)
            {
                temp = arr[rand.Next(0, arr.Length)];
                IDString += temp;
                NewPassword = IDString;
            }
            return NewPassword;
        }
    }
}
