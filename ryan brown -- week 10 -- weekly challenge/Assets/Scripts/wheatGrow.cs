using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wheatGrow : MonoBehaviour
{
    [SerializeField] GameObject harvestableWheat;
    public float growTime = 10f;
    float finishTime;

    // Start is called before the first frame update
    void Awake()
    {
        finishTime = Time.time + growTime;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time < finishTime)
        {
            transform.localScale = new Vector3(4, 4 + 8*(1-((finishTime - Time.time)/growTime)), 4);
        }
        else
        {
            Instantiate(harvestableWheat, transform.position, transform.rotation, transform.parent);
            Destroy(gameObject);
        }
    }
}
