namespace BlodBanken_Fabian_Henrik_Petrus;

internal class BloodUnitManager
{
    private BloodUnitDB _bloodUnitDb = new ();

    public Dictionary<string, int> GetBloodUnitsAmount()
    {
        var bloodTypekey = new BloodTypeKey();
        
        List<BloodUnit> listOfBloodUnits = _bloodUnitDb.Read();
        listOfBloodUnits.Sort(new BloodUnitComparer());
        Dictionary<string, int> bloodUnitDict = new();

        // Initiation: Sets 'current blood type' to first entry in 'list of blood units'
        // Adds the corresponding bloodtype name to the dictionary
        
        // Loop: Checks the current iteration of bloodUnits' 'blood_type' against currentBT
        // If ! match: add a new bloodtype name to the dict and start at 1; 
        // Else: Increment bloodtype Count in dict

        int currentBType = listOfBloodUnits.First().blood_type;
        bloodUnitDict.Add(bloodTypekey.BloodType[currentBType], 1);
        foreach (var bloodUnit in listOfBloodUnits)
        {
            if (bloodUnit.blood_type != currentBType)
            {
                currentBType = bloodUnit.blood_type;
                bloodUnitDict.Add(bloodTypekey.BloodType[currentBType], 1);
            }
            else
            {
                bloodUnitDict[bloodTypekey.BloodType[currentBType]]++;
            }
        }

        return bloodUnitDict;
    }

    public void EnterNewBloodUnits(int amountOfUnits, Booking booking)
    {
        for (int i = 0; i < amountOfUnits; i++)
        {
            BloodUnit bU = new()
            {
                donor_id = booking.donor_id,
                booking_id = booking.id,
                blood_type = booking.BloodType,
                is_consumed = false
            };

            _bloodUnitDb.Create(bU);
        }
    }
}