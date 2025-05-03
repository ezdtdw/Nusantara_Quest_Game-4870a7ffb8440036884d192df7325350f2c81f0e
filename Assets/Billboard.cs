using UnityEngine;

public class Billboard : MonoBehaviour
{

    public Transform cam; // The target to look at
    // Start is called once before the first execution of Update after the MonoBehaviour is created


    // Update is called once per frame
    void LateUpdate()
    {
        transform.LookAt(transform.position + cam.forward); // Make the object look at the target
    }
}
