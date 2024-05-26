using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.VisualBasic;
using MyProject.Models;
using System.Data;

public class UserController : Controller
{
    List<CountryDetails> GetCountryList = new List<CountryDetails>();
    List<StateDetails> GetStateList = new List<StateDetails>(); 
    List<CityDetails> GetCityList = new List<CityDetails>();
    private readonly IWebHostEnvironment webHostEnvironment;
    public static object? fl;

    public UserController(IWebHostEnvironment hostEnvironment)
    {
        UserDataAccessLayer = new UserDataAccessLayer();
        webHostEnvironment = hostEnvironment;
    }

    readonly UserDataAccessLayer UserDataAccessLayer;

    public new ActionResult User()
    {
        return View();
    }

    public ActionResult Submit(UserView user)
    {
        try
        { 

            return RedirectToAction(nameof(ShowData));
        }
        catch
        {
            return View();
        }
    }

    public ActionResult Edit(int Id)
    {
        UserView user = new UserView();
        using (SqlConnection con = new SqlConnection(Connection.CName))
        {
            SqlCommand cmd = new SqlCommand("ShowUserDetails", con);
            cmd.Parameters.AddWithValue("@Id", Id);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            SqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                user.Id = Convert.ToInt32(rdr["Id"]);
                user.FirstName = rdr["FirstName"].ToString();
                user.LastName = rdr["LastName"].ToString();
                user.Email = rdr["Email"].ToString();
                user.Country = rdr["Country"].ToString();
                user.State = rdr["State"].ToString();
                user.City = rdr["City"].ToString();
                user.Phone = Convert.ToInt64(rdr["Phone"]);
                user.Password = rdr["Password"].ToString();
                user.FilePath = rdr["FilePath"].ToString();
            }
            con.Close();
        }
        fl = user.FilePath;

