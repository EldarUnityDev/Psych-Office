using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tremble : MonoBehaviour
{
    public bool timeToTremble;
    public float amplitude = 2f;
    public float frequency = 5f;
    Quaternion startRot;       // cached original rotation
    float phaseOffset;         // per‑instance offset so multiple objects don’t sync
    // Start is called before the first frame update
    void Start()
    {

    }
    void Awake()
    {
        startRot = transform.localRotation;
        phaseOffset = Random.value * Mathf.PI * 2;   // randomize starting phase
    }
    // Update is called once per frame
    void Update()
    {
        if (timeToTremble)
        {
            TrembleMe();
        }
    }
    public void TrembleMe()
    {
        float angle = Mathf.Sin(Time.time * frequency * Mathf.PI * 2 + phaseOffset) * amplitude;
        transform.localRotation = startRot * Quaternion.Euler(angle, 0, 0);
    }
}
