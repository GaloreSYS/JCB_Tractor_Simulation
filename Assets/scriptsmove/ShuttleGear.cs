using UnityEngine;
using UnityEngine.Serialization;

namespace scriptsmove
{
    public class ShuttleGear : MonoBehaviour
    {
        [FormerlySerializedAs("vechicleData")] [FormerlySerializedAs("gearspeedfrontback")] public ArmDataJCB vehicleData;

        public float obj = 90, obj2 = 0, obj3 = 0; //obj3=1;

        //2 is forward
        //1 is reverse

        public void FrontBackSelector(int value)
        {
            vehicleData.frontandbackdecider = value;
            vehicleData.gearValue = 1;
        }
    }
}
