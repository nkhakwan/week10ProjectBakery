using System.Collections.Generic;

namespace Places.Models
{
  public class City
  {
    public string CityName { get; set; }
    public string MyPicture { get; set;}
    public string Companion { get; set;}
    public string MyJournal { get; set; }
    public int Id { get; }

    public static List<City> CityList = new List<City>();

    public City(string cityName, string myPicture, string companion, string myJournal)
    {
      CityName = cityName;
      MyPicture = myPicture;
      Companion = companion;
      MyJournal = myJournal;
      CityList.Add(this);
      Id = CityList.Count;
    }

    public static List<City> GetAll()
    {
      return CityList;
    }

    public static City FindMyPlace(int SearchId)
    {
      return CityList[SearchId-1];
    }
    
    public static void ClearAll()
    {
      CityList.Clear();
    }

    public static void DeleteMyPlace(int SearchId)
    {
      CityList.RemoveAt(SearchId-1);
    }
  }
}