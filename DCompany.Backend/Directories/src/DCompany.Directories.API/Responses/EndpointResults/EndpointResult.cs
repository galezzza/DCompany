﻿using CSharpFunctionalExtensions;
using DCompany.Shared.SharedKernel;
using IResult = Microsoft.AspNetCore.Http.IResult;

namespace DCompany.Directories.API.Responses.EndpointResults;

public class EndpointResult<TValue> : IResult
{
    private readonly IResult _result;

    public EndpointResult(Result<TValue, Error> result)
    {
        _result = result.IsSuccess
            ? new SuccesResult<TValue>(result.Value)
            : new ErrorsResult(result.Error);
    }

    public EndpointResult(Result<TValue, ErrorList> result)
    {
        _result = result.IsSuccess
            ? new SuccesResult<TValue>(result.Value)
            : new ErrorsResult(result.Error);
    }

    public Task ExecuteAsync(HttpContext httpContext) =>
        _result.ExecuteAsync(httpContext);

    public static implicit operator EndpointResult<TValue>(Result<TValue, Error> result)
        => new EndpointResult<TValue>(result);

    public static implicit operator EndpointResult<TValue>(Result<TValue, ErrorList> result)
        => new EndpointResult<TValue>(result);
}
