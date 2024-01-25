using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tractormanager : MonoBehaviour
{
    //   public GameObject senseglove;
    public ArmDataJCB gearspeednumber;
    public ArmDataJCB objgear,Tractorr;
    public float speedincrease = 1;
    //   public movementmanager checker;

    [Space(20)]

    [Space(10)]
    [Range(20, 590)]
    public int maxSpeed = 90;
    [Range(10, 320)]
    public int maxReverseSpeed = 45;
    [Range(1, 10)]
    public int accelerationMultiplier = 5;
    [Space(10)]

    //   [Range(10, 45)]
    //   public int maxSteeringAngle = 27; 


    [Range(-65, 45)]
    public float maxSteeringAngle;
    public GameObject steerwheel, gearlevercontrol;
    public float a, b,c;
    public bool front;




    [Range(0.1f, 1f)]
    public float steeringSpeed = 0.5f;
    [Space(10)]
    [Range(100, 600)]
    public int brakeForce = 350;
    [Range(1, 10)]
    public int decelerationMultiplier = 6;
    [Range(1, 10)]
    public int handbrakeDriftMultiplier = 5;
    [Space(10)]
    public Vector3 bodyMassCenter;


    public GameObject frontLeftMesh;
    public WheelCollider frontLeftCollider;
    [Space(10)]
    public GameObject frontRightMesh;
    public WheelCollider frontRightCollider;
    [Space(10)]
    public GameObject rearLeftMesh;
    public WheelCollider rearLeftCollider;
    [Space(10)]
    public GameObject rearRightMesh;
    public WheelCollider rearRightCollider;





    public float carSpeed;
    //  [HideInInspector]
    public bool isDrifting;
    //   [HideInInspector]
    public bool isTractionLocked;


    Rigidbody carRigidbody;
    public float steeringAxis;
    public float throttleAxis;
    float driftingAxis;
    float localVelocityZ;
    float localVelocityX;
    bool deceleratingCar;
    bool touchControlsSetup = false;

    WheelFrictionCurve FLwheelFriction;
    float FLWextremumSlip;
    WheelFrictionCurve FRwheelFriction;
    float FRWextremumSlip;
    WheelFrictionCurve RLwheelFriction;
    float RLWextremumSlip;
    WheelFrictionCurve RRwheelFriction;
    float RRWextremumSlip;

    public int gearNumber, TempGearValue;
    public GearInputType GetInputFrom;
    public enum GearInputType
    {
        Keyboard,
        Gloves
    }

    void Start()
    {
        accelerationMultiplier = 9;


        front = false;


        carRigidbody = gameObject.GetComponent<Rigidbody>();
        carRigidbody.centerOfMass = bodyMassCenter;

        FLwheelFriction = new WheelFrictionCurve();
        FLwheelFriction.extremumSlip = frontLeftCollider.sidewaysFriction.extremumSlip;
        FLWextremumSlip = frontLeftCollider.sidewaysFriction.extremumSlip;
        FLwheelFriction.extremumValue = frontLeftCollider.sidewaysFriction.extremumValue;
        FLwheelFriction.asymptoteSlip = frontLeftCollider.sidewaysFriction.asymptoteSlip;
        FLwheelFriction.asymptoteValue = frontLeftCollider.sidewaysFriction.asymptoteValue;
        FLwheelFriction.stiffness = frontLeftCollider.sidewaysFriction.stiffness;
        FRwheelFriction = new WheelFrictionCurve();
        FRwheelFriction.extremumSlip = frontRightCollider.sidewaysFriction.extremumSlip;
        FRWextremumSlip = frontRightCollider.sidewaysFriction.extremumSlip;
        FRwheelFriction.extremumValue = frontRightCollider.sidewaysFriction.extremumValue;
        FRwheelFriction.asymptoteSlip = frontRightCollider.sidewaysFriction.asymptoteSlip;
        FRwheelFriction.asymptoteValue = frontRightCollider.sidewaysFriction.asymptoteValue;
        FRwheelFriction.stiffness = frontRightCollider.sidewaysFriction.stiffness;
        RLwheelFriction = new WheelFrictionCurve();
        RLwheelFriction.extremumSlip = rearLeftCollider.sidewaysFriction.extremumSlip;
        RLWextremumSlip = rearLeftCollider.sidewaysFriction.extremumSlip;
        RLwheelFriction.extremumValue = rearLeftCollider.sidewaysFriction.extremumValue;
        RLwheelFriction.asymptoteSlip = rearLeftCollider.sidewaysFriction.asymptoteSlip;
        RLwheelFriction.asymptoteValue = rearLeftCollider.sidewaysFriction.asymptoteValue;
        RLwheelFriction.stiffness = rearLeftCollider.sidewaysFriction.stiffness;
        RRwheelFriction = new WheelFrictionCurve();
        RRwheelFriction.extremumSlip = rearRightCollider.sidewaysFriction.extremumSlip;
        RRWextremumSlip = rearRightCollider.sidewaysFriction.extremumSlip;
        RRwheelFriction.extremumValue = rearRightCollider.sidewaysFriction.extremumValue;
        RRwheelFriction.asymptoteSlip = rearRightCollider.sidewaysFriction.asymptoteSlip;
        RRwheelFriction.asymptoteValue = rearRightCollider.sidewaysFriction.asymptoteValue;
        RRwheelFriction.stiffness = rearRightCollider.sidewaysFriction.stiffness;




        //        senseglove.SetActive(true);


    }

    void Update()
    {
        gears();
        if (GetInputFrom == GearInputType.Keyboard)
        {
            gearNumber = TempGearValue;
        }

        if(GetInputFrom == GearInputType.Gloves)
        {
            gearNumber = gearspeednumber.gearValue;
        }



        if (Tractorr.tractorbrakess == true)
        {

            Brakes();

        }






        //gearspeednumber.gearnumber = objgear.gearValue;
        //   GoReverse();
        //   GoForward();

        //     Debug.Log(gearlevercontrol.gameObject.transform.localEulerAngles.x+"okok");

        carSpeed = (2 * Mathf.PI * frontLeftCollider.radius * frontLeftCollider.rpm * 60) / 1000;
        localVelocityX = transform.InverseTransformDirection(carRigidbody.velocity).x;
        localVelocityZ = transform.InverseTransformDirection(carRigidbody.velocity).z;

        if (Input.GetKey(KeyCode.S))
        {
            CancelInvoke("DecelerateCar");
            deceleratingCar = false;
            GoReverse();
        }



        if (gearNumber == 5)
        {

         //   if ((gearlevercontrol.gameObject.transform.localEulerAngles.y > 300) && ((gearlevercontrol.gameObject.transform.localEulerAngles.y < 360)))
            {

         //       throttleAxis = 1f;
           //     maxSpeed = 50;
                CancelInvoke("DecelerateCar");
                deceleratingCar = false;
                GoReverse();

                accelerationMultiplier = 5;
                //     GoForward();

            }
        }





        if ((gearlevercontrol.gameObject.transform.localEulerAngles.y == 0))// ||( gearlevercontrol.gameObject.transform.localEulerAngles.x <=5))//////////
        {
            //                  Debug.Log("8");
            //                  Debug.Log( gearlevercontrol.gameObject.transform.localEulerAngles.x);
            CancelInvoke("DecelerateCar");
            throttleAxis = 0f;
            maxSpeed = 0;
            //         accelerationMultiplier = 0;
            deceleratingCar = false;
            //       GoForward();
            //        front = true;
        }

   //     if (gearspeednumber.stampaccelerator == true)
        {
            //        Debug.Log(gearspeednumber.stampaccelerator+"dbz");
 ////////           if (gearspeednumber.frontandbackdecider == 2)                               /////////////////////////////////////
            {
                //           Debug.Log(gearspeednumber.frontandbackdecider + "dbzz");

          //      if(Input.GetKey(KeyCode.S)) 
               if (gearNumber == 1)
                {
                    //            Debug.Log(gearspeednumber.gearnumber + "dbzzzzz");
                    //          if ((gearlevercontrol.gameObject.transform.localEulerAngles.y > 0) && (gearlevercontrol.gameObject.transform.localEulerAngles.y <= 10))
                    {
                        Debug.Log("1");
                        throttleAxis = 0.8f;
                        maxSpeed = 200;
                        accelerationMultiplier = 5;
                        GoForward();
                        Debug.Log(gearNumber+"ddddddd");
                        //     GoReverse();
                    }
                }


                if (gearNumber == 2)
                {
                    //         if ((gearlevercontrol.gameObject.transform.localEulerAngles.y >= 11) && (gearlevercontrol.gameObject.transform.localEulerAngles.y <= 20))
                    {
                        Debug.Log("2");
                        throttleAxis = 1.9f;
                        maxSpeed = 250;
                        accelerationMultiplier = 5;
                        GoForward();

                        //     GoReverse();
                    }
                }
          //     if (Input.GetKey(KeyCode.S))
                         if (gearNumber == 3)//////////
                {
                    //       if ((gearlevercontrol.gameObject.transform.localEulerAngles.y >= 21) && (gearlevercontrol.gameObject.transform.localEulerAngles.y <= 30))
                    {
                        Debug.Log("3");
                        throttleAxis = 2.4f;
                        maxSpeed = 380;

                        accelerationMultiplier = 5;
                        GoForward();

                        //    GoReverse();
                    }
                }


                if (gearNumber == 4)
                {

                    //       if ((gearlevercontrol.gameObject.transform.localEulerAngles.y >= 31) && (gearlevercontrol.gameObject.transform.localEulerAngles.y <= 40))
                    {
                        Debug.Log("4");
                        throttleAxis = 5.6f;
                        maxSpeed = 450;
                        accelerationMultiplier = 5;
                        GoForward();

                        //      GoReverse();

                    }

                }

                if (Input.GetKey(KeyCode.W))
                {


                    Debug.Log("4");
                    throttleAxis = 4.8f;
                    maxSpeed = 450;

                    GoForward();
                }
      /*          if (Input.GetKey(KeyCode.S))
                {

                    //throttleAxis = 0.8f;
                    maxSpeed = 250;
                    GoReverse();
                }*/
            }
        }       /*
            if ((gearlevercontrol.gameObject.transform.localEulerAngles.y >= 41) && (gearlevercontrol.gameObject.transform.localEulerAngles.y <= 50))
            {
            Debug.Log("5");
                throttleAxis = 1f;
                maxSpeed = 300;

            GoForward();
            }
            if ((gearlevercontrol.gameObject.transform.localEulerAngles.y >= 50)&& (gearlevercontrol.gameObject.transform.localEulerAngles.y <= 150))
            {
            Debug.Log("6");
                throttleAxis = 1f;
                maxSpeed = 500;

            GoForward();
            }*/
        //  if ((gearlevercontrol.gameObject.transform.localEulerAngles.x >= 50))

        //    gearlevercontrol.gameObject.transform.localEulerAngles.x = 50;
        //    }


        if (steerwheel.gameObject.transform.localEulerAngles.x >= 0)
        {
            steeringAxis = 0.5f;
            maxSteeringAngle = steerwheel.gameObject.transform.localEulerAngles.x;
            Debug.Log(maxSteeringAngle);
            if (steerwheel.gameObject.transform.localEulerAngles.x > 45)
            {
                Debug.Log("hihi");
                maxSteeringAngle = 45;
            }
              TurnRight();
      //      TurnLeft();
             //    Debug.Log("Right"+ steerwheel.gameObject.transform.localRotation.x);
        }



       a = steerwheel.gameObject.transform.localEulerAngles.x - 360;
           Debug.Log(a + "aaaaa");
        if (a < 0 && a >= -13)
        {
            //        Debug.Log("pokemin"+a+maxSteeringAngle);
            maxSteeringAngle = -13;
            TurnLeft();
      //  TurnRight();
        }
        if (a < -13 && a > -220)
        {
            //         Debug.Log("pokemon"+a+maxSteeringAngle);
            steeringAxis = 0.5f;
            maxSteeringAngle = a;
            if (a < -95)
            {
                maxSteeringAngle = -95;
            }
            if (a < -165)
            {
                maxSteeringAngle = -95;
            }
            //        Debug.Log("max=" + maxSteeringAngle);
                 TurnLeft();
       //     Debug.Log
        //   TurnRight();
        }

        
        



        if (steerwheel.transform.rotation.y == 0)
        {
            //        Debug.Log("zero");
        }

        /*   if (Input.GetKey(KeyCode.A))
            {
                TurnLeft();
            }
            if (Input.GetKey(KeyCode.D))
            {
                TurnRight();
            }*/
        if (Input.GetKey(KeyCode.Space))
        {
            CancelInvoke("DecelerateCar");
            deceleratingCar = false;
            Handbrake();
        }
        if ((!Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.W)))
        {
            // Test          ThrottleOff();
        }
        if ((!Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.W)) && !Input.GetKey(KeyCode.Space) && !deceleratingCar)
        {
            //  Test         InvokeRepeating("DecelerateCar", 0f, 0.1f);
            //   Test        deceleratingCar = true;
        }
        if (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D) && steeringAxis != 0f)
        {
            ResetSteeringAngle();
        }
        //put end if block
        AnimateWheelMeshes();
    }
    public void GoForward()
    {

        Debug.Log("1");
        if (Mathf.Abs(localVelocityX) > 2.5f)
        {
            isDrifting = true;
        }
        else
        {
            isDrifting = false;
        }
        //       throttleAxis = throttleAxis + (Time.deltaTime * 3f);
        /*    if (throttleAxis > 1f)
            {
                Debug.Log("2");
                throttleAxis = 1f;
            }*/

        /*     if (localVelocityZ < -1f)
             {
                 Debug.Log("brakes");
                 Brakes();
             }*/
        //    else
        {
            //       Debug.Log("3");
            if (Mathf.RoundToInt(carSpeed) < maxSpeed)
            {
                Debug.Log("4");
                frontLeftCollider.brakeTorque = 0;
                frontLeftCollider.motorTorque = (accelerationMultiplier * 50f) * throttleAxis;
                frontRightCollider.brakeTorque = 0;
                frontRightCollider.motorTorque = (accelerationMultiplier * 50f) * throttleAxis;
                rearLeftCollider.brakeTorque = 0;
                rearLeftCollider.motorTorque = (accelerationMultiplier * 50f) * throttleAxis;
                rearRightCollider.brakeTorque = 0;
                rearRightCollider.motorTorque = (accelerationMultiplier * 50f) * throttleAxis;

                Debug.Log(frontLeftCollider.motorTorque + "q");
                Debug.Log(frontRightCollider.motorTorque + "w");
                Debug.Log(rearLeftCollider.motorTorque + "e");
                Debug.Log(rearRightCollider.motorTorque + "r");
            }

            else
            {

                //             Debug.Log("5");
                frontLeftCollider.motorTorque -= 120;
                frontRightCollider.motorTorque -= 120;
                rearLeftCollider.motorTorque -= 120;
                rearRightCollider.motorTorque -= 120;
            }
        }
    }


    private void OnCollisionStay(Collision collision)
    {

        if (collision.gameObject.tag == "Left")
        {

            speedincrease += speedincrease * Time.deltaTime;
            Debug.Log(speedincrease + "s");
        }
    }





    public void GoReverse()
    {

        if (Mathf.Abs(localVelocityX) > 2.5f)
        {
            isDrifting = true;

        }
        else
        {
            isDrifting = false;

        }

        throttleAxis = throttleAxis - (Time.deltaTime * 3f);
        if (throttleAxis < -1f)
        {
            throttleAxis = -1f;
        }

        if (localVelocityZ > 1f)
        {
            Brakes();
        }
        else
        {
            if (Mathf.Abs(Mathf.RoundToInt(carSpeed)) < maxReverseSpeed)
            {

                frontLeftCollider.brakeTorque = 0;
                frontLeftCollider.motorTorque = (accelerationMultiplier * 50f) * throttleAxis;
                frontRightCollider.brakeTorque = 0;
                frontRightCollider.motorTorque = (accelerationMultiplier * 50f) * throttleAxis;
                rearLeftCollider.brakeTorque = 0;
                rearLeftCollider.motorTorque = (accelerationMultiplier * 50f) * throttleAxis;
                rearRightCollider.brakeTorque = 0;
                rearRightCollider.motorTorque = (accelerationMultiplier * 50f) * throttleAxis;
            }
            else
            {




                frontLeftCollider.motorTorque = 0;
                frontRightCollider.motorTorque = 0;
                rearLeftCollider.motorTorque = 0;
                rearRightCollider.motorTorque = 0;
            }
        }
    }

    public void Brakes()
    {

        frontLeftCollider.motorTorque = 0;
        frontRightCollider.motorTorque = 0;
        rearLeftCollider.motorTorque = 0;
        rearRightCollider.motorTorque = 0;
        accelerationMultiplier = 0;
        throttleAxis = 0;

        frontLeftCollider.brakeTorque = 0;
        frontLeftCollider.motorTorque = (accelerationMultiplier * 50f) * throttleAxis;
        frontRightCollider.brakeTorque = 0;
        frontRightCollider.motorTorque = (accelerationMultiplier * 50f) * throttleAxis;
        rearLeftCollider.brakeTorque = 0;
        rearLeftCollider.motorTorque = (accelerationMultiplier * 50f) * throttleAxis;
        rearRightCollider.brakeTorque = 0;
        rearRightCollider.motorTorque = (accelerationMultiplier * 50f) * throttleAxis;





        frontLeftCollider.brakeTorque = brakeForce;
        frontRightCollider.brakeTorque = brakeForce;
        rearLeftCollider.brakeTorque = brakeForce;
        rearRightCollider.brakeTorque = brakeForce;
    }


    public void Handbrake()
    {
        CancelInvoke("RecoverTraction");

        driftingAxis = driftingAxis + (Time.deltaTime);
        float secureStartingPoint = driftingAxis * FLWextremumSlip * handbrakeDriftMultiplier;

        if (secureStartingPoint < FLWextremumSlip)
        {
            driftingAxis = FLWextremumSlip / (FLWextremumSlip * handbrakeDriftMultiplier);
        }
        if (driftingAxis > 1f)
        {
            driftingAxis = 1f;
        }

        if (Mathf.Abs(localVelocityX) > 2.5f)
        {
            isDrifting = true;
        }
        else
        {
            isDrifting = false;
        }

        if (driftingAxis < 1f)
        {
            FLwheelFriction.extremumSlip = FLWextremumSlip * handbrakeDriftMultiplier * driftingAxis;
            frontLeftCollider.sidewaysFriction = FLwheelFriction;

            FRwheelFriction.extremumSlip = FRWextremumSlip * handbrakeDriftMultiplier * driftingAxis;
            frontRightCollider.sidewaysFriction = FRwheelFriction;

            RLwheelFriction.extremumSlip = RLWextremumSlip * handbrakeDriftMultiplier * driftingAxis;
            rearLeftCollider.sidewaysFriction = RLwheelFriction;

            RRwheelFriction.extremumSlip = RRWextremumSlip * handbrakeDriftMultiplier * driftingAxis;
            rearRightCollider.sidewaysFriction = RRwheelFriction;
        }


        isTractionLocked = true;


    }


    public void TurnLeft()
    {
        steeringAxis = steeringAxis - (Time.deltaTime * 10f * steeringSpeed);
        if (steeringAxis < -1f)
        {
            steeringAxis = -1f;
        }
        var steeringAngle = steeringAxis * maxSteeringAngle;
        frontLeftCollider.steerAngle = Mathf.Lerp(frontLeftCollider.steerAngle, steeringAngle, steeringSpeed);//steerinj anjle is to be controlled by handle
        frontRightCollider.steerAngle = Mathf.Lerp(frontRightCollider.steerAngle, steeringAngle, steeringSpeed);
    }



    public void TurnRight()
    {
        steeringAxis = steeringAxis + (Time.deltaTime * 10f * steeringSpeed);
        if (steeringAxis > 1f)
        {
            steeringAxis = 1f;
        }
        var steeringAngle = steeringAxis * maxSteeringAngle;
        frontLeftCollider.steerAngle = Mathf.Lerp(frontLeftCollider.steerAngle, steeringAngle, steeringSpeed);
        frontRightCollider.steerAngle = Mathf.Lerp(frontRightCollider.steerAngle, steeringAngle, steeringSpeed);
    }

    public void ResetSteeringAngle()
    {
        if (steeringAxis < 0f)
        {
            steeringAxis = steeringAxis + (Time.deltaTime * 10f * steeringSpeed);
        }
        else if (steeringAxis > 0f)
        {
            steeringAxis = steeringAxis - (Time.deltaTime * 10f * steeringSpeed);
        }
        if (Mathf.Abs(frontLeftCollider.steerAngle) < 1f)
        {
            steeringAxis = 0f;
        }
        var steeringAngle = steeringAxis * maxSteeringAngle;
        frontLeftCollider.steerAngle = Mathf.Lerp(frontLeftCollider.steerAngle, steeringAngle, steeringSpeed);
        frontRightCollider.steerAngle = Mathf.Lerp(frontRightCollider.steerAngle, steeringAngle, steeringSpeed);
    }


    void AnimateWheelMeshes()
    {
        try
        {
            Quaternion FLWRotation;
            Vector3 FLWPosition;
            frontLeftCollider.GetWorldPose(out FLWPosition, out FLWRotation);
            frontLeftMesh.transform.position = FLWPosition;
            frontLeftMesh.transform.rotation = FLWRotation;

            Quaternion FRWRotation;
            Vector3 FRWPosition;
            frontRightCollider.GetWorldPose(out FRWPosition, out FRWRotation);
            frontRightMesh.transform.position = FRWPosition;
            frontRightMesh.transform.rotation = FRWRotation;

            Quaternion RLWRotation;
            Vector3 RLWPosition;
            rearLeftCollider.GetWorldPose(out RLWPosition, out RLWRotation);
            rearLeftMesh.transform.position = RLWPosition;
            rearLeftMesh.transform.rotation = RLWRotation;

            Quaternion RRWRotation;
            Vector3 RRWPosition;
            rearRightCollider.GetWorldPose(out RRWPosition, out RRWRotation);
            rearRightMesh.transform.position = RRWPosition;
            rearRightMesh.transform.rotation = RRWRotation;
        }
        catch (Exception ex)
        {
            Debug.LogWarning(ex);
        }
    }

    public void ThrottleOff()
    {
        frontLeftCollider.motorTorque = 0;
        frontRightCollider.motorTorque = 0;
        rearLeftCollider.motorTorque = 0;
        rearRightCollider.motorTorque = 0;
    }

    public void DecelerateCar()
    {
        if (Mathf.Abs(localVelocityX) > 2.5f)
        {
            isDrifting = true;

        }
        else
        {
            isDrifting = false;

        }

        if (throttleAxis != 0f)
        {
            if (throttleAxis > 0f)
            {
                throttleAxis = throttleAxis - (Time.deltaTime * 10f);
            }
            else if (throttleAxis < 0f)
            {
                throttleAxis = throttleAxis + (Time.deltaTime * 10f);
            }
            if (Mathf.Abs(throttleAxis) < 0.15f)
            {
                throttleAxis = 0f;
            }
        }
        carRigidbody.velocity = carRigidbody.velocity * (1f / (1f + (0.025f * decelerationMultiplier)));

        frontLeftCollider.motorTorque = 0;
        frontRightCollider.motorTorque = 0;
        rearLeftCollider.motorTorque = 0;
        rearRightCollider.motorTorque = 0;

        if (carRigidbody.velocity.magnitude < 0.25f)
        {
            carRigidbody.velocity = Vector3.zero;
            CancelInvoke("DecelerateCar");
        }
    }


    public void gears()
    {
        if(Input.GetKeyDown(KeyCode.U))
        {
            TempGearValue = 0;
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            TempGearValue = 1;
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            TempGearValue = 2;
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            TempGearValue = 3;
        }
        if (Input.GetKeyDown(KeyCode.LeftBracket))
        {
            TempGearValue = 4;
        }
        if (Input.GetKeyDown(KeyCode.RightBracket))
        {
            TempGearValue = 5;
        }

        if (Input.GetKeyDown(KeyCode.Space))

        {
            Debug.Log("brake");
            TempGearValue = 0;

            Brakes();

        }
        

    }


    




}
