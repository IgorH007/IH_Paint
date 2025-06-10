using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IH_Paint
{
    public class HistoryManager
    {
        private Stack<ICommand> _undoStack = new Stack<ICommand>();
        private Stack<ICommand> _redoStack = new Stack<ICommand>();
        private const int MaxHistorySize = 100; //undo/redo steps

        public bool CanUndo => _undoStack.Any();
        public bool CanRedo => _redoStack.Any();

        public event System.Action HistoryChanged; 

        public void ExecuteCommand(ICommand command)
        {
            if (_undoStack.Count >= MaxHistorySize)
            {
            }

            command.Execute();
            _undoStack.Push(command);
            _redoStack.Clear(); //clears redo stack

            OnHistoryChanged();
        }
        public void Undo()
        {
            if (CanUndo)
            {
                ICommand command = _undoStack.Pop();
                command.Unexecute();
                _redoStack.Push(command);
                OnHistoryChanged();
            }
        }
        public void Redo()
        {
            if (CanRedo)
            {
                ICommand command = _redoStack.Pop();
                command.Execute();
                _undoStack.Push(command);
                OnHistoryChanged();
            }
        }
        public void ClearHistory()
        {
            _undoStack.Clear();
            _redoStack.Clear();
            OnHistoryChanged();
        }
        protected virtual void OnHistoryChanged()
        {
            HistoryChanged?.Invoke();
        }
    }
}
