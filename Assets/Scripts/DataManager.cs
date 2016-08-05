using UnityEngine;
using System.Collections;
using System;
using System.IO;

using System.Runtime.Serialization.Formatters.Binary;

public class DataManager : MonoBehaviour {
    string[] tmpString;
    char[] delimeterCharacteres = {'|',',' };
    public string fileName;

    public int items;
    public int extraPoint;
    //public int lives;
    public string currency="";

    public static DataManager instance;

    void Awake()
    {
        instance = this; //Solamente que exista un objeto en la escena
        LoadData();
    }

    public void LoadData()
    {
      if(File.Exists(Application.persistentDataPath + "/" + fileName))
        {
            StreamReader sr = new StreamReader(Application.persistentDataPath + "/" + fileName);
            string stringLine;
            while((stringLine = sr.ReadLine()) != null)
            {
                tmpString = stringLine.Split(delimeterCharacteres);
                items = int.Parse(tmpString[0]);
                //          lives = int.Parse(tmpString[1]);
                currency = tmpString[1];
                extraPoint = int.Parse(tmpString[2]);     
            }
            sr.Close();
        }
      else
        {
            items = 0;
            //lives = 3;
            currency = "";
            extraPoint = 0;
            SaveData();
        }
      //  print(Application.temporaryCachePath);
    }

    public void SaveData()
    {
        StreamWriter sw = new StreamWriter(Application.persistentDataPath +"/" + fileName);
        String tmpData = items + "|" + currency + "|" + extraPoint;
        //print(Application.temporaryCachePath);
        //Debug.Log(tmpData);
        sw.WriteLine(tmpData);
        sw.Close();
    }

    /*void OnGUI()
    {
        GUI.Label(new Rect(0.10f * Screen.width, 0.10f * Screen.height, 150, 100), "Archivo = " + rutaArchivo);
        GUI.Label(new Rect(0.10f * Screen.width, 0.20f * Screen.height, 150, 100), "Items = " +items);
        GUI.Label(new Rect(0.10f * Screen.width, 0.30f * Screen.height, 150, 100), "Currency = " + items);
        GUI.Label(new Rect(0.10f * Screen.width, 0.40f * Screen.height, 150, 100), "Points = " + items);
    }
    */
}

[Serializable]
class DatosAGuardar
{
    public int items;
    public string currecy;
    public int extraPoint;
}
