using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Linq;

namespace F27T0P_HFT_2021222.Client
{
    class Program
    {
        static RestService rest;

        static void Main(string[] args)
        {
            rest = new RestService("http://localhost:42137/");
        }
    }
}
