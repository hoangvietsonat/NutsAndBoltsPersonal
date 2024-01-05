using System.Collections.Generic;
using UnityEngine;

public class TouchEventHandler : MonoBehaviour
{
    //Define list game object to check click
    [SerializeField] protected List<GameObject> gameObjects = new List<GameObject>();

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Collider2D hitCollider = Physics2D.OverlapPoint(clickPosition);
            //foreach list gameObjects
            foreach (GameObject gameObject in gameObjects)
            {
                //if hitCollider is not null
                if (hitCollider != null && hitCollider.gameObject == gameObject)
                {
                    Debug.Log("Hit " + gameObject.name);
                }
            }
        }
    }
}
