using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Windows;
using UnityEngine.UI;

public class SaveData : MonoBehaviour
{
    [SerializeField] string PlayerName;
    [SerializeField] int PlayerAge;
   

  

    private void Start()
    {
      
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            SavePlayerData();
            getPlayerData();
        }
    }

    void SavePlayerData()
    {
        string filePath = Application.persistentDataPath + "/PlayerScoreData.file";
        FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate);
        BinaryWriter sw = new BinaryWriter(fs);

        sw.Write(this.PlayerName);
        sw.Write(this.PlayerAge);
       
        sw.Close();

        print("----S------A-------V------E-----D-----");
    }

    void getPlayerData()
    {
        string filePath = Application.persistentDataPath + "/PlayerScoreData.file";
        FileStream fs = new FileStream(filePath, FileMode.Open);
        BinaryReader sr = new BinaryReader(fs);

        string pName = sr.ReadString();
        int pAge = sr.ReadInt32();
      

        print(pName);
        print(pAge);
       
        sr.Close();

        print("---R---E---T---R---I---E----V---E----D---");
    }
}
