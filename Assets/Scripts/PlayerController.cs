using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Samples.StarterAssets;

public class PlayerController : MonoBehaviour
{
    private GameObject locmotionSystem; 

    // Start is called before the first frame update
    void Start()
    {
        locmotionSystem = GameObject.Find("Locomotion System");

        if (locmotionSystem != null)
        { 
            DynamicMoveProvider moveProvider = locmotionSystem.GetComponent<DynamicMoveProvider>();

            moveProvider.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
