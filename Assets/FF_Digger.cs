using System.Collections;
using System.Collections.Generic;
using Digger.Modules.Core.Sources;
using Digger.Modules.Runtime.Sources;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Serialization;

public class FfDigger : MonoBehaviour
{
    public static FfDigger Instance;

    [Space(10)] [Required] [SerializeField]
    private DiggerMasterRuntime diggerMasterRuntime;


    [FormerlySerializedAs("editAsynchronously")]
    [Tooltip("Enable to edit the terrain asynchronously and avoid impacting the frame rate too much.")]
    [PropertySpace(SpaceAfter = 15, SpaceBefore = 15)]
    [ToggleLeft]
    public bool digAsynchronously = true;

    [BoxGroup("Modification parameters")] public BrushType brush = BrushType.Sphere;
    [BoxGroup("Modification parameters")] public ActionType action = ActionType.Dig;

    [BoxGroup("Modification parameters")] [Range(0, 7)]
    public int textureIndex;

    [BoxGroup("Modification parameters")] [Range(0.5f, 10f)]
    public float size = 4f;

    [BoxGroup("Modification parameters")] [Range(0f, 1f)]
    public float opacity = 0.5f;

    [ReadOnly] [Space(15)] public bool canDig;
    [ReadOnly] public bool resetStones;

    [PropertySpace(SpaceBefore = 15)] public ParticleSystem dust;

    [Required] public Transform diggerObject;

    public Rigidbody tlb;
    public GameObject stonePrefab;
    public Transform stonePos;

    public GameObject mud;
    [Range(-1, 1)] public float minimumMudGrowValue;
    [Range(-1, 1)] public float maximumMudGrowValue;

    public float scaleMultiplier;

    public Vector3 maxLimit;
    public Vector3 minLimit;
    public float scalingSpeed;

    [BoxGroup("BackHoe")] public GameObject bucket;

    [ReadOnly] [BoxGroup("BackHoe")] public float prevBucketPos, currentBucketPos;


    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        if (!diggerMasterRuntime)
        {
            enabled = false;
        }

        foreach (var smoke in smokes)
        {
            smoke.Stop();
        }
        
        mud.transform.localScale = new Vector3(0, 0, 0); //Resetting Sand in Bucket
    }

    public int spawnedStoneCount;


    public void AddTerrain(Transform digger, float s)
    {
        diggerMasterRuntime.Modify(digger.position, brush, ActionType.Add, textureIndex, opacity, s);
    }


    private void Update()
    {
        if (smokes[0].isPlaying)
        {
            mudFalling = true;
        }
        else
        {
            mudFalling = false;
        }
        
        currentBucketPos = bucket.GetComponent<JCBbackBucket>().ValueRL;

        if (leftLegOn && rightLegOn)
        {
            TurnOffRb();
        }
        else
        {
            turnOnRB();
        }

        if (canDig)
        {
            if (currentBucketPos < minimumMudGrowValue && currentBucketPos > maximumMudGrowValue)
            {
                ScoopMud(MudAction.PickUpAndDrop);
            }
        }
        else
        {
            if (currentBucketPos < minimumMudGrowValue && currentBucketPos > maximumMudGrowValue)
            {
                ScoopMud(MudAction.OnlyDrop);
            }
        }


        if (canDig)
        {
            if (currentBucketPos < -0.5f)
            {
                canDig = false;
            }
        }

        if (!canDig)
        {
            dust.gameObject.SetActive(false);
            return;
        }

        dust.gameObject.SetActive(true);

        if (digAsynchronously)
        {
            diggerMasterRuntime.ModifyAsyncBuffured(diggerObject.position, brush, action, textureIndex, opacity,
                size);
        }
        else
        {
            diggerMasterRuntime.Modify(diggerObject.position, brush, action, textureIndex, opacity, size);
        }
        
        if (mudFalling && spawnRockCoroutine == null)
        {
            spawnRockCoroutine = StartCoroutine(SpawnStones());
        }
        else if (!mudFalling && spawnRockCoroutine != null)
        {
            StopCoroutine(spawnRockCoroutine);
            spawnRockCoroutine = null;
        }
        
    }

    public Coroutine spawnRockCoroutine;
    public bool leftLegOn;
    public bool rightLegOn;

    private void turnOnRB()
    {
        tlb.constraints = RigidbodyConstraints.None;
    }

    private void TurnOffRb()
    {
        tlb.constraints = RigidbodyConstraints.FreezeAll;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name != "Digger") return;

        canDig = true;
        SpawnRocksAndPile.Instance.ground = false;

        resetStones = true;
        spawnedStoneCount = 0;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name != "Digger") return;

        canDig = false;
        resetStones = false;
    }

    public bool scooper;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name != "Digger") return;

        mud.gameObject.SetActive(true);

        if (bucket.GetComponent<JCBbackBucket>().ValueRL <= 0.5 && bucket.GetComponent<JCBbackBucket>().ValueRL >= -1f)
        {
            scooper = true;

            prevBucketPos = 0;
        }
        else
        {
            scooper = false;
        }
    }

    public ParticleSystem[] smokes;

    private enum MudAction
    {
        PickUpAndDrop,
        OnlyDrop
    }

    private void ScoopMud(MudAction mudAction)
    {
        var scale = -Vector3.one * (currentBucketPos * scaleMultiplier);

        if (mudAction == MudAction.OnlyDrop)
        {
            if (scale.x >= 0 && scale.x < mud.transform.localScale.x)
            {
                mud.transform.localScale = scale;
                foreach (var smoke in smokes)
                {
                    smoke.Play();
                }
            }
            else
            {
                foreach (var smoke in smokes)
                {
                    smoke.Stop();
                }
              
            }
        }
        else
        {
            if (scale.x >= 0)
            {
                mud.transform.localScale = scale;
                
            }

            if (scale.x >= 0&&scale.x < mud.transform.localScale.x)
            {
                foreach (var smoke in smokes)
                {
                    Debug.Log("Playing Smoke");
                    smoke.Play();
                }
                if (scale.x > mud.transform.localScale.x)
                {
                    var e = dust.emission;
                    e.rateOverTime = 0;
                }
            }
            else
            {
                if (scale.x > mud.transform.localScale.x)
                {
                    var e = dust.emission;
                    e.rateOverTime = 1000;
                }
                foreach (var smoke in smokes)
                {
                    smoke.Stop();
                }
            }
        }
    }

    public bool spawning;

    public bool mudFalling;
    private IEnumerator SpawnStones()
    {
        while (true)
        {
            yield return new WaitForSeconds(.25f);
            SpawnRock();
        }
    }

    private void SpawnRock()
    {
        if (resetStones == false)
        {
            if (spawnedStoneCount <= 1)
            {
                var s = Instantiate(stonePrefab, stonePos.position, stonePos.rotation);
                const float i = 5;
                s.transform.localScale = new Vector3(i, i, i);
                spawnedStoneCount++;
            }
            else
            {
                CancelInvoke(nameof(SpawnRock));
                spawning = false;
            }
        }
        else
        {
            spawning = false;
        }
    }
}