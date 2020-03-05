using AquaFramework.Exceptions;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace AquaFramework.Binding.BindingHelpers
{
    class BindingHelperForList<T> : IBindingHelper
    {
        GenerateGameObject _generateCell;
        ScrollRect _scrollRect;
        IBindableList<T> _list;
        GameObject _cell;
        Model _model;
        List<GameObject> _existence = new List<GameObject>();
        List<GameObject> _buffer = new List<GameObject>();

        public BindingHelperForList(ScrollRect scrollRect, IBindableList<T> list, GameObject cell, Model model, GenerateGameObject generateCell)
        {
            _scrollRect = scrollRect;
            _list = list;
            _cell = cell;
            _model = model;
            _generateCell = generateCell;

            if (_model == Model.OneTime)
            {
                OnListChanged(_list);
            }
            else if (_model == Model.OneWay)
            {
                OnListChanged(_list);
                _list.OnListChanged += OnListChanged;
            }
        }

        void OnListChanged(IBindableList<T> list)
        {
            while (_existence.Count < list.Count)
            {
                if (_buffer.Count > 0)
                {
                    GameObject temp = _buffer[0];
                    _buffer.RemoveAt(0);
                    temp.SetActive(true);
                    _existence.Add(temp);
                }
                else
                {
                    GameObject temp = _generateCell?.Invoke(_cell, _scrollRect.content);
                    _existence.Add(temp);
                }
            }
            while (_existence.Count > list.Count)
            {
                GameObject temp = _existence[0];
                _existence.RemoveAt(0);
                temp.SetActive(false);
                _buffer.Add(temp);
            }
            for (int i = 0; i < _existence.Count; i++)
            {
                _existence[i].transform.SetAsLastSibling();
                IBindableListCell<T> temp = _existence[i].GetComponent<IBindableListCell<T>>();
                if (temp == null) throw new AquaFrameworkException("The cell doesn't implement IBindableListCell<T>");
                temp.Index = i;
                temp.Value = list[i];
                temp.SetContext(list[i]);
            }
        }

        public void UnBind()
        {
            _generateCell = null;
            _scrollRect = null;
            _list = null;
            _cell = null;
            _existence.Clear();
            _buffer.Clear();
            _existence = null;
            _scrollRect = null;
        }
    }

    class BindingHelperForList<TCellData, TListContext> : IBindingHelper
    {
        GenerateGameObject _generateCell;
        ScrollRect _scrollRect;
        IBindableList<TCellData, TListContext> _list;
        GameObject _cell;
        Model _model;
        List<GameObject> _existence = new List<GameObject>();
        List<GameObject> _buffer = new List<GameObject>();

        public BindingHelperForList(ScrollRect scrollRect, IBindableList<TCellData, TListContext> list, GameObject cell, Model model, GenerateGameObject generateCell)
        {
            _scrollRect = scrollRect;
            _list = list;
            _cell = cell;
            _model = model;
            _generateCell = generateCell;

            if (_model == Model.OneTime)
            {
                OnListChanged(_list);
            }
            else if (_model == Model.OneWay)
            {
                OnListChanged(_list);
                _list.OnListChanged += OnListChanged;
            }
        }

        void OnListChanged(IBindableList<TCellData, TListContext> list)
        {
            while (_existence.Count < list.Count)
            {
                if (_buffer.Count > 0)
                {
                    GameObject temp = _buffer[0];
                    _buffer.RemoveAt(0);
                    temp.SetActive(true);
                    _existence.Add(temp);
                }
                else
                {
                    GameObject temp = _generateCell?.Invoke(_cell, _scrollRect.content);
                    _existence.Add(temp);
                }
            }
            while (_existence.Count > list.Count)
            {
                GameObject temp = _existence[0];
                _existence.RemoveAt(0);
                temp.SetActive(false);
                _buffer.Add(temp);
            }
            for (int i = 0; i < _existence.Count; i++)
            {
                _existence[i].transform.SetAsLastSibling();
                IBindableListCell<TCellData, TListContext> temp = _existence[i].GetComponent<IBindableListCell<TCellData, TListContext>>();
                if (temp == null) throw new AquaFrameworkException("The cell doesn't implement IBindableListCell<T>");
                temp.Index = i;
                temp.Value = list[i];
                temp.ListContext = list.ListContext;
                temp.SetContext(list[i]);
            }
        }

        public void UnBind()
        {
            _generateCell = null;
            _scrollRect = null;
            _list = null;
            _cell = null;
            _existence.Clear();
            _buffer.Clear();
            _existence = null;
            _scrollRect = null;
        }
    }
}
