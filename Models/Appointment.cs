using System;

namespace dotnetapp.Models
{
public class Appointment
{
    public int Appointmentid { get; set; }
    public string? Patientname { get; set; }
    public string? Doctorname { get; set; }
    public DateTime? AppointmentDate { get; set; }
    public TimeSpan? StartTime { get; set; }
    public TimeSpan? EndTime { get; set; }
    public string? Reason { get; set; }
}
}