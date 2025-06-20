﻿namespace DCompany.Shared.SharedKernel;

public static class Errors
{
    public static class General
    {
        public static Error ValueIsInvalid(string? valueName = null)
        {
            string label = valueName ?? "value";
            return Error.Validation("value.is.invalid", $"{label} is invalid.");
        }

        public static Error CannotBeEmpty(string? stringName = null)
        {
            string label = stringName ?? "value";
            return Error.Validation("value.is.invalid", $"{label} cannot be empty.");
        }

        public static Error ValueIsRequired(string? stringName = null)
        {
            string label = stringName == null ? string.Empty : stringName + " ";
            return Error.Validation("value.is.invalid", $"Invalid {label}lenght");
        }

        public static Error NotFound(ErrorNotFoundObjectDto? dto)
        {
            string label = dto == null ? string.Empty : $"for {dto.ObjectName}: {dto.ObjectValue}";
            return Error.NotFound("record.not.found", $"record not found {label}.");
        }

        public static Error Failure()
        {
            return Error.Failure("unexpected.error", "An unexpected error occurred.");
        }

        public static Error Conflict(string? conflictName = null)
        {
            string label = conflictName == null ? string.Empty : $"for {conflictName}";
            return Error.Conflict("conflict.occurred", $"A conflict occurred {label}.");
        }

        public record ErrorNotFoundObjectDto(object? ObjectName, object? ObjectValue);
    }
}
