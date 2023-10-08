using System;
namespace eHealthClinic.Core.CommandQuery.Interface
{
	public interface ICommandResponse
	{
		int ErrorCode { get; set; }
		bool HasError { get; set; }
	}

    public interface ICommandResponse<T>: ICommandResponse
    {
        T? Data { get; set; }
    }
}

