﻿// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using Microsoft.AspNetCore.WebHooks.Routing;

namespace Microsoft.AspNetCore.Routing
{
    /// <summary>
    /// Extension methods for the <see cref="RouteData"/> class.
    /// </summary>
    public static class WebHookRouteDataExtensions
    {
        /// <summary>
        /// Gets an indication a receiver for the current request is configured.
        /// </summary>
        /// <param name="routeData">The <see cref="RouteData"/> for the current request.</param>
        /// <returns>
        /// <c>true</c> if an indication <see cref="WebHookReceiverExistsConstraint"/> ran successfully was found in
        /// the <paramref name="routeData"/>; <c>false</c> otherwise.
        /// </returns>
        public static bool GetReceiverExists(this RouteData routeData)
        {
            if (routeData == null)
            {
                throw new ArgumentNullException(nameof(routeData));
            }

            if (routeData.Values.TryGetValue(WebHookReceiverRouteNames.ReceiverExistsKeyName, out var exists))
            {
                var receiverExists = (bool)exists;
                return receiverExists == true;
            }

            return false;
        }

        /// <summary>
        /// Gets the event names for the current request.
        /// </summary>
        /// <param name="routeData">The <see cref="RouteData"/> for the current request.</param>
        /// <param name="eventNames">Set to the event names identified in the request.</param>
        /// <returns>
        /// <c>true</c> if event names were found in the <paramref name="routeData"/>; <c>false</c> otherwise.
        /// </returns>
        public static bool TryGetEventNames(this RouteData routeData, out string[] eventNames)
        {
            if (routeData == null)
            {
                throw new ArgumentNullException(nameof(routeData));
            }

            if (routeData.Values.TryGetValue(WebHookReceiverRouteNames.EventKeyName, out var names))
            {
                eventNames = (string[])names;
                return eventNames.Length != 0;
            }

            eventNames = null;
            return false;
        }

        /// <summary>
        /// Gets the receiver id for the current request.
        /// </summary>
        /// <param name="routeData">The <see cref="RouteData"/> for the current request.</param>
        /// <param name="id">Set to the id of the requested receiver.</param>
        /// <returns>
        /// <c>true</c> if a receiver id was found in the <paramref name="routeData"/>; <c>false</c> otherwise.
        /// </returns>
        public static bool TryGetReceiverId(this RouteData routeData, out string id)
        {
            if (routeData == null)
            {
                throw new ArgumentNullException(nameof(routeData));
            }

            if (routeData.Values.TryGetValue(WebHookReceiverRouteNames.IdKeyName, out var identifier))
            {
                id = (string)identifier;
                return !string.IsNullOrEmpty(id);
            }

            id = null;
            return false;
        }

        /// <summary>
        /// Gets the receiver name for the current request.
        /// </summary>
        /// <param name="routeData">The <see cref="RouteData"/> for the current request.</param>
        /// <param name="receiverName">Set to the name of the requested receiver.</param>
        /// <returns>
        /// <c>true</c> if a receiver name was found in the <paramref name="routeData"/>; <c>false</c> otherwise.
        /// </returns>
        public static bool TryGetReceiverName(this RouteData routeData, out string receiverName)
        {
            if (routeData == null)
            {
                throw new ArgumentNullException(nameof(routeData));
            }

            if (routeData.Values.TryGetValue(WebHookReceiverRouteNames.ReceiverKeyName, out var receiver))
            {
                receiverName = (string)receiver;
                return !string.IsNullOrEmpty(receiverName);
            }

            receiverName = null;
            return false;
        }
    }
}
