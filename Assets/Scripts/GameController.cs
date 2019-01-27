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
    public int sizeMultiplier = 2;
    void Start()
    {
        generator = GetComponent<MazeConstructor>();      // 2
        generator.GenerateNewMaze(sizex, sizey);
        int[] myHousePosition = new int[] {sizex-2, sizey-1};
                    
        for (int y=0;y<sizey;y++) {
            for (int x=0;x<sizex;x++)
            {
                if (x==sizex-2 && y == sizey - 1)
                {
                    Instantiate(MyHouse, new Vector3(x * spriteSize * sizeMultiplier, y * spriteSize * sizeMultiplier, 0), Quaternion.identity);
                } else { 
                    if (generator.data[x,y] == 1) {
                        if (randomBoolean())
                        {
                            Instantiate(Wall, new Vector3(x * spriteSize * sizeMultiplier, y * spriteSize * sizeMultiplier, 0), Quaternion.identity);
                        }
                        else
                        {
                            Instantiate(Wall2, new Vector3(x * spriteSize * sizeMultiplier, y * spriteSize * sizeMultiplier, 0), Quaternion.identity);
                        }
                    }
                    else
                    {
                        Instantiate(Road, new Vector3(x * spriteSize * sizeMultiplier, y * spriteSize * sizeMultiplier, 1), Quaternion.identity);
                    }
                }
            }
        }
        Instantiate(Player, new Vector3(1 * spriteSize, 1 * spriteSize, 0), Quaternion.identity);
        // Instantiate(Player, new Vector3(myHousePosition[0] * spriteSize, (myHousePosition[1]-1) * spriteSize, 0), Quaternion.identity);
        Tuple<int, int> enemyPosition = RandomPosition();
        //Instantiate(Enemy, new Vector3(enemyPosition.Item1 * spriteSize, enemyPosition.Item2 * spriteSize, 0), Quaternion.identity);

        Tuple<int, int> keyPosition = RandomPosition();
        // Instantiate(Key, new Vector3(keyPosition.Item1 * spriteSize, keyPosition.Item2 * spriteSize, 0), Quaternion.identity);
        Instantiate(Key, new Vector3(3 * spriteSize, 1 * spriteSize, 0), Quaternion.identity);
        GameObject.FindWithTag("MainCamera").GetComponent<CameraController>().gameAreaY = sizey * spriteSize*sizeMultiplier;
        GameObject.FindWithTag("MainCamera").GetComponent<CameraController>().gameAreaX = sizex * spriteSize*sizeMultiplier;
    }

    public Tuple<int, int> RandomPosition() {
        for(int i=0; ; i++) {
            int xBlockPosition = UnityEngine.Random.Range(0, sizex-1);
            int yBlockPosition = UnityEngine.Random.Range(0, sizey-1);

            if(generator.data[xBlockPosition, yBlockPosition] == 0) {
                return new Tuple<int, int>(xBlockPosition, yBlockPosition); 
            }
        }
        
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