using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "New Shared Data", menuName = "Shared Data", order = 1)]
public class SharedData : ScriptableObject
{
    public string name;
    public List<string> list; //공유 필요한 변수 추가해서 사용하세요!

}