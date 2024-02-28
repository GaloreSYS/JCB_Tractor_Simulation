using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TractorBucketCOntroller : MonoBehaviour
{
    public ArmDataJCB TractorPlow;

    public void Upside()
    {
      
        TractorPlow.TractorPlowUP = true;
        TractorPlow.TractorPlowDown = false;
    }

    public void Downside()
    {
        TractorPlow.TractorPlowUP = false;
        TractorPlow.TractorPlowDown = true;
    }
}
