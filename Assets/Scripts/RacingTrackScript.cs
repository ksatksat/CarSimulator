using UnityEngine;

public class RacingTrackScript : MonoBehaviour
{
    [SerializeField] private Renderer[] asphaltTrack;
    [SerializeField] private Renderer[] dirtTrack;
    [SerializeField] private Renderer[] snowTrack;
    [SerializeField] private Renderer[] dustTrack;

    [SerializeField] private Material asphalt;
    [SerializeField] private Material snow;
    [SerializeField] private Material dirt;
    [SerializeField] private Material dust;

    private void Awake()
    {
        foreach (Renderer rend in asphaltTrack)
        {
            rend.material = asphalt;
        }
        foreach (Renderer rend in snowTrack)
        {
            rend.material = snow;
        }
        foreach (Renderer rend in dirtTrack)
        {
            rend.material = dirt;
        }
        foreach (Renderer rend in dustTrack)
        {
            rend.material = dust;
        }
    }
}
