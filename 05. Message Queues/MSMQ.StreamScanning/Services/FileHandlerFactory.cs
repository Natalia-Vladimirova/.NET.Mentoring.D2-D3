﻿using MSMQ.StreamScanning.Interfaces;
using NLog;

namespace MSMQ.StreamScanning.Services
{
    public class FileHandlerFactory : IFileHandlerFactory
    {
        private readonly INameHelper _nameHelper;
        private readonly IPdfService _pdfService;

        private static int handlerNumber;

        public FileHandlerFactory(INameHelper nameHelper, IPdfService pdfService)
        {
            _nameHelper = nameHelper;
            _pdfService = pdfService;
        }

        public IFileHandler GetHandler()
        {
            var loggerName = $"{nameof(FileHandler)} {++handlerNumber}";
            return new FileHandler(_nameHelper, _pdfService, LogManager.GetLogger(loggerName));
        }
    }
}
