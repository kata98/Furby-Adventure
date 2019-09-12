using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    Rigidbody2D rb;

    [SerializeField]
    float speed = 8;

    public Animator animator;
    public bool isMoving = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    RaycastHit2D hit;
    
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(-speed * Time.deltaTime, 0, 0);
            animator.SetBool("isMoving", true);
        }

        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            animator.SetBool("isMoving", false);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(speed * Time.deltaTime, 0, 0);
            animator.SetBool("isMoving", true);
        }

        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            animator.SetBool("isMoving", false);
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            hit = Physics2D.Raycast(transform.position, -Vector2.up, 2.5f);

            if(hit.collider != null)
            rb.AddForce(Vector2.up*15, ForceMode2D.Impulse);
        }


    }

    [SerializeField]
    GameObject deathPanel;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "deathCollision")
        {
            SendMessageUpwards("remove_life");
        }

        if (col.gameObject.tag == "eggCollision")
        {
            SendMessageUpwards("collect_egg", col.gameObject);
            SendMessageUpwards("play_eatingAC");
        }

        if (col.gameObject.name == "nextLevel")
        {
            SendMessageUpwards("save_eggCount");
            SendMessageUpwards("NextLevel");
        }

        if (col.gameObject.name == "babyFurby")
        {
            SendMessageUpwards("GameOver");
            StartCoroutine(GameWon());

        }

    }

    IEnumerator GameWon()
    {
        yield return new WaitForSeconds(.8f);
        SceneManager.LoadScene(0);
    }
}
