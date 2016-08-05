using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class buyInstruments : MonoBehaviour {

    private int items;
    private string currency;
    private int extraPoint;

    public Text messageBuy;
    public GameObject accept;
    public GameObject message;

    public void loadLevelSelect()
    {
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }

    public void buyEstetoscopio()
    {
        DataManager.instance.LoadData();
        items = DataManager.instance.items;
        currency = DataManager.instance.currency;
        message.SetActive(true);
        if (currency != "Estetoscopio")
        {
           
            if (items >= 10)
            {
                messageBuy.text = "Estas seguro de compara un Estetoscopio";
                accept.SetActive( true);
            }
            else
            {
                messageBuy.text = "Lo lamento te faltan " + (10 - items) + " Pastillas";
                accept.SetActive(false);
            }
        }
        else
        {
            messageBuy.text = "Ya cuentas con un Estetoscopio";
            accept.SetActive(false);
        }
    }

    public void cancel()
    {
        message.SetActive(false);
    }

    public void acceptOnClick()
    {
        items -= 10;
        currency = "Estetoscopio";
        extraPoint = 10;
        DataManager.instance.items = items;
        DataManager.instance.currency = currency;
        DataManager.instance.extraPoint = extraPoint;
        DataManager.instance.SaveData();
        message.SetActive(false);
    }


}
