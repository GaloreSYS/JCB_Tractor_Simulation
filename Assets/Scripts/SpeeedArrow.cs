using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeeedArrow : MonoBehaviour
{
    public float minAngle = 0f;
    public float masAngle = 0f;
    public float MaxValue = 100;
    public float MinValue = 0;
    public float CurrentValue = 0f;
    public float ConsumptionRatio = 0.1f;
    [SerializeField]private Ratio SetRatio;

    private void FixedUpdate()
    {
        if (SetRatio == Ratio.DecreaseRatio)
            CurrentValue -= ConsumptionRatio * Time.fixedDeltaTime;
        else if(SetRatio == Ratio.IncreaseRatio)
            CurrentValue += ConsumptionRatio * Time.fixedDeltaTime;

        ShowChanges(CurrentValue, MinValue, MaxValue);
    }

    private void ShowChanges(float speed, float min, float max)
    {
        this.transform.localEulerAngles = new Vector3(0, 0, Mathf.Lerp(minAngle, masAngle, Mathf.InverseLerp(min, max, speed)));
    }
}
    public enum Ratio
    {
        IncreaseRatio,
        DecreaseRatio
    }
