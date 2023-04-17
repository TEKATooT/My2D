using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BestScript : MonoBehaviour
{
    public SpriteRenderer Target;


    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(gameObject.name);
        
        Debug.Log(Time.time);

        Target = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
