using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class CheckHole : MonoBehaviour
{
    // Start is called before the first frame update
    //define list hole 
    [SerializeField] private List<GameObject> holes = new List<GameObject>();

    protected List<GameObject> Holes { get => holes; }
    [SerializeField]private WoodJoint woodJoint; // Khai báo biến instance của class getPoint
    private bool isClicking = false;
    private void Awake()
    {
            }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        this.DetechMouseClickIntoGameObject();

    }
    protected virtual void DetechMouseClickIntoGameObject()
    {
        if (InputManager.Instance.OnClicking > 0 && !this.isClicking)
        {
            // check if mouse click into gameobject
            // if yes, then do something
            this.isClicking = true;
            RaycastHit2D hit = Physics2D.Raycast(InputManager.Instance.MouseWorldPos, Vector2.zero);
            //check if collider with one of the hole
            if (hit.collider != null)
            {
                //check if collider with one of the hole
                GameObject hole = hit.collider.gameObject;
                if (this.holes.Contains(hole))
                {
                    woodJoint.JointWithHole(hole.transform);  
                }
            }
        }
        else if(InputManager.Instance.OnClicking == 0)
        {
            this.isClicking = false;
        }
    }
}
