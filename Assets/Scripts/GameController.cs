﻿using System;
using UnityEngine;

[RequireComponent(typeof(MazeConstructor))]               // 1

public class GameController : MonoBehaviour
{
    private MazeConstructor generator;
    public Transform Wall;
    public Transform Road;
    public Transform Player;
    public Transform Enemy;
    public Transform Key;
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
                    Instantiate(Road, new Vector3(x * spriteSize, y * spriteSize, 1), Quaternion.identity);
                }
            }
        }
        Instantiate(Player, new Vector3(1 * spriteSize, 1 * spriteSize, 0), Quaternion.identity);
        Instantiate(Enemy, new Vector3((sizex -2) * spriteSize, (sizey -2) * spriteSize, 0), Quaternion.identity);

        Tuple<int, int> keyPosition = KeyPosition();
        Instantiate(Key, new Vector3(keyPosition.Item1 * spriteSize, keyPosition.Item2 * spriteSize, 0), Quaternion.identity);
        
    }

    public Tuple<int, int> KeyPosition() {
        for(int i=0; ; i++) {
            int xBlockPosition = UnityEngine.Random.Range(0, sizex-1);
            int yBlockPosition = UnityEngine.Random.Range(0, sizey-1);

            if(generator.data[xBlockPosition, yBlockPosition] == 0) {
                return new Tuple<int, int>(xBlockPosition, yBlockPosition); 
            }
        }
        
    }
}