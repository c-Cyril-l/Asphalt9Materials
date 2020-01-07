using System;
using System.Diagnostics;
using System.Windows.Input;

namespace Helpers.Utilities
{
    public class RelayCommand : ICommand
    {
        #region Declarations

        private readonly Action<object> _execute;
        private readonly Predicate<object> _canExecute;

        #endregion

        #region Constructors

        public RelayCommand(Action<object> execute, Predicate<object> canExecute)
        {
            _execute = execute ?? throw new NullReferenceException(nameof(execute));
            _canExecute = canExecute;
        }

        public RelayCommand(Action<object> execute) : this(execute, null) { }

        #endregion

        #region ICommand Members

        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        [DebuggerStepThrough]
        public bool CanExecute(object parameter) { return _canExecute?.Invoke(parameter) ?? true; }

        public void Execute(object parameter)
        {
            _execute(parameter);
        }
        #endregion
    }
}

