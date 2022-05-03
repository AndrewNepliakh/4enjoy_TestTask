using Newtonsoft.Json;
using System;
using System.IO;
using Managers;
using UnityEngine;
using Zenject;

public static class SaveManager
{
    [Inject] private static UserManager _userManager;
    
    public static void Save()
    {
        var saveDataPath = Application.persistentDataPath + "/SaveData.json"; ;
        
        var saveData = new SaveData()
        {
            UserData = new UserData{User = _userManager.CurrentUser}
        };

        var json = JsonConvert.SerializeObject(saveData);

        if (!File.Exists(saveDataPath))
        {
            var file = File.Create(saveDataPath);
            file.Close();
        }

        File.WriteAllText(saveDataPath, json);
    }

    public static SaveData Load()
    {
        var saveDataPath = Application.persistentDataPath + "/SaveData.json"; ;
        
        if (File.Exists(saveDataPath))
        {
            var json = File.ReadAllText(saveDataPath);
            SaveData saveData;
            try
            {
                saveData = JsonConvert.DeserializeObject<SaveData>(json);
            }
            catch (Exception e)
            {
                saveData = GetDefaultSaveData();
            }
           
            return saveData;
        }

        return GetDefaultSaveData();
    }

    private static SaveData GetDefaultSaveData()
    {
        var lastUser = new User();
        return new SaveData
        {
            UserData = new UserData{User = lastUser}
        };
    }
}