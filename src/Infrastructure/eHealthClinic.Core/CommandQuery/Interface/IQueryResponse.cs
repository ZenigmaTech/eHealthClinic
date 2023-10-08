using System;
namespace eHealthClinic.Core.CommandQuery.Interface
{
	public interface IQueryResponse
	{
        int ErrorCode { get; set; }
        bool HasError { get; set; }
    }
}

