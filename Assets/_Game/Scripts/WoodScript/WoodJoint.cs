using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodJoint : MonoBehaviour
{
    // Start is called before the first frame update
    //define holes script
    [SerializeField] protected CheckHole holes;
    //define list joint
    [SerializeField] protected List<GameObject> joints = new List<GameObject>();
    void Start()
    {
        //debug log all of holes.holes

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void JointWithHole(Transform hole)
    {
        Debug.Log("Joint with hole");   
        
    }
}
