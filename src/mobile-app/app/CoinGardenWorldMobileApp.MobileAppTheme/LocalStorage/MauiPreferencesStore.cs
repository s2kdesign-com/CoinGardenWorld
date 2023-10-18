using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Maui.Storage;
using Newtonsoft.Json;

namespace CoinGardenWorldMobileApp.MobileAppTheme.LocalStorage
{
    public class MauiPreferencesStore : IHybridStorage
    {

        /// <summary>
        /// Store an element using any kind of key (if it doesnt exist)
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void Set(string key, object value)
        {
            string keyvalue = JsonConvert.SerializeObject(value);
            if (keyvalue != null && !string.IsNullOrEmpty(keyvalue))
            {
                Preferences.Set(key, keyvalue);
            }
        }

        /// <summary>
        /// Get an element using a certain key, with type T
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public T Get<T>(string key)
        {
            T UnpackedValue = default;
            string keyvalue = Preferences.Get(key, string.Empty);

            if (keyvalue != null && !string.IsNullOrEmpty(keyvalue))
            {
                UnpackedValue = JsonConvert.DeserializeObject<T>(keyvalue);
            }
            return UnpackedValue;
        }

        /// <summary>
        /// Delete an element with a certain key
        /// </summary>
        /// <param name="key"></param>
        public void Delete(string key)
        {
            Preferences.Remove(key);
        }

        /// <summary>
        /// Check if an element with a certain key exists
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool Exists(string key)
        {
            return Preferences.ContainsKey(key);
        }

        /// <summary>
        /// ATTENTION: Clears the whole Preferences-Store
        /// </summary>
        public void ClearAll()
        {
            Preferences.Clear();
        }
    }
}
