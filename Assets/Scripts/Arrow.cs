using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public GameObject gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager");
        Destroy(gameObject, 3); // 3秒後，刪除自己
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // 當箭頭碰到其他有碰撞體的東西時
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject); // 碰到有碰撞體的東西就刪除自己

        if (collision.tag == "Increase Score")
        {
            gameManager.GetComponent<GameManager>().IncreaseScore();
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
