using System;
using JetBrains.Annotations;
using Saltuk.Utils.Validation;

namespace MigrationItems
{
    public sealed class UserInputParameter
    {
        public UserInputParameter([NotNull] string name, [NotNull] string description, [NotNull] Type type)
        {
            ThrowIf.Argument.IsNull(name, nameof(name));
            ThrowIf.Argument.IsNull(description, nameof(description));
            ThrowIf.Argument.IsNull(type, nameof(type));

            Name = name;
            Description = description;
            Type = type;
        }

        [NotNull]
        public string Name { get; }

        [NotNull]
        public string Description { get; }

        [NotNull]
        public Type Type { get; }

        private bool Equals(UserInputParameter other)
        {
            return string.Equals(Name, other.Name);
        }

        public override bool Equals(object obj)
        {
            if (obj is null)
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            return obj is UserInputParameter parameter && Equals(parameter);
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
    }
}