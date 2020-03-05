# AquaFramework
## View
所有View都需要继承ViewBase类，所有的绑定关系会在view的OnDestory方法调用时解除
### 为UGUI绑定可绑定属性  
Aqua Framework支持将部分UGUI元素的属性绑定到可绑定属性上，绑定方式如下：  
`Bind<T>(UGUIElement uguiElement, string source, IBindableProperty<T> target, Model model)`
* 参数  
    * uguiElement ugui控件，如Button，Image
    * source 属性名，如Image的sprite，建议使用nameof关键字来获取属性名
    * target 可绑定属性，可绑定属性的类型需要与属性类型相同
    * model 绑定模式，再Aqua Framework中有OneTime，OneWay，TowWay三种绑定模式
        * OneTime：在绑定时，参与绑定的ugui的属性被同步为可绑定属性的值，之后参与绑定ugui的属性不再随着可绑定属性的值变化而变化
        * OneWay：在绑定时，参与绑定的ugui的属性被同步为可绑定属性的值，之后，若可绑定属性的值发生变化，ugui的属性也会随之变化
        * TowWay：在OneWay的基础上，若是改变ugui的属性的值，可绑定属性的值也会随之变化
* 示例
    * 将slider的value属性绑定到可绑定属性上  
    `Bind(_slider, nameof(_slider.value), _viewModel.target, Model.TowWay);`
* 支持列表
    * Image
        1. sprite  
            * Model  
            OneTime √
            OneWay √
            TowWay ×
    * TextMeshProUGUI
        1. text
            * Model  
            OneTime √
            OneWay √
            TowWay ×
    * TMP_InputField
        1. text
            * Model  
            OneTime √
            OneWay √
            TowWay √
    * Slider
        1. value
            * Model  
            OneTime √
            OneWay √
            TowWay √
    * Toggle
        1. isOn
            * Model  
            OneTime √
            OneWay √
            TowWay √
    * ScrollRect  
    Aqua Framework支持将ScrollRect与可绑定列表与可绑定字典绑定  
        1. ScrollRect与可绑定列表的绑定
            1. 定义cell的数据结构  
            ```C#
            public class CellData
            {
            string _text;
            public CellData(string text)
            {
            _text = text;
            }
            public string Text { get => _text; set => _text = value; }
            }
            ```
            
            2. 定义cell的view
            ```C#
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
            ```
            
            3. 绑定cell到可绑定列表
            ```C#
            Bind(_scrollRect, _viewModelExample.List, _cell, Model.OneTime);
            ```
            _scrollRect：ScrollRect控件  
            List：可绑定列表  
            _cell：cell的预制体  
            Model：对列表的绑定支持OneTime和OneWay两种方式

### 为UGUI绑定响应函数
* 定义响应函数
```C#
public void OnClick()
{
Debug.Log("Button Click");
}
```
    
* 绑定
```C#
Bind(_button.onClick, _viewModelExample.OnClick);
```

### 为委托绑定可绑定属性
可将Action<T>类型的委托绑定到可绑定属性上
* 定义函数
```C#
void SetText(string value)
{
   _text.text = value;
}
```
   
* 绑定
```C#
Bind(SetText, _viewModelExample.Text, Model.OneTime);
```
委托绑定支持 OneTime和OneWay两种方式，委托绑定主要用于扩展对ugui绑定的支持

## View Model 和 Model
View Model可以继承ViewModelBase类来获取创建可绑定成员的方法，或者是使用Zenject或BindableMemberFactory来创建可绑定成员
### 可绑定属性
* 创建一个可绑定属性
```C#
public IBindableProperty<string> Text;
Text = CreateBindableProperty<string>();
```

* 修改或读取可绑定属性值
```C#
Text.Value = "Hello World";
```
若可绑定属性为非string的引用类型，则创建一个新对象来替代原来的对象

```C#
public IBindableProperty<Sprite> ImageSource;
ImageSource = CreateBindableProperty<Sprite>();
ImageSource.Value = Resources.Load<Sprite>("path");
```

* 为可绑定属性添加响应函数
```C#
void OnTextValueChanged(string value)
{
Debug.Log("Text value changed: " + value);
}
Text.ValueChanged += OnTextValueChanged;
```
在可绑定属性发生改变时，该回调会被调用

### 可绑定列表
* 创建一个可绑定列表
```C#
public IBindableList<CellData> MyList;
_viewModelExample.MyList[1] = new MyCellData();
MyList = CreateBindableList<CellData>(true, 5);
```
* 对可绑定列表中的元素进行操作
IBindableList<T>接口中的方法与属性与List<T>中的方法和属性一致  
你可以想使用List<T>一样对IBindableList<T>进行操作
```C#
_viewModelExample.MyList.Add(new MyCellData());
_viewModelExample.MyList.RemoveAt(0);

```

* 为可绑定列表添加响应函数
```C#
MyList.OnAdd += (IBindableList<CellData> myCellDatas, List<CellData> list) =>
{
    foreach (CellData myCellData in list)
    {
        Debug.Log(myCellData.Text);
    }
};
MyList.OnRemove += (IBindableList<CellData> myCellDatas, List<CellData> list) =>
{
    foreach (CellData myCellData in list)
    {
        Debug.Log(myCellData.Text);
    }
};
MyList.OnListChanged += (IBindableList<CellData> myCellDatas) =>
{
    Debug.Log("List changed");
};
```
可绑定列表共有三个事件：OnListChanged、OnAdd和OnRemove，OnListChanged在列表的元素发生变化时被调用（注：修改某个元素的具体属性并不会触发事件），OnAdd在列表元素增加时调用，OnRemove在列表元素减少时被调用。
### 可观察的字典
* 创建一个可绑定字典
```C#
public IBindableDictionary<int, string> KeyValuePairs;
KeyValuePairs = CreateBindableDictionary<int, string>();
```
* 对可绑定字典中的元素进行操作
```C#
KeyValuePairs.Add(1,"1");
KeyValuePairs.Remove(1);
```
像使用Dictionary<TKey, TValue>一样使用IBindableDictionary
* 对可绑定字典添加响应函数
```C#
KeyValuePairs = CreateBindableDictionary<int, string>();
KeyValuePairs.OnAdd += KeyValuePairs_OnAdd;
KeyValuePairs.OnDictionaryChanged += KeyValuePairs_OnDictionaryChanged;
KeyValuePairs.OnRemove += KeyValuePairs_OnRemove;

private void KeyValuePairs_OnRemove(IBindableDictionary<int, string> arg1, Dictionary<int, string> arg2)
{
    throw new NotImplementedException();
}

private void KeyValuePairs_OnDictionaryChanged(IBindableDictionary<int, string> obj)
{
    throw new NotImplementedException();
}

private void KeyValuePairs_OnAdd(IBindableDictionary<int, string> arg1, Dictionary<int, string> arg2)
{
    throw new NotImplementedException();
}
```


