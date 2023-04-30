namespace Example.Infrastructure
{
    public interface IDto<TDto, TValue> where TDto : IDto<TDto, TValue> where TValue : IHasDto<TValue, TDto>
    {
        static abstract TDto From(TValue value);
        TValue AsValue();
    }

    public interface IHasDto<TValue, TDto> where TValue : IHasDto<TValue, TDto> where TDto : IDto<TDto, TValue>
    {
        void UpdateFrom(TDto value);
    }

    public static class Extensions
    {
        public static TDto AsDto<TDto, TValue>(this TValue value) where TValue : IHasDto<TValue, TDto> where TDto : IDto<TDto, TValue> =>
            TDto.From(value);

        public static List<TDto> AsDto<TDto, TValue>(this IEnumerable<TValue> sequence) where TValue : IHasDto<TValue, TDto> where TDto : IDto<TDto, TValue> =>
            sequence.Select(item => TDto.From(item)).ToList();
    }
}
