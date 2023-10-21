using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


class Scripture
{
    private Reference _reference;
    private List<Word> _words;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = text.Split(' ').Select(word => new Word(word)).ToList();
    }

    public void Display()
    {
        Console.Clear();
        StringBuilder scriptureText = new StringBuilder();

        foreach (Word word in _words)
        {
            scriptureText.Append(word.GetRenderedText() + " ");
        }

        Console.WriteLine(_reference.ToString() + "\n" + scriptureText);
    }

    public bool AllWordsHidden()
    {
        return _words.All(word => word.IsHiddenWord());
    }

    public void HideRandomWord()
    {
        List<Word> unhidWords = _words.Where(word => !word.IsHiddenWord()).ToList();
        
        Random random = new Random();
        int randomIndex;
        Console.WriteLine("unhid word count:");
        Console.WriteLine(unhidWords.Count);
        randomIndex = random.Next(0, unhidWords.Count - 1);
        Console.WriteLine(randomIndex);

        unhidWords[randomIndex].Hide();
           
    }
   
}