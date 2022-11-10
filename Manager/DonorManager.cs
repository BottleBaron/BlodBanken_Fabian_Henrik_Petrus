namespace BlodBanken_Fabian_Henrik_Petrus;

class DonorManager
{
    // Change this to appeal to crud structure 
     public List<Donor> GetDonors(int bloodType)
    {
        List<Donor> foundDonors = SQLWriter.sp_SelectTable<Donor>("*", $"donors WHERE blood_type = {bloodType}");
        return foundDonors;
    }
}