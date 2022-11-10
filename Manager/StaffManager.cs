namespace BlodBanken_Fabian_Henrik_Petrus;

class StaffManager
{
    public Staff TryLogin(string loginName, string passWord)
    {
        List<Staff> allStaffList = SQLWriter.sp_SelectTable<Staff>("*", "staff");

        foreach (var staff in allStaffList)
        {
            if(loginName == staff.login_name && passWord == staff.password) return staff;
        }

        return null;
    }
}