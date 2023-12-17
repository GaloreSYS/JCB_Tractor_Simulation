using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Vehicle",menuName = "Vehicle/VehicleData")]
public class VehicleData : ScriptableObject
{
    public string VehicleName;
    public List<float> MotorForce;
    public List<float> SpeedRange;
    public float BreakForce;
    public int MaxSpeed;
    public float ParkingBreak;
    public float CreeperSpeed;

    [Header("Fuel")]
    public float FuelminAngle = -119.84f;
    public float FuelmasAngle = 8.47f;
    public float FuelMaxValue = 0;
    public float FuelMinValue = 100;
    public float FuelCurrentValue = 100f;
    public float FuelConsumptionRatio = 0.01f;
    public Ratio FuelDifferenceRatio = Ratio.DecreaseRatio;
    [Header("Temperature")]
    public float TempminAngle = 93.8f;
    public float TempmasAngle = 201.6f;
    public float TempMaxValue = 110;
    public float TempMinValue = 20;
    public float TempCurrentValue = 20f;
    public float TempConsumptionRatio = 0.05f;
    public Ratio TempDifferenceRatio = Ratio.IncreaseRatio;

}
