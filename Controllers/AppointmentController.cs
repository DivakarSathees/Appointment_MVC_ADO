// using System;
// using System.Collections.Generic;
// using System.Diagnostics;
// using System.Linq;
// using System.Threading.Tasks;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.Extensions.Logging;
// using dotnetapp.Models;
// using System.Data;
// using Microsoft.Data.SqlClient;

// public class AppointmentController : Controller
// {
//     private string connectionString = "User ID=sa;password=examlyMssql@123;server=dfeafccbbabafefbcfacbdcbaeadbebabcdebdca-0;Database=AppointmentDB;trusted_connection=false;Persist Security Info=False;Encrypt=False";

//     public ActionResult Index()
//     {
//         List<Appointment> appointments = new List<Appointment>();
// try
// {
//         using (SqlConnection connection = new SqlConnection(connectionString))
//         {
//             string query = "SELECT * FROM Appointment";

//             using (SqlCommand command = new SqlCommand(query, connection))
//             {
//                 connection.Open();

//                 SqlDataReader reader = command.ExecuteReader();

//                 while (reader.Read())
//                 {
//                     Appointment appointment = new Appointment();

//                     appointment.Appointmentid = Convert.ToInt32(reader["Appointmentid"]);
//                     appointment.Patientname = reader["Patientname"].ToString();
//                     appointment.Doctorname = reader["Doctorname"].ToString();
//                     appointment.AppointmentDate = Convert.ToDateTime(reader["AppointmentDate"]);
//                     appointment.StartTime = TimeSpan.Parse(reader["StartTime"].ToString());
//                     appointment.EndTime = TimeSpan.Parse(reader["EndTime"].ToString());
//                     appointment.Reason = reader["Reason"].ToString();
//                     appointments.Add(appointment);
//                 }

//                 reader.Close();
//             }
//         }
// }
// catch(Exception ex)
// {
//     Console.WriteLine(ex.Message);
// }
//         return View(appointments);

//     }

//     public ActionResult Create()
//     {
//         return View();
//     }

//     [HttpPost]
//     public ActionResult Create(Appointment appointment)
//     {
//         using (SqlConnection connection = new SqlConnection(connectionString))
//         {
//             string query = "INSERT INTO Appointment (Doctorname, Patientname, Appointmentdate, StartTime, Endtime, reason) VALUES (@Doctorname, @Patientname, @AppointmentDate, @StartTime, @EndTime, @Reason)";

//             using (SqlCommand command = new SqlCommand(query, connection))
//             {
//                 // command.Parameters.AddWithValue("@id", Book.id);
//                 command.Parameters.AddWithValue("@Doctorname", appointment.Doctorname);
//                 command.Parameters.AddWithValue("@Patientname", appointment.Patientname);
//                 command.Parameters.AddWithValue("@AppointmentDate", appointment.AppointmentDate);
//                 command.Parameters.AddWithValue("@StartTime", appointment.StartTime);
//                 command.Parameters.AddWithValue("@EndTime", appointment.EndTime);
//                 command.Parameters.AddWithValue("@Reason", appointment.Reason);


//                 connection.Open();

//                 command.ExecuteNonQuery();
//             }
//         }

//         return RedirectToAction("Index");
//     }


//     public ActionResult Edit(int id)
//     {
//     Appointment appointment = new Appointment();

//     using (SqlConnection connection = new SqlConnection(connectionString))
//     {
//         // Console.WriteLine(@Appointmentid);
//         string query = "SELECT * FROM Appointment WHERE Appointmentid = @Appointmentid";

//         using (SqlCommand command = new SqlCommand(query, connection))
//         {
//             command.Parameters.AddWithValue("@Appointmentid", id);

//             connection.Open();

//             SqlDataReader reader = command.ExecuteReader();

//             while (reader.Read())
//             {
//                     appointment.Appointmentid = Convert.ToInt32(reader["Appointmentid"]);
//                     appointment.Patientname = reader["Patientname"].ToString();
//                     appointment.Doctorname = reader["Doctorname"].ToString();
//                     appointment.AppointmentDate = Convert.ToDateTime(reader["AppointmentDate"]);
//                     appointment.StartTime = TimeSpan.Parse(reader["StartTime"].ToString());
//                     appointment.EndTime = TimeSpan.Parse(reader["EndTime"].ToString());
//                     appointment.Reason = reader["Reason"].ToString();
//             }

