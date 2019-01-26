using System;
using UnityEngine;

[RequireComponent(typeof(MazeConstructor))]               // 1

public class GameController : MonoBehaviour
{
    private MazeConstructor generator;
    public Transform Wall;
    public Transform Road;
    public int sizex = 13;
    public int sizey = 15;
    public float spriteSize = 0.32F;

    void Start()
    {
        generator = GetComponent<MazeConstructor>();      // 2
        generator.GenerateNewMaze(sizex, sizey);
        for (int y=0;y<sizey;y++) {
            for (int x=0;x<sizex;x++)
            {
                if (generator.data[x,y] == 1) {
                    Instantiate(Wall, new Vector3(x* spriteSize, y*spriteSize, 0), Quaternion.identity);
                }
                else
                {
                    Instantiate(Road, new Vector3(x * spriteSize, y * spriteSize, 0), Quaternion.identity);
                }
            }
        }
    }
}