using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[RequireComponent(typeof(Inventory))]
public class DisplayInventory : MonoBehaviour
{
    private Inventory _inventory;

    [SerializeField] private GameObject _sectorUIContainer;
    [SerializeField] private GameObject _sectorUIElement;
    [SerializeField] private GameObject _evidenceUIContainer;
    [SerializeField] private GameObject _evidenceUIElement;

#region unity events
    private void OnEnable()
    {
        _inventory = GetComponent<Inventory>();
    }

    private void Start()
    {
        PopulateSectorUIList();
        PopulateEvidenceUIList();
    }
#endregion

#region custom methods
    private void PopulateSectorUIList()
    {
        foreach (Sector sectorItem in _inventory.SectorItems)
        {
            // instantiates the UI element
            var sector = Instantiate<GameObject>(_sectorUIElement);
            sector.name = sectorItem.DataName;

            // parents and scales stuff correctly according to the canvas
            sector.transform.SetParent(_sectorUIContainer.transform);
            sector.transform.localScale = Vector3.one;
            Vector3 localPos = sector.transform.localPosition;
            sector.transform.localPosition = new Vector3(localPos.x, localPos.y, 0);

            // fetches the text elements in the prefabs
            TextMeshProUGUI[] sectorData = sector.GetComponentsInChildren<TextMeshProUGUI>();

            // fills in the categories for each of them, in the order!
            sectorData[0].text = sectorItem.DataName;
            sectorData[1].text = sectorItem.RemainingTime.ToString();
            sectorData[2].text = $"{sectorItem.CorruptionLevel}%";
            sectorData[3].text = sectorItem.Status.ToString();
            
        }
    }

    private void PopulateEvidenceUIList()
    {
        foreach (Evidence evidenceItem in _inventory.EvidenceItems)
        {
            // instantiates the UI element
            var sector = Instantiate<GameObject>(_evidenceUIElement);
            sector.name = evidenceItem.DataName;

            // parents and scales stuff correctly according to the canvas
            sector.transform.SetParent(_evidenceUIContainer.transform);
            sector.transform.localScale = Vector3.one;
            Vector3 localPos = sector.transform.localPosition;
            sector.transform.localPosition = new Vector3(localPos.x, localPos.y, 0);

            // fetches the text elements in the prefabs
            TextMeshProUGUI[] sectorData = sector.GetComponentsInChildren<TextMeshProUGUI>();

            // fills in the categories for each of them, in the order!
            sectorData[0].text = evidenceItem.DataName;
            sectorData[1].text = evidenceItem.Type.ToString();
            sectorData[2].text = $"{evidenceItem.CorruptionLevel}%";
        }
    }

    #region tentative at making a generic method rather failed
    private void PopulateUIList<T>(GameObject itemContainer, GameObject itemEntryPrefab, List<T> dataBlocks)
    {
        bool isEvidence = false;
        bool isSector = false;

        // casting to access all properties of types
        List<Evidence> evidenceList = new List<Evidence>();
        List<Sector> sectorList = new List<Sector>();
        List<DataBlock> dataBlockList = dataBlocks as List<DataBlock>;

        if (dataBlocks is List<Evidence>)
        {
            evidenceList = dataBlocks as List<Evidence>;
            Debug.Log(evidenceList);
            isEvidence = true;
        }
        else if (dataBlocks is List<Sector>)
        {
            sectorList = dataBlocks as List<Sector>;
            Debug.Log(sectorList);
            isSector = true;
        }
        else Debug.LogWarning("Type demanded for populating list not supported by script");


        for (int i = 0; i < dataBlockList.Count; i++)
        {
            var entryLine = Instantiate<GameObject>(itemEntryPrefab);
            entryLine.name = dataBlockList[i].DataName;

            // parents and scales stuff correctly according to the canvas
            entryLine.transform.SetParent(itemContainer.transform);
            entryLine.transform.localScale = Vector3.one;
            Vector3 localPos = entryLine.transform.localPosition;
            entryLine.transform.localPosition = new Vector3(localPos.x, localPos.y, 0);

            // fetches the text elements in the prefabs
            TextMeshProUGUI[] TMPEntries = entryLine.GetComponentsInChildren<TextMeshProUGUI>();

            if (isEvidence)
            {
                TMPEntries[0].text = dataBlockList[i].DataName;
                TMPEntries[1].text = "type of the object";
                TMPEntries[2].text = dataBlockList[i].CorruptionLevel.ToString();
            }

            if (isSector)
            {
                // fills in the categories for each of them, in the order!
                TMPEntries[0].text = dataBlockList[i].DataName;
                TMPEntries[1].text = sectorList[i].RemainingTime.ToString();
                TMPEntries[2].text = $"{dataBlockList[i].CorruptionLevel}%";
                TMPEntries[3].text = sectorList[i].Status.ToString();
            }
        }

    }
    #endregion
#endregion
}
