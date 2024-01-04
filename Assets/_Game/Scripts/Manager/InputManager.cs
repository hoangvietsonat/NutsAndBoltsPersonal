using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private static InputManager instance;
    public static InputManager Instance { get => instance; }

    [SerializeField] private Vector3 mouseWorldPos;
    public Vector3 MouseWorldPos { get => mouseWorldPos; }

    [SerializeField] private float onClicking;
    public float OnClicking { get => onClicking; }




    private void Awake()
    {
        // confirm that only one inputManager 
        if (instance != null)
        {
            Debug.Log("not only one InputManager");
        }
        InputManager.instance = this;
    }
    private void FixedUpdate()
    {
        this.GetMousePos();
    }
    private void Update()
    {
        this.GetMouseDown();
    }
    protected virtual void GetMousePos()
    {
        this.mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    protected virtual void GetMouseDown()
    {
        this.onClicking = Input.GetAxis("Fire1");
    }
    //function getMouseDown 1 time for 1 click
   
  
}
