using System.Runtime.CompilerServices;

namespace BlodBanken_Fabian_Henrik_Petrus;

public class Booking
{
    // DataBase Properties
    public int Id { get; }
    public int DonorId { get; set; }
    public int StaffId { get; set; }
    public DateTime AppointmentDate { get; set; }
    public bool IsDone { get; set; }

    // Runtime Properties
    public string DonorName { get; set; }
    public string StaffName { get; set; }

    public void GetNameValues()
    {
        StaffDB staffDb = new();
        DonorDB donorDb = new();
        Donor d = donorDb.SelectDonor(DonorId);
        Staff s = staffDb.SelectStaff(StaffId);

        this.DonorName = d.Name;
        this.StaffName = s.Name;
    }
     
    public override string ToString()
    {
        return $"{Id} {DonorId}:{DonorName} {StaffId}:{StaffName} {AppointmentDate} {IsDone}";
    }
}