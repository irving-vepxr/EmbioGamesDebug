using UnityEngine;
using System.Collections;

public class moveToutch : MonoBehaviour {
    public float speed;

    void OnCollisionEnter(Collision c)
    {
        if(c != null)
        {
            // Debug.Log("Existe Collision");
            if (c.gameObject.tag.Equals("floor"))
            {
                Destroy(this.gameObject, 2f);
            }
            else
            {
                if (c.gameObject.name.Equals("Amnios"))
                {
                    Debug.Log("Collision with Amnios");
                    Destroy(c.gameObject, 0.5f);
                }

                else
                    Debug.Log("Error pierdes una vida");
            }
        }
    }
}
