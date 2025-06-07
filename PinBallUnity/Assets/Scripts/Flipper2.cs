using UnityEngine;

public class Flipper2 : MonoBehaviour
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
            motor.motorSpeed = 1000f; // Teste com positivo/negativo
        }
        else
        {
            motor.motorSpeed = -1000f;
        }

        hinge.motor = motor;
    }
}