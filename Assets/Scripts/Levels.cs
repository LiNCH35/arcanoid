using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using System.Linq;

public class Levels : MonoBehaviour {

    class BlockState
    {
        public Vector2Int pos;
        public string color;

        public BlockState(Vector2Int _pos, string _color)
        {
            pos = _pos;
            color = _color;
        }
        public BlockState(Vector2Int _pos)
        {
            pos = _pos;
            color = "Red";
        }
    }

    public GameObject levelCanvas;

    private Text levelText;
    private Text info;
    private GameObject racket;
    private List<BlockState[]> levels = new List<BlockState[]>();
    private int curLvl;
    private int score;

    private BlockState[] level0 =
    {

    };
    private BlockState[] level1 = {
            new BlockState(new Vector2Int(3,6), "Yellow"),
        new BlockState(new Vector2Int(4,6), "Yellow"),
        new BlockState(new Vector2Int(4,7), "Yellow"),
        new BlockState(new Vector2Int(4,8), "Yellow"),
        new BlockState(new Vector2Int(4,9), "Yellow"),
        new BlockState(new Vector2Int(4,10), "Yellow"),
        new BlockState(new Vector2Int(3,10), "Yellow"),
        new BlockState(new Vector2Int(5,10), "Yellow"),
    };
    private BlockState[] level2 = {
            new BlockState(new Vector2Int(0,3), "Dark"),
        new BlockState(new Vector2Int(1,3), "Dark"),
        new BlockState(new Vector2Int(2,3), "Dark"),
        new BlockState(new Vector2Int(3,3), "Dark"),
        new BlockState(new Vector2Int(4,3), "Dark"),
        new BlockState(new Vector2Int(5,3), "Dark"),
        new BlockState(new Vector2Int(6,3), "Dark"),
        new BlockState(new Vector2Int(7,3), "Dark"),
            new BlockState(new Vector2Int(3,7)),
        new BlockState(new Vector2Int(4,7)),
        new BlockState(new Vector2Int(4,8)),
        new BlockState(new Vector2Int(3,9)),
        new BlockState(new Vector2Int(3,10)),
        new BlockState(new Vector2Int(4,10)),
    };
    private BlockState[] level3 = {
            new BlockState(new Vector2Int(0,3), "Red"),
        new BlockState(new Vector2Int(1,3), "Yellow"),
        new BlockState(new Vector2Int(2,3), "Green"),
        new BlockState(new Vector2Int(3,3), "Green"),
        new BlockState(new Vector2Int(4,3), "Green"),
        new BlockState(new Vector2Int(5,3), "Green"),
        new BlockState(new Vector2Int(6,3), "Yellow"),
        new BlockState(new Vector2Int(7,3), "Blue"),
            new BlockState(new Vector2Int(0,4), "Red"),
        new BlockState(new Vector2Int(1,4), "Yellow"),
        new BlockState(new Vector2Int(2,4), "Yellow"),
        new BlockState(new Vector2Int(3,4), "Yellow"),
        new BlockState(new Vector2Int(4,4), "Yellow"),
        new BlockState(new Vector2Int(5,4), "Green"),
        new BlockState(new Vector2Int(6,4), "Yellow"),
        new BlockState(new Vector2Int(7,4), "Blue"),
            new BlockState(new Vector2Int(0,5), "Red"),
        new BlockState(new Vector2Int(1,5), "Yellow"),
        new BlockState(new Vector2Int(2,5), "Yellow"),
        new BlockState(new Vector2Int(3,5), "Yellow"),
        new BlockState(new Vector2Int(4,5), "Yellow"),
        new BlockState(new Vector2Int(5,5), "Green"),
        new BlockState(new Vector2Int(6,5), "Yellow"),
        new BlockState(new Vector2Int(7,5), "Blue"),
            new BlockState(new Vector2Int(0,6), "Red"),
        new BlockState(new Vector2Int(1,6), "Yellow"),
        new BlockState(new Vector2Int(2,6), "Green"),
        new BlockState(new Vector2Int(3,6), "Green"),
        new BlockState(new Vector2Int(4,6), "Green"),
        new BlockState(new Vector2Int(5,6), "Green"),
        new BlockState(new Vector2Int(6,6), "Yellow"),
        new BlockState(new Vector2Int(7,6), "Blue"),
            new BlockState(new Vector2Int(0,7), "Red"),
        new BlockState(new Vector2Int(1,7), "Yellow"),
        new BlockState(new Vector2Int(2,7), "Yellow"),
        new BlockState(new Vector2Int(3,7), "Yellow"),
        new BlockState(new Vector2Int(4,7), "Yellow"),
        new BlockState(new Vector2Int(5,7), "Green"),
        new BlockState(new Vector2Int(6,7), "Yellow"),
        new BlockState(new Vector2Int(7,7), "Blue"),
            new BlockState(new Vector2Int(0,8), "Red"),
        new BlockState(new Vector2Int(1,8), "Yellow"),
        new BlockState(new Vector2Int(2,8), "Yellow"),
        new BlockState(new Vector2Int(3,8), "Yellow"),
        new BlockState(new Vector2Int(4,8), "Yellow"),
        new BlockState(new Vector2Int(5,8), "Green"),
        new BlockState(new Vector2Int(6,8), "Yellow"),
        new BlockState(new Vector2Int(7,8), "Blue"),
             new BlockState(new Vector2Int(0,9), "Red"),
        new BlockState(new Vector2Int(1,9), "Yellow"),
        new BlockState(new Vector2Int(2,9), "Green"),
        new BlockState(new Vector2Int(3,9), "Green"),
        new BlockState(new Vector2Int(4,9), "Green"),
        new BlockState(new Vector2Int(5,9), "Green"),
        new BlockState(new Vector2Int(6,9), "Yellow"),
        new BlockState(new Vector2Int(7,9), "Blue"),
    };
    private BlockState[] level4 = {
            new BlockState(new Vector2Int(0,3), "Yellow"),
        new BlockState(new Vector2Int(0,4), "Yellow"),
        new BlockState(new Vector2Int(0,5), "Yellow"),
        new BlockState(new Vector2Int(1,5), "Yellow"),
        new BlockState(new Vector2Int(2,3), "Yellow"),
        new BlockState(new Vector2Int(2,4), "Yellow"),
        new BlockState(new Vector2Int(2,5), "Yellow"),
        new BlockState(new Vector2Int(2,6), "Yellow"),
        new BlockState(new Vector2Int(2,7), "Yellow"),
             new BlockState(new Vector2Int(0,10), "Pink"),
        new BlockState(new Vector2Int(0,11), "Pink"),
        new BlockState(new Vector2Int(0,12), "Pink"),
        new BlockState(new Vector2Int(1,12), "Pink"),
        new BlockState(new Vector2Int(2,10), "Pink"),
        new BlockState(new Vector2Int(2,11), "Pink"),
        new BlockState(new Vector2Int(2,12), "Pink"),
        new BlockState(new Vector2Int(2,13), "Pink"),
        new BlockState(new Vector2Int(2,14), "Pink"),
            new BlockState(new Vector2Int(5,3), "Dark"),
        new BlockState(new Vector2Int(5,4), "Dark"),
        new BlockState(new Vector2Int(5,5), "Dark"),
        new BlockState(new Vector2Int(6,5), "Dark"),
        new BlockState(new Vector2Int(7,3), "Dark"),
        new BlockState(new Vector2Int(7,4), "Dark"),
        new BlockState(new Vector2Int(7,5), "Dark"),
        new BlockState(new Vector2Int(7,6), "Dark"),
        new BlockState(new Vector2Int(7,7), "Dark"),
             new BlockState(new Vector2Int(5,10), "Blue"),
        new BlockState(new Vector2Int(5,11), "Blue"),
        new BlockState(new Vector2Int(5,12), "Blue"),
        new BlockState(new Vector2Int(6,12), "Blue"),
        new BlockState(new Vector2Int(7,10), "Blue"),
        new BlockState(new Vector2Int(7,11), "Blue"),
        new BlockState(new Vector2Int(7,12), "Blue"),
        new BlockState(new Vector2Int(7,13), "Blue"),
        new BlockState(new Vector2Int(7,14), "Blue"),
    };
    private BlockState[] level5 =
    {
            new BlockState(new Vector2Int(6,1), "Green"),
        new BlockState(new Vector2Int(2,1), "Green"),
        new BlockState(new Vector2Int(7,2), "Green"),
        new BlockState(new Vector2Int(5,2), "Green"),
        new BlockState(new Vector2Int(3,2), "Green"),
        new BlockState(new Vector2Int(1,2), "Green"),
        new BlockState(new Vector2Int(7,3), "Green"),
        new BlockState(new Vector2Int(5,3), "Green"),
        new BlockState(new Vector2Int(3,3), "Green"),
        new BlockState(new Vector2Int(1,3), "Green"),
            new BlockState(new Vector2Int(6,5), "Dark"),
        new BlockState(new Vector2Int(6,6), "Dark"),
        new BlockState(new Vector2Int(2,5), "Dark"),
        new BlockState(new Vector2Int(2,6), "Dark"),
        new BlockState(new Vector2Int(7,9), "Dark"),
        new BlockState(new Vector2Int(6,10), "Dark"),
        new BlockState(new Vector2Int(1,9), "Dark"),
        new BlockState(new Vector2Int(2,10), "Dark"),
        new BlockState(new Vector2Int(7,11), "Dark"),
        new BlockState(new Vector2Int(1,11), "Dark"),
            new BlockState(new Vector2Int(2,13), "Red"),
        new BlockState(new Vector2Int(2,14), "Red"),
        new BlockState(new Vector2Int(3,15), "Red"),
        new BlockState(new Vector2Int(4,14), "Red"),
        new BlockState(new Vector2Int(4,13), "Red"),
        new BlockState(new Vector2Int(5,15), "Red"),
        new BlockState(new Vector2Int(6,14), "Red"),
        new BlockState(new Vector2Int(6,13), "Red"),
    };
    private BlockState[] level6 =
    {
            new BlockState(new Vector2Int(0,12), "Red"),
        new BlockState(new Vector2Int(1,12), "Red"),
        new BlockState(new Vector2Int(2,12), "Red"),
        new BlockState(new Vector2Int(5,12), "Red"),
        new BlockState(new Vector2Int(6,12), "Red"),
        new BlockState(new Vector2Int(7,12), "Red"),
            new BlockState(new Vector2Int(0,11), "Red"),
        new BlockState(new Vector2Int(1,11), "Yellow"),
        new BlockState(new Vector2Int(2,11), "Red"),
        new BlockState(new Vector2Int(5,11), "Red"),
        new BlockState(new Vector2Int(6,11), "Yellow"),
        new BlockState(new Vector2Int(7,11), "Red"),
            new BlockState(new Vector2Int(0,10), "Red"),
        new BlockState(new Vector2Int(1,10), "Yellow"),
        new BlockState(new Vector2Int(2,10), "Red"),
        new BlockState(new Vector2Int(5,10), "Red"),
        new BlockState(new Vector2Int(6,10), "Yellow"),
        new BlockState(new Vector2Int(7,10), "Red"),
            new BlockState(new Vector2Int(0,9), "Red"),
        new BlockState(new Vector2Int(1,9), "Yellow"),
        new BlockState(new Vector2Int(2,9), "Red"),
        new BlockState(new Vector2Int(5,9), "Red"),
        new BlockState(new Vector2Int(6,9), "Yellow"),
        new BlockState(new Vector2Int(7,9), "Red"),
            new BlockState(new Vector2Int(0,8), "Red"),
        new BlockState(new Vector2Int(1,8), "Red"),
        new BlockState(new Vector2Int(2,8), "Dark"),
        new BlockState(new Vector2Int(5,8), "Dark"),
        new BlockState(new Vector2Int(6,8), "Red"),
        new BlockState(new Vector2Int(7,8), "Red"),
            new BlockState(new Vector2Int(0,7), "Red"),
        new BlockState(new Vector2Int(1,7), "Dark"),
        new BlockState(new Vector2Int(2,7), "Pink"),
        new BlockState(new Vector2Int(5,7), "Pink"),
        new BlockState(new Vector2Int(6,7), "Dark"),
        new BlockState(new Vector2Int(7,7), "Red"),
            new BlockState(new Vector2Int(0,6), "Dark"),
        new BlockState(new Vector2Int(1,6), "Pink"),
        new BlockState(new Vector2Int(2,6), "Pink"),
        new BlockState(new Vector2Int(5,6), "Pink"),
        new BlockState(new Vector2Int(6,6), "Pink"),
        new BlockState(new Vector2Int(7,6), "Dark"),
    };
    private BlockState[] level7 = {
            new BlockState(new Vector2Int(0,13), "Yellow"),
        new BlockState(new Vector2Int(0,14), "Dark"),
        new BlockState(new Vector2Int(3,13), "Yellow"),
        new BlockState(new Vector2Int(3,14), "Dark"),
        new BlockState(new Vector2Int(6,13), "Yellow"),
        new BlockState(new Vector2Int(6,14), "Dark"),
            new BlockState(new Vector2Int(1,10), "Yellow"),
        new BlockState(new Vector2Int(1,11), "Dark"),
        new BlockState(new Vector2Int(4,10), "Yellow"),
        new BlockState(new Vector2Int(4,11), "Dark"),
        new BlockState(new Vector2Int(7,10), "Yellow"),
        new BlockState(new Vector2Int(7,11), "Dark"),
            new BlockState(new Vector2Int(2,7), "Yellow"),
        new BlockState(new Vector2Int(2,8), "Dark"),
        new BlockState(new Vector2Int(5,7), "Yellow"),
        new BlockState(new Vector2Int(5,8), "Dark"),
            new BlockState(new Vector2Int(0,4), "Yellow"),
        new BlockState(new Vector2Int(0,5), "Dark"),
        new BlockState(new Vector2Int(3,4), "Yellow"),
        new BlockState(new Vector2Int(3,5), "Dark"),
        new BlockState(new Vector2Int(6,4), "Yellow"),
        new BlockState(new Vector2Int(6,5), "Dark"),
            new BlockState(new Vector2Int(1,1), "Yellow"),
        new BlockState(new Vector2Int(1,2), "Dark"),
        new BlockState(new Vector2Int(4,1), "Yellow"),
        new BlockState(new Vector2Int(4,2), "Dark"),
        new BlockState(new Vector2Int(7,1), "Yellow"),
        new BlockState(new Vector2Int(7,2), "Dark"),
    };
    private BlockState[] level8 = {
            new BlockState(new Vector2Int(1,5), "Dark"),
        new BlockState(new Vector2Int(2,5), "Dark"),
        new BlockState(new Vector2Int(3,5), "Dark"),
        new BlockState(new Vector2Int(4,5), "Dark"),
        new BlockState(new Vector2Int(5,5), "Dark"),
        new BlockState(new Vector2Int(6,5), "Dark"),
            new BlockState(new Vector2Int(1,11), "Green"),
        new BlockState(new Vector2Int(2,11), "Dark"),
        new BlockState(new Vector2Int(3,11), "Dark"),
        new BlockState(new Vector2Int(4,11), "Dark"),
        new BlockState(new Vector2Int(5,11), "Dark"),
        new BlockState(new Vector2Int(6,11), "Green"),
            new BlockState(new Vector2Int(0,5), "Dark"),
        new BlockState(new Vector2Int(7,5), "Dark"),
        new BlockState(new Vector2Int(0,11), "Green"),
        new BlockState(new Vector2Int(7,11), "Green"),
            new BlockState(new Vector2Int(0,6), "Green"),
        new BlockState(new Vector2Int(1,6), "Green"),
        new BlockState(new Vector2Int(2,6), "Green"),
        new BlockState(new Vector2Int(3,6), "Green"),
        new BlockState(new Vector2Int(4,6), "Green"),
        new BlockState(new Vector2Int(5,6), "Green"),
        new BlockState(new Vector2Int(6,6), "Green"),
        new BlockState(new Vector2Int(7,6), "Green"),
            new BlockState(new Vector2Int(0,7), "Green"),
        new BlockState(new Vector2Int(1,7), "Green"),
        new BlockState(new Vector2Int(2,7), "Green"),
        new BlockState(new Vector2Int(3,7), "Green"),
        new BlockState(new Vector2Int(4,7), "Green"),
        new BlockState(new Vector2Int(5,7), "Green"),
        new BlockState(new Vector2Int(6,7), "Green"),
        new BlockState(new Vector2Int(7,7), "Green"),
            new BlockState(new Vector2Int(0,8), "Green"),
        new BlockState(new Vector2Int(1,8), "Green"),
        new BlockState(new Vector2Int(2,8), "Green"),
        new BlockState(new Vector2Int(3,8), "Green"),
        new BlockState(new Vector2Int(4,8), "Green"),
        new BlockState(new Vector2Int(5,8), "Green"),
        new BlockState(new Vector2Int(6,8), "Green"),
        new BlockState(new Vector2Int(7,8), "Green"),
            new BlockState(new Vector2Int(0,9), "Green"),
        new BlockState(new Vector2Int(1,9), "Green"),
        new BlockState(new Vector2Int(2,9), "Green"),
        new BlockState(new Vector2Int(3,9), "Green"),
        new BlockState(new Vector2Int(4,9), "Green"),
        new BlockState(new Vector2Int(5,9), "Green"),
        new BlockState(new Vector2Int(6,9), "Green"),
        new BlockState(new Vector2Int(7,9), "Green"),
            new BlockState(new Vector2Int(0,10), "Green"),
        new BlockState(new Vector2Int(1,10), "Green"),
        new BlockState(new Vector2Int(2,10), "Green"),
        new BlockState(new Vector2Int(3,10), "Green"),
        new BlockState(new Vector2Int(4,10), "Green"),
        new BlockState(new Vector2Int(5,10), "Green"),
        new BlockState(new Vector2Int(6,10), "Green"),
        new BlockState(new Vector2Int(7,10), "Green"),
    };
    private BlockState[] level9 =
    {
            new BlockState(new Vector2Int(0,16), "Dark"),
        new BlockState(new Vector2Int(1,16), "Dark"),
        new BlockState(new Vector2Int(6,16), "Dark"),
        new BlockState(new Vector2Int(7,16), "Dark"),
        new BlockState(new Vector2Int(0,14), "Dark"),
        new BlockState(new Vector2Int(1,14), "Dark"),
        new BlockState(new Vector2Int(6,14), "Dark"),
        new BlockState(new Vector2Int(7,14), "Dark"),
            new BlockState(new Vector2Int(2,16), "Red"),
        new BlockState(new Vector2Int(5,16), "Red"),
        new BlockState(new Vector2Int(2,15), "Red"),
        new BlockState(new Vector2Int(5,15), "Red"),
        new BlockState(new Vector2Int(2,14), "Red"),
        new BlockState(new Vector2Int(5,14), "Red"),
        new BlockState(new Vector2Int(2,13), "Red"),
        new BlockState(new Vector2Int(5,13), "Red"),
        new BlockState(new Vector2Int(3,13), "Red"),
        new BlockState(new Vector2Int(4,13), "Red"),
        new BlockState(new Vector2Int(3,12), "Red"),
        new BlockState(new Vector2Int(4,12), "Red"),
            new BlockState(new Vector2Int(0,5), "Red"),
        new BlockState(new Vector2Int(1,5), "Red"),
        new BlockState(new Vector2Int(6,5), "Red"),
        new BlockState(new Vector2Int(7,5), "Red"),
        new BlockState(new Vector2Int(0,7), "Red"),
        new BlockState(new Vector2Int(1,7), "Red"),
        new BlockState(new Vector2Int(6,7), "Red"),
        new BlockState(new Vector2Int(7,7), "Red"),
            new BlockState(new Vector2Int(2,7), "Dark"),
        new BlockState(new Vector2Int(5,7), "Dark"),
        new BlockState(new Vector2Int(2,6), "Dark"),
        new BlockState(new Vector2Int(5,6), "Dark"),
        new BlockState(new Vector2Int(2,5), "Dark"),
        new BlockState(new Vector2Int(5,5), "Dark"),
        new BlockState(new Vector2Int(2,4), "Dark"),
        new BlockState(new Vector2Int(5,4), "Dark"),
        new BlockState(new Vector2Int(3,4), "Dark"),
        new BlockState(new Vector2Int(4,4), "Dark"),
        new BlockState(new Vector2Int(3,3), "Dark"),
        new BlockState(new Vector2Int(4,3), "Dark"),
    };
    private BlockState[] level10 = {
            new BlockState(new Vector2Int(0,0), "Dark"),
        new BlockState(new Vector2Int(0,1), "Dark"),
        new BlockState(new Vector2Int(0,2), "Dark"),
        new BlockState(new Vector2Int(0,3), "Dark"),
        new BlockState(new Vector2Int(0,4), "Dark"),
        new BlockState(new Vector2Int(0,5), "Yellow"),
        new BlockState(new Vector2Int(0,6), "Yellow"),
        new BlockState(new Vector2Int(0,7), "Yellow"),
        new BlockState(new Vector2Int(0,8), "Yellow"),
        new BlockState(new Vector2Int(0,9), "Yellow"),
        new BlockState(new Vector2Int(0,10), "Yellow"),
        new BlockState(new Vector2Int(0,11), "Yellow"),
            new BlockState(new Vector2Int(1,0), "Yellow"),
        new BlockState(new Vector2Int(1,1), "Yellow"),
        new BlockState(new Vector2Int(1,2), "Yellow"),
        new BlockState(new Vector2Int(1,3), "Yellow"),
        new BlockState(new Vector2Int(1,4), "Yellow"),
        new BlockState(new Vector2Int(1,5), "Yellow"),
        new BlockState(new Vector2Int(1,6), "Yellow"),
        new BlockState(new Vector2Int(1,7), "Dark"),
        new BlockState(new Vector2Int(1,8), "Dark"),
        new BlockState(new Vector2Int(1,9), "Dark"),
        new BlockState(new Vector2Int(1,10), "Dark"),
        new BlockState(new Vector2Int(1,11), "Dark"),
             new BlockState(new Vector2Int(3,0), "Dark"),
        new BlockState(new Vector2Int(3,1), "Dark"),
        new BlockState(new Vector2Int(3,2), "Dark"),
        new BlockState(new Vector2Int(3,3), "Dark"),
        new BlockState(new Vector2Int(3,4), "Dark"),
        new BlockState(new Vector2Int(3,5), "Dark"),
        new BlockState(new Vector2Int(3,6), "Green"),
        new BlockState(new Vector2Int(3,7), "Green"),
        new BlockState(new Vector2Int(3,8), "Green"),
        new BlockState(new Vector2Int(3,9), "Green"),
        new BlockState(new Vector2Int(3,10), "Green"),
        new BlockState(new Vector2Int(3,11), "Green"),
            new BlockState(new Vector2Int(4,0), "Green"),
        new BlockState(new Vector2Int(4,1), "Green"),
        new BlockState(new Vector2Int(4,2), "Green"),
        new BlockState(new Vector2Int(4,3), "Green"),
        new BlockState(new Vector2Int(4,4), "Green"),
        new BlockState(new Vector2Int(4,5), "Green"),
        new BlockState(new Vector2Int(4,6), "Dark"),
        new BlockState(new Vector2Int(4,7), "Dark"),
        new BlockState(new Vector2Int(4,8), "Dark"),
        new BlockState(new Vector2Int(4,9), "Dark"),
        new BlockState(new Vector2Int(4,10), "Dark"),
        new BlockState(new Vector2Int(4,11), "Dark"),
            new BlockState(new Vector2Int(6,0), "Red"),
        new BlockState(new Vector2Int(6,1), "Red"),
        new BlockState(new Vector2Int(6,2), "Red"),
        new BlockState(new Vector2Int(6,3), "Red"),
        new BlockState(new Vector2Int(6,4), "Red"),
        new BlockState(new Vector2Int(6,5), "Red"),
        new BlockState(new Vector2Int(6,6), "Red"),
        new BlockState(new Vector2Int(6,7), "Dark"),
        new BlockState(new Vector2Int(6,8), "Dark"),
        new BlockState(new Vector2Int(6,9), "Dark"),
        new BlockState(new Vector2Int(6,10), "Dark"),
        new BlockState(new Vector2Int(6,11), "Dark"),
            new BlockState(new Vector2Int(7,0), "Dark"),
        new BlockState(new Vector2Int(7,1), "Dark"),
        new BlockState(new Vector2Int(7,2), "Dark"),
        new BlockState(new Vector2Int(7,3), "Dark"),
        new BlockState(new Vector2Int(7,4), "Dark"),
        new BlockState(new Vector2Int(7,5), "Red"),
        new BlockState(new Vector2Int(7,6), "Red"),
        new BlockState(new Vector2Int(7,7), "Red"),
        new BlockState(new Vector2Int(7,8), "Red"),
        new BlockState(new Vector2Int(7,9), "Red"),
        new BlockState(new Vector2Int(7,10), "Red"),
        new BlockState(new Vector2Int(7,11), "Red"),
    };


