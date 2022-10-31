using System;
using System.Data;
using System.Data.SqlClient;

namespace gebzedemo.Models
{

    public class IletisimDb
    {

        SqlConnection con = new SqlConnection("Data Source=DESKTOP-4JD2R8F\\TEW_SQLEXPRESS;Database=gezgebze; User ID=sa;Password=enesusta; Integrated Security=True");

        public string SaveRecord(IletisimSend iletisimSend)
        {
            try
            {

                SqlCommand com = new SqlCommand("iletisimEkle", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@name", iletisimSend.Name);
                com.Parameters.AddWithValue("@surname", iletisimSend.Surname);
                com.Parameters.AddWithValue("@phone", iletisimSend.Phone);
                com.Parameters.AddWithValue("@message", iletisimSend.Message);
                com.Parameters.AddWithValue("@email", iletisimSend.Email);
                con.Open();
                com.ExecuteNonQuery();
                con.Close();
                return ("Iletisim Formu Basariyla Gonderildi");
            }
            catch (Exception ex)
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                return (ex.Message.ToString());
            }
        }


    }
}
