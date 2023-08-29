using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    System.IO.Ports.SerialPort sp;

    // Start is called before the first frame update
    void Start()
    {
        sp = new System.IO.Ports.SerialPort("COM5", 9600);
        sp.Open();
        sp.ReadTimeout = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (sp.IsOpen)
        {
            try
            {
                if (sp.BytesToRead > 0)
                {
                    int data = sp.ReadByte();
                    if (data == 1)
                    {
                        transform.Translate(Vector3.left * Time.deltaTime * 5);
                    }
                    else if (data == 2)
                    {
                        transform.Translate(Vector3.right * Time.deltaTime * 5);
                    }
                }
            }
            catch (System.Exception)
            {
                // 예외 처리 코드
            }
        }
    }
}