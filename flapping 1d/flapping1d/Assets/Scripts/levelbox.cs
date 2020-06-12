using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelbox : MonoBehaviour
{

	public float timer = 0.001f;
    private Vector3 scale;
    private Vector3 position;
    public float distance;

    public int attack;
    public GameObject player;

    private float down_timer;
    private float up_timer;

    public float attack_timer;

    public GameObject spike_d ,spike_u;



    // Start is called before the first frame update
    void Start()
    {
        scale = transform.localScale;
        position = transform.position;
        //timer = 500;
    }

    // Update is called once per frame
    void Update()
    {
        
        timer += Time.deltaTime;
        scale = new Vector3( 4.5f , 6f + (3.4f / ((timer < 20f ? 20f : timer) / 20f)), 1);
        transform.eulerAngles = new Vector3( 0, 0, Mathf.Sin(timer) * timer / 1.2f);

        distance = Mathf.Cos(timer * 0.7f) * (timer > 20 ? 20 : timer) / 10f;
        if(distance > 5) distance = 5;
        if(distance < -5) distance = -5;
        transform.position = position + ( transform.rotation * new Vector3(0, distance, 0));

        transform.localScale = scale;
        if(attack == 1) down_spikes();
        if(attack == 2) up_spikes();

        if(attack == 0)
        {
            if(down_timer == 0 && up_timer == 0 && attack_timer == 0)
            {
                //reset
                attack_timer = 3;
            }
            attack_timer -= Time.deltaTime;
            if(attack_timer < 0)
            {
                attack = Random.Range(1 , 3);
                attack_timer = 0;
            }
        }



    }

    void down_spikes ()
    {
        spike_d.GetComponent<SpriteRenderer>().color = Color.red;
        down_timer += Time.deltaTime * (4 + (4 / (1 + timer / 30)));
        if(down_timer < 3.14f) return;
        float new_scale = (Mathf.Cos(down_timer) + 1) * (1.4f - (1.4f / (1 + timer / 10)));
        //changes position of down spikes
        transform.localScale = scale - new Vector3( 0, new_scale, 0);
        transform.position = transform.position + ( transform.rotation * new Vector3(0, new_scale / 2, 0));
        player.GetComponent<flapper>().offset = +new_scale / 2f;
        if(down_timer > 3.14f * 3)
        {
            spike_d.GetComponent<SpriteRenderer>().color = Color.white;
            attack = 0;
            down_timer = 0;
            transform.localScale = scale;
        }
    }

    void up_spikes ()
    {
        spike_u.GetComponent<SpriteRenderer>().color = Color.red;
        up_timer += Time.deltaTime * (4 + (4 / (1 + timer / 30)));
        if(up_timer < 3.14f) return;
        float new_scale = (Mathf.Cos(up_timer) + 1) * (1.4f - (1.4f / (1 + timer / 10)));
        //changes position of down spikes
        transform.localScale = scale - new Vector3( 0, new_scale, 0);
        transform.position = transform.position - ( transform.rotation * new Vector3(0, new_scale / 2, 0));
        player.GetComponent<flapper>().offset = -new_scale / 2f;
        if(up_timer > 3.14f * 3)
        {
            spike_u.GetComponent<SpriteRenderer>().color = Color.white;
            attack = 0;
            up_timer = 0;
            transform.localScale = scale;
        }
    }
}
