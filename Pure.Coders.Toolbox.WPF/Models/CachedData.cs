using Pure.BO.Coders;
using Pure.Coders.Service;
using Pure.Library;

namespace Pure.Coders.Toolbox.WPF.Models
{
    public class CachedData
    {
        public CachedData(ICodersService codersService)
        {
            _codersService = codersService;
            Task.Run(async () => await PopulateDataAsync());
        }
        private readonly ICodersService _codersService;

        public CodeFlavour[]? CodeFlavours { get; set; } = [];

        public CodeObjectMatrix[] CodeObjectMappings { get; set; } = [];

        private async Task PopulateDataAsync()
        {
            using CancellationTokenSource cancellationTokenSource = new();

            Result<CodeFlavour[], Exception> resultCodeFlavours = await _codersService.AllCodeFlavoursAsync(cancellationTokenSource.Token);
            if (resultCodeFlavours.IsSuccess)
            {
                CodeFlavours = resultCodeFlavours.ResultValue;
            }

            Result<CodeObjectMatrix[], Exception> resultCodeMappings = await _codersService.AllCodeObjectMappingsAsync(cancellationTokenSource.Token);
            if (resultCodeMappings.IsSuccess)
            {
                CodeObjectMappings = resultCodeMappings.ResultValue!;
            }
        }
    }
}
