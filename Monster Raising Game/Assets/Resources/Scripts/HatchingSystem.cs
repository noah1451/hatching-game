using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HatchingSystem : MonoBehaviour
{
    public EggScriptable EggStats;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Invoke("Hatch", EggStats.HatchTime);
    }

    public void Hatch()
    {
        Instantiate(EggStats.Animal.PhysicalAnimal, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
