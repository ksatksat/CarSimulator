using UnityEngine;

public class RampScript : MonoBehaviour
{
    [SerializeField] private Renderer[] ramps;
    [SerializeField] private Material ramp;

    private void Awake()
    {
        foreach (Renderer rampRend in ramps)
        {
            rampRend.material = ramp;
        }
    }
}
