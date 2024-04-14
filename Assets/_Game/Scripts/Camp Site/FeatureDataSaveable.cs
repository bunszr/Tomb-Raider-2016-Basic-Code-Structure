using UnityEngine;

[System.Serializable]
public class FeatureDataSaveable
{
    [SerializeField] string guid;
    [SerializeField] bool isOpen = true;

    public FeatureDataSaveable(string guid, bool isOpen)
    {
        this.guid = guid;
        this.isOpen = isOpen;
    }

    public string Guid { get => guid; }
    public bool IsOpen { get => isOpen; set => isOpen = value; }

    // [Button]
    public bool CreateGuidIfNotExist()
    {
        if (guid == string.Empty)
        {
            guid = System.Guid.NewGuid().ToString();
            return true;
        }
        return false;
    }

    public void CreateNewGuid() => guid = System.Guid.NewGuid().ToString();
}