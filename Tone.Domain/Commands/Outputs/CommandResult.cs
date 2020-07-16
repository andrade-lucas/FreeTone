using Tone.Shared.Commands;

namespace Tone.Domain.Commands.Outputs
{
    public class CommandResult : ICommandResult
    {
        public bool Status { get; set; }
        public string Message { get; set; }
        public object Errors { get; set; }
        public object Data { get; set; }

        public CommandResult(bool status, string message, object errors = null, object data = null)
        {
            Status = status;
            Message = message;
            Errors = errors;
            Data = data;
        }
    }
}