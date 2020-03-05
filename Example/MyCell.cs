using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AquaFramework;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MyCell : ViewBase, IBindableListCell<CellData>
{
    [SerializeField] TextMeshProUGUI _text;
    //1.如何实现IBindableListCell接口中的Index和Value属性
    int _index;
    public int Index { get => _index; set => _index = value; }
    CellData _value;
    public CellData Value { get => _value; set => _value = value; }

    //2.使用SetContext完成对cell的初始化
    public void SetContext(CellData item)
    {
        _text.text = item.Text;
    }

    //3.释放Value属性
    void OnDestroy()
    {
        Value = null;
    }
}