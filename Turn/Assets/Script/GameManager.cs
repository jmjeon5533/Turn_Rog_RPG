using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = new GameManager();
    private void Awake()
    {
        instance = this;
    }
    [SerializeField] Transform EnemyPosParent, TeamPosParent;
    public List<EnemyBase> enemyBases = new List<EnemyBase>();
    public List<Mapdata> MapDataList = new List<Mapdata>();
    public List<TeamBase> TeamBases = new List<TeamBase>();
    [SerializeField] Mapdata MapdataPrefab;
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        for(int i = 0; i < EnemyPosParent.childCount; i++)
        {
            Gizmos.DrawWireCube(EnemyPosParent.GetChild(i).transform.position, new Vector3(1, 1, 1));
        }
        Gizmos.color = Color.green;
        for (int i = 0; i < TeamPosParent.childCount; i++)
        {
            Gizmos.DrawWireCube(TeamPosParent.GetChild(i).transform.position, new Vector3(1, 1, 1));
        }
    }
    private void Start()
    {
        for(int i = 0; i < 5; i++)
        CreateMapData();
        CunnectMapNode();
        MapMoveStart(0);
    }
    public void CreateMapData()
    {
        var m = MapdataPrefab.Copy();
        m.initialWave();
        MapDataList.Add(m);
    }
    public void MapMoveStart(int index)
    {
        switch (MapDataList[index].mapEvent)
        {
            case MapEvent.None:
                {

                    break;
                }
            case MapEvent.Battle:
                {
                    BattleStart(MapDataList[index]);
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
    public void BattleStart(Mapdata Mdata)
    {
        for(int i = 0; i < Mdata.enemies.Count; i++)
        {
            Instantiate(Mdata.enemies[i], EnemyPosParent.GetChild(i).transform.position, Quaternion.identity);
        }
        for(int i = 0; i < TeamBases.Count; i++)
        {
            Instantiate(TeamBases[i], TeamPosParent.GetChild(i).transform.position, Quaternion.identity);
        }
    }
    public void CunnectMapNode()
    {

    }
}
