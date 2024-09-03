using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DataSourse
{
	internal class DataSource :INotifyPropertyChanged
	{
		private readonly Command redCommand;
		private readonly Command greenCommand;
		private readonly Command blueCommand;
		private readonly Command yellowCommand;
		private string selectedColor = "Black";

		public DataSource()
		{
			redCommand = new DelegateCommand(
				() => SelectedColor = "Red",
				() => SelectedColor != "Red"
				);
			greenCommand = new DelegateCommand(
				() => SelectedColor = "Green",
				() => SelectedColor != "Green"
				);
			blueCommand = new DelegateCommand(
				() => SelectedColor = "Blue",
				() => SelectedColor != "Blue"
				);
			yellowCommand = new DelegateCommand(
				() => SelectedColor = "Yellow",
				() => SelectedColor != "Yellow"
				);


			PropertyChanged += (sender, e) =>
			{
				if (e.PropertyName.Equals(nameof(SelectedColor)))
				{
					redCommand.RaiseCanExecuteChanged();
					greenCommand.RaiseCanExecuteChanged();
					blueCommand.RaiseCanExecuteChanged();
					yellowCommand.RaiseCanExecuteChanged();
				}
			};
		}

		public ICommand RedCommand => redCommand;
		public ICommand GreenCommand => greenCommand;
		public ICommand BlueCommand => blueCommand;
		public ICommand YellowCommand => yellowCommand;

		public string SelectedColor
		{
			get => selectedColor;
			set
			{
				if (selectedColor != value)
				{
					selectedColor = value;
					OnPropertyChanged(new PropertyChangedEventArgs(nameof(SelectedColor)));
				}
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;
		private void OnPropertyChanged(PropertyChangedEventArgs e)
		{
			PropertyChanged?.Invoke(this, e);
		}
	}
}

