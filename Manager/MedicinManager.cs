namespace BlodBanken_Fabian_Henrik_Petrus;

internal class MedicinManager
{
    private MedicinDB _medicinDb = new();


    public bool VerifyMedicine(string medicine)
    {
        if (medicine.Length>0)
        {
            return true;
        }

        else
        {
            return false;
        }
    }


}