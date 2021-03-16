using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace BlogAppApi.Core.DTOs
{
    public class Response<T> where T : class
    {
        public T Data { get; private set; }
        [JsonIgnore]
        public int StatusCode { get; private set; }

        public ErrorDto Error { get; private set; }

        public static Response<T> Success(T data, int statusCode)
        {
            return new Response<T> { Data = data, StatusCode = statusCode};
        }

        public static Response<T> Success(int statusCode)
        {
            return new Response<T> { Data = default, StatusCode = statusCode };
        }

        public static Response<T> Fail(ErrorDto errorDto, int statusCode)
        {
            return new Response<T>
            {
                Error = errorDto,
                StatusCode = statusCode,
            };
        }

        public static Response<T> Fail(string errorMessage, int statusCode)
        {
            var errorDto = new ErrorDto(errorMessage);

            return new Response<T>
            {
                Error = errorDto,
                StatusCode = statusCode,
            };
        }
    }
}
