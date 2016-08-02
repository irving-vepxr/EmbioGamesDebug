using UnityEngine;
using System.Collections;

public enum SelectorState { ORGAN_SELECTION, TERRAIN_SELECTION}

public class OrganSelector : MonoBehaviour
{

    public SelectorState currentState;
    private GameObject tmpOrgan;
    private Vector3 destPosition;
    private float velocity;
    private Ray toutchRay;
    private RaycastHit rayCastHit;

    //private string nameOrgan="No organos";



    void Start()
    {
        currentState = SelectorState.ORGAN_SELECTION;
    }

    void Update()
    {
        if (Input.touchCount > 0 || Input.GetMouseButtonDown(0))
        {
            toutchRay = Camera.main.ScreenPointToRay(new Vector3( Input.GetTouch(0).position.x, Input.GetTouch(0).position.y, Camera.main.nearClipPlane) );
            //toutchRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(toutchRay, out rayCastHit))
            {
                Debug.Log(rayCastHit.transform.tag);
      

                if (rayCastHit.transform.tag == "Organ")
                {
                    tmpOrgan = rayCastHit.transform.gameObject;
                   // nameOrgan = rayCastHit.transform.name;
                   // Debug.Log(nameOrgan);
                    EstadoJuego.instance.compareOrgan(tmpOrgan);
                }
            }
            switch (currentState)
            {
                case SelectorState.ORGAN_SELECTION:
                    if (tmpOrgan != null)
                        currentState = SelectorState.TERRAIN_SELECTION;
                    break;
                case SelectorState.TERRAIN_SELECTION:
                    if (rayCastHit.transform.tag != "Organ")
                    {
                        destPosition = rayCastHit.point;
                        tmpOrgan.SendMessage("Move", destPosition, SendMessageOptions.DontRequireReceiver);
                    }
                    break;
            }
        }
    }

    /*
    void OnGUI()
    {
       
        GUI.Label(new Rect(Screen.width*0.7f,Screen.height* 0.9f, Screen.width * 0.3f, Screen.height * 0.1f), nameOrgan);
    }
    */
}
