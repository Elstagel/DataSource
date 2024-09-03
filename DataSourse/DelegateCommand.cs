using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataSourse
{
	internal sealed class DelegateCommand : Command
	{
		private static readonly Func<bool> defaultCanExecuteMethod = () => true;
		private readonly Func<bool> canExecuteMethod;
		private readonly Action executeMethod;

		public DelegateCommand(Action executeMethod) :
			this(executeMethod, defaultCanExecuteMethod)
		{
		}

		public DelegateCommand(Action executeMethod, Func<bool> canExecuteMethod)
		{
			this.executeMethod = executeMethod;
			this.canExecuteMethod = canExecuteMethod;
		}

		protected override bool CanExecute()
		{
			return canExecuteMethod();
		}

		protected override void Execute()
		{
			executeMethod();
		}
	}
}
