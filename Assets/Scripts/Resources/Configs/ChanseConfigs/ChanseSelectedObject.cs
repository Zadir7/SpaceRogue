using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ChanseSelectObject", menuName = "ChanseSelectedObject")]
public class ChanseSelectedObject : ScriptableObject
{
    public List<ChanseSelectObjectConfig> ChanseSelectobjects;
}
