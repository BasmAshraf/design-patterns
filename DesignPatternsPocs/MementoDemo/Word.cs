namespace MementoDemo
{
    public class Word
    {
        public string CurrentWord { get; private set; }
        public void SaveWord(string word)
        {
            CurrentWord = word;
        }

    }
}
