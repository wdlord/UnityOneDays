using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleMovement : MonoBehaviour
{
    [SerializeField] GameObject leftPaddle;
    [SerializeField] GameObject rightPaddle;
    [Space]
    [SerializeField] float thrust = 0.05f;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            leftPaddle.transform.position += new Vector3(0, thrust, 0);
        }

        if (Input.GetKey(KeyCode.S))
        {
            leftPaddle.transform.position += new Vector3(0, -thrust, 0);
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            rightPaddle.transform.position += new Vector3(0, thrust, 0);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            rightPaddle.transform.position += new Vector3(0, -thrust, 0);
        }
    }

}
