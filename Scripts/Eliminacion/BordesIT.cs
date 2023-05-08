using UnityEngine;

using Vuforia;
public class BordesIT : MonoBehaviour



{
    public ImageTargetBehaviour imageTarget;
    private Vector2 targetSize;

    void Start()
    {
        Debug.Log("target imagineo "+ imageTarget.GetSize());
            
        
    }
}
