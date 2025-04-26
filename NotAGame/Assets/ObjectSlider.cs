using UnityEngine;
using UnityEngine.UI;

public class ObjectSlider : MonoBehaviour
{
    public Slider mySlider;
    public float maxValue = 0f;
    private float currentValue;
    public DangerZone timerObject;

    void Start()
    {
        currentValue = maxValue;
        mySlider.maxValue = maxValue;
        mySlider.value = currentValue;
    }

    void Update()
    {
        // Example: Decrease over time
        currentValue = timerObject.timer;
        mySlider.value = currentValue;

        if (currentValue <= 0)
        {
            Debug.Log("Object is dead!");
        }
    }
}

