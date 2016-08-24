namespace RecyclingStation.WasteDisposal
{
    using System;
    using System.Collections.Generic;
    using Attributes;
    using Constants;
    using Interfaces;

    public class StrategyHolder : IStrategyHolder
    {
        private readonly IDictionary<Type, IGarbageDisposalStrategy> strategies;

        public StrategyHolder()
        {
            this.strategies = new Dictionary<Type, IGarbageDisposalStrategy>();
        }

        public IReadOnlyDictionary<Type,IGarbageDisposalStrategy> GetDisposalStrategies
        {
            get { return (IReadOnlyDictionary<Type, IGarbageDisposalStrategy>)this.strategies; }
        }

        public bool AddStrategy(Type disposableAttribute, IGarbageDisposalStrategy strategy)
        {
            if (disposableAttribute != typeof(DisposableAttribute) && disposableAttribute.BaseType != typeof(DisposableAttribute))
            {
                throw new ArgumentException(ConstantMessages.GarbageDoesNotImplementDisposableAttribute);
            }

            if (!this.strategies.ContainsKey(disposableAttribute))
            {
                this.strategies.Add(disposableAttribute, strategy);

                return true;
            }

            return false;
        }

        public bool RemoveStrategy(Type disposableAttribute)
        {
            if (disposableAttribute != typeof(DisposableAttribute) && disposableAttribute.BaseType != typeof(DisposableAttribute))
            {
                throw new ArgumentException(ConstantMessages.GarbageDoesNotImplementDisposableAttribute);
            }

            if (this.strategies.ContainsKey(disposableAttribute))
            {
                this.strategies.Remove(disposableAttribute);

                return true;
            }

            return false;
        }
    }
}
