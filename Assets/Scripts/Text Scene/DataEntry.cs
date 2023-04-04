using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[Serializable]
public class DataEntry : MonoBehaviour, IComparable<DataEntry>
{

    [SerializeField] TextMeshProUGUI Db;
    [SerializeField] TextMeshProUGUI User;
    [SerializeField] TextMeshProUGUI Time;
    [SerializeField] TextMeshProUGUI Command;


    public string DbText;
    public string UserText;
    public string TimeText;
    public string CommandText;


    private void Start()
    {
        SetupPrefab();
    }

    void SetupPrefab()
    {
        Db.text = DbText;
        User.text = UserText;
        Time.text = TimeText;
        Command.text = CommandText;
    }


    // Default sort by User
    public int CompareTo(DataEntry obj)
    {
        return this.UserText.CompareTo(obj.UserText);
    }

    public override string ToString()
    {
        return $"{DbText} {UserText} {TimeText} {CommandText} ";
    }

}

#region Comparer Classes
class CompareByCommand : IComparer<DataEntry>
{

    public int Compare(DataEntry x, DataEntry y)
    {
        return x.CommandText.CompareTo(y.CommandText);
    }
}

class CompareByTime : IComparer<DataEntry>
{
    public int Compare(DataEntry x, DataEntry y)
    {
        return x.TimeText.CompareTo(y.TimeText);
    }
}

class CompareByDb : IComparer<DataEntry>
{
    public int Compare(DataEntry x, DataEntry y)
    {
        return x.DbText.CompareTo(y.DbText);
    }
}

#endregion
