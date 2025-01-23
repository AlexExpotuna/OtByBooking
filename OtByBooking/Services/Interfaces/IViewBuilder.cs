using OtByBooking.Repository.Interfaces;

namespace OtByBooking.Services.Interfaces;

public interface IViewBuilder<TResult, TModel> 
    //where TResult : class
    //where TModel : class
{
    List<TModel> GetModels();
    List<TResult> Build(List<TModel> model);
    void AddRepository(IOtRepository repository);
}
