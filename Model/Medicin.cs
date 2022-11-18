namespace BlodBanken_Fabian_Henrik_Petrus;

public class Medicin
{   //Cannot delete health_info due to child row. Two options to use Delete on medicine. 
    //Either by selecting ID WHERE healthInfo ID = x and delete them or to delete where HealthInfoId = x
    public int Id { get; set; }
    public int HealthInfoId { get; set; }
    public string Medicine { get; set; }


}