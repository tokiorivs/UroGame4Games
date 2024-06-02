using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// add/remove sprites -> to be used on cards for gamemanager.cs
/// </summary>
public class CardSpriteManager : Singleton<CardSpriteManager>
{
    [SerializeField] List<Sprite> m_Sprites;

    public List<Sprite> Sprites
    {
        get
        {
            return m_Sprites;
        }
    }
}