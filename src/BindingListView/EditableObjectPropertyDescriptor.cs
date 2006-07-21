using System;
using System.ComponentModel;

namespace Equin.ApplicationFramework
{
    /// <summary>
    /// Allows a <see cref="ObjectView&lt;T&gt;"/> to appear to data binding as type <typeparamref name="T"/>.
    /// In additon, it will raise property changed events on behalf of the wrapped data object.
    /// </summary>
    /// <typeparam name="T">The type of data object being viewed.</typeparam>
    public class EditableObjectPropertyDescriptor<T> : PropertyDescriptor
    {
        /// <summary>
        /// Creates a new <see cref="EditableObjectPropertyDescriptor&lt;T&gt;"/> that wraps a given
        /// <see cref="System.ComponentModel.PropertyDescriptor"/> and uses a given <see cref="System.ComponentModel.PropertyChangedEventHandler"/>
        /// to notify when changes are made.
        /// </summary>
        /// <param name="propertyDescriptor">The <see cref="System.ComponentModel.PropertyDescriptor"/> to wrap.</param>
        /// <param name="propertyChanged">The delegate used to notify about changes to the property.</param>
        public EditableObjectPropertyDescriptor(PropertyDescriptor propertyDescriptor, PropertyChangedEventHandler propertyChanged)
            : base(propertyDescriptor)
        {
            _pd = propertyDescriptor;
            _propertyChanged = propertyChanged;
        }

        private PropertyDescriptor _pd;
        private PropertyChangedEventHandler _propertyChanged;

        /// <summary>
        /// Gets the <see cref="System.ComponentModel.PropertyDescriptor"/> being wrapped.
        /// </summary>
        public PropertyDescriptor ItemPropertyDescriptor
        {
            get
            {
                return _pd;
            }
        }

        /// <summary>
        /// Sets the property of component to the given value.
        /// </summary>
        /// <param name="component">The object to set the property of.</param>
        /// <param name="value">The value to set.</param>
        public override void SetValue(object component, object value)
        {
            T item = GetItem(component);
            if (item is INotifyPropertyChanged)
            {
                // The item should handle raising its own events.
                _pd.SetValue(item, value);
            }
            else
            {
                // See if the property's value changes when we set it.
                object before = GetValue(component);
                _pd.SetValue(item, value);
                object after = GetValue(component);
                if ((before == null && after != null) || !before.Equals(after))
                {
                    _propertyChanged(item, new PropertyChangedEventArgs(Name));
                }
            }
        }

        /// <summary>
        /// Returns the <typeparamref name="T"/> that is actually being edited.
        /// </summary>
        /// <param name="component">An <see cref="ObjectView&lt;T&gt;"/> wrapping a <typeparamref name="T"/> object.</param>
        /// <returns>The <typeparamref name="T"/>.</returns>
        private T GetItem(object component)
        {
            if (component is T)
            {
                return (T)component;
            }
            else if (component is ObjectView<T>)
            {
                return ((ObjectView<T>)component).Object;
            }
            else if (component is ListItemPair<T>)
            {
                return ((ListItemPair<T>)component).Item.Object;
            }
            throw new ArgumentException("Type of component is not valid.", "component");
        }

        #region PropertyDescriptor Methods forwarded to our private member

        public override bool CanResetValue(object component)
        {
            return _pd.CanResetValue(GetItem(component));
        }

        public override Type ComponentType
        {
            get { return _pd.ComponentType; }
        }

        public override object GetValue(object component)
        {
            return _pd.GetValue(GetItem(component));
        }

        public override bool IsReadOnly
        {
            get { return _pd.IsReadOnly; }
        }

        public override Type PropertyType
        {
            get { return _pd.PropertyType; }
        }

        public override void ResetValue(object component)
        {
            _pd.ResetValue(GetItem(component));
        }

        public override bool ShouldSerializeValue(object component)
        {
            return _pd.ShouldSerializeValue(GetItem(component));
        }

        #endregion
    }
}
