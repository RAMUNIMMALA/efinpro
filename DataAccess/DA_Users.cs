using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Models;

namespace DataAccess
{
    public class DA_Users : Utility
    {
        Users _user = null;
        public Users CreateUser(Users usr)
        {
            try
            {
                IDbDataParameter[] arrparams = new IDbDataParameter[]{
                    DB_UTILITY.CreateParameter("@ic_FirstName",DbType.String,ParameterDirection.Input,usr.FirstName),
                    DB_UTILITY.CreateParameter("@ic_LastName",DbType.String,ParameterDirection.Input,usr.LastName),
                    DB_UTILITY.CreateParameter("@ic_MailId",DbType.String,ParameterDirection.Input,usr.MailId),
                    DB_UTILITY.CreateParameter("@ic_Password",DbType.String,ParameterDirection.Input,GeneratePassword()),
                    DB_UTILITY.CreateParameter("@ic_ContactNumber",DbType.String,ParameterDirection.Input,usr.ContactNumber),
                    DB_UTILITY.CreateParameter("@ic_Role",DbType.Int16,ParameterDirection.Input,"1"),
                };
                dsresultset = DB_UTILITY.RunSP("USP_INSERT_NEWUSER", arrparams);
                if (ValidateResultSet(dsresultset))
                {
                    _user = OBJECT_UTILITY.GetConvert<Users>(dsresultset.Tables[0]);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _user;
        }
        public string GeneratePassword()
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

