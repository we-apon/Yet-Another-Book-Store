using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Dccelerator;


namespace YABS.DesktopClient.Helpers {
    public static class DependencyProperty<T> where T : DependencyObject {
        public static DependencyProperty Register<TProperty>(Expression<Func<T, TProperty>> propertyExpression) {
            return Register(propertyExpression, default(TProperty), null);
        }


        public static DependencyProperty Register<TProperty>(Expression<Func<T, TProperty>> propertyExpression, TProperty defaultValue) {
            return Register(propertyExpression, defaultValue, null);
        }


        public static DependencyProperty Register<TProperty>(Expression<Func<T, TProperty>> propertyExpression, Func<T, PropertyChangedCallback<TProperty>> propertyChangedCallbackFunc) {
            return Register(propertyExpression, default(TProperty), propertyChangedCallbackFunc);
        }


        public static DependencyProperty Register<TProperty>(Expression<Func<T, TProperty>> propertyExpression, TProperty defaultValue, Func<T, PropertyChangedCallback<TProperty>> propertyChangedCallbackFunc) {
            var propertyName = propertyExpression.Path();
            var callback = ConvertCallback(propertyChangedCallbackFunc);

            return DependencyProperty.Register(propertyName, typeof (TProperty), typeof (T), new PropertyMetadata(defaultValue, callback));
        }


        static PropertyChangedCallback ConvertCallback<TProperty>(Func<T, PropertyChangedCallback<TProperty>> propertyChangedCallbackFunc) {
            if (propertyChangedCallbackFunc == null)
                return null;
            return (d, e) => {
                var callback = propertyChangedCallbackFunc((T) d);
                callback?.Invoke(new DependencyPropertyChangedEventArgs<TProperty>(e));
            };
        }
    }




    public delegate void PropertyChangedCallback<TProperty>(DependencyPropertyChangedEventArgs<TProperty> e);

    public class DependencyPropertyChangedEventArgs<T> : EventArgs
    {
        public DependencyPropertyChangedEventArgs(DependencyPropertyChangedEventArgs e)
        {
            NewValue = (T)e.NewValue;
            OldValue = (T)e.OldValue;
            Property = e.Property;
        }

        public T NewValue { get; private set; }
        public T OldValue { get; private set; }
        public DependencyProperty Property { get; private set; }
    }


}