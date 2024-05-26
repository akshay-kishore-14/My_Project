using MyProject.Models;
using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Owin.Security.Provider;


public class UserDataAccessLayer
{
    string connection = Connection.CName;

    public IEnumerable<UserView> GetAllUser()
    {
        UserView user = new UserView();
        List<UserView> lstUser = new List<UserView>();
        using (SqlConnection con = new SqlConnection(connection))
        {
            SqlCommand cmd = new SqlCommand("GetAllUser", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            SqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                UserView user1 = new UserView()
                {
                    Id = rdr.GetInt32("Id"),
                    FirstName = rdr["FirstName"].ToString(),
                    LastName = rdr["LastName"].ToString(),
                    Email = rdr["Email"].ToString(),
                    FilePath = rdr["FilePath"].ToString()
                };
                lstUser.Add(user1);
            }
            con.Close();
        }
        return lstUser;
    }

    public void DeleteUser(int? Id)
    {
        using (SqlConnection con = new SqlConnection(connection))
        {
            SqlCommand cmd = new SqlCommand("DeleteUser", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", Id);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}