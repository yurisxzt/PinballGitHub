using UnityEngine;

public class Flipper : MonoBehaviour
{
    public KeyCode key;
    private HingeJoint2D hinge;

    void Start()
    {
        hinge = GetComponent<HingeJoint2D>();
    }

    void Update()
    {
        JointMotor2D motor = hinge.motor;

        if (Input.GetKey(key))
        {
            motor.motorSpeed = -1000f;
        }
        else
        {
            motor.motorSpeed = 1000f;
        }

        hinge.motor = motor;
    }
}