//             reader.Close();
//         }
//     }

//     return View(appointment);
// }

//     [HttpPost]
//     public ActionResult Edit(Appointment appointment)
//     {
//         using (SqlConnection connection = new SqlConnection(connectionString))
//         {
// string query = "UPDATE Appointment SET Patientname = @Patientname, Doctorname = @Doctorname, Appointmentdate = @AppointmentDate, StartTime = @StartTime, EndTime = @Endtime, reason = @Reason WHERE Appointmentid = @Appointmentid";

//             using (SqlCommand command = new SqlCommand(query, connection))
//             {
//                 command.Parameters.AddWithValue("@Appointmentid", appointment.Appointmentid);

//                 Console.WriteLine(appointment.Appointmentid);
//                 command.Parameters.AddWithValue("@Doctorname", appointment.Doctorname);
//                  Console.WriteLine(appointment.Doctorname);
//                 command.Parameters.AddWithValue("@Patientname", appointment.Patientname);
//                 command.Parameters.AddWithValue("@AppointmentDate", appointment.AppointmentDate);
//                 command.Parameters.AddWithValue("@StartTime", appointment.StartTime);
//                 command.Parameters.AddWithValue("@EndTime", appointment.EndTime);
//                 command.Parameters.AddWithValue("@Reason", appointment.Reason);

//                 connection.Open();

//                 command.ExecuteNonQuery();
//             }
//         }

//         return RedirectToAction("Index");
//     }

   

//     public ActionResult Delete(int id)
//     {
//     using (SqlConnection connection = new SqlConnection(connectionString))
//     {
//         string query = "DELETE FROM Appointment WHERE Appointmentid = @Appointmentid";

//         using (SqlCommand command = new SqlCommand(query, connection))
//         {
//             command.Parameters.AddWithValue("@Appointmentid", id);

//             connection.Open();

//             command.ExecuteNonQuery();
//         }
//     }

//     return RedirectToAction("Index");
//     }


// }


using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using dotnetapp.Models;
using System.Data;
using Microsoft.Data.SqlClient;

public class AppointmentController : Controller
{
    private string connectionString = "User ID=sa;password=examlyMssql@123;server=dffafdafebcfacbdcbaeadbebabcdebdca-0;Database=AppointmentDB;trusted_connection=false;Persist Security Info=False;Encrypt=False";

    public ActionResult Index()
    {
        // List<Appointment> appointments = new List<Appointment>();
try
{
        List<Appointment> appointments = new List<Appointment>();

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string query = "SELECT * FROM Appointment";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Appointment appointment = new Appointment();

                    appointment.Appointmentid = Convert.ToInt32(reader["Appointmentid"]);
                    appointment.Patientname = reader["Patientname"].ToString();
                    appointment.Doctorname = reader["Doctorname"].ToString();
                    appointment.AppointmentDate = Convert.ToDateTime(reader["AppointmentDate"]);
                    appointment.StartTime = TimeSpan.Parse(reader["StartTime"].ToString());
                    appointment.EndTime = TimeSpan.Parse(reader["EndTime"].ToString());
                    appointment.Reason = reader["Reason"].ToString();
                    appointments.Add(appointment);
                }

                reader.Close();
            }
        }
        return View(appointments);

}
catch(Exception ex)
{
    Console.WriteLine(ex.Message);
            return BadRequest("An error occurred while retrieving the furniture item.");

}
        // return View(appointments);

    }

    public ActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public ActionResult Create(Appointment appointment)
    {
        try{
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string query = "INSERT INTO Appointment (Doctorname, Patientname, Appointmentdate, StartTime, Endtime, reason) VALUES (@Doctorname, @Patientname, @AppointmentDate, @StartTime, @EndTime, @Reason)";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                // command.Parameters.AddWithValue("@id", Book.id);
                command.Parameters.AddWithValue("@Doctorname", appointment.Doctorname);
                command.Parameters.AddWithValue("@Patientname", appointment.Patientname);
                command.Parameters.AddWithValue("@AppointmentDate", appointment.AppointmentDate);
                command.Parameters.AddWithValue("@StartTime", appointment.StartTime);
                command.Parameters.AddWithValue("@EndTime", appointment.EndTime);
                command.Parameters.AddWithValue("@Reason", appointment.Reason);


                connection.Open();

                command.ExecuteNonQuery();
            }
        }
        }
        catch(Exception ex)
{
    Console.WriteLine(ex.Message);
            return BadRequest("An error occurred while creating the appointment item.");

}


        return RedirectToAction("Index");
    }


