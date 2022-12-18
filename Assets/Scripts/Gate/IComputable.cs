using UnityEngine;

namespace Gate
{
    public interface IComputable
    {
        int CalculateSpawnCount(int armyCount);
    }
}