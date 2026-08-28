using System;
using System.ComponentModel;
using System.Reflection;

namespace Equin.ApplicationFramework
{
    /// <summary>
    /// Wraps a <see cref="FieldInfo"/> as a <see cref="PropertyDescriptor"/> so that public
    /// fields can be treated the same as properties by the "provided views" mechanism
    /// (see <see cref="ObjectView&lt;T&gt;.GetProvidedView"/>), which otherwise only sees
    /// properties because it is built on <see cref="System.ComponentModel.TypeDescriptor"/>.
    /// </summary>
    /// <remarks>
    /// <see cref="GetValue"/> and <see cref="SetValue"/> resolve the real target via the
    /// inherited <see cref="PropertyDescriptor.GetInvocationTarget"/> instead of operating on
    /// <paramref name="component"/> directly. This mirrors how the built-in reflection-based
    /// property descriptors behave: when <paramref name="component"/> is an
    /// <see cref="ObjectView&lt;T&gt;"/> wrapper rather than the wrapped object itself,
    /// GetInvocationTarget consults <see cref="ICustomTypeDescriptor.GetPropertyOwner"/> to
    /// find the actual object the field is declared on.
    /// </remarks>
    class FieldPropertyDescriptor : PropertyDescriptor
    {
        public FieldPropertyDescriptor(FieldInfo field)
            : base(field.Name, null)
        {
            _field = field;
        }

        private readonly FieldInfo _field;

        public override Type ComponentType
        {
            get { return _field.DeclaringType; }
        }

        public override bool IsReadOnly
        {
            get { return _field.IsInitOnly || _field.IsLiteral; }
        }

        public override Type PropertyType
        {
            get { return _field.FieldType; }
        }

        public override bool CanResetValue(object component)
        {
            return false;
        }

        public override object GetValue(object component)
        {
            return _field.GetValue(GetInvocationTarget(ComponentType, component));
        }

        public override void ResetValue(object component)
        {
            throw new NotSupportedException();
        }

        public override void SetValue(object component, object value)
        {
            _field.SetValue(GetInvocationTarget(ComponentType, component), value);
            OnValueChanged(component, EventArgs.Empty);
        }

        public override bool ShouldSerializeValue(object component)
        {
            return false;
        }
    }
}
