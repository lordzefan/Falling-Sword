using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBox : MonoBehaviour
{
    public int damageSword =35;
    public GameObject swordObsticle;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerHealth>().TakeDamage(damageSword);
            print("damage player");
            Destroy(swordObsticle);
        }

        if (other.CompareTag("Ground"))
        {
            print("kena tanah");
            Destroy(swordObsticle);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
