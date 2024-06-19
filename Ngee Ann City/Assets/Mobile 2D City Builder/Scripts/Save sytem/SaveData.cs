using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MobileCityBuilder
{
    [System.Serializable]
    public class SaveData
    {
        public List<BuildingData> buildings = new List<BuildingData>();
        public Player player = new Player(16);
    }
}