using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class NightVisionToggle : MonoBehaviour
{
    public Light2D globalLight2D;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            globalLight2D.enabled = !globalLight2D.enabled;
        }
    }
}
