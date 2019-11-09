using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {
    
    public GameObject blocks;
    private Levels levels;

	// Use this for initialization
	void Start () {
        blocks = gameObject.transform.parent.gameObject;
        levels = blocks.GetComponent<Levels>();
    }

    public void DestroyBlock()
    {
        GetComponent<BoxCollider2D>().isTrigger = true;
        GetComponent<Animation>().Play("BlockDisappear");
        transform.parent = null;
        StartCoroutine(NextLevel());
    }

    IEnumerator NextLevel()
    {
        yield return new WaitForSeconds(0.1f);
        if (blocks.transform.childCount == 1)
        {
            levels.NextLevel();
        }
        levels.UpdateInfo(transform.position);
        // Destroy the whole Block
        Destroy(gameObject);
    }
}
