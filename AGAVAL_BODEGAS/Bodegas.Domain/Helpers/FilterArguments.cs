using Bodegas.Domain.Entities;
using System.Linq.Expressions;

namespace Bodegas.Domain.Helpers
{
    public class FilterArguments<T> where T : BaseEntity
    {
        public Expression<Func<T, T>>? Select { get; set; } = default!;
        public Expression<Func<T, bool>>? Where { get; set; } = default!;
        public int Size { get; set; } = default!;
        public int Page { get; set; } = default!;
        public string? Tipo { get; set; } = default!;
        public string? Sort { get; set; } = default!;
        public string? Direction { get; set; } = default!;
        public string? Column { get; set; } = default!;
        public string? Filter { get; set; } = default!;
        public string? Text { get; set; } = default!;
        public string? Start { get; set; } = default!;
        public string? End { get; set; } = default!;
    }
}
