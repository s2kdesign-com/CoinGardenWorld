using Blazored.LocalStorage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinGardenWorldMobileApp.MobileAppTheme.LocalStorage
{
    public class BlazorLocalStorage : IHybridStorage
    {
        private readonly ISyncLocalStorageService _localStorageService;
        public BlazorLocalStorage(ISyncLocalStorageService localStorage)
        {
            _localStorageService = localStorage;
        }
        public  void Set(string key, object value)
        {
             _localStorageService.SetItem(key, value);
        }

        public T Get<T>(string key)
        {
            return _localStorageService.GetItem<T>("name");
        }

        public void Delete(string key)
        {
            _localStorageService.RemoveItem(key);
        }

        public bool Exists(string key)
        {
            return (_localStorageService.Keys().Any(k => k == key)) ;
        }

        public void ClearAll()
        {
            _localStorageService.Clear();
        }
    }
}
