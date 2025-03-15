using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;//Rigidbody2D�^�̕ϐ�
    bool is_field = false;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        this.gameObject.transform.position = new Vector2(-9, -2);
    }

    
    void FixedUpdate()
    {
        if(Input.GetAxisRaw("Horizontal") > 0)//�����E��󂪉�����Ă�����
        {
            if(rb.velocity.x < 5)//�����������ւ̑��x��7�ȉ��Ȃ�
            {
                //�E�ɗ͂������鏈��
                rb.AddForce(new Vector2(50, 0));
            }
        } else if(Input.GetAxisRaw("Horizontal") < 0)//��������󂪉�����Ă�����
        {
            if( rb.velocity.x > -5)
            {
                //���ɗ͂������鏈��
                rb.AddForce(new Vector2(-50, 0));
            }
        } else if(Input.GetAxisRaw("Horizontal") == 0)//�ǂ�����������Ă��Ȃ��Ȃ�
        {
            rb.velocity = new Vector2(0, rb.velocity.y); //���x��0�ɐݒ�
        }

        if (Input.GetKey(KeyCode.Space) && is_field == true)
        {
            Debug.Log("junp");
            rb.AddForce(new Vector2(0, 4), ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {           
            ContactPoint2D contact_face = collision.contacts[0];
            Debug.Log(contact_face.normal.y);
            if (contact_face.normal.y >= 0.7f)
            {
                Destroy(collision.gameObject);
            } else
            {
                Destroy(gameObject);
            }
        } else if(collision.gameObject.tag == "Goal")
        {
            //�S�[�����m
            SceneManager.LoadScene("ResultScene");
        }
        is_field = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        is_field = false;
    }
}
