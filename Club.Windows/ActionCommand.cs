﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Club.Windows
{

    public class ActionCommand : ICommand
    {
        private readonly Action<Object> action;
        private readonly Predicate<Object> predicate;

        public ActionCommand(Action<Object> action) : this(action, null)
        {


        }
        public ActionCommand(Action<Object> action, Predicate<Object> predicate)
        {
            if (action == null) throw new ArgumentNullException("action", "Debe especifacr una Accion<T>");
            this.action = action;
            this.predicate = predicate;
        }

        public event EventHandler CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
            }

            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            if (null == predicate)
            {
                return true;
            }
            return predicate(parameter);
        }

        public void Execute()
        {
            Execute(null);
        }

        public void Execute(object parameter)
        {
            action(parameter);
        }
    }
}
