using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace MobileCityBuilder
{
    [System.Serializable]
    public class SaveData
    {
        // Save the buildings that were put onto the scene
        public List<BuildingData> buildings = new List<BuildingData>();
    }
}