using UnityEngine;
using System.Collections;

public class CrateController : MonoBehaviour {

	void Update()
    {
        renderer.sortingOrder = 1000 - (int)((transform.position.y - renderer.bounds.extents.y) * 100);
    }
}
