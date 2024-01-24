using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName ="gearshifter", menuName ="Scriptables/JCB InputSystem/Gearandbrake",order =0)]
public class movementmanager : ScriptableObject
{

    public bool Accelerator, frontlever, gearshiftlever,stampaccelerator;

    public int gearnumber, frontandbackdecider;

}
