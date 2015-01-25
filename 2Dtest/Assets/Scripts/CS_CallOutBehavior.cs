using UnityEngine;
using System.Collections;

public class CS_CallOutBehavior : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        //if (other.tag == "Call Outs")
        //{
            print("Collision!");
        //}
    }

    void OnTriggerStay(Collider other)
    {
        //if (other.tag == "Call Outs")
        //{
            print("Collision!");
        //}
    }
}
