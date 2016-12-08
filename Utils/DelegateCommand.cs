using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RSSE
{
        public class DelegateCommand : ICommand
        {
            private Action execute;
            private Func<bool> canExecute;

            public DelegateCommand(Action execute, Func<bool> canExecute)
            {
                this.execute = execute;
                this.canExecute = canExecute;
            }

            public DelegateCommand(Action execute)
                : this(execute, null)
            {
            }

            public bool CanExecute(object parameter)
            {
                if (this.canExecute == null)
                    return true;

                return this.canExecute();
            }

            public event EventHandler CanExecuteChanged;

            public void RaiseCanExecuteChanged()
            {
                if (this.CanExecuteChanged != null)
                    this.CanExecuteChanged(this, EventArgs.Empty);
            }

            public void Execute(object parameter)
            {
                if (this.execute != null)
                    this.execute();
            }
        }

        public class DelegateCommand<T> : ICommand
        {
            private Action<T> execute;
            private Func<bool> canExecute;

            public DelegateCommand(Action<T> execute, Func<bool> canExecute)
            {
                this.execute = execute;
                this.canExecute = canExecute;
            }

            public DelegateCommand(Action<T> execute)
                : this(execute, null)
            {
            }

            public bool CanExecute(object parameter)
            {
                if (this.canExecute == null)
                    return true;

                return this.canExecute();
            }

            public event EventHandler CanExecuteChanged;

            public void RaiseCanExecuteChanged()
            {
                if (this.CanExecuteChanged != null)
                    this.CanExecuteChanged(this, EventArgs.Empty);
            }

            public void Execute(object parameter)
            {
                if (this.execute != null)
                    this.execute((T)parameter);
            }
        }
}
