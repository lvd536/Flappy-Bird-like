using UnityEngine;

public interface IStorageService
{
    public object Load(object obj);
    public void Save(object obj);
}
