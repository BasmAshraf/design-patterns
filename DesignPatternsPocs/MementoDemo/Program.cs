using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MementoDemo
{
    class Program
    {
        private WordOriginator _word = new WordOriginator();
        private Stack<WordMemento> _wordHistory { get; set; } = new Stack<WordMemento>();
        private Stack<WordMemento> _undoWordHistory { get; set; } = new Stack<WordMemento>();
        static void Main(string[] args)
        {
            var program = new Program();
            program.SaveWord("Life");
            program.SaveWord("Peace");
            program.SaveWord("Happiness");
            program.Undo();
            program.Undo();
            program.Redo();
            var currentWord =program. _word.CurrentWord;
            // expected: Peace
            Console.WriteLine($"{currentWord}");
            Console.ReadLine();
        }

        public void SaveWord(string word)
        {
            _word.SaveWord(word);
            _wordHistory.Push(_word.CreateWordMemento());
        }

        public void Undo()
        {
           var popedWord= _wordHistory.Pop();
            _undoWordHistory.Push(popedWord);
            _word.ResumeFrom(_wordHistory.Peek());
        }
        public void Redo()
        {
            _word.ResumeFrom(_undoWordHistory.Peek());
            var popedWord=_undoWordHistory.Pop();
            _wordHistory.Push(popedWord);
        }
    }
}
