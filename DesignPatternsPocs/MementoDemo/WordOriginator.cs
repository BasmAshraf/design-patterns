namespace MementoDemo
{
    public class WordOriginator : Word
    {

        public WordMemento CreateWordMemento()
        {
            var wordMemento= new WordMemento();
            wordMemento.Word = CurrentWord;
            return wordMemento;
        }

        public void ResumeFrom(WordMemento wordMemento)
        {
            SaveWord(wordMemento.Word);
        }
    }
}