    // Use this for initialization
    void Start ()
    {
        levelText = levelCanvas.transform.GetChild(0).GetChild(0).gameObject.GetComponent<Text>();
        info = levelCanvas.transform.GetChild(1).gameObject.GetComponent<Text>();
        racket = GameObject.FindGameObjectWithTag("Player");

        levels.Add(level0);

        levels.Add(level1);
        levels.Add(level2);
        levels.Add(level3);
        levels.Add(level4);
        levels.Add(level5);
        levels.Add(level6);
        levels.Add(level7);
        levels.Add(level8);
        levels.Add(level9);
        levels.Add(level10);

        for (int i = 0; i < 3; i++)
        {
            levels.Add(level3);
        }

        curLvl = 0;
        score = 0;
        NextLevel();
    }

    public void UpdateInfo(Vector3 pos)
    {
        score++;
        info.text = "Level: " + curLvl + "\nScore: " + score;
        if (score % 4 == 0)
        {
            GameObject newo = Instantiate<GameObject>(Resources.Load<GameObject>("Prefabs/BlockDown"));
            Reform reform = newo.GetComponent<Reform>();
            reform.NewBlock(pos);
        }
    }

    public int GetScore()
    {
        return score;
    }
	
    public void NextLevel()
    {
        //var firstItem = myList.ElementAt(0);
        curLvl++;
        if (curLvl > levels.Count - 1)
            return;
        for (int i = 0; i < transform.GetChild(0).childCount; i++)
        {
            Destroy(transform.GetChild(0).GetChild(i).gameObject);
        }

        BlockState[] level = levels[curLvl];
        for (int i = 0; i < level.Length; i++)
        {
            levelCanvas.SetActive(true);
            levelText.text = "Level\n" + curLvl;
            levelCanvas.transform.GetChild(0).gameObject.GetComponent<Animation>().Play("Panel");

            GameObject newo = Instantiate<GameObject>(Resources.Load<GameObject>("Prefabs/Block" + level[i].color));
            if(level[i].color == "Dark")
                newo.transform.SetParent(transform.GetChild(0));
            else
                newo.transform.SetParent(transform);
            newo.transform.position = transform.position + new Vector3(level[i].pos.x * 16 * 1.63f, -level[i].pos.y * 8 * 1.54f, 0);
            //test = newo.GetComponent<Renderer>().name;
            racket.GetComponent<Racket>().StartPosition();

        }
    }
}
