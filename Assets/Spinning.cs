using UnityEngine;

public class Spinning : MonoBehaviour
{
    public int targetFrameRate = 30;
    private bool IsSpinning;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        IsSpinning = true;
        Application.targetFrameRate = targetFrameRate;
    }

    // Update is called once per frame
    private void Update()
    {
        if (IsSpinning)
        {
            transform.Rotate(90,0,0);
        }
    }
}
