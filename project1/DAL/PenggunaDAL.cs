using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Security.Cryptography; //untuk membuat password md5
using project1.Models;
using System.Data.SqlClient;
using System.Text;

namespace project1.DAL
{
    public class PenggunaDAL
    {
        private string GEtConnStr()
        {
            return @"Data Source=.\SQLEXPRESS;Initial Catalog=Sample;Integrated Security=True";

        }
        
        public string GetMD5Hash(string password)
        {

            UnicodeEncoding unicode = new UnicodeEncoding();
            byte[] dataHash = unicode.GetBytes(password);
            MD5 md5 = new MD5CryptoServiceProvider();
            var hasil = md5.ComputeHash(dataHash);
            return Convert.ToBase64String(hasil);
        }

        public void Refistrasi(Pengguna pengguna)
        {
            using (SqlConnection conn = new SqlConnection(GEtConnStr()))
            {
                string strSql = @"insert into Pengguna(Username,Password,Aturan) values (@Username,@Password,@Aturan)";
                SqlCommand cmd = new SqlCommand(strSql, conn);
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("Username", pengguna.Username);
                cmd.Parameters.AddWithValue("Password", GetMD5Hash(pengguna.Password));
                cmd.Parameters.AddWithValue("Aturan",pengguna.Email);

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    throw new Exception(ex.Number.ToString() + " - " + ex.Message);
                }
            }
        }
    }
}