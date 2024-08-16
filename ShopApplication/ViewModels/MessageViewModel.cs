using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApplication.ViewModels
{
	public enum Messege 
	{
		UnSet,
		Status,
		Error
	}
    public  class MessegeViewModel : ViewModelBase
    {
		private string _messege;
		public string Messege
		{
			get
			{
				return _messege;
			}
			private set
			{
				_messege = value;
				OnPropertyChanged(nameof(Messege));
			}
		}

		private Messege _messageType;
		public Messege MessegeType
		{
			get
			{
				return _messageType;
			}
			private set
			{
				_messageType = value;
				OnPropertyChanged(nameof(MessegeType));
			}
		}

		public void SetMessege(string messege, Messege messegeType)
		{
			Messege = messege;
			MessegeType = messegeType;
		}
	}
}