//     public ActionResult Edit(int id)
//     {
//         try{
//     Appointment appointment = null;

//     using (SqlConnection connection = new SqlConnection(connectionString))
//     {
//         // Console.WriteLine(@Appointmentid);
//         string query = "SELECT * FROM Appointment WHERE Appointmentid = @Appointmentid";

//         using (SqlCommand command = new SqlCommand(query, connection))
//         {
//             command.Parameters.AddWithValue("@Appointmentid", id);

//             connection.Open();

//             SqlDataReader reader = command.ExecuteReader();

//             while (reader.Read())
//             {
//                 appointment = new Appointment();
//                     appointment.Appointmentid = Convert.ToInt32(reader["Appointmentid"]);
//                     appointment.Patientname = reader["Patientname"].ToString();
//                     appointment.Doctorname = reader["Doctorname"].ToString();
//                     appointment.AppointmentDate = Convert.ToDateTime(reader["AppointmentDate"]);
//                     appointment.StartTime = TimeSpan.Parse(reader["StartTime"].ToString());
//                     appointment.EndTime = TimeSpan.Parse(reader["EndTime"].ToString());
//                     appointment.Reason = reader["Reason"].ToString();
//             }

//             reader.Close();
//         }
//     }
//     if (appointment == null)
//         {
//             return NotFound();
//         }
//     return View(appointment);

//         }
//         catch (Exception ex)
//     {
//         Console.WriteLine(ex.Message);
//         // You can handle the exception as per your requirements (e.g., logging, displaying an error message)
//         return BadRequest("An error occurred while retrieving the furniture item.");
//     }

//     // return View(appointment);
// }

//     [HttpPost]
//     public ActionResult Edit(Appointment appointment)
//     {
//         try{
//         using (SqlConnection connection = new SqlConnection(connectionString))
//         {
// string query = "UPDATE Appointment SET Patientname = @Patientname, Doctorname = @Doctorname, Appointmentdate = @AppointmentDate, StartTime = @StartTime, EndTime = @Endtime, reason = @Reason WHERE Appointmentid = @Appointmentid";

//             using (SqlCommand command = new SqlCommand(query, connection))
//             {
//                 command.Parameters.AddWithValue("@Appointmentid", appointment.Appointmentid);

//                 Console.WriteLine(appointment.Appointmentid);
//                 command.Parameters.AddWithValue("@Doctorname", appointment.Doctorname);
//                  Console.WriteLine(appointment.Doctorname);
//                 command.Parameters.AddWithValue("@Patientname", appointment.Patientname);
//                 command.Parameters.AddWithValue("@AppointmentDate", appointment.AppointmentDate);
//                 command.Parameters.AddWithValue("@StartTime", appointment.StartTime);
//                 command.Parameters.AddWithValue("@EndTime", appointment.EndTime);
//                 command.Parameters.AddWithValue("@Reason", appointment.Reason);

//                 connection.Open();
//                 int rowsAffected = command.ExecuteNonQuery();

//                 if (rowsAffected == 0)
//                 {
//                     // The provided ID does not exist in the Furniture table
//                     return NotFound();
//                 }
//             }
//         }
//         }
//         catch(Exception ex)
// {
//     Console.WriteLine(ex.Message);
// }

//         return RedirectToAction("Index");
//     }

   

    public ActionResult Delete(int id)
    {
        try{
            if (id <= 0)
        {
            return BadRequest();
        }
    using (SqlConnection connection = new SqlConnection(connectionString))
    {
        string query = "DELETE FROM Appointment WHERE Appointmentid = @Appointmentid";

        using (SqlCommand command = new SqlCommand(query, connection))
        {
            command.Parameters.AddWithValue("@Appointmentid", id);

            connection.Open();

            int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected == 0)
                {
                    return NotFound();
                }
        }
    }}
    catch(Exception ex)
{
    Console.WriteLine(ex.Message);
    return BadRequest("An error occurred while deleting the furniture item.");

}

    return RedirectToAction("Index");
    }


}