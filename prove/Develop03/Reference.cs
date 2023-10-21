using System.Diagnostics.Contracts;
using System.Runtime.InteropServices;

class Reference
{
    private string _book;
    private int _chapter;
    private int _verseStart;
    private int _verseEnd;

    public Reference(string book, int chapter, int verseStart)
    {
        _book = book;
        _chapter = chapter;
        _verseStart = verseStart;
    }

    public Reference(string book, int chapter, int verseStart, int verseEnd)
    {
        _book = book;
        _chapter = chapter;
        _verseStart = verseStart;
        _verseEnd = verseEnd;
    }

     public string GetBook()
    {
        return _book;
    }

    public void SetBook(string book)
    {
        _book = book;
    }

    public int GetChapter()
    {
        return _chapter;
    }

    public void SetChapter(int chapter)
    {
        _chapter = chapter;
    }

    public int GetVerseStart()
    {
        return _verseStart;
    }

    public void SetVerseStart(int verseStart)
    {
        _verseStart = verseStart;
    }

    public int GetVerseEnd()
    {
        return _verseEnd;
    }

    public void SetVerseEnd(int verseEnd)
    {
        _verseEnd = verseEnd;
    }

    public override string ToString()
    {
        if (_verseEnd > 0)
        {
            return $"{_book} {_chapter}:{_verseStart}-{_verseEnd}";
        }
        else
        { 
            return $"{_book} {_chapter}:{_verseStart}";
        }
    }
}