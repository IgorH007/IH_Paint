using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IH_Paint
{
    public class DrawShapeCommand : ICommand
    {
        private Shape _shapeToProcess;
        private Action<Shape> _addShapeAction;   
        private Action<Shape> _removeShapeAction;
        public DrawShapeCommand(Shape shape, Action<Shape> addAction, Action<Shape> removeAction)
        {
            _shapeToProcess = shape;
            _addShapeAction = addAction;
            _removeShapeAction = removeAction;
        }

        public void Execute()
        {
            _addShapeAction?.Invoke(_shapeToProcess);
        }

        public void Unexecute()
        {
            _removeShapeAction?.Invoke(_shapeToProcess);
        }
    }
}
