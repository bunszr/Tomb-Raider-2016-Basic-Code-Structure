using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class UpdateManager : SingletonAndDontDestroyOnLoad<UpdateManager>
{
    [ReadOnly, ShowInInspector] List<UpdateData> updateDataList = new List<UpdateData>();
    [ReadOnly, ShowInInspector] List<UpdateData> fixedUpdateDataList = new List<UpdateData>();
    [ReadOnly, ShowInInspector] List<UpdateData> lateUpdateDataList = new List<UpdateData>();

    public delegate void UpdateMethodDelegate();

    public void RegisterAsUpdate(MonoBehaviour monoBehaviour, UpdateMethodDelegate updateMethodDelegate)
    {
        updateDataList.Add(new UpdateData(monoBehaviour, updateMethodDelegate));
    }

    public void UnregisterAsUpdate(MonoBehaviour monoBehaviour, UpdateMethodDelegate updateMethodDelegate)
    {
        RemoveFromList(updateDataList, monoBehaviour, updateMethodDelegate);
    }

    public void RegisterAsFixedUpdate(MonoBehaviour monoBehaviour, UpdateMethodDelegate updateMethodDelegate)
    {
        fixedUpdateDataList.Add(new UpdateData(monoBehaviour, updateMethodDelegate));
    }

    public void UnregisterAsFixedUpdate(MonoBehaviour monoBehaviour, UpdateMethodDelegate updateMethodDelegate)
    {
        RemoveFromList(fixedUpdateDataList, monoBehaviour, updateMethodDelegate);
    }

    public void RegisterAsLateUpdate(MonoBehaviour monoBehaviour, UpdateMethodDelegate updateMethodDelegate)
    {
        lateUpdateDataList.Add(new UpdateData(monoBehaviour, updateMethodDelegate));
    }

    public void UnregisterAsLateUpdate(MonoBehaviour monoBehaviour, UpdateMethodDelegate updateMethodDelegate)
    {
        RemoveFromList(lateUpdateDataList, monoBehaviour, updateMethodDelegate);
    }

    void RemoveFromList(List<UpdateData> updateDatas, MonoBehaviour monoBehaviour, UpdateMethodDelegate updateMethodDelegate)
    {
        for (int i = 0; i < updateDatas.Count; i++)
        {
            if (updateDatas[i].mono == monoBehaviour && updateDatas[i].UpdateMethodDelegate == updateMethodDelegate)
            {
                updateDatas.Remove(updateDatas[i]);
                break;
            }
        }
    }

    [System.Serializable]
    public struct UpdateData
    {
        public MonoBehaviour mono;
        public UpdateMethodDelegate UpdateMethodDelegate;

        [ReadOnly, ShowInInspector] public bool HasUpdated => mono != null && mono.isActiveAndEnabled;

        public UpdateData(MonoBehaviour monoBehaviour, UpdateMethodDelegate updateMethodDelegate)
        {
            this.mono = monoBehaviour;
            this.UpdateMethodDelegate = updateMethodDelegate;
        }

        public void UpdateCommon()
        {
            if (mono != null && mono.isActiveAndEnabled) UpdateMethodDelegate();
        }
    }

    private void Update()
    {
        for (int i = 0; i < updateDataList.Count; i++) updateDataList[i].UpdateCommon();
    }

    private void FixedUpdate()
    {
        for (int i = 0; i < fixedUpdateDataList.Count; i++) fixedUpdateDataList[i].UpdateCommon();
    }

    private void LateUpdate()
    {
        for (int i = 0; i < lateUpdateDataList.Count; i++) lateUpdateDataList[i].UpdateCommon();
    }
}