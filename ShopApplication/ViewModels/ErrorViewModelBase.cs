using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApplication.ViewModels
{
    public class ErrorViewModelBase : ViewModelBase,INotifyDataErrorInfo
    {
        public bool HasErrors => _errors.Any();
        public IEnumerable GetErrors(string? propertyName)
        {
            if (string.IsNullOrEmpty(propertyName))
                return _errors.Values.Select(p => p).ToList();
            if (_errors.ContainsKey(propertyName))
                return _errors[propertyName];
            return Enumerable.Empty<string>();
        }
        public event EventHandler<DataErrorsChangedEventArgs>? ErrorsChanged;
        public Dictionary<string, List<string>> _errors = new();
        public void OnErrorsChanged(string propertyName)
        {
            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
        }
        public void AddError(string propertyName, string error)
        {
            if (!_errors.ContainsKey(propertyName))
                _errors.Add(propertyName, null);
            _errors[propertyName].Add(error);
        }

        public void ClearErrors(string propertyName)
        {
            if (_errors.ContainsKey(propertyName))
                _errors.Remove(propertyName);
        }
    }
}
