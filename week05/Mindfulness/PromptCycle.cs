public class PromptCycle
{
    private readonly List<string> _items;
    private int _nextIndex;

    public PromptCycle(IEnumerable<string> items)
    {
        _items = new List<string>(items);
        Shuffle();
    }

    public string Next()
    {
        if (_nextIndex == _items.Count)
        {
            Shuffle();
        }

        return _items[_nextIndex++];
    }

    private void Shuffle()
    {
        for (int index = _items.Count - 1; index > 0; index--)
        {
            int swapIndex = Random.Shared.Next(index + 1);
            (_items[index], _items[swapIndex]) = (_items[swapIndex], _items[index]);
        }

        _nextIndex = 0;
    }
}