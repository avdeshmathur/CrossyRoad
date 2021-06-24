using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "Terrain Data", menuName = "terrainData")]
public class TerrainData : ScriptableObject
{
    public List <GameObject> PossibleTerrain;  
    public int maxInSuccession;
}
