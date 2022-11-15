namespace BlodBanken_Fabian_Henrik_Petrus;

internal class StaffManager
{
    private StaffDB _staffDb = new();
    
    public Staff TryLogin(string loginName, string passWord)
    {
        List<Staff> residentStaff = _staffDb.Read(); 
    
        foreach (var staff in residentStaff)
        {
            if(loginName == staff.login_name && passWord == staff.password) return staff;
        }
    
        return null;
    }
}