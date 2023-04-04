using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataHandler : MonoBehaviour
{
    [SerializeField]
    TextAsset _DataCSV;
    [SerializeField]
    DataEntry _DataEntryPrefab;
    [SerializeField]
    Transform _ContentTransform;

    string[] _dataFromCSV;

    DataEntry[] _entries;
    DataEntry[] _copyForUi;

    void Start()
    {
        ReadCsvFile();

        UpdateUi();
    }

    void ReadCsvFile()
    {
        _dataFromCSV = _DataCSV.text.Split("\n".ToCharArray());
        _entries = new DataEntry[_dataFromCSV.Length - 1];

        for (int i = 1; i < _dataFromCSV.Length; i++)
        {
            string[] line = _dataFromCSV[i].Split(",");
            if (line.Length > 0)
            {
                // Create new entry
                _entries[i - 1] = new DataEntry();

                // Fill entry with data
                _entries[i - 1].DbText = line[0];
                _entries[i - 1].UserText = line[1];
                _entries[i - 1].TimeText = line[2];
                _entries[i - 1].CommandText = line[3];

            }
        }
    }

    void UpdateUi()
    {
        // Copy the entries array to display in the UI
        _copyForUi = _entries;

        // Delete old Ui entries
        int childrenCount = _ContentTransform.childCount;
        for (int i = 0; i < childrenCount; i++)
        {
            Destroy(_ContentTransform.GetChild(i).gameObject);
        }

        // Create updated Ui entries from the copyForUi array
        foreach (DataEntry entry in _copyForUi)
        {
            DataEntry temp = Instantiate(_DataEntryPrefab, _ContentTransform);
            temp.DbText = entry.DbText;
            temp.UserText = entry.UserText;
            temp.TimeText = entry.TimeText;
            temp.CommandText = entry.CommandText;
        }

    }

    #region Compare Functions
    public void CompareByUser()
    {
        Array.Sort(_entries);

        // Print sorted array to console
        string str = "Sorted by User array:\n";
        foreach (DataEntry s in _entries)
        {
            str += $"{s}\n";
        }
        print(str);

        UpdateUi();
    }

    public void CompareByCommand()
    {
        Array.Sort(_entries, new CompareByCommand());

        // Print sorted array to console
        string str = "Sorted by Command array:\n";
        foreach (DataEntry s in _entries)
        {
            str += $"{s}\n";
        }
        print(str);

        UpdateUi();
    }

    public void CompareByDb()
    {
        Array.Sort(_entries, new CompareByDb());

        // Print sorted array to console
        string str = "Sorted by DB array:\n";
        foreach (DataEntry s in _entries)
        {
            str += $"{s}\n";
        }
        print(str);

        UpdateUi();
    }

    public void CompareByTime()
    {
        Array.Sort(_entries, new CompareByTime());

        // Print sorted array to console
        string str = "Sorted by Time array:\n";
        foreach (DataEntry s in _entries)
        {
            str += $"{s}\n";
        }
        print(str);

        UpdateUi();
    }
    #endregion


}
