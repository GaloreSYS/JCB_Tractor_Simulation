using Digger.Modules.Core.Sources;
using Digger.Modules.Runtime.Sources;
using UnityEngine;
using UnityEngine.Serialization;

public class FF_Digger : MonoBehaviour
{
    public static FF_Digger Instance;
    
    [Header("Async parameters")]
    [Tooltip("Enable to edit the terrain asynchronously and avoid impacting the frame rate too much.")]
    public bool editAsynchronously = true;

    [Header("Modification parameters")] public BrushType brush = BrushType.Sphere;
    public ActionType action = ActionType.Dig;
    [Range(0, 7)] public int textureIndex;
    [Range(0.5f, 10f)] public float size = 4f;
    [Range(0f, 1f)] public float opacity = 0.5f;
    public float countdown = 2;
    private DiggerMasterRuntime diggerMasterRuntime;

    public bool canDig, resetStones;
    public ParticleSystem dust;

    [FormerlySerializedAs("cubde")] public Transform diggerObject;

    public Rigidbody tlb;
    public GameObject stonePrefab;
    public Transform stonePos;
    public float timmer = 0f;
    [Header("Mud properties")]
    public GameObject mud;
    public Vector3 maxLimit;
    public Vector3 minLimit;
    public float saclingSpeed;
    public bool IsScooped=false;
    public GameObject Bucket;
    

    private void Awake()
    {
        Instance = this;    
    }

    private void Start()
    {
        diggerMasterRuntime = FindObjectOfType<DiggerMasterRuntime>();
        if (!diggerMasterRuntime)
        {
            enabled = false;
            Debug.LogWarning(
                "DiggerRuntimeUsageExample component requires DiggerMasterRuntime component to be setup in the scene. DiggerRuntimeUsageExample will be disabled.");
        }

        mud.transform.localScale = new Vector3(0, 0, 0);
    }

    public int count;
    void SpawnRock()
    {
        if (resetStones == false)
        {
            if (count <= 5)
            {
                var s = Instantiate(stonePrefab, stonePos.position, stonePos.rotation);
                float size = 5;
                s.transform.localScale = new Vector3(size, size, size);
                count++;
            }
            else{
                CancelInvoke(nameof(SpawnRock));
                Spawning = false;
            }
        }

    }

    public void AddTerrain(Transform digger,float s)
    {
        diggerMasterRuntime.Modify(digger.position, brush, ActionType.Add, textureIndex, opacity, s);
    }
    private void Update()
    {
        if (leftLegOn && rightLegOn)
        {
            turnOffRB();
        }
        else
        {
            turnOnRB();
        }
        if (Bucket.GetComponent<JCBbackBucket>().ValueRL<1.06f && Bucket.GetComponent<JCBbackBucket>().ValueRL>0f  )
        {
            Debug.LogError("decreasing function called");
            ScoopMud(false);
            IsScooped = false;
        }
        if (canDig == true)
        {
            timmer += Time.deltaTime;

            if (timmer > 2f)
            {
                canDig = false;
                countdown = 0;
            }
        }
        else
        {
            timmer = 0f;
        }

        if (!canDig)
        {
             
            dust.gameObject.SetActive(false);
            return;
        }
         dust.gameObject.SetActive(true);
        if (editAsynchronously)
        {
            diggerMasterRuntime.ModifyAsyncBuffured(diggerObject.position, brush, action, textureIndex, opacity,
                size);
        }
        else
        {
            diggerMasterRuntime.Modify(diggerObject.position, brush, action, textureIndex, opacity, size);
        }

    
    }

    public bool leftLegOn;
    public bool rightLegOn;
    public void turnOnRB()
    {
        tlb.constraints = RigidbodyConstraints.None;
    }

    public void turnOffRB()
    {
        Debug.Log("HERE ");
        tlb.constraints = RigidbodyConstraints.FreezeAll;
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.name == "Digger")
        {

            canDig = true;
            SpawnRocksAndPile.Instance.ground = false;
          
            resetStones = true;
            count = 0;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Digger")
        {
            canDig = false;
            CancelInvoke(nameof(SpawnRock));
          
            timmer = 0;
            resetStones = false;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "Digger")
        {
            Debug.LogError("scale is increasing");
            mud.gameObject.SetActive(true);
            if (Bucket.GetComponent<JCBbackBucket>().ValueRL<=0.5 && Bucket.GetComponent<JCBbackBucket>().ValueRL>=-2f )
            {
               ScoopMud(true);
            }
            else
            {
                ScoopMud(false);
            }

            if (mud.transform.localScale==maxLimit)
            {
                IsScooped = true;
            }
            
        }
    }
public ParticleSystem smoke;
    public void ScoopMud(bool scoop)
    {
        if (scoop==true)
        {
            mud.transform.localScale = Vector3.MoveTowards(mud.transform.localScale, maxLimit, saclingSpeed * Time.deltaTime);
            //mud.transform.localScale = maxLimit;
        }
        else
        {
            if(mud.transform.localScale.x>0.1)
            {
            Spawnstones();
            smoke.Play();
            }else{
                smoke.Stop();
            }
            mud.transform.localScale = Vector3.MoveTowards(mud.transform.localScale, minLimit, saclingSpeed * Time.deltaTime);
        }
        
    }

    public bool Spawning;
    public void Spawnstones()
    {
        if(Spawning)return;
        Spawning = true;
        InvokeRepeating(nameof(SpawnRock), 1, 0.1f);
    }
}
