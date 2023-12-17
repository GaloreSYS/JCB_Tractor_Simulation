using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashboardController : MonoBehaviour
{
    public GameObject IgnitionKey;
    public Material HighlightMaterial;
	private Material[] materials;

	private Ray _ray;
	private RaycastHit _hit;

    private void Start()
    {
		materials = IgnitionKey.GetComponent<MeshRenderer>().materials;

	}
    void Update()
	{
		_ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		if (Physics.Raycast(_ray, out _hit))
		{
			if (Input.GetMouseButtonDown(0))
            {
					Debug.Log("o..." + _hit.collider.name + Vehicle.Engine.EngineManager.CurrentEngineState);
				if (_hit.collider.CompareTag("IgnitionKey"))
                {
					var mats = IgnitionKey.GetComponent<MeshRenderer>().materials;
					if(Vehicle.Engine.EngineManager.CurrentEngineState == Vehicle.Engine.EngineState.OFF)
                    {
						for (int i = 0; i < mats.Length; i++)
						{
							if (mats[i] == HighlightMaterial)
								IgnitionKey.GetComponent<MeshRenderer>().materials = new Material[] { materials[0] };
								//IgnitionKey.GetComponent<MeshRenderer>().materials[i] = null;
						}
							//Vehicle.Engine.EngineManager.SwitchEngineState(Vehicle.Engine.EngineState.ON);
						Debug.Log("sup...");
                    }
					else
                    {
						Debug.Log("supfffff...");

						IgnitionKey.GetComponent<MeshRenderer>().materials[IgnitionKey.GetComponent<MeshRenderer>().materials.Length - 1] = HighlightMaterial;
						//Vehicle.Engine.EngineManager.SwitchEngineState(Vehicle.Engine.EngineState.OFF);
					}

				}
            }
		}
	}
}
