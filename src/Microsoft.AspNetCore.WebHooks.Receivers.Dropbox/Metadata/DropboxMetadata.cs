﻿// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Microsoft.AspNetCore.WebHooks.Metadata
{
    /// <summary>
    /// An <see cref="IWebHookMetadata"/> service containing metadata about the Dropbox receiver.
    /// </summary>
    public class DropboxMetadata :
        WebHookMetadata,
        IWebHookEventMetadata,
        IWebHookRequestMetadataService
    {
        /// <summary>
        /// Instantiates a new <see cref="DropboxMetadata"/> instance.
        /// </summary>
        public DropboxMetadata()
            : base(DropboxConstants.ReceiverName)
        {
        }

        // IWebHookEventMetadata...

        /// <inheritdoc />
        public string ConstantValue => DropboxConstants.EventName;

        /// <inheritdoc />
        public string HeaderName => null;

        /// <inheritdoc />
        public string PingEventName => null;

        /// <inheritdoc />
        public string QueryParameterKey => null;

        // IWebHookRequestMetadataService...

        /// <inheritdoc />
        public WebHookBodyType BodyType => WebHookBodyType.Json;
    }
}
