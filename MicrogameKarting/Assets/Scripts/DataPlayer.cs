using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public static class DataPlayer 
{
    public static AllData allData;
    private const string ALL_DATA = "ALL_DATA";
    private static UnityEvent updateCoin = new UnityEvent();
    static DataPlayer()
    {
        allData = JsonUtility.FromJson<AllData>(PlayerPrefs.GetString(ALL_DATA));
        if (allData == null)
        {
            var carDefaultId = 1;
            allData = new AllData
            {
                carList = new List<int> { carDefaultId },
                currentCar = carDefaultId,
                coin = 200,
            };
        }
        SaveData();
    }
    public static void SaveData()
    {
        var data = JsonUtility.ToJson(allData);
        PlayerPrefs.SetString(ALL_DATA, data);
    }
    public static bool isOwnedCarWithId(int id)
    {
        return allData.isOwnedCarWithId(id);
    }
    public static void AddCar(int id)
    {
        allData.AddCar(id);
        SaveData();
    }
    public static int GetCurrentCar()
    {
        var index =  allData.currentCar;
        SaveData();
        return index;
    }
    public static void SetCurrentCar(int currentCar)
    {
        allData.SetCurrentCar(currentCar);
    }
    public static void SetCoin(int coin)
    {
        allData.SetCoin(coin);
    }

    public static int GetCoin()
    {
        return allData.GetCoin();
    }

    public static bool isEnoughMoney(int cost)
    {
        return allData.isEnoughMoney(cost);
    }

    public static void Subcoin(int cost)
    {
        allData.SubCoin(cost);
        updateCoin?.Invoke();
        SaveData();
    }
    public static void AddCoin(int cost)
    {
        allData.AddCoin(cost);
        SaveData();
    }
    public static void AddListener(UnityAction coin)
    {
        updateCoin.AddListener(coin);
    }
    public static void RemoveListener(UnityAction coin)
    {
        updateCoin.RemoveListener(coin);
    }
    public static int GetPrevCarId()
    {
        var index = allData.GetPrevCarId();
        SaveData();
        return index;
    }

    public static int GetNextCarId()
    {
        var index = allData.GetNextCarId();
        SaveData();
        return index;
    }
}

public class AllData
{
    public List<int> carList;
    public int currentCar;
    public int coin;
    public bool isOwnedCarWithId(int id)
    {
        return carList.Contains(id);
    }
    public void AddCar(int id)
    {
        carList.Add(id);
    }
    public int GetCurrentCar()
    {
        return currentCar;
    }
    public void SetCurrentCar(int currentCar)
    {
        this.currentCar = currentCar;
    }
    public void SetCoin(int coin)
    {
        this.coin = coin;
    }
    public int GetCoin()
    {
        return coin;
    }
    public bool isEnoughMoney(int cost)
    {
        return coin >= cost; 
    }
    public void SubCoin(int cost)
    {
        coin -= cost;
    }
    public void AddCoin(int cost)
    {
        coin += cost;
    }
    public int GetPrevCarId()
    {
        var carId = 1;
        var currentCarIndex = carList.IndexOf(currentCar);
        if (currentCarIndex == 0)
        {
            carId = carList[carList.Count - 1];
        }
        else
        {
            carId = carList[currentCarIndex - 1];
        }
        currentCar = carId;
        return carId;
    }

    public int GetNextCarId()
    {
        var carId = 1;
        var currentCarIndex = carList.IndexOf(currentCar);

        if (currentCarIndex == carList.Count - 1)
        {
            carId = carList[0];
        }
        else
        {
            carId = carList[currentCarIndex + 1];
        }

        currentCar = carId;
        return carId;
    }

}
