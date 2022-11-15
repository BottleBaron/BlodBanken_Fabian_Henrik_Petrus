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
        if (name.Contains(' ')&& name.Count()>5)
        {
            return true;
        }

        else
        {
            return false;
        }
    }


    public bool ValidateAddress(string [] address)
    {
        
        //Checks that the fields are not empty. 
        if (address[0].Length > 0 && address[1].Length > 0 && address[2].Length > 0)
        {   
            //Checks that the zip code is 5 digits long. 
            if (address[1].Length == 5)
            {
                return true;
            }

            else
            {
                return false;
            }
            
        }

        else
        {
            return false;
        }
    }




     public bool ValidatePhoneNumber(string phoneNumber)
    {
        
        //Checks that the phonenumber only contains digits and more than 8 digits. 
        if (phoneNumber.All(Char.IsDigit)==true && phoneNumber.Length>8)
        {   
           return true;      
        }

        else
        {
            return false;
        }
    }


    public bool ValidateDateOfBirth(string dateOfBirth)
{   
            try
            {
            //Converts string to ints
            int year, month, day;
            year = Convert.ToInt32(dateOfBirth.Substring(0, 4));
            month = Convert.ToInt32(dateOfBirth.Substring(4, 2));
            day = Convert.ToInt32(dateOfBirth.Substring(6, 2));
            
            //Assign ints to a Dateonly. If success the date is correct. 
            DateOnly dateOfBirthDO = new(year,month,day);
            return true;
          

            }
            catch (System.Exception)
            {
                
                return false;
            }                   

}





}
