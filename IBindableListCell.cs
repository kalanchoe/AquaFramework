namespace AquaFramework
{
    public interface IBindableListCell<T>
    {
        int Index { set; get; }
        T Value { set; get; }
        void SetContext(T item);
    }

    public interface IBindableListCell<TCellData, TListContext>
    {
        int Index { set; get; }
        TCellData Value { set; get; }
        void SetContext(TCellData item);
        TListContext ListContext { set; get; }
    }
}
