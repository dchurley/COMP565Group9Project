using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopTrigger : MonoBehaviour
{
    public GameObject enterIcon;
    public Animator animator;
    private SpriteRenderer spriteR;

    [SerializeField] private bool triggerActive = false;

    // Start is called before the first frame update
    void Start()
    {
        spriteR = enterIcon.GetComponent<SpriteRenderer>();
        spriteR.color = new Color(1f, 1f, 1f, 0f);
        enterIcon.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (triggerActive && Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Save Menu Open");
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        enterIcon.SetActive(true);
        animator.SetBool("isActive", true);
        triggerActive = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        animator.SetBool("isActive", false);
        triggerActive = false;
    }

}
