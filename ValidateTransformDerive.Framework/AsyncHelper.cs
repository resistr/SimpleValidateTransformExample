// Copyright (c) Microsoft Corporation, Inc. All rights reserved.
// Licensed under the MIT License, Version 2.0.
// https://github.com/aspnet/AspNetIdentity/blob/master/src/Microsoft.AspNet.Identity.Core/AsyncHelper.cs

using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;

namespace ValidateTransformDerive.Framework
{
    /// <summary>
    /// A helper class to run asynchronous operations synchronously.
    /// </summary>
    public static class AsyncHelper
    {
        private static readonly TaskFactory _myTaskFactory = new TaskFactory(CancellationToken.None,
            TaskCreationOptions.None, TaskContinuationOptions.None, TaskScheduler.Default);

        /// <summary>
        /// Run a <see cref="Task"/><typeparamref name="TResult"/> synchronously.
        /// </summary>
        /// <typeparam name="TResult">The type of the result of the task.</typeparam>
        /// <param name="func">The delegate of the task to run.</param>
        /// <returns>The result of the asynchronous operation.</returns>
        public static TResult RunSync<TResult>(Func<Task<TResult>> func)
        {
            // save culture information
            var cultureUi = CultureInfo.CurrentUICulture;
            var culture = CultureInfo.CurrentCulture;

            // start the task on a new thread
            return _myTaskFactory.StartNew(() =>
            {
                // restore the culture information on the new thread
                Thread.CurrentThread.CurrentCulture = culture;
                Thread.CurrentThread.CurrentUICulture = cultureUi;

                // run the task
                return func();
            })
            // unwrap the task to get underlying exceptions if any
            .Unwrap()
            // get the awaiter that waits on the task to complete
            .GetAwaiter()
            // get the result of the task to return
            .GetResult();
        }

        // save culture information
        public static void RunSync(Func<Task> func)
        {
            // save culture information
            var cultureUi = CultureInfo.CurrentUICulture;
            var culture = CultureInfo.CurrentCulture;

            // start the task on a new thread
            _myTaskFactory.StartNew(() =>
            {
                // restore the culture information on the new thread
                Thread.CurrentThread.CurrentCulture = culture;
                Thread.CurrentThread.CurrentUICulture = cultureUi;
                
                // run the task
                return func();
            })
            // unwrap the task to get underlying exceptions if any
            .Unwrap()
            // get the awaiter that waits on the task to complete
            .GetAwaiter()
            // get the result of the task (causes the awaiter to wait for void)
            .GetResult();
        }
    }
}
