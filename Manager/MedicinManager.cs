namespace BlodBanken_Fabian_Henrik_Petrus;

internal class MedicinManager
{
    private MedicinDB _medicinDb = new();


    public bool VerifyMedicine(string medicine)
    {
        if (medicine.Length>0)  return true;
     
        return false;
    }

    public void SaveMedicinListToDB(List <string> medcineInputs,int healthInformationId)
    {
        foreach (string medicines in medcineInputs)
        {
            Medicin newMedicine  = new();
            newMedicine.HealthInfoId = healthInformationId;
            newMedicine.Medicine = medicines;

            _medicinDb.Create(newMedicine);
        

        }
    }
}