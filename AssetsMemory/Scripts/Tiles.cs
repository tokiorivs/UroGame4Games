using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tiles : MonoBehaviour
{
    public int x;
    public int y;
    public CardManager table;

    public void Setup(int x_, int y_, CardManager table_)
    {
        this.x = x_;
        this.y = y_;
        this.table = table_;
    }
}
