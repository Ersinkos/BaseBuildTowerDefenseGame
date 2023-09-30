using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingGhost : MonoBehaviour
{
    private GameObject spriteGameObject;
    private ResourceNearbyOverlay resourceNearbyOverlay;
    private void Awake()
    {
        spriteGameObject = GameObject.Find("GhostSprite").gameObject;
        resourceNearbyOverlay = transform.Find("pfResourceNearbyOverlay").GetComponent<ResourceNearbyOverlay>();


        Hide();
    }
    private void Update()
    {
        transform.position = UtilsClass.GetMouseWorldPosition();
    }
    private void Start()
    {
        BuildingManager.instance.OnActiveBuildingTypeChanged += BuildingManager_OnActiveBuildingTypeChanged;
    }

    private void BuildingManager_OnActiveBuildingTypeChanged(object sender, BuildingManager.OnActiveBuildingTypeChangedEventArgs e)
    {
        if (e.activeBuildingType == null)
        {
            Hide();
            resourceNearbyOverlay.Hide();
        }
        else
        {
            Show(e.activeBuildingType.sprite);
            resourceNearbyOverlay.Show(e.activeBuildingType.resourceGeneratorData);
        }
    }

    private void Show(Sprite ghostSprite)
    {
        spriteGameObject.SetActive(true);
        spriteGameObject.GetComponent<SpriteRenderer>().sprite = ghostSprite;
    }
    private void Hide()
    {
        spriteGameObject.SetActive(false);
    }
}
