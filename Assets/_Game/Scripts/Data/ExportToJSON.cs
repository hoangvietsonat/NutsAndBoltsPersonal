using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using System.IO;

public class ExportToJSON : MonoBehaviour
{
    public GameObject objectToExport; // Kéo và thả GameObject cha cần export trong Inspector

    [System.Serializable]
    public class ObjectData
    {
        public string name;
        public Vector3 position;
        public Vector3 rotation;
    }

    public void Export()
    {

        List<ObjectData> objectDataList = new List<ObjectData>();

        foreach (Transform child in objectToExport.transform)
        {
            ObjectData objectData = new ObjectData();
            objectData.name = child.name;
            objectData.position = child.position;
            objectData.rotation = child.rotation.eulerAngles;
            objectDataList.Add(objectData);
        }

        string json = JsonHelper.ToJson(objectDataList.ToArray(), true);

        string path = EditorUtility.SaveFilePanel(
            "Save JSON",
            "",
            "exportedData.json",
            "json");

        if (!string.IsNullOrEmpty(path))
        {
            File.WriteAllText(path, json);
            Debug.Log("Exported to: " + path);
        }
    }
}

// Class helper để sử dụng JsonUtility cho List trong Unity
public static class JsonHelper
{
    public static string ToJson<T>(T[] array, bool prettyPrint)
    {
        string json = "{\n\t\"Items\": [\n";
        for (int i = 0; i < array.Length; i++)
        {
            string itemJson = JsonUtility.ToJson(array[i]);
            json += "\t\t" + itemJson;
            if (i < array.Length - 1)
            {
                json += ",";
            }
            json += "\n";
        }
        json += "\t]\n}";
        return json;
    }
}
