using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarDestroyer : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "StarTop" || other.tag == "StarBottom")
        {
            Destroy(other.transform.parent.gameObject);
        }
    }
}
