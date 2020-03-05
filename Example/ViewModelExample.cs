using AquaFramework;
using System;
using System.Collections.Generic;
using UnityEngine;

public class ViewModelExample : ViewModelBase
{
    //public IBindableProperty<string> Text;
    //public IBindableProperty<float> Float;
    //public IBindableProperty<Sprite> ImageSource;
    public IBindableList<CellData> MyList;
    //public IBindableDictionary<int, string> KeyValuePairs;
    //public void OnClick()
    //{
    //    Debug.Log("Button Click");
    //}
    //public void OnValueChanged<T>(T value)
    //{
    //    Debug.Log("Value Changed: " + value);
    //}
    public ViewModelExample()
    {
        //属性绑定

        //1.如何创建一个值类型或string类型的可绑定属性
        //Text = CreateBindableProperty<string>();
        //Float = CreateBindableProperty<float>();
        //2.如何修改和设置一个可绑定属性的值
        //Text.Value = "Hello World";
        //Float.Value = 0.5f;

        //3.如何创建一个引用类型的可绑定的属性
        //ImageSource = CreateBindableProperty<Sprite>();
        //4.当使用引用类型的可绑定属性时，使用一个新的类替换原来的值，而不是直接修改原来的值
        //ImageSource.Value = Resources.Load<Sprite>("Aqua1");

        //5.为可绑定属性添加响应函数
        //Text.ValueChanged += OnTextValueChanged;
        //Float.ValueChanged += OnValueChanged;

        //列表绑定

        //1.如何创建一个可绑定列表
        /*MyList = CreateBindableList<CellData>(true, 5);*///创建一个大小为3的循环绑定列表
        //MyList = CreateBindableList<MyCellData>(false, -1);//创建一个无限列表

        //2.如何为列表添加响应函数
        //MyList.OnAdd += (IBindableList<CellData> myCellDatas, List<CellData> list) =>
        //{
        //    foreach (CellData myCellData in list)
        //    {
        //        Debug.Log(myCellData.Text);
        //    }
        //};
        //MyList.OnRemove += (IBindableList<CellData> myCellDatas, List<CellData> list) =>
        //{
        //    foreach (CellData myCellData in list)
        //    {
        //        Debug.Log(myCellData.Text);
        //    }
        //};
        //MyList.OnListChanged += (IBindableList<CellData> myCellDatas) =>
        //{
        //    Debug.Log("List changed");
        //};

        //KeyValuePairs = CreateBindableDictionary<int, string>();
        //KeyValuePairs.OnAdd += KeyValuePairs_OnAdd;
        //KeyValuePairs.OnDictionaryChanged += KeyValuePairs_OnDictionaryChanged;
        //KeyValuePairs.OnRemove += KeyValuePairs_OnRemove;
        //KeyValuePairs.Add(1,"1");
        //KeyValuePairs.Add(1,"1");
        //KeyValuePairs.Add(1,"1");
        //KeyValuePairs.Remove(1);
    }
   
    //private void KeyValuePairs_OnRemove(IBindableDictionary<int, string> arg1, Dictionary<int, string> arg2)
    //{
    //    throw new NotImplementedException();
    //}

    //private void KeyValuePairs_OnDictionaryChanged(IBindableDictionary<int, string> obj)
    //{
    //    throw new NotImplementedException();
    //}

    //private void KeyValuePairs_OnAdd(IBindableDictionary<int, string> arg1, Dictionary<int, string> arg2)
    //{
    //    throw new NotImplementedException();
    //}

    //void OnTextValueChanged(string value)
    //{
    //    Debug.Log("Text value changed: " + value);
    //}
}