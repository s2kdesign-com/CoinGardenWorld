using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinGardenWorldMobileApp.MobileAppTheme.LocalStorage
{
    public interface IHybridStorage
    {

        /// <summary>
        /// Store an element using any kind of key (if it doesnt exist)
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        void Set(string key, object value);

        /// <summary>
        /// Get an element using a certain key, with type T
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        T Get<T>(string key);


        /// <summary>
        /// Delete an element with a certain key
        /// </summary>
        /// <param name="key"></param>
        void Delete(string key);

        /// <summary>
        /// Check if an element with a certain key exists
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        bool Exists(string key);

        /// <summary>
        /// ATTENTION: Clears the whole Preferences-Store
        /// </summary>
        void ClearAll();
    }
}
