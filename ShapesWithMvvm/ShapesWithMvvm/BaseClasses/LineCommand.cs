using System;
using System.Windows.Input;
using System.Windows.Shapes;

namespace ShapesWithMvvm.BaseClasses
{
    public class LineCommand : ICommand
    {

        event EventHandler ICommand.CanExecuteChanged
        {
            add
            {
                throw new NotImplementedException();
            }

            remove
            {
                throw new NotImplementedException();
            }
        }

        bool ICommand.CanExecute(object parameter)
        {
            Line selectedLine = Mouse.DirectlyOver as Line;
            return selectedLine!=null;
        }

        void ICommand.Execute(object parameter)
        {
            Line selectedLine = Mouse.DirectlyOver as Line;
            selectedLine.X1 += 50;
        }
    }
}
