namespace Tone.Shared.Commands
{
    public interface ICommandResult
    {
        bool Status { get; set; }
        string Message { get; set; }
        object Data { get; set; }
    }
}