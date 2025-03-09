using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;//Rigidbody2D�^�̕ϐ�
    bool is_field = false;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        this.gameObject.transform.position = new Vector2(-9, -2);
    }

    
    void Update()
    {
        if(Input.GetAxisRaw("Horizontal") > 0)//�����E��󂪉�����Ă�����
        {
            if(rb.velocity.x < 7)//�����������ւ̑��x��7�ȉ��Ȃ�
            {
                //�E�ɗ͂������鏈��
                rb.AddForce(new Vector2(5, 0));
            }
        } else if(Input.GetAxisRaw("Horizontal") < 0)//��������󂪉�����Ă�����
        {
            if( rb.velocity.x > -7)
            {
                //���ɗ͂������鏈��
                rb.AddForce(new Vector2(-5, 0));
            }
        } else if(Input.GetAxisRaw("Horizontal") == 0)//�ǂ�����������Ă��Ȃ��Ȃ�
        {
            rb.velocity = new Vector2(0, rb.velocity.y); //���x��0�ɐݒ�
        }

        if (Input.GetKeyDown(KeyCode.Space) && is_field == true)
        {
            rb.AddForce(new Vector2(0, 7), ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        is_field = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        is_field = false;
    }
}
