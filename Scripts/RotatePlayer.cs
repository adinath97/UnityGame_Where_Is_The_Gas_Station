using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePlayer : MonoBehaviour
{
    public static Quaternion targetAngle_30 = Quaternion.Euler(0,0,-120f);
    public static Quaternion targetAngle_0 = Quaternion.Euler(0,0,-90f);
    public static Quaternion currentAngle;
    
    // Start is called before the first frame update
    void Start()
    {
        currentAngle = targetAngle_0;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.rotation = Quaternion.Slerp(this.transform.rotation,currentAngle,0.2f);
    }

    public static void ChangeCurrentAngle(Quaternion newAngle) {
        currentAngle = newAngle;
    }
}
