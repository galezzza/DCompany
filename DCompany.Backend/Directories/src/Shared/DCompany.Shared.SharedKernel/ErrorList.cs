﻿using System.Collections;
using CSharpFunctionalExtensions;

namespace DCompany.Shared.SharedKernel;

public record ErrorList : IEnumerable<Error>
{
    private readonly List<Error> _errors = [];

    public ErrorList(IEnumerable<Error> errors)
    {
        _errors = errors.ToList();
    }

    public IEnumerator<Error> GetEnumerator()
    {
        return _errors.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
