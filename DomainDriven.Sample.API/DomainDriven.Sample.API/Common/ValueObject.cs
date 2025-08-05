namespace DomainDriven.Sample.API.Common
{
    public abstract class ValueObject : IEquatable<ValueObject>
    {
        protected abstract IEnumerable<object> GetEqualityComponents();

        private bool ValuesAreEqual(ValueObject valueObject)
            => GetEqualityComponents().SequenceEqual(valueObject.GetEqualityComponents());

        public virtual bool Equals(ValueObject? other)
            => other is not null && ValuesAreEqual(other);

        public override bool Equals(object? obj)
            => obj is ValueObject valueObject && ValuesAreEqual(valueObject);

        public override int GetHashCode()
            => GetEqualityComponents().Aggregate(default(int), (hashCode, value) => HashCode.Combine(hashCode, value.GetHashCode()));

        public static bool operator ==(ValueObject? left, ValueObject? right)
        {
            if (ReferenceEquals(left, null) ^ ReferenceEquals(right, null))
                return false;

            return left.Equals(right);
        }
        public static bool operator !=(ValueObject? left, ValueObject? right)
            => !(left == right);
    }
}
