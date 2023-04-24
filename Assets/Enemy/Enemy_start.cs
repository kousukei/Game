using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_start : MonoBehaviour
{
    public GameObject Enemy;

    [SerializeField, Header("Œø‰Ê‰¹Component")]
    AudioControl audioControl;
    Vector3 vector3;
    public Stage stage;
    bool stage1Flag = true;
    bool stage2Flag = true;
    bool stage3Flag = true;
    public enum Stage
    {
        stage_1, stage_2, stage_3
    }
    void Start()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            vector3 = this.gameObject.transform.position;
            switch (stage)
            {
                case Stage.stage_1:
                    if (stage1Flag)
                    {
                        for (int i = 0; i < 10; i++)
                        {
                            vector3.x = Random.Range(this.gameObject.transform.position.x - this.gameObject.transform.localScale.x / 2, this.gameObject.transform.position.x + this.gameObject.transform.localScale.x / 2);
                            vector3.y = Random.Range(this.gameObject.transform.position.y, this.gameObject.transform.position.y + this.gameObject.transform.localScale.y / 2);
                            vector3.z = Random.Range(this.gameObject.transform.position.z - this.gameObject.transform.localScale.z / 2, this.gameObject.transform.position.z + this.gameObject.transform.localScale.z / 2);
                            Instantiate(Enemy, vector3, this.gameObject.transform.rotation);
                        }
                        audioControl.StageSound(stage);
                        //audioSource.PlayOneShot(audioclip);
                        stage1Flag = false;
                    }
                    break;
                case Stage.stage_2:
                    if (stage2Flag)
                    {
                        for (int i = 0; i < 10; i++)
                        {
                            vector3.x = Random.Range(this.gameObject.transform.position.x - this.gameObject.transform.localScale.x / 2, this.gameObject.transform.position.x + this.gameObject.transform.localScale.x / 2);
                            vector3.y = Random.Range(this.gameObject.transform.position.y, this.gameObject.transform.position.y + this.gameObject.transform.localScale.y / 2);
                            vector3.z = Random.Range(this.gameObject.transform.position.z - this.gameObject.transform.localScale.z / 2, this.gameObject.transform.position.z + this.gameObject.transform.localScale.z / 2);
                            Instantiate(Enemy, vector3, this.gameObject.transform.rotation);
                        }
                        audioControl.StageSound(stage);
                        //audioSource.PlayOneShot(audioclip);
                        stage2Flag = false;
                    }
                    break;
                case Stage.stage_3:
                    if (stage3Flag)
                    {
                        for (int i = 0; i < 10; i++)
                        {
                            vector3.x = Random.Range(this.gameObject.transform.position.x - this.gameObject.transform.localScale.x / 2, this.gameObject.transform.position.x + this.gameObject.transform.localScale.x / 2);
                            vector3.y = Random.Range(this.gameObject.transform.position.y, this.gameObject.transform.position.y + this.gameObject.transform.localScale.y / 2);
                            vector3.z = Random.Range(this.gameObject.transform.position.z - this.gameObject.transform.localScale.z / 2, this.gameObject.transform.position.z + this.gameObject.transform.localScale.z / 2);
                            Instantiate(Enemy, vector3, this.gameObject.transform.rotation);
                        }
                        audioControl.StageSound(stage);
                        //audioSource.PlayOneShot(audioclip);
                        stage3Flag = false;
                    }
                    break;
            }

        }
    }
    private void OnCollisionEnter(Collision collision)
    {

    }
}
