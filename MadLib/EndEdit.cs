using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndEdit : MonoBehaviour
{
    [SerializeField] GameObject manager;

    public void GetInput(string s)
    {
        manager.GetComponent<Manager>().AddInput(s);
    }
}
