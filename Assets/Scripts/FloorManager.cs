using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class FloorManager : MonoBehaviour
{
    public GameObject floor1;
    public GameObject floor2;
    public GameObject player;
    public GameObject pointCube;
    public GameObject parentTop;
    public GameObject parentBottom;

    bool changeHeightTop = false;
    bool changeHeightBottom = false;
    int heightTop = 8;
    int heightBottom = -8;
    int numberTop;
    int numberBottom;
    bool isPinkTop = true;
    bool isPinkBottom = true;

    public bool createPoint;
    public float position = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //playerのx座標を取得してそこから17右にオブジェクトを生成
        if (player.transform.position.x > position)
        {
            //確率を取得
            changeHeightTop = RandomNumber(numberTop);
            createPoint = RareNumber(numberTop);

            //確率を判断して生成
            if (changeHeightTop == true)
            {
                if(7 < heightTop && heightTop < 10)
                {
                    heightTop += Random.Range(-1,2);
                }
                else if (heightTop <= 7)
                {
                    heightTop ++;
                }
                else if (heightTop >= 10)
                {
                    heightTop --;
                }
                if(isPinkTop == true){
                    if(createPoint) 
                    {
                        Instantiate(pointCube, new Vector3(position + 15, heightTop - 5.5f, 0), transform.rotation);
                    }
                    Instantiate(floor1, new Vector3(position + 15, heightTop, 0), transform.rotation, parentTop.transform);
                    isPinkTop = false;
                } 
                else if (isPinkTop == false)
                {
                    if(createPoint) 
                    {
                        Instantiate(pointCube, new Vector3(position + 15, heightTop - 5.5f, 0), transform.rotation);
                    }
                    Instantiate(floor2, new Vector3(position + 15, heightTop, 0), transform.rotation, parentTop.transform);
                    isPinkTop = true;
                }
                
            } 
            else if (changeHeightTop == false)
            {
                createPoint = RareNumber(numberTop);
                if(isPinkTop == true){
                    if(createPoint) 
                    {
                        Instantiate(pointCube, new Vector3(position + 15, heightTop - 5.5f, 0), transform.rotation);
                    }
                    Instantiate(floor1, new Vector3(position + 15, heightTop, 0), transform.rotation, parentBottom.transform);
                    isPinkTop = false;
                } 
                else if (isPinkTop == false)
                {
                    if(createPoint) 
                    {
                        Instantiate(pointCube, new Vector3(position + 15, heightTop - 5.5f, 0), transform.rotation);
                    }
                    Instantiate(floor2, new Vector3(position + 15, heightTop, 0), transform.rotation, parentBottom.transform);
                    isPinkTop = true;
                }
            }

            //確率を取得
            changeHeightBottom = RandomNumber(numberBottom);
            createPoint = RareNumber(numberBottom);

            //確率を判断して生成
            if (changeHeightBottom == true)
            {
                if(-10 < heightBottom && heightBottom < -7)
                {
                    heightBottom += Random.Range(-1,2);
                }
                else if (heightBottom <= -10)
                {
                    heightBottom ++;
                }
                else if (heightBottom >= -7)
                {
                    heightBottom --;
                }
                if(isPinkBottom == true){
                    if(createPoint) 
                    {
                        Instantiate(pointCube, new Vector3(position + 15, heightBottom + 5.5f, 0), transform.rotation);
                    }
                    Instantiate(floor1, new Vector3(position + 15, heightBottom, 0), transform.rotation);
                    isPinkBottom = false;
                } 
                else if (isPinkBottom == false)
                {
                    if(createPoint) 
                    {
                        Instantiate(pointCube, new Vector3(position + 15, heightBottom + 5.5f, 0), transform.rotation);
                    }
                    Instantiate(floor2, new Vector3(position + 15, heightBottom, 0), transform.rotation);
                    isPinkBottom = true;
                }
            } 
            else if (changeHeightBottom == false)
            {
                if(isPinkBottom == true){
                    if(createPoint) 
                    {
                        Instantiate(pointCube, new Vector3(position + 15, heightBottom + 5.5f, 0), transform.rotation);
                    }
                    Instantiate(floor1, new Vector3(position + 15, heightBottom, 0), transform.rotation);
                    isPinkBottom = false;
                } 
                else if (isPinkBottom == false)
                {
                    if(createPoint) 
                    {
                        Instantiate(pointCube, new Vector3(position + 15, heightBottom + 5.5f, 0), transform.rotation);
                    }
                    Instantiate(floor2, new Vector3(position + 15, heightBottom, 0), transform.rotation);
                    isPinkBottom = true;
                }
            }
            position += 1;
        }
    }

    bool RandomNumber(int num)
    {
        bool value = true;
        num = Random.Range(0, 100);
        if (num < 23)
        {
            value = true;
        }
        else if (num >= 23)
        {
            value = false;
        }
        return value;
    }

    bool RareNumber(int num)
    {
        bool value = true;
        num = Random.Range(0, 100);
        if (num < 7)
        {
            value = true;
        }
        else if (num >= 7)
        {
            value = false;
        }
        return value;
    }
}
