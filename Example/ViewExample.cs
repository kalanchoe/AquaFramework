using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AquaFramework.Binding;
using AquaFramework;
using Zenject;
using UnityEngine.UI;
using TMPro;

public class ViewExample : ViewBase
{
    //0.使用Zenject注入view model
    [Inject] ViewModelExample _viewModelExample;
    [SerializeField] GameObject _cell;
    [SerializeField] Button _button;
    [SerializeField] TextMeshProUGUI _text;
    [SerializeField] Toggle _toggle;
    [SerializeField] Slider _slider;
    [SerializeField] TMP_InputField _inputField;
    [SerializeField] Image _image;
    [SerializeField] ScrollRect _scrollRect;
    // Start is called before the first frame update    
    void Start()
    {
        //1.为UGUI绑定响应函数
       //Bind(_button.onClick, _viewModelExample.OnClick);
        //Bind(_toggle.onValueChanged, _viewModelExample.OnValueChanged);
        //Bind(_slider.onValueChanged, _viewModelExample.OnValueChanged);
        //Bind(_inputField.onValueChanged, _viewModelExample.OnValueChanged);
        //2.为委托绑定可绑定属性
        //Bind(SetText, _viewModelExample.Text, Model.OneTime);//单次绑定：action会在绑定时被调用一次
        //Bind(SetText, _viewModelExample.Text, Model.OneWay);//单向绑定：action会在可绑定属性的值改变时被调用一次
        //Bind(SetText, _viewModelExample.Text, Model.TowWay);//双向绑定：action不支持双向绑定，抛出异常 AquaFrameworkException: Do not support tow way binding for action.
        //3.为Image绑定可绑定属性
        //Bind(_image, nameof(_image.sprite), _viewModelExample.ImageSource, Model.OneTime);//单次绑定：image的sprite属性会在绑定时被更新为可绑定属性的值
        //Bind(_image, nameof(_image.sprite), _viewModelExample.ImageSource, Model.OneWay);//单向绑定：image的sprite属性会在可绑定属性的值被改变时更新
        //Bind(_image, nameof(_image.sprite), _viewModelExample.ImageSource, Model.TowWay);//双向绑定：image的sprite属性不支持双向绑定，抛出异常 AquaFrameworkException: Do not support tow way binding for Image.
        //4.为TextMeshProUGUI绑定可绑定属性
        //Bind(_text, nameof(_text.text), _viewModelExample.Text, Model.OneTime);
        //Bind(_text, nameof(_text.text), _viewModelExample.Text, Model.OneWay);
        //Bind(_text, nameof(_text.text), _viewModelExample.Text, Model.TowWay);//双向绑定：TextMeshProUGUI不支持双向绑定，抛出异常 AquaFrameworkException: Do not support tow way binding for TextMeshProUGUI.
        //5.为TMP_InputField绑定可绑定属性
        //Bind(_inputField, nameof(_inputField.text), _viewModelExample.Text, Model.OneTime);
        //Bind(_inputField, nameof(_inputField.text), _viewModelExample.Text, Model.OneWay);
        //Bind(_inputField, nameof(_inputField.text), _viewModelExample.Text, Model.TowWay);
        //6.为Slider绑定可绑定属性
        //Bind(_slider, nameof(_slider.value), _viewModelExample.Float, Model.OneTime);
        //Bind(_slider, nameof(_slider.value), _viewModelExample.Float, Model.OneWay);
        //Bind(_slider, nameof(_slider.value), _viewModelExample.Float, Model.TowWay);
        //7.为ScrollRect绑定可绑定列表
        //Bind(_scrollRect, _viewModelExample.MyList, _cell, Model.OneTime);//content的内容在绑定时与可绑定列表同步一次
        //Bind(_scrollRect, _viewModelExample.MyList, _cell, Model.OneWay);//content的内容在可绑定列表发生变化时进行同步
        //_viewModelExample.MyList.Add(new MyCellData("1"));
        //_viewModelExample.MyList.Add(new MyCellData("2"));
        //_viewModelExample.MyList.Add(new MyCellData("3"));
        //_viewModelExample.MyList.Add(new MyCellData("4"));
        //_viewModelExample.MyList.Add(new MyCellData("5"));
        //_viewModelExample.MyList[1] = new MyCellData("6");
        //_viewModelExample.MyList.RemoveAt(0);
        //_viewModelExample.MyList.RemoveAt(0);
    }

    // Update is called once per frame
    void Update()
    {
    }

    void SetText(string value)
    {
        _text.text = value;
    }
}
