using UnityEngine;

public class EnemyController : MonoBehaviour
{



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        foreach(Rigidbody ragdollBone in GetComponentsInChildren<Rigidbody>())

        {
            ragdollBone.isKinematic = true;
        }
        
                
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ragdollTrigger()
    {
        foreach(Rigidbody ragdollBone in GetComponentsInChildren<Rigidbody>())

        {
           ragdollBone.isKinematic = false;
        }


    }



}
