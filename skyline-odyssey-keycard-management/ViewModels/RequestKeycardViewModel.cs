using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace skyline_odyssey_keycard_management.ViewModels
{
	public class RequestKeycardViewModel : ViewModelBase
	{
		private string _firstCheckBox;
		public string FirstCheckBox
		{
			get => _firstCheckBox;
			set
			{
				_firstCheckBox = value;
				OnPropertyChanged(nameof(FirstCheckBox));
			}
		}
		
		private string _secondCheckBox;
		public string SecondCheckBox
		{
			get => _secondCheckBox;
			set
			{
				_secondCheckBox = value;
				OnPropertyChanged(nameof(SecondCheckBox));
			}
		}

		private string _thirdCheckBox;
		public string ThirdCheckBox
		{
			get => _thirdCheckBox;
			set
			{
				_thirdCheckBox = value;
				OnPropertyChanged(nameof(ThirdCheckBox));
			}
		}

		private string _reason;
		public string Reason
		{
			get => _reason;
			set
			{
				_reason = value;
				OnPropertyChanged(nameof(Reason));
			}
		}
	}
}
