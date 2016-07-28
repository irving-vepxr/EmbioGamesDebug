using UnityEngine;
using System.Collections;

public class CountDown : MonoBehaviour {

    public float timeLeft = 300.0f;
    private static int timeLeftPivot = 0;
    public bool stop = false;
    public GUIText guiTimer;

    public void startTimer(float from)
    {
        stop = false;
        timeLeft = from;
        Update();
        StartCoroutine(updateCoroutine());
    }

    void Update()
    {
        if (stop) return;
        timeLeft -= Time.deltaTime;
        if (timeLeft > 0)
        {
            if ((int)timeLeft != timeLeftPivot)
            {
                timeLeftPivot = (int)timeLeft;
                guiTimer.text = timeLeftPivot.ToString("D3");
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