        if (user.Country == "India")
        {
            ViewBag.Country = new SelectList(
         new List<SelectListItem>
            {
            new SelectListItem { Value = "0", Text = "India" },
            new SelectListItem { Value = "1", Text = "Pakistan" },
            new SelectListItem { Value = "2", Text = "USA" },
        }, "Value", "Text");

            if (user.State == "U.P")
            {
                ViewBag.State = new SelectList(
         new List<SelectListItem>
            {
            new SelectListItem { Value = "0", Text = "U.P" },
            new SelectListItem { Value = "1", Text = "Kerala" },
            new SelectListItem { Value = "2", Text = "Kasmir" },
        }, "Value", "Text");

                if (user.City == "Kanpur")
                {
                    ViewBag.City = new SelectList(
         new List<SelectListItem>
            {
            new SelectListItem { Value = "0", Text = "Kanpur" },
            new SelectListItem { Value = "1", Text = "Dg" },
        }, "Value", "Text");
                }

                else
                {
                    ViewBag.City = new SelectList(
         new List<SelectListItem>
            {
            new SelectListItem { Value = "0", Text = "Dg" },
            new SelectListItem { Value = "1", Text = "Kanpur" },
        }, "Value", "Text");
                }
            }

            else if (user.State == "Kerala")
            {
                ViewBag.State = new SelectList(
         new List<SelectListItem>
            {
            new SelectListItem { Value = "0", Text = "Kerala" },
            new SelectListItem { Value = "1", Text = "U.P" },
            new SelectListItem { Value = "2", Text = "Kasmir" },
        }, "Value", "Text");

                if (user.City == "Pal")
                {
                    ViewBag.City = new SelectList(
         new List<SelectListItem>
            {
            new SelectListItem { Value = "0", Text = "Pal" },
            new SelectListItem { Value = "1", Text = "Tri" },
        }, "Value", "Text");
                }

                else
                {

                    ViewBag.State = new SelectList(
             new List<SelectListItem>
                {
            new SelectListItem { Value = "0", Text = "Tri" },
            new SelectListItem { Value = "1", Text = "Pal" },
            }, "Value", "Text");

                }
            }

            else
            {
                ViewBag.State = new SelectList(
         new List<SelectListItem>
            {
            new SelectListItem { Value = "0", Text = "Kasmir" },
            new SelectListItem { Value = "1", Text = "U.P" },
            new SelectListItem { Value = "2", Text = "Kerala" },
        }, "Value", "Text");

                if (user.City == "Jammu")
                {
                    ViewBag.City = new SelectList(
         new List<SelectListItem>
            {
            new SelectListItem { Value = "0", Text = "Jammu" },
            new SelectListItem { Value = "1", Text = "Manali" },
        }, "Value", "Text");
                }
                else
                {
                    ViewBag.City = new SelectList(
         new List<SelectListItem>
            {
            new SelectListItem { Value = "0", Text = "Manali" },
            new SelectListItem { Value = "1", Text = "Jammu" },
        }, "Value", "Text");
                }
            }
        }
        else if (user.Country == "Pakistan")
        {
            ViewBag.Country = new SelectList(
            new List<SelectListItem>
            {
            new SelectListItem { Value = "1", Text = "Pakistan" },
            new SelectListItem { Value = "0", Text = "India" },
            new SelectListItem { Value = "2", Text = "USA" },
           }, "Value", "Text");

            if (user.State == "Punjab")
            {
                ViewBag.State = new SelectList(
            new List<SelectListItem>
            {
            new SelectListItem { Value = "0", Text = "Punjab" },
            new SelectListItem { Value = "1", Text = "Baluchistan" },
            new SelectListItem { Value = "2", Text = "Sind" },
           }, "Value", "Text");

                if (user.City == "Lahore")
                {
                    ViewBag.City = new SelectList(
           new List<SelectListItem>
           {
            new SelectListItem { Value = "0", Text = "Lahore" },
            new SelectListItem { Value = "1", Text = "Faisalabad" },
          }, "Value", "Text");
                }

                else
                {
                    ViewBag.City = new SelectList(
           new List<SelectListItem>
           {
            new SelectListItem { Value = "0", Text = "Faisalabad" },
            new SelectListItem { Value = "1", Text = "Lahore" },
          }, "Value", "Text");
                }
            }

            else if (user.State == "Baluchistan")
            {
                ViewBag.State = new SelectList(
            new List<SelectListItem>
            {
            new SelectListItem { Value = "0", Text = "Baluchistan" },
            new SelectListItem { Value = "1", Text = "Punjab" },
            new SelectListItem { Value = "2", Text = "Sind" },
           }, "Value", "Text");

                if (user.City == "Quetta")
                {
                    ViewBag.City = new SelectList(
            new List<SelectListItem>
            {
            new SelectListItem { Value = "0", Text = "Quetta" },
            new SelectListItem { Value = "1", Text = "Nasirabad" },
           }, "Value", "Text");
                }

                else
                {
                    ViewBag.City = new SelectList(
            new List<SelectListItem>
            {
            new SelectListItem { Value = "0", Text = "Nasirabad" },
            new SelectListItem { Value = "1", Text = "Quetta" },
           }, "Value", "Text");
                }
            }

            else
            {
                if (user.City == "Krachi")
                {
                    ViewBag.City = new SelectList(
                new List<SelectListItem>
                {
            new SelectListItem { Value = "1", Text = "Krachi" },
            new SelectListItem { Value = "0", Text = "Mirpur khas" },
               }, "Value", "Text");
                }

                else
                {
                    ViewBag.City = new SelectList(
                new List<SelectListItem>
                {
            new SelectListItem { Value = "1", Text = "Mirpur khas" },
            new SelectListItem { Value = "0", Text = "Krachi" },
               }, "Value", "Text");
                }
            }

        }
        else
        {
            ViewBag.Country = new SelectList(
        new List<SelectListItem>
        {
            new SelectListItem { Value = "2", Text = "USA" },
            new SelectListItem { Value = "0", Text = "India" },
            new SelectListItem { Value = "1", Text = "Pakistan" },
        }, "Value", "Text");

            if (user.State == "Colorado")
            {
                ViewBag.State = new SelectList(
        new List<SelectListItem>
        {
            new SelectListItem { Value = "2", Text = "Colorado" },
            new SelectListItem { Value = "0", Text = "Delaware" },
            new SelectListItem { Value = "1", Text = "Georgia" },
        }, "Value", "Text");

                if (user.City == "Alabama")
                {
                    ViewBag.City = new SelectList(
        new List<SelectListItem>
        {
            new SelectListItem { Value = "2", Text = "Alabama" },
            new SelectListItem { Value = "0", Text = "Arizona" },
        }, "Value", "Text");
                }

                else
                {
                    ViewBag.City = new SelectList(
        new List<SelectListItem>
        {
            new SelectListItem { Value = "2", Text = "Arizona" },
            new SelectListItem { Value = "0", Text = "Alabama" },
        }, "Value", "Text");
                }
            }

            else if (user.State == "Delaware")
            {
                ViewBag.State = new SelectList(
        new List<SelectListItem>
        {
            new SelectListItem { Value = "2", Text = "Delaware" },
            new SelectListItem { Value = "0", Text = "Colorado" },
            new SelectListItem { Value = "1", Text = "Georgia" },
        }, "Value", "Text");

                if (user.City == "Bellefonte")
                {
                    ViewBag.City = new SelectList(
        new List<SelectListItem>
        {
            new SelectListItem { Value = "2", Text = "Bellefonte" },
            new SelectListItem { Value = "0", Text = "Felton" },
        }, "Value", "Text");
                }

                else
                {
                    ViewBag.City = new SelectList(
        new List<SelectListItem>
        {
            new SelectListItem { Value = "2", Text = "Felton" },
            new SelectListItem { Value = "0", Text = "Bellefonte" },
        }, "Value", "Text");
                }
            }

            else
            {
                ViewBag.State = new SelectList(
        new List<SelectListItem>
        {
            new SelectListItem { Value = "2", Text = "Georgia" },
            new SelectListItem { Value = "0", Text = "Colorado" },
            new SelectListItem { Value = "1", Text = "Delaware" },
        }, "Value", "Text");

                if (user.City == "Rustavi")
                {
                    ViewBag.City = new SelectList(
        new List<SelectListItem>
        {
            new SelectListItem { Value = "2", Text = "Rustavi" },
            new SelectListItem { Value = "0", Text = "Kobulati" },
        }, "Value", "Text");
                }

                else
                {
                    ViewBag.City = new SelectList(
        new List<SelectListItem>
        {
            new SelectListItem { Value = "2", Text = "Kobulati" },
            new SelectListItem { Value = "0", Text = "Rustavi" },
        }, "Value", "Text");
                }
            }
        }

