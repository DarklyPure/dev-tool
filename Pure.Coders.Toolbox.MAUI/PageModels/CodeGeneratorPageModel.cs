using CommunityToolkit.Mvvm.ComponentModel;

namespace Pure.Coders.Toolbox.MAUI.PageModels;

public partial class CodeGeneratorPageModel : ObservableObject, IQueryAttributable, ICodeGeneratorPageModel
{
    public bool IsBusy;

    bool ICodeGeneratorPageModel.IsBusy => throw new NotImplementedException();

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        throw new NotImplementedException();
    }
}
