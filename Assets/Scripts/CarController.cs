using UnityEngine;

public class CarController : MonoBehaviour
{
    private const string HORIZONTAL = "Horizontal";
    private const string VERTICAL = "Vertical";
    private float horizontalInput, verticalInput, currentBreakForce, currentSteerAngle;
    private bool isBreaking;
    [SerializeField] private float motorForce;
    [SerializeField] private float breakForce;
    [SerializeField] private float maxSteerAngle;
    [SerializeField] private WheelCollider leftFrontWheelCollider;
    [SerializeField] private WheelCollider rightFrontWheelCollider;
    [SerializeField] private WheelCollider leftRearWheelCollider;
    [SerializeField] private WheelCollider rightRearWheelCollider;
    [SerializeField] private Transform leftFrontWheelTransform;
    [SerializeField] private Transform rightFrontWheelTransform;
    [SerializeField] private Transform leftRearWheelTransform;
    [SerializeField] private Transform rightRearWheelTransform;
    [SerializeField] private Transform centerOfMass;
    Rigidbody m_rigidbody;

    private void Start()
    {
        m_rigidbody = GetComponent<Rigidbody>();
        m_rigidbody.centerOfMass = centerOfMass.localPosition;
    }

    private void FixedUpdate()
    {
        GetInput();
        HandleMotor();
        HandleSteering();
        UpdateWheels();
    }
    private void GetInput()
    {
        horizontalInput = Input.GetAxis(HORIZONTAL);
        verticalInput = Input.GetAxis(VERTICAL);
        isBreaking = Input.GetKey(KeyCode.Space);
    }

    private void HandleMotor()
    {
        leftFrontWheelCollider.motorTorque = verticalInput * motorForce;
        rightFrontWheelCollider.motorTorque = verticalInput * motorForce;
        currentBreakForce = isBreaking ? breakForce : 0f;
        if (isBreaking)
        {
            ApplyBreaking();
        }
    }

    private void ApplyBreaking()
    {
        leftFrontWheelCollider.brakeTorque = currentBreakForce;
        rightFrontWheelCollider.brakeTorque = currentBreakForce;
        leftRearWheelCollider.brakeTorque = currentBreakForce;
        rightRearWheelCollider.brakeTorque = currentBreakForce;
    }

    private void HandleSteering()
    {
        currentSteerAngle = maxSteerAngle * horizontalInput;
        leftFrontWheelCollider.steerAngle = currentSteerAngle;
        rightFrontWheelCollider.steerAngle = currentSteerAngle;
    }


    private void UpdateWheels()
    {
        UpdateSingleWheel(leftFrontWheelCollider, leftFrontWheelTransform);
        UpdateSingleWheel(rightFrontWheelCollider, rightFrontWheelTransform); 
        UpdateSingleWheel(leftRearWheelCollider, leftRearWheelTransform); 
        UpdateSingleWheel(leftRearWheelCollider, leftRearWheelTransform);
    }

    private void UpdateSingleWheel(WheelCollider wheelCollider, Transform wheelTransform)
    {
        Vector3 pos;
        Quaternion rot;
        wheelCollider.GetWorldPose(out pos, out rot);
        wheelTransform.rotation = rot * Quaternion.Euler(0f, 0f, 90f);
        wheelTransform.position = pos;
    }
}
