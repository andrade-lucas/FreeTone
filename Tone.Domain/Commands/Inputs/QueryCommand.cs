using Tone.Shared.Commands;

namespace Tone.Domain.Commands.Inputs
{
    public class QueryCommand : ICommand
    {
        public string ActualPage { get; set; }
        public string Pages { get; set; }
        public int Skip { get; set; }
        public string Query { get; set; }

        public QueryCommand(string actualPage = "1", string pages = "1", int skip = 10, string query = "")
        {
            ActualPage = actualPage;
            Pages = pages;
            Skip = skip;
            Query = query;
        }
    }
}