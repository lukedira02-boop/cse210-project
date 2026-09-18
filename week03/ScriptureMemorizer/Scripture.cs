public class Scripture
{
    private readonly Reference _reference;
    private readonly List<Word> _words;
    private readonly Random _random = new();

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = text.Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(word => new Word(word))
            .ToList();
    }

    public string GetDisplayText()
    {
        string words = string.Join(' ', _words.Select(word => word.GetDisplayText()));
        return $"{_reference}\n{words}";
    }

    public void HideRandomWords(int numberOfWords)
    {
        List<Word> visibleWords = _words.Where(word => !word.IsHidden()).ToList();
        int wordsToHide = Math.Min(numberOfWords, visibleWords.Count);

        for (int index = 0; index < wordsToHide; index++)
        {
            int randomIndex = _random.Next(visibleWords.Count);
            visibleWords[randomIndex].Hide();
            visibleWords.RemoveAt(randomIndex);
        }
    }

    public bool IsCompletelyHidden()
    {
        return _words.All(word => word.IsHidden());
    }
}