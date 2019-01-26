using System;
using UnityEngine;

[RequireComponent(typeof(MazeConstructor))]               // 1

public class GameController : MonoBehaviour
{
    private MazeConstructor generator;
    public Transform Wall;
    public Transform Wall2;
    public Transform Road;
    public Transform Player;
    public Transform Enemy;
    public Transform Key;
    public Transform MyHouse;
    public int sizex = 13;
    public int sizey = 15;
    public float spriteSize = 0.32F;
    public int sizeMultiplayer = 2;
    void Start()
    {
        generator = GetComponent<MazeConstructor>();      // 2
        generator.GenerateNewMaze(sizex, sizey);
        for (int y=0;y<sizey;y++) {
            for (int x=0;x<sizex;x++)
            {
                if (generator.data[x,y] == 1) {
                    if (randomBoolean())
                    {
                        Instantiate(Wall, new Vector3(x * spriteSize * sizeMultiplayer, y * spriteSize * sizeMultiplayer, 0), Quaternion.identity);
                    }
                    else
                    {
                        Instantiate(Wall2, new Vector3(x * spriteSize * sizeMultiplayer, y * spriteSize * sizeMultiplayer, 0), Quaternion.identity);
                    }
                }
                else
                {
                    Instantiate(Road, new Vector3(x * spriteSize * sizeMultiplayer, y * spriteSize * sizeMultiplayer, 1), Quaternion.identity);
                }
            }
        }
        Instantiate(Player, new Vector3(1 * spriteSize, 1 * spriteSize, 0), Quaternion.identity);
        Instantiate(Enemy, new Vector3((sizex -2) * spriteSize, (sizey -2) * spriteSize, 0), Quaternion.identity);
    }


    bool randomBoolean()
    {
        if (UnityEngine.Random.value >= 0.5)
        {
            return true;
        }
        return false;
    }
}