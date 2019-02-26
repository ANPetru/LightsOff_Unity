using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    public static int NUM_ROWS_COLS;
    public LevelChanger LevelChanger;
    private Light[] l;
    private Light[,] lights;

    // Use this for initialization
    void Start()
    {
        l = GetComponentsInChildren<Light>();
        NUM_ROWS_COLS = (int)Mathf.Round(Mathf.Sqrt(l.Length)); 
        InitBoxes();
    }

    private void Update()
    {
        if (CheckLights())
        {
            LevelChanger.PlayFadeAnim();
        }
    }

    private void InitBoxes()
    {
        lights = new Light[NUM_ROWS_COLS, NUM_ROWS_COLS];
        int k = 0;
        for (int i = 0; i < NUM_ROWS_COLS; i++)
        {
            for (int j = 0; j < NUM_ROWS_COLS; j++)
            {
                lights[i, j] = l[k];
                GetNumNeigbours(i, j);
                k++;
            }
        }

        for (int i = 0; i < NUM_ROWS_COLS; i++)
        {
            for (int j = 0; j < NUM_ROWS_COLS; j++)
            {
                GetNumNeigbours(i, j);
            }
        }
    }

    private void GetNumNeigbours(int row, int col)
    {

        if (row - 1 >= 0)
        {
            lights[row, col].AddNeighbour(lights[row - 1, col]);
        }
        if (col + 1 < Board.NUM_ROWS_COLS)
        {
            lights[row, col].AddNeighbour(lights[row, col + 1]);

        }
        if (row + 1 < Board.NUM_ROWS_COLS)
        {
            lights[row, col].AddNeighbour(lights[row + 1, col]);

        }
        if (col - 1 >= 0)
        {
            lights[row, col].AddNeighbour(lights[row, col - 1]);

        }

    }

    private bool RandomLights()
    {
        for (int i = 0; i < NUM_ROWS_COLS; i++)
        {
            for (int j = 0; j < NUM_ROWS_COLS; j++)
            {
                if (Random.Range(1, 3) == 2)
                    lights[i, j].isOn = true;
            }
        }

        return CheckLights();
    }

    private bool CheckLights()
    {
        for (int i = 0; i < NUM_ROWS_COLS; i++)
        {
            for (int j = 0; j < NUM_ROWS_COLS; j++)
            {
                if (lights[i, j].isOn)
                {
                    return false;
                }
            }
        }
        return true;
    }
}
