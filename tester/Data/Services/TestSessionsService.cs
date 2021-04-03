﻿using System;
using System.Collections.Generic;
using System.Net;

namespace tester.Data.Services
{
    public class TestSessionsService
    { 
        public List<Session> Sessions { get; set; } = new();
    }

    public record Session
    {
        public string NameSurname { get; set; }
        public string TestName { get; set; }
        public ushort QuestionIndex { get; set; }
        public string IpAddress { get; set; }
        
    }
}