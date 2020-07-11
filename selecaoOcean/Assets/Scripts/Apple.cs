using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour
{

    private SpriteRenderer sprtRenderer;
    private CircleCollider2D circCollider;

    public GameObject collected;

    // Start is called before the first frame update
    void Start()
    {
        sprtRenderer = GetComponent<SpriteRenderer>();
        circCollider = GetComponent<CircleCollider2D>();
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Player")
        {
            sprtRenderer.enabled = false; 
            circCollider.enabled = false; 
            collected.SetActive(true);

            GameController.instance.BirdScored();

            Destroy(this.gameObject, 0.2f);
        }
    }



}
