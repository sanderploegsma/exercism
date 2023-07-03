module BookingUpForBeauty

// The following line is needed to use the DateTime type
open System

let schedule (appointmentDateDescription: string) : DateTime =
    DateTime.Parse(appointmentDateDescription)

let hasPassed (appointmentDate: DateTime) : bool = appointmentDate < DateTime.Now

let isAfternoonAppointment (appointmentDate: DateTime) : bool =
    appointmentDate.Hour >= 12 && appointmentDate.Hour < 18

let description (appointmentDate: DateTime) : string =
    sprintf "You have an appointment on %s." (appointmentDate.ToString())

let anniversaryDate () : DateTime =
    let thisYear = DateTime.Now.Year
    DateTime(2019, 9, 15, 0, 0, 0).AddYears(thisYear - 2019)
