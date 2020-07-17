﻿using Microsoft.AspNetCore.Http;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OtlobProject.Helpers
{
    public static class SessionHelper
    {
        public static void SetObjectAsJson(this ISession session ,string Key ,object value)
        {
            session.SetString(Key, JsonConvert.SerializeObject(value));
        }

        public static T GetObjectAsJson<T>(this ISession session, string Key)
        {
            var value = session.GetString(Key);
            return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);
        }
    }
}
