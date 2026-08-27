using System;
using System.ComponentModel;

namespace Equin.ApplicationFramework
{
    /// <summary>
    /// Wraps a <see cref="PropertyDescriptor"/> for a <typeparamref name="T"/> property so that
    /// its <see cref="ComponentType"/> is <see cref="ObjectView&lt;T&gt;"/> instead of <typeparamref name="T"/>.
    /// </summary>
    /// <remarks>
    /// <see cref="AggregateBindingListView&lt;T&gt;"/> exposes <see cref="ObjectView&lt;T&gt;"/> instances
    /// through its <see cref="System.Collections.IList"/> indexer, but without this wrapper
    /// <see cref="System.ComponentModel.ITypedList.GetItemProperties"/> reports property descriptors
    /// whose ComponentType is <typeparamref name="T"/>. That mismatch makes data-bound controls that
    /// call PropertyDescriptor.GetValue directly on the raw row object (instead of going through
    /// TypeDescriptor/ICustomTypeDescriptor, as DataGridView does) throw an InvalidCastException.
    /// </remarks>
    class ObjectViewPropertyDescriptor<T> : PropertyDescriptor
    {
        public ObjectViewPropertyDescriptor(PropertyDescriptor property)
            : base(property)
        {
            _property = property;
        }

        private readonly PropertyDescriptor _property;

        private static object Unwrap(object component)
        {
            if (component is ObjectView<T>)
            {
                return ((ObjectView<T>)component).Object;
            }
            return component;
        }

        public override Type ComponentType
        {
            get { return typeof(ObjectView<T>); }
        }

        public override bool IsReadOnly
        {
            get { return _property.IsReadOnly; }
        }

        public override Type PropertyType
        {
            get { return _property.PropertyType; }
        }

        public override bool CanResetValue(object component)
        {
            return _property.CanResetValue(Unwrap(component));
        }

        public override object GetValue(object component)
        {
            return _property.GetValue(Unwrap(component));
        }

        public override void ResetValue(object component)
        {
            _property.ResetValue(Unwrap(component));
        }

        public override void SetValue(object component, object value)
        {
            _property.SetValue(Unwrap(component), value);
        }

        public override bool ShouldSerializeValue(object component)
        {
            return _property.ShouldSerializeValue(Unwrap(component));
        }
    }
}
