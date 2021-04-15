using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.Business.Commands
{
    public class CommandManager
    {
        private Stack<ICommand> _commands = new Stack<ICommand>();

        public void Invoke(ICommand command)
        {
            if (command.CanExecute())
            {
                command.Execute();
                _commands.Push(command);
            }
        }

        public void Undo()
        {
            while(_commands.Count>0)
            {
                var command = _commands.Pop();
                command.Undo();
            }
        }

    }
}
