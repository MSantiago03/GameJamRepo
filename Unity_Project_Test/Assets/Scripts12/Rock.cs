using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Rock : MonoBehaviour
{
    public int level;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void destroyRock()
    {
        Destroy(transform.gameObject);
    }
}