        return View(user);
    }

    public ActionResult Delete(int Id)
    {
        UserView user = new UserView();
        using (SqlConnection con = new SqlConnection(Connection.CName))
        {
            SqlCommand cmd = new SqlCommand("ShowUserDetails", con);
            cmd.Parameters.AddWithValue("@Id", Id);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            SqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                user.Id = Convert.ToInt32(rdr["Id"]);
                user.FirstName = rdr["FirstName"].ToString();
                user.LastName = rdr["LastName"].ToString();
                user.Email = rdr["Email"].ToString();
                user.Country = rdr["Country"].ToString();
                user.State = rdr["State"].ToString();
                user.City = rdr["City"].ToString();
                user.Phone = Convert.ToInt64(rdr["Phone"]);
                user.FilePath = rdr["FilePath"].ToString();
            }
            con.Close();
        }
        return View(user);
    }

    public JsonResult DeleteUser(UserView user)
    {
            UserDataAccessLayer.DeleteUser(user.Id);
            return Json("Success");
    }

    public ActionResult Details(int Id)
    {
        UserView user = new UserView();
        using (SqlConnection con = new SqlConnection(Connection.CName))
        {
            SqlCommand cmd = new SqlCommand("ShowUserDetails", con);
            cmd.Parameters.AddWithValue("@Id", Id);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            SqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                user.Id = Convert.ToInt32(rdr["Id"]);
                user.FirstName = rdr["FirstName"].ToString();
                user.LastName = rdr["LastName"].ToString();
                user.Email = rdr["Email"].ToString();
                user.Country = rdr["Country"].ToString();
                user.State = rdr["State"].ToString();
                user.City = rdr["City"].ToString();
                user.Phone = Convert.ToInt64(rdr["Phone"]);
                user.FilePath = rdr["FilePath"].ToString();
            }
            con.Close();
        }
        return View(user);
    }

    public ActionResult EmptyTable()
    {
        return View();
    }

    public ActionResult ShowData()
    {
        IEnumerable<UserView> user = UserDataAccessLayer.GetAllUser();
        var l = user.ToList();
        if (l.Count == 0)
        {
            return RedirectToAction(nameof(EmptyTable));
        }
        else
        {
            return View(user);
        }
    }

    public List<CountryDetails>? CountryDataList()
    {

        try
        {
            using (SqlConnection conn = new SqlConnection(Connection.CName))
            {
                conn.Open();
                using (SqlCommand command = new SqlCommand("GetCountry", conn))
                {

                    command.CommandType = CommandType.StoredProcedure;
                    //command.Parameters.AddWithValue("@subverticaloptionid", SubVerticalOptions);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        GetCountryList.Add(new CountryDetails()
                        {
                            CountryName = reader["Country"].ToString()
                        });
                    }
                    reader.Close();
                    conn.Close();
                }
            }

            return GetCountryList;
        }
        catch (Exception)
        {
            //ActivityLog(User.FindFirst(System.Security.Claims.ClaimTypes.Email)?.Value, "", "Compliance_GetCluster", ex.Message, ex.InnerException != null ? ex.InnerException.ToString() : "");
            return null;
        }
    }

    public List<StateDetails>? StateDataList(string val)
    {

        CountryDetails cn = new CountryDetails();
        try
        {

            using (SqlConnection conn = new SqlConnection(Connection.CName))
            {
                conn.Open();
                using (SqlCommand command = new SqlCommand("GetState", conn))
                {

                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@countryname", val);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        GetStateList.Add(new StateDetails()
                        {
                            StateName = reader["State"].ToString()
                        });
                    }
                    reader.Close();
                    conn.Close();
                }
            }

            return GetStateList;
        }
        catch (Exception)
        {
            //ActivityLog(User.FindFirst(System.Security.Claims.ClaimTypes.Email)?.Value, "", "Compliance_GetCluster", ex.Message, ex.InnerException != null ? ex.InnerException.ToString() : "");
            return null;
        }
    }

    public List<CityDetails>? CityDataList(string val)
    {

        CountryDetails cn = new CountryDetails();
        try
        {

            using (SqlConnection conn = new SqlConnection(Connection.CName))
            {
                conn.Open();
                using (SqlCommand command = new SqlCommand("GetCity", conn))
                {

                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@statename", val);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        GetCityList.Add(new CityDetails()
                        {
                            CityName = reader["City"].ToString()
                        });
                    }
                    reader.Close();
                    conn.Close();
                }
            }

            return GetCityList;
        }
        catch (Exception)
        {
            //ActivityLog(User.FindFirst(System.Security.Claims.ClaimTypes.Email)?.Value, "", "Compliance_GetCluster", ex.Message, ex.InnerException != null ? ex.InnerException.ToString() : "");
            return null;
        }
    }

    public JsonResult? AddUser(UserView user)
    {
        try {
            var uniqueFileName = UploadedFile(user.Image);

            using (SqlConnection con = new SqlConnection(Connection.CName))
            {
                SqlCommand cmd = new SqlCommand("AddUser", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@FirstName", user.FirstName);
                cmd.Parameters.AddWithValue("@LastName", user.LastName);
                cmd.Parameters.AddWithValue("@Email", user.Email);
                cmd.Parameters.AddWithValue("@Country", user.Country);
                cmd.Parameters.AddWithValue("@State", user.State);
                cmd.Parameters.AddWithValue("@City", user.City);
                cmd.Parameters.AddWithValue("@Phone", user.Phone);
                cmd.Parameters.AddWithValue("@Password", user.Password);
                cmd.Parameters.AddWithValue("@FilePath", uniqueFileName);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }

            return Json("Success");
        }
        catch(Exception)
        {
            return null;
        }
    }

    public JsonResult? UpdateUser(UserView user)
    {
        try
        {
            var uniqueFileName = UploadedFile(user.Image);
            if (uniqueFileName == "~/UserImage/")
            {
                uniqueFileName = (string?)fl;
            }
            using (SqlConnection con = new SqlConnection(Connection.CName))
            {
                SqlCommand cmd = new SqlCommand("UpdateUser", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Id", user.Id);
                cmd.Parameters.AddWithValue("@FirstName", user.FirstName);
                cmd.Parameters.AddWithValue("@LastName", user.LastName);
                cmd.Parameters.AddWithValue("@Email", user.Email);
                cmd.Parameters.AddWithValue("@Country", user.Country);
                cmd.Parameters.AddWithValue("@State", user.State);
                cmd.Parameters.AddWithValue("@City", user.City);
                cmd.Parameters.AddWithValue("@Phone", user.Phone);
                cmd.Parameters.AddWithValue("@Password", user.Password);
                cmd.Parameters.AddWithValue("@FilePath", uniqueFileName);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }

            return Json("Success");
        }
        catch (Exception)
        {
            return null;
        }
    }

    private string UploadedFile(IFormFile img)
    {
        string? uniqueFileName = null;

        if (img != null)
        {
            string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "UserImage");
            uniqueFileName = Guid.NewGuid().ToString() + "_" + img.FileName;
            string filePath = Path.Combine(uploadsFolder, uniqueFileName);
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                img.CopyTo(fileStream);
            }
        }

        return "~/UserImage/" + uniqueFileName;
    }
    [HttpPost]
    public JsonResult? Login(UserView user)
    {
        try
        {
            using (SqlConnection con = new SqlConnection(Connection.CName))
            {
                SqlCommand cmd = new SqlCommand("CheckLogin", con);
                cmd.Parameters.AddWithValue("@user_email", user.check_email);
                cmd.Parameters.AddWithValue("@user_pass", user.check_pass);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    user.Email = rdr["Email"].ToString();
                    user.Password = rdr["Password"].ToString();
                }
                con.Close();
            }

            if (user.Email != null & user.Password != null)
            {
                return Json("Success");
            }
            else
            {
                return Json("Email Id not found or Incorrect Credential");
            }
        }
        catch (Exception)
        {
            return null;
        }
    }

    public JsonResult EmailValidate(UserView user)
    {
        using (SqlConnection con = new SqlConnection(Connection.CName))
        {
            SqlCommand cmd = new SqlCommand("EmailValidation", con);
            cmd.Parameters.AddWithValue("@Email_valid", user.email_valid);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            SqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                user.Email = rdr["Email"].ToString();
            }
            con.Close();

            if (user.Email == null)
            {
                return Json("Not Found");
            }
            else
            {
                return Json("Found");
            }
            
        }
    }
}
