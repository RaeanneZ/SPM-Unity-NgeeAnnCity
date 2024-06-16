using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MobileCityBuilder
{
    public class GameManager : MonoBehaviour
    {
        [Header("Arrays")]
        public GameObject[] structureArray;
        [HideInInspector]
        public SaveData save;

        [Header("Scripts")]
        public CameraController cameraController;
        public RoadManager roadManager;
        
        [Header("Game Objects")]
        public GameObject mainPanel;
        public GameObject shop;
        public GameObject buildRoadsPanel;
        public GameObject replaceBuidlingsPanel;
        public GameObject destroyBuidlingsPanel;
        public GameObject spawnPointOfBuildings;
        [HideInInspector]
        public GameObject selectedBuilding;

        //Variables
        [HideInInspector]
        public bool buildingSelected;
        [HideInInspector]
        public int buildingNumber;
        [HideInInspector]
        public bool replaceMode;
        [HideInInspector]
        public bool destroyMode;

        void Start()
        {
            mainPanel.SetActive(true);
            shop.SetActive(false);
            buildRoadsPanel.SetActive(false);
            replaceBuidlingsPanel.SetActive(false);
            destroyBuidlingsPanel.SetActive(false);
            replaceMode = false;
            destroyMode = false;
            OnLoad();
        }

        void Update()
        {
            if(buildingSelected)
            {
                cameraController.movement = false;
            }
            else
            {
                cameraController.movement = true;
            }
        }

        //Buttons

        public void OpenShop()
        {
            mainPanel.SetActive(false);
            shop.SetActive(true);
            buildingSelected = true;
        }

        //This button close everything, so I used it for every Panel
        public void CloseButton()
        {
            mainPanel.SetActive(true);
            shop.SetActive(false);
            replaceBuidlingsPanel.SetActive(false);
            destroyBuidlingsPanel.SetActive(false);
            buildingSelected = false;
            replaceMode = false;
            destroyMode = false;
            selectedBuilding = null;
        }

        public void BuyBuilding(int number)
        {
            buildingNumber = number;
            cameraController.movement = false;
            shop.SetActive(false);
            GameObject house = Instantiate(structureArray[buildingNumber], spawnPointOfBuildings.transform.position, Quaternion.identity);
            selectedBuilding = house;
            Building buildingScript = house.GetComponent<Building>();
            buildingScript.buildingState = Building.BuildingState.firstStart;
            buildingScript.mouseDrag = true;
            buildingSelected = true;
        }

        public void ReplaceBuildingsMode()
        {
            replaceMode = true;
            mainPanel.SetActive(false);
            shop.SetActive(false);
            replaceBuidlingsPanel.SetActive(true);
            if(selectedBuilding != null)
            {
                Building replacableBuilding = selectedBuilding.GetComponent<Building>();
                replacableBuilding.ResetCanvas();
                replacableBuilding.buildingState = Building.BuildingState.replacing;
            }
        }

        public void DestroyBuildingsMode()
        {
            destroyMode = true;
            mainPanel.SetActive(false);
            shop.SetActive(false);
            destroyBuidlingsPanel.SetActive(true);
            if(selectedBuilding != null)
            {
                Building destroyableBuilding = selectedBuilding.GetComponent<Building>();
                destroyableBuilding.ResetCanvas();
                destroyableBuilding.buildingState = Building.BuildingState.destroying;
            }
        }

        public void OpenRoadsPanel()
        {
            mainPanel.SetActive(false);
            buildRoadsPanel.SetActive(true);
            buildingSelected = true;
            shop.SetActive(false);
            roadManager.buildRoadsByClick = true;
        }

        public void YesButtonRoad()
        {
            mainPanel.SetActive(true);
            buildRoadsPanel.SetActive(false);
            buildingSelected = false;
            roadManager.changeTheSprite = false;
            roadManager.buildRoadsByClick = false;
            roadManager.selectedObject = null;

            roadManager.AddingInfoFromRoadsArray();
            OnSave();
        }

        public void NoButtonRoad()
        {
            mainPanel.SetActive(true);
            buildRoadsPanel.SetActive(false);
            buildingSelected = false;
            roadManager.changeTheSprite = true;
            roadManager.buildRoadsByClick = false;
            roadManager.selectedObject = null;
            Invoke("TurnOffSpritesChanging", 0.3f);

            foreach(RoadThatWasRecentlyMadeData roads in roadManager.roadsThatWasRecentlyMadeArray)
            {
                Destroy(roads.roadGameObject);
            }
            roadManager.roadsThatWasRecentlyMadeArray.Clear();
        }

        private void TurnOffSpritesChanging()
        {
            roadManager.changeTheSprite = false;
        }

        //Save system

        public void OnSave()
        {
            SerializationManager.Save(save);
        }

        public void OnLoad()
        {
            save = SerializationManager.Load();

            for(int i = 0; i < save.buildings.Count; i++)
            {
                BuildingData currentBuilding = save.buildings[i];
                GameObject obj = Instantiate(structureArray[(int)currentBuilding.buildingType]);
                if(currentBuilding.buildingType != BuildingType.Road)
                {
                    Building structure = obj.GetComponent<Building>();
                    structure.nextUpdate = currentBuilding.Level;
                }
                obj.transform.position = currentBuilding.position;
                obj.transform.rotation = currentBuilding.rotation;
            }
        }
    }
}
