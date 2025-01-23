using OtByBooking.Repository.Interfaces;

namespace OtByBooking.Services.Interfaces;

public interface IViewBuilder<TResult, TDto>
    where TDto : IDto
{
    List<TDto> GetModels();
    List<TResult> Build(List<TDto> model);
    void AddRepository(IOtRepository repository);
}
