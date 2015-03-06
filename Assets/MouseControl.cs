using UnityEngine;
using System.Collections;

public class MouseControl : MonoBehaviour {

    public float Multiplier = 1.2f;
    public float RotationMultiplier = 1.5f;

    public float LimitX;
    public float LimitYTop;
    public float LimitYBot;

    // Use this for initialization
    void Start () {

    }
    
    // Update is called once per frame
    void Update () {


        var pos = transform.position;
        pos += new Vector3(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y")) * Multiplier;

        if (pos.x <= -LimitX)
            pos.x = -LimitX;
        else if (pos.x >= LimitX)
            pos.x = LimitX;

        if (pos.y <= -LimitYBot)
            pos.y = -LimitYBot;
        else if (pos.y >= LimitYTop)
            pos.y = LimitYTop;

        GetComponent<Rigidbody>().MovePosition(pos);
        GetComponent<Rigidbody>().MoveRotation(Quaternion.Euler(-pos.y * RotationMultiplier, 0, 0));

        //transform.position = pos;
    }
}
