using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class prefabspawner : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] prefab;
    public float time;
    private float timer;
    void Start()
    {
        timer = time;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if(timer < 0) {
            GameObject pb = Instantiate(prefab[Random.Range(0, prefab.Length)]);
            pb.transform.position = transform.position;
            timer = time;
        }
    }
}
