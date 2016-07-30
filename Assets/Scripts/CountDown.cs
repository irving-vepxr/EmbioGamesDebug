using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CountDown : MonoBehaviour {

    public float timeLeft = 300.0f;
    private static int timeLeftPivot = 0;
    public bool stop = true;
    public Text guiTimer;

    public bool detener = true;
    public GameObject camara;
    
    void Start()
    {
        EventoMarcador detener = GetComponent<EventoMarcador>();
        stop = true;
    }
    
    public void startTimer(float from)
    {
        stop = true;
        timeLeft = from;
        Update();
        StartCoroutine(updateCoroutine());
    }

    void Update()
    {
        EventoMarcador detenerEvento = GetComponent<EventoMarcador>();
        stop = detenerEvento.detener;
        if (stop) return;

        timeLeft -= Time.deltaTime;
        if (timeLeft > 0)
        {
            if ((int)timeLeft != timeLeftPivot)
            {
                timeLeftPivot = (int)timeLeft;
                guiTimer.text = timeLeftPivot.ToString("D3");
                if(timeLeftPivot == 15)
                {
                    camara.GetComponent<WarningVisionImageEffect>().enabled = true;
                }
            }

        }
        else
        {
            stop = true;
        }
    }

    private IEnumerator updateCoroutine()
    {
        while (!stop)
        {
            yield return new WaitForSeconds(0.2f);
        }
    }
}
