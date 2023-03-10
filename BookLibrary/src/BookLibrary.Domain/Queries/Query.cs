using FluentValidation.Results;

namespace BookLibrary.Domain.Queries
{
    public abstract class Query<TResponse> : QueryMessage<TResponse>
    {
        protected Query()
        {
            Timestamp = DateTime.Now;
        }

        public DateTime Timestamp { get; private set; }
        public ValidationResult ValidationResult { get; set; } = new ValidationResult();

        public abstract bool IsValid();
    }
}
