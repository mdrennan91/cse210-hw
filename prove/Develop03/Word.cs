using System;

class Word 
{
    private string _word;
    private bool _hidden;

    public Word(string text)
    {
        _word = text;
        _hidden = false;
    }

    public string GetWord()
    {
        return _word;
    }

    public void SetWord(string text)
    {
        _word = text;
    }

    public void Hide()
    {
        _hidden = true;
        Console.WriteLine(_word);
    }

    public void Show()
    {
        _hidden = false;
    }

    public bool IsHiddenWord()
    {
        return _hidden;
    }

    public string GetRenderedText()
    {
        return _hidden ? new string('_', _word.Length) : _word;
    }
}