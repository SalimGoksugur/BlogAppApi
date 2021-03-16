using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace BlogAppApi.Core.DTOs
{
    public class ErrorDto
    {
        public List<String> Errors { get; private set; } = new List<string>();


        public ErrorDto(string error)
        {
            Errors.Add(error);
        }

        public ErrorDto(List<string> errors)
        {
            Errors = errors;
        }
    }
}
