using ShopApplication.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApplication.Stores
{
    public  class MessegeStore
    {
		private MessegeViewModel _messageViewModelIndicator;
		public MessegeViewModel MessegeViewModelIndicator
		{
			get
			{
				return _messageViewModelIndicator;
			}
			set
			{
				_messageViewModelIndicator = value;
			}
		}
        public MessegeStore(MessegeViewModel messegViewModel)
        {
			MessegeViewModelIndicator = messegViewModel;   
        }
        public void OnMessageChanged(string messege,Messege messegeType)
		{
			MessegeChanged?.Invoke(messege, messegeType);
		}
		public void SetMessege(string messege, Messege messegeType)
		{
			MessegeViewModelIndicator.SetMessege(messege, messegeType);
            OnMessageChanged(_messageViewModelIndicator.Messege, _messageViewModelIndicator.MessegeType);

        }
        public event MessegeEventHandler MessegeChanged;
		public delegate void MessegeEventHandler(string message, Messege messegeType);
	}
}
