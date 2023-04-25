using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MapEvent
{
    None,
    Battle,
    Buff,
    Debuff
}

[System.Serializable]
public class Mapdata
{
    public List<EnemyBase> enemies = new List<EnemyBase>();
    public MapEvent mapEvent;

    public Mapdata Copy()
    {
        var mapData = new Mapdata();
        //mapData.mapEvent = mapEvent;
        //mapData.enemies = enemies;
        return mapData;
    }
    public void initialWave()
    {
        mapEvent = (MapEvent)Random.Range(0, 4);
        switch (mapEvent)
        {
            case MapEvent.None:
                {

                    break;
                }
            case MapEvent.Battle:
                {
                    WaveAdd();
                    break;
                }
            case MapEvent.Buff:
                {

                    break;
                }
            case MapEvent.Debuff:
                {
                    break;
                }
        }
    }
    public void WaveAdd()
    {
        var gm = GameManager.instance;
        for (int i = 0; i < Random.Range(1, 5); i++)
        {
            enemies.Add(gm.enemyBases[Random.Range(0, gm.enemyBases.Count)]);
        }
    }
}
