using UnityEngine;

public class WallScript : MonoBehaviour
{
    [SerializeField] private Renderer[] walls;
    [SerializeField] private Material wallMat;
    private void Awake()
    {
        foreach (Renderer wall in walls)
        {
            wall.material = wallMat;
        }
    }
}
