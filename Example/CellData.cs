using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AquaFramework;

public class CellData
{
    string _text;

    public CellData(string text)
    {
        _text = text;
    }

    public string Text { get => _text; set => _text = value; }
}
