using System;
using UnityEngine;

namespace Vehicle.Engine
{

    public class EngineManager : MonoBehaviour
    {
        public VehicleData _vehicleData;
        protected DrivingMode driveMode;
        protected EngineState engineState;
        protected AccelerationTypes accelerationTypes = AccelerationTypes.NormalSpeed;
        public static EngineState CurrentEngineState 
        { 
            get { return _currEnginestate; }
            set { _currEnginestate = value; }
        }
        private static EngineState _currEnginestate = EngineState.OFF;
        protected GearSpeed gearSpeed;
        protected MoveDirection currentGear;
        protected float Speed, Torque;
        protected float MaxSpeed;
        protected bool IsPBrake
        {
            get { return _isPBrake; }
        }
        private bool _isPBrake = true;
        protected float creeperSpeed;
        protected bool IsCreeperSpeed
        {
            get { return _isCreeperSpeed; }
        }
        private bool _isCreeperSpeed = false;
        protected bool IsHandThrottle
        {
            get { return _isHandThrottle; }
        }
        private bool _isHandThrottle = false;
        protected bool IsDiffLock
        {
            get { return _isDiffLock; }
        }
        private bool _isDiffLock = false;
        protected bool IsPTOEngaged
        {
            get { return _isPTOEngaged; }
        }
        private bool _isPTOEngaged = false;
        public float parkingBrake;
        protected int CurrentGearIn
        {
            get { return _currentGearIn; }
        }
        private int _currentGearIn = 0;

        void Start()
        {
            currentGear = MoveDirection.Neutral;
            driveMode = DrivingMode.FourWheelDrive;
            engineState = EngineState.ON;
            MaxSpeed = _vehicleData.SpeedRange[_currentGearIn];
            creeperSpeed = _vehicleData.CreeperSpeed;
        }
        private void OnDestroy()
        {
        }

        protected void SwitchDriveMode(DrivingMode dM)
        {
            driveMode = dM;
        }

        //protected void EvaluateRPMTorque()
        //{

        //}

        protected void SwitchEngineONOFF(EngineState state)
        {
            _currEnginestate = state;
        }

        protected void SwitchGear(GearSpeed gear)
        {
            gearSpeed = gear;
            MaxSpeed = SetEngineSpeed(gearSpeed);
        }

        private float SetEngineSpeed(GearSpeed gearSpeed)
        {
            float speed;
            switch (gearSpeed)
            {
                case GearSpeed.LOW:
                    speed = _vehicleData.MotorForce[0];
                    break;
                case GearSpeed.MEDIUM:
                    speed = _vehicleData.MotorForce[1];
                    break;
                case GearSpeed.HIGH:
                    speed = _vehicleData.MotorForce[2];
                    break;
                default:
                    speed = _vehicleData.MotorForce[0];
                    break;
            }
            return speed;
        }

        protected void SwitchShuttleLever(MoveDirection moveDir)
        {
            currentGear = moveDir;
            //switch (moveDir)
            //{
            //    case MoveDirection.Front:
            //        break;
            //    case MoveDirection.Back:
            //        break;
            //    case MoveDirection.Neutral:
            //        break;
            //    default:
            //        break;
            //}
        }

        protected bool InteractParkingBrake()
        {
            _isPBrake = true;
            return _isPBrake;
        }
        protected bool ReleasingParkingBrake()
        {
            _isPBrake = false;
            return _isPBrake;
        }

        protected bool InteractCreeperSpeed()
        {
            _isCreeperSpeed = true;
            return _isCreeperSpeed;
        }

        protected bool InteractHandThrottler()
        {
            _isHandThrottle = true;
            return _isHandThrottle;
        }

        protected bool InteractDiffLock()
        {
            _isDiffLock = !_isDiffLock;
            return _isDiffLock;
        }

        protected void IncreaseGear()
        {
            if(_currentGearIn<4)
            {
                _currentGearIn++;
                MaxSpeed = _vehicleData.SpeedRange[_currentGearIn-1];
            }
        }

        protected void DecreaseGear()
        {
            if (_currentGearIn > 0)
            {
                _currentGearIn--;
                MaxSpeed = _vehicleData.SpeedRange[_currentGearIn - 1];
            }
        }
        
        protected bool InteractPTO()
        {
            _isPTOEngaged = true;
            return _isPTOEngaged;
        }
        protected bool ReleasePTO()
        {
            _isPTOEngaged = false;
            return _isPTOEngaged;
        }

    }

    public enum DrivingMode
    {
        FourWheelDrive,
        TwoWheelDrive
    }

    public enum EngineState
    {
        ON,
        OFF
    }

    public enum GearSpeed
    {
        LOW,
        MEDIUM,
        HIGH
    }

    public enum MoveDirection
    {
        Neutral,
        Front,
        Back
    }

    public enum AccelerationTypes
    {
        HandThrottle,
        CreeperSpeed,
        NormalSpeed,
    }
}