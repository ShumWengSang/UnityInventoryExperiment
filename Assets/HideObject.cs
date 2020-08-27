using UnityEngine;

public class HideObject : MonoBehaviour
{
    private void OnValidate()
    {
        gameObject.hideFlags = HideFlags.HideInInspector;
    }
}