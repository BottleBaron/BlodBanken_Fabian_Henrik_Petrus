namespace BlodBanken_Fabian_Henrik_Petrus;

internal class DonorManager
{
    private DonorDB _donorDb = new();

    // Change this to appeal to crud structure 
    //public List<Donor> GetDonors(int bloodType)

    //List<Donor> foundDonors = SQLWriter.sp_SelectTable<Donor>("*", $"donors WHERE blood_type = {bloodType}");
    //return foundDonors;


    public bool ValidateName(string name)
    {
        //Checks that the name contains a blankspace and is more than 5 characters long. 
        //Expand method to check for upper case etc. 
        if (name.Contains(' ') && name.Count() > 5)
        {
            return true;
        }
        return false;
    }


    public bool ValidateAddress(string[] address)
    {
        //Checks that the fields are not empty. 
        if (address[0].Length > 0 && address[1].Length > 0 && address[2].Length > 0)
        {
            //Checks that the zip code is 5 digits long. Must adhere to format XXXXXX
            if (address[1].Length == 5 && address[1].All(char.IsDigit))
            {
                return true;
            }
        }
        return false;
    }


    public bool ValidatePhoneNumber(string phoneNumber)
    {
        //Checks that the phonenumber only contains digits and more than 8 digits. 
        if (phoneNumber.All(Char.IsDigit) == true && phoneNumber.Length > 8)
        {
            return true;
        }
        return false;
    }


    public bool ValidateDateOfBirth(string dateOfBirth)
    {
        if (DateTime.TryParse(dateOfBirth, out DateTime result)) return true;

        return false;
    }


    public bool ValidateBloodGroup(char keyPress)
    {
        if (Int32.TryParse(keyPress.ToString(), out int bloodType))
        {
            if (bloodType >= 1 && bloodType <= 8)
            {
                return true;
            }
        }
        return false;
    }
    
    public int SaveDonorToDB(Donor newDonor)
    {
        int savedDonorId;
        savedDonorId = _donorDb.Create(newDonor);
        return savedDonorId;
    }

    public Donor SelectDonor(int id)
    {
        Donor donor = _donorDb.SelectDonor(id);
        return donor;
    }

    public List <Donor> GetDonorByBloodType(int bloodType)
    {
        List <Donor> donorList = _donorDb.GetDonorByBloodType(bloodType);
        return donorList;
    }
}