namespace AccountBalanceDDD.Domain.Aggregate
{
    public abstract class AggregateState
    {
        public void Apply(Event @event)
        {
            var apply = GetType().GetMethod("Apply", new[] { @event.GetType() });

            apply.Invoke(this, new object[] { @event });
        }
    }
}